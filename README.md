# .NET Developer Journey 🚀

Daily learning journey towards becoming a Junior Full-Stack .NET Developer.

## 🎯 Target Role
Junior Full-Stack .NET Developer

## 🛠 Tech Stack

**Backend:** C#, .NET 8, ASP.NET Core Web API, EF Core, REST API, JWT  
**Frontend:** React, TypeScript, JavaScript, HTML, CSS, Tailwind  
**Database:** SQL Server, MongoDB  
**Tools:** Visual Studio, VS Code, Git, GitHub, Postman, Swagger, Docker, Azure, CI/CD  

---

# 📚 Learning Progress

## Phase 0 - Developer Setup ✅

Completed:
- Development Environment Setup
- SQL Server Management Studio
- Postman
- Git & GitHub Workflow

---

# Phase 1 - .NET Backend Foundation 🚀

## Week 1 - C# Foundation ✅

### Day 1 - C# Fundamentals ✅
Learned C# syntax, project structure, variables, data types, methods, and classes.

Built:
- Student Profile
- User Registration
- Salary Calculator

---

### Day 2 - Control Flow ✅
Learned conditions, operators, switch statements, and loops.

Built:
- Grade Calculator
- Login System
- Calculator Practice

---

### Day 3 & 4 - Object-Oriented Programming ✅
Learned OOP principles including encapsulation, inheritance, polymorphism, interfaces, and service layer concepts.

Built:
- Banking System
- User Management Practice

---

### Day 5 - Collections & LINQ ✅
Learned collections, List<T>, and LINQ queries.

Built:
### Appointment System V1

Implemented models, interfaces, services, and appointment business rules.

---

### Day 6 - Exceptions & JSON Storage ✅
Learned exception handling, file handling, and JSON serialization.

Built:
### Appointment System V2

Implemented custom exceptions and JSON persistence.

---

### Day 7 - Console Project ✅

Built:
# Appointment Management System

Implemented:
- Appointment CRUD
- Search & Cancel Features
- Business Validations
- JSON Storage

---

# Week 2 - Database & Web Development 🚀

### Day 8 - SQL Server Fundamentals ✅

Learned database design, tables, relationships, primary keys, and foreign keys.

Built:
### AppointmentDB

Created Customers, Services, and Appointments tables.

---

### Day 9 - SQL CRUD Queries ✅

Learned SELECT, INSERT, UPDATE, DELETE, filtering, sorting, and joins.

Implemented relational database queries.

---

### Day 10 - Advanced SQL ✅

Learned constraints, aggregate functions, GROUP BY, HAVING, and indexing.

Implemented database rules and reporting queries.

---

### Day 11 - Entity Framework Core Basics ✅

Built:
### AppointmentEF

Learned:
- ORM Concepts
- DbContext & DbSet
- Entity Relationships
- EF Core Migrations

Implemented EF Core with SQL Server integration.

---

### Day 12 - EF Core CRUD & Service Layer ✅

Implemented:
- EF Core CRUD Operations
- LINQ Database Queries
- Service Layer
- Business Validations

---

### Day 13 - ASP.NET Core Web API CRUD ✅

Built:

# AppointmentAPI

Learned:
- REST API Development
- Controllers
- Routing
- Dependency Injection
- Swagger Testing

Implemented:
- ASP.NET Core Web API
- EF Core Integration
- SQL Server Persistence
- CRUD Endpoints

APIs Created:

```text
GET       /api/Appointments
GET       /api/Appointments/{id}
POST      /api/Appointments
PUT       /api/Appointments/{id}
DELETE    /api/Appointments/{id}
```

---

### Day 14 - API Refactoring & Professional Structure ✅

Upgraded AppointmentAPI architecture.

Converted:

```text
Controller
    ↓
DbContext
```

Into:

```text
Controller
    ↓
IAppointmentService
    ↓
Service Layer
    ↓
EF Core
    ↓
SQL Server
```

Implemented:
- DTO Pattern
- Request & Response Models
- Service Layer Separation
- Dependency Injection
- Clean Controller Design
- Business Validation Rules

Added DTOs:
- CreateAppointmentDto
- UpdateAppointmentDto
- AppointmentDto

Validation:
- Prevent Past Appointments
- Prevent Duplicate Active Bookings

Tested:
- GET / POST / PUT / DELETE APIs
- DTO Responses
- Business Rules

---

# 🔥 Current Focus

## Production API Development

Learning:
- Global Exception Handling
- Repository Pattern
- Async / Await
- API Response Wrappers
- Authentication

---

# 🏗 Upcoming Roadmap

## Backend
- Clean Architecture
- JWT Authentication
- Role Authorization
- Unit Testing

## Frontend
- React
- TypeScript
- API Integration

## Deployment
- Docker
- Azure
- CI/CD

---

# 📌 Portfolio Projects

## Appointment Booking Platform 🚀

Completed:
- Console Version ✅
- SQL Database ✅
- EF Core Version ✅
- Web API CRUD ✅
- DTO + Service Architecture ✅

Upcoming:
- Repository Pattern
- Authentication
- React Frontend
- Deployment

---

## Expense & Budget Manager SaaS (Planned)

Stack:

ASP.NET Core | EF Core | SQL Server | React | JWT

---

## Hotel Management Modernization (Planned)

Upgrade:

Windows Forms + ADO.NET

↓

Modern Full Stack .NET Application

---

# 📈 Progress

```text
Setup                         ✅

C# Foundation                 ✅
OOP                           ✅
Collections + LINQ            ✅
Exception Handling            ✅

SQL Server                    ✅
Entity Framework Core         ✅

ASP.NET Core Web API CRUD     ✅
DTO Pattern                   ✅
Service Layer                 ✅
Business Rules                ✅


Current:
Production API Practices 🚀


Next:
Exception Handling
       ↓
Repository Pattern
       ↓
Authentication
       ↓
React Integration
       ↓
Deployment
```

---

```text
Learn → Build → Refactor → Improve → Deploy 🚀
```