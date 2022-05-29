#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

WORKDIR /src
#["e-widencje/e-widencje.csproj", "e-widencje/"]
COPY . /src
RUN dotnet restore "e-widencje.csproj"
RUN dotnet build "e-widencje.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./e-widencje/*.csproj" -c Release -o /app/publish

FROM node AS node-builder
WORKDIR /node
COPY ./ClientApp /node
RUN npm install
RUN npm build

FROM base AS final
WORKDIR /app
EXPOSE 5050
RUN mkdir /app/wwwroot
COPY --from=publish /app/publish .
COPY --from=node-builder /node/build ./wwwroot

ENTRYPOINT ["dotnet", "e-widencje.dll"]