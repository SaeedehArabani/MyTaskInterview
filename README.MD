#README:

# MyTaskInterview

## Overview
This project contains an ASP.NET Core 8 Web API, MSSQL 2019 and Angular 18 front-end. It allows you to Create, Read ,Update, Delete (CRUD) Operations on customer entity export a txt file that customers are added, and some practice like filter a fantastic function in javaScript.
This Task is done for Bahman.co interview session

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
