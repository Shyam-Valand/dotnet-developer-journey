# .NET Developer Journey 🚀

Daily progress log of my journey toward becoming a Full-Stack .NET Developer.

Building practical applications using:

C# • ASP.NET Core Web API • Entity Framework Core • SQL Server • React • TypeScript • Azure • Docker

---

# 🎯 Target Role

Full-Stack .NET Developer

Focus:

- Backend Architecture
- REST API Development
- Database Design
- Clean Code Practices
- Enterprise Application Development

---

# 🛠 Tech Stack

## Backend

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- REST APIs
- JWT Authentication

## Frontend

- React
- TypeScript
- JavaScript
- HTML
- CSS
- Tailwind CSS

## Database

- SQL Server
- MongoDB

## Tools & Practices

- Visual Studio
- VS Code
- Git
- GitHub
- GitHub Issues
- Pull Requests
- Postman
- Swagger
- Docker
- Azure
- CI/CD

---

# 📅 Daily Learning Progress


# Day 0 - Developer Setup ✅

Completed:

- Installed Visual Studio
- Installed VS Code
- Setup SQL Server Management Studio
- Setup Postman
- Setup Git & GitHub
- Created Developer Workflow

---

# Week 1 - C# Foundation

---

## Day 1 - C# Fundamentals ✅

Learned:

- C# Syntax
- Project Structure
- Variables
- Data Types
- Methods
- Classes

Practiced:

- Console Application Development

Built:

- Student Profile Application
- User Registration Application
- Salary Calculator

---

## Day 2 - Control Flow ✅

Learned:

- If / Else Conditions
- Switch Statements
- Operators
- Loops

Practiced:

- Conditional Logic
- Iteration Problems

Built:

- Grade Calculator
- Login System
- Calculator Practice
- Number Practice Programs

---

## Day 3 - Object-Oriented Programming Basics ✅

Learned:

- Classes
- Objects
- Constructors
- Properties
- Encapsulation

Practiced:

- Object Modeling
- Business Logic Design

Built:

- Customer Practice System
- Bank Account System

---

## Day 4 - Advanced OOP & Service Layer Concepts ✅

Learned:

- Inheritance
- Polymorphism
- Interfaces
- Abstraction
- Service Layer Concepts

Implemented:

- Interface Based Programming
- User/Admin Inheritance
- Service Classes
- Clean Code Structure

---

## Day 5 - Collections & LINQ ✅

Learned:

- Collections
- List<T>
- LINQ Queries

Built:

## Appointment System V1

Implemented:

- Models
- Interfaces
- Appointment Service
- CRUD Operations
- Business Rules

---

## Day 6 - Exceptions & JSON Storage ✅

Learned:

- Exception Handling
- File Handling
- JSON Serialization

Built:

## Appointment System V2

Implemented:

- Custom Exceptions
- JSON Persistence

---

## Day 7 - Console Appointment Management System ✅

Implemented:

- Appointment CRUD
- Search
- Cancellation
- Validation Rules
- JSON Storage

---

# Week 2 - Database & Backend Development

---

## Day 8 - SQL Server Fundamentals ✅

Learned:

- Database Design
- Tables
- Relationships
- Primary Keys
- Foreign Keys

Built:

## AppointmentDB

Implemented:

- Customers
- Services
- Appointments

---

## Day 9 - SQL CRUD Operations ✅

Learned:

- SELECT
- INSERT
- UPDATE
- DELETE
- JOIN Queries

Implemented:

- Appointment Database Operations

---

## Day 10 - Advanced SQL ✅

Learned:

- Constraints
- Aggregations
- GROUP BY
- HAVING
- Indexing

Implemented:

- Database Rules
- Reporting Queries

---

## Day 11 - Entity Framework Core Basics ✅

Learned:

- ORM
- DbContext
- DbSet
- Relationships
- Migrations

Built:

## AppointmentEF

Implemented:

- EF Core Models
- SQL Server Integration
- Migrations

---

## Day 12 - EF Core CRUD & Service Layer ✅

Implemented:

- EF Core CRUD
- LINQ Queries
- Service Layer
- Business Validations

---

## Day 13 - ASP.NET Core Web API CRUD ✅

Built:

# AppointmentAPI V1

Learned:

- REST API Development
- Controllers
- Routing
- Dependency Injection
- Swagger

Implemented:

- GET API
- POST API
- PUT API
- DELETE API
- EF Core Integration

---

# Day 14 - API Architecture Refactoring ✅

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
Service Interface
    ↓
Service Layer
    ↓
EF Core
    ↓
