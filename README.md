# multiverse

## Pre-requisite: 
* nodejs  
  * bower  
* dotnet core 2.0
* SQL Server 2016 Express

## Development:
* All api projects should have dotnet watch. See bc.multiverser.edu.csproj  
* All api projects should have Identity & JwtAuthentications  
* appSettings.[env].json is missing on all projects, you should configure them by copy appSettings.json to appSettings.[env].json and reconfigure it
* For "Development" environment, just create appSettings.Development.json
* There is bc.multiverse.edu

## Deployment (Development only)
* Backend:  
> cd src/bc.services.\<api service\>; dotnet restore; dotnet watch run  
> cd src/bc.multiverse.edu; dotnet restore; bower install; dotnet watch run  

* Frontend:
> cd frontend; npm install; npm run dev