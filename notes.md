## VsCode commands ----------------------------------------------------------------------------------
1. CTRL+SHIFT+P | .NET: New File to create a new file for the dotnet project
2. CTRL+SHIFT+P | SQLite: Open database

## Dotnet CLI commands ------------------------------------------------------------------------------

### Commands to create a dotnet project
1. dotnet --info
2. dotnet new list
3. dotnet new webapi -h
4. dotnet new sln
5. dotnet new webapi -controllers -n API
6. dotnet sln -h
7. dotnet sln add API/
8. dotnet sln list

### Run dotnet project
1. dotnet run
2. dotnet watch

### Verify and fix dotnet certification
1. dotnet dev-certs https -h
2. dotnet dev-certs https --check
3. dotnet dev-certs https --clean
4. dotnet dev-certs https --trust

### Commands
1. dotnet restore | when making updates to packages
2. dotnet tool list -g | Check dotnet tools I have
3. dotnet ef | Entity Framework Core .NET Command-line Tools

### Packages
1. microsoft.entityframeworkcore
2. microsoft.entityframeworkcore.Design
3. microsoft.entityframeworkcore.Sqlite
4. System.IdentityModel.Tokens.Jwt
5. Microsoft.IdentityModel.Tokens
6. Microsoft.AspNetCore.Authentication.JwtBearer
7. CloudinaryDotNet
8. Microsoft.AspNetCore.Identity.EntityFrameworkCore
9. Microsoft.EntityFrameworkCore.SqlServer
10. dotnet add package Microsoft.AspNetCore.OpenApi
11. dotnet add package Swashbuckle.AspNetCore

## Other
1. dotnet restore | is used when removing packages

### Dotnet Tools install
1. dotnet tool install -g dotnet-ef

### Dotnet Migrations for sqlite
1. dotnet ef migrations -h | Check options
2. dotnet ef migrations add InitialCreate -o Data/Migrations | Creates a new migration to sqlite
3. dotnet ef database update | Updates/creates database with migrations
4. dotnet ef migrations add UserEntityUpdated | Updates a migrations to sql
5. dotnet ef database drop | drop the database
6. dotnet ef migrations has-pending-model-changes | Check if any migrations is pending
7. Delete migrations folder

### Dotnet Migrations for prod
1. dotnet ef migrations add InitialCreate -o Data/Migrations
2. dotnet publish -c Release -o ./bin/Publish

### Git commands
1. dotnet new gitignore
2. git log

## Angular CLI commands ------------------------------------------------------------------------------

### Help commands
1. ng g --help

### Angular CLI commands
1. npm install -g @angular/cli
2. ng new client
3. ng g environments

### Run angular project
1. ng serve

### Packages
1. npm i -D daisyui@latest
2. npm install @microsoft/signalr

### Self-signed certificate is mkcert github
1. choco install mkcert
2. mkcert -install
3. ssl folder creation
4. mkcert localhost

## Publishing
1. ng build
2. dotnet publish -c Release -o ./bin/Publish ---OR--- dotnet publish -c Release -o C:\demoiis
3. Update client and backend
4. docker compose up -d
5. docker compose down