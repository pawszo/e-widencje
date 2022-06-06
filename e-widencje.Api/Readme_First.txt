
The project contains a fake authorization system, so you can change it to Identity or another.

# Installation
	1. By default asp.net core and react projects use fake mocks for users and authorization system.
    you may comment `redux.mockAxios(axios)` in index.tsx to enable `net core mocks fake authorization system`
	instead react mocks. 

	2. Build and run the project.
	OR  
	3.1 To run project with fake react mocks you need to uncomment `redux.mockAxios(axios)`
	3.2	Open project's folder in console and run command `npm install`.

	3.3 Type `npm run build`, it will compile the main and vendor bundles.
	3.4 Type `npm start` to run the project


	Also feel free to use the issue tracker: https://github.com/vladyslav-kozh/react-core-boilerplate/issues
