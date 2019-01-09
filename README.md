# bonneTable

###### Backend ASP.NET .NET Core 2.1
Backend written in dotnet core 2.1 with MongoDb database MongoDb Atlas
* ASP.NET API Core 2.1
* MongoDb
* xUnit
* Serilog
* NSubstitute
* FluentAssertions
* JWT Authentication / Authorization
* MSSQL Db with EF Core for storing Admin login credentials
* Hashes and salts input

###### Frontend Vue.js
* Vue.js 
* axios
* vuex
* veeValidate
* JWT bearer authentication


#### Set-up db with seed
Commands seeds db with one admin:
Username: **test**
password: **test**

Run commands in:
`add-migration init`
`script-migration`
`update-database -verbose`
