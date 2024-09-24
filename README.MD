#README:

# MyTaskInterview

## Overview
This project consists of an ASP.NET Core 8 Web API, MSSQL 2019 database, and an Angular 18 front-end. It supports full Create, Read, Update, Delete (CRUD) operations on the Customer entity, as well as the ability to export customer data to a .txt file. The project also includes features like data filtering, along with practical JavaScript functionality.

The solution follows a Clean Architecture with the CQRS (Command Query Responsibility Segregation) design pattern, utilizing the Mediator library for improved separation of concerns. Additionally, Fluent Validation, a powerful open-source library, has been implemented for input validation. Minimal APIs were incorporated, given the small scale of the project.

This task was completed as part of the interview process for Bahman.co.

## Prerequisites
- .NET SDK 8.0 or higher
- Node.js 18.x or higher
- SQL Server 2019 or higher
- Git

## How to run the project

### 1. Clone the repository:
Bash

git clone https://github.com/SaeedehArabani/MyTaskInterview.git
cd MyTask

2. Set up the API

Navigate to the /api folder:

cd MyTask\Backend

Install dependencies:

dotnet restore

Update appsettings.json with the correct database connection string and IP address.

Run the API:
cd MyTask\Backend\Services\Api

dotnet run


3. Set up the Angular UI

Navigate to the /ui folder:

cd MyTask\Front

Install dependencies:

npm install

Start the Angular app:

ng serve


4. Open the app

The API will run on http://localhost:8085 (or the specified IP).

The Angular UI will run on http://localhost:4200.
