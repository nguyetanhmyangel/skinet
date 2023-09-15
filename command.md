# Commands used in project
* dotnet new list
* dotnet new sln
* dotnet new webapi -n Api
* dotnet new classlib -n Core
* dotnet new classlib -n Infrastructure
* dotnet sln add Api
* dotnet sln add Core
* dotnet sln add Infrastructure
* dotnet add reference ../Infrastructure
* dotnet add reference ../Core
* dotnet restore
* dotnet tool install --global dotnet-ef --version 7.0.10 / dotnet tool update --global dotnet-ef --version 7.0.10 
* dotnet build
* dotnet ef migrations add InitialCreate -p Infrastructure -s Api -o Data/Migrations
* dotnet new gitignore