SQL Server
```

Implemented:

- DTO Pattern
- Service Layer
- Dependency Injection
- Clean Controller Design

Business Rules:

- Prevent Past Appointments
- Prevent Duplicate Slots

---

# Day 15 - Production API Practices ✅

Upgraded AppointmentAPI with enterprise backend practices.

Learned:

- Repository Pattern
- Async Programming
- Exception Handling

Implemented:

- IAppointmentRepository
- AppointmentRepository
- Async / Await
- EF Core Async Queries
- Custom Exceptions
- Global Exception Middleware
- ApiResponse<T>

Architecture:

```text
Controller
    ↓
Service Layer
    ↓
Repository Layer
    ↓
EF Core
    ↓
SQL Server
```

Tested:

- CRUD Operations ✅
- Validation Rules ✅
- Error Handling ✅

---
# Day 16 - Appointment Availability Validation & GitHub Workflow ✅

Enhanced AppointmentAPI with real-world booking rules and professional development workflow.

Learned:

- GitHub Issue Management
- Feature Branch Workflow
- Pull Request Workflow
- Code Review Process
- Advanced Business Rule Implementation

Practiced:

- Creating GitHub Issues
- Working With Feature Branches
- Creating Pull Requests
- Reviewing Code Changes
- Merging Feature Branches

Implemented:

## Appointment Overlap Validation

Added:

- Service Duration Based Availability Checking
- Appointment Start Time Calculation
- Appointment End Time Calculation
- Overlapping Appointment Detection
- Reschedule Conflict Prevention

Example:

Existing Appointment:

```text
10:00 - 10:30
```

Blocked:

```text
10:05 ❌
10:15 ❌
```

Allowed:

```text
10:30 ✅
```

Updated:

## Repository Layer

Implemented:

- Appointment Availability Query
- Duration Based Conflict Checking
- EF Core Overlap Logic

## Service Layer

Implemented:

- Create Appointment Validation
- Update Appointment Validation
- Business Rule Enforcement
- Cancelled Appointment Availability Handling


Business Rules:

- Prevent Same Time Booking
- Prevent Booking Inside Existing Appointment Duration
- Allow Booking After Appointment Completion
- Allow Cancelled Slots To Be Reused


Testing Completed:

- Same Start Time Conflict ✅
- Duration Overlap Conflict ✅
- Valid Slot Booking ✅
- Different Service Booking ✅
- Reschedule Validation ✅
- Cancelled Slot Rebooking ✅


GitHub Workflow Completed:

```text
Issue Created
      ↓
Feature Branch
      ↓
Development
      ↓
Testing
      ↓
Commit
      ↓
Pull Request
      ↓
Code Review
      ↓
Merge Into Main
```

Completed:

- Created GitHub Issue ✅
- Implemented Feature Branch Development ✅
- Created Pull Request ✅
- Linked PR With Issue ✅
- Reviewed Code Changes ✅
- Merged Feature Into Main ✅

---

# 🔥 Current Focus

Authentication & Security

Learning Next:

- ASP.NET Core Identity
- JWT Authentication
- Refresh Tokens
- Role Based Authorization
- Secure API Development

---

# 📌 Portfolio Projects


## Healthcare Appointment Booking Platform 🚀

Current Project


Completed:

- Console Application ✅
- SQL Database ✅
- EF Core Version ✅
- ASP.NET Core Web API ✅
- DTO Architecture ✅
- Service Layer ✅
- Repository Pattern ✅
- Async Programming ✅
- Global Exception Handling ✅
- API Response Wrapper ✅
- Appointment Business Rules ✅
- Appointment Overlap Validation ✅
- GitHub Issue Workflow ✅
- Feature Branch Development ✅
- Pull Request Workflow ✅


Upcoming:

- JWT Authentication
- Authorization
- React Frontend
- Unit Testing
- Docker
- Azure Deployment

---

## Enterprise Banking Ledger System ⭐

Planned enterprise application.

Stack:

- ASP.NET Core Web API
- EF Core
- SQL Server
- React
- JWT
- Azure

---

## Hotel Management Modernization

Planned migration:

```text
Windows Forms + SQL Server

        ↓

React + ASP.NET Core Web API + EF Core
```

---

# 📈 Progress

```text
C# Fundamentals             ✅
OOP                         ✅
Collections + LINQ          ✅
Exception Handling          ✅

SQL Server                  ✅
Entity Framework Core       ✅

ASP.NET Core Web API        ✅
DTO Pattern                 ✅
Service Layer               ✅
Repository Pattern          ✅
Async Programming           ✅
Global Error Handling       ✅
API Response Wrapper        ✅
Business Rules              ✅
Appointment Validation      ✅

GitHub Issues               ✅
Feature Branch Workflow     ✅
Pull Request Workflow       ✅


Current:

Authentication & Security 🚀


Next:

JWT Authentication
        ↓
Authorization
        ↓
React Integration
        ↓
Testing
        ↓
Deployment
```

---

```text
Learn → Build → Refactor → Improve → Deploy 🚀
```