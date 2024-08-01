# BlazorSozluk

BlazorSozluk is a web application where users can share information in a dictionary format on various topics. This project leverages modern technologies like Blazor, RabbitMQ, .NET 6, Entity Framework 6 (EF6), and software architectural patterns such as CQRS, Onion Architecture, and MediatR.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Architecture](#architecture)
- [Contributors](#contributors)
- [License](#license)

## Features

- User registration and login
- Topic creation and editing
- Commenting on topics
- User profile management
- Real-time notifications (using RabbitMQ)
- Command and query handling with CQRS and MediatR

## Technologies Used

- **Blazor**: A framework for building single-page applications (SPA).
- **RabbitMQ**: A message broker for real-time notifications.
- **.NET 6**: The core platform for the application.
- **Entity Framework 6 (EF6)**: An ORM (Object-Relational Mapping) tool for data access.
- **CQRS (Command Query Responsibility Segregation)**: A pattern for separating command and query responsibilities.
- **Onion Architecture**: A layered architecture style.
- **MediatR**: A library for implementing CQRS and other patterns.

## Setup

### Requirements

- .NET 6 SDK
- SQL Server or another supported database
- RabbitMQ

### Steps

1. Clone this repository:
   ```bash
   git clone https://github.com/Cemal-rd/BlazorSozluk.git
   cd BlazorSozluk
Install dependencies:

bash
dotnet restore
Set up your database and add the connection string to appsettings.json.

Start RabbitMQ and add the connection details to appsettings.json.

Apply database migrations:

dotnet ef database update
Run the application:

bash

dotnet run

Architecture
Onion Architecture
Onion Architecture is a layered architecture style where dependencies flow from outer layers to inner layers. This project is divided into the following layers:

Core: Contains business logic and domain models.
Application: Contains application logic and services. MediatR commands and queries are located here.
Infrastructure: Contains database access and integrations with third-party services.
Presentation: Contains Blazor components and the UI layer.
CQRS and MediatR
This project implements the CQRS (Command Query Responsibility Segregation) pattern. Commands and queries are handled using MediatR.

Commands: Operations that modify the database.
Queries: Operations that retrieve data.
