# multiverse

## Pre-requisite: 
* nodejs (https://nodejs.org/en/download/)
  * bower  
  * vue-cli  
  * webpack
* dotnet core 2.0
* SQL Server 2016 Express

## Development:
* All api projects should have dotnet watch. See bc.multiverser.edu.csproj 
![image](https://user-images.githubusercontent.com/7732856/31445720-d69ab5aa-aec8-11e7-91d7-8f7802514731.png)
* All api projects should have Identity & JwtAuthentications  
![image](https://user-images.githubusercontent.com/7732856/31445802-137b5664-aec9-11e7-94a3-0d7f89c15a9d.png)
![image](https://user-images.githubusercontent.com/7732856/31445832-29f6fc04-aec9-11e7-9783-436a41f3a03d.png)
* appSettings.[env].json is missing on all projects, you should configure them by copy appSettings.json to appSettings.[env].json and reconfigure it
* For "Development" environment, just create appSettings.Development.json
![image](https://user-images.githubusercontent.com/7732856/31445627-a0861374-aec8-11e7-8a88-1fc088d29fcc.png)

## Deployment (Development only)
* Backend:  
> cd src/bc.services.\<api service\>; dotnet restore; dotnet watch run  
> cd src/bc.multiverse.edu; dotnet restore; bower install; dotnet watch run  

* Frontend:  
  * Install vue-cli to enable hot-reload
> cd frontend; npm install; npm run dev
