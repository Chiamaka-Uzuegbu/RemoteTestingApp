#
This project is built with .Net5.0 and Microsoft SQL as Database.
It's a code first approached Running Migrations on Application Launch using Entity Framework Core.

#Requirements
Visual Studio, Microfot SQL

#Running the code
Clone the code to your local machine and then open the project with Visual Studio
From the Visual Studio Package Manager Console, run "dotnet restore" to add all project dependencies.
Compile the code and run.
The code has a Swagger Documentation for the API endpoints, Some endpoints are protected
a user account is needed to be created and logged in to get a token that needs to be added to 
the header for Authorization.

#Running the test
The test can be ran using visual studio or using the command "dotnet test" on the command line.