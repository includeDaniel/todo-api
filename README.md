# todo-api

## Overview

This repository contains a .NET 8 API built with hexagonal architecture, utilizing PostgreSQL as the database. The project strictly adheres to SOLID principles and is designed for managing ToDo items.

## Features

- Hexagonal architecture for modularity and maintainability.
- Swagger for the interface.
- Authorization with login and register.
- PostgreSQL for seamless data storage and retrieval.
- Follows SOLID principles for a scalable and well-structured design.
- ToDo functionality: create, read, update, delete and edit tasks.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/todo-api.git

2. Navigate to the project directory:
   ```bash
   cd Todo-API

3. Build the project:
   ```bash
   dotnet build

4. Set up your PostgreSQL database and update the connection string in the configuration.

5. Apply database migrations:
   ```bash
   dotnet ef database update

6. Run the API:
   ```bash
   dotnet run

### Configuration
Update the database connection string in the appsettings.json file.

### API Endpoints
 - GET /api/todo: Retrieve all ToDo items
 - GET /api/todo/{id}: Retrieve a specific ToDo item
 - POST /api/todo: Create a new ToDo item
 - PUT /api/todo/{id}: Update a ToDo item
 - DELETE /api/todo/{id}: Delete a ToDo item

![image](https://github.com/includeDaniel/todo-api/assets/62966657/946e0c96-c079-4d97-89d0-719de9bea540)
