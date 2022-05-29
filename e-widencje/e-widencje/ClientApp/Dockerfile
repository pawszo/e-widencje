FROM node:16.15.0-alpine
WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY package-lock.json /app/package-lock.json
COPY package.json /app/package.json

COPY . /app
RUN npm install
EXPOSE 5001
CMD ["npm", "start"]