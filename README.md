# .NET Developer Journey 🚀

Building enterprise-ready backend applications through daily hands-on development, following professional software engineering practices and GitHub workflow.

Daily progress log of my journey toward becoming a Full-Stack .NET Developer.

Building practical applications using:

C# • ASP.NET Core Web API • Entity Framework Core • SQL Server • React • TypeScript • Azure • Docker

---

## 🎯 Repository Goals

- Learn enterprise .NET backend development
- Build production-style portfolio projects
- Follow professional GitHub workflow
- Document daily progress

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

### Appointment System V1

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

### Appointment System V2

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

### AppointmentDB

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

### AppointmentEF

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

### AppointmentAPI V1

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

## Day 14 - API Architecture Refactoring ✅

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

# Week 3 - Enterprise Backend Development

---

## Day 15 - Production API Practices ✅

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

## Day 16 - Appointment Availability Validation & GitHub Workflow ✅

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

### Appointment Overlap Validation

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

### Repository Layer

Implemented:

- Appointment Availability Query
- Duration Based Conflict Checking
- EF Core Overlap Logic

### Service Layer

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

## Day 17 - JWT Authentication & Authorization ✅

**Implemented secure authentication system for AppointmentAPI.**

Learned:

- JWT Authentication
- Claims Based Authentication
- Role Based Authorization
- API Security Practices

Implemented:

- User Model
- Users Table
- Authentication DTOs
- User Repository
- Auth Service
- Password Hashing
- JWT Token Generation
- JWT Middleware Configuration

Authentication Flow:

```text
Register/Login
      ↓
Validate User
      ↓
Generate JWT Token
      ↓
Access Protected APIs
```

JWT Claims Added:

- UserId
- Name
- Email
- Role

### Authorization:

Implemented:

- [Authorize]
- Role Based Access Control
- Protected Appointment APIs

Roles:

- Patient
- Doctor
- Admin

Security Added:

- Custom 401 Unauthorized Response
- Custom 403 Forbidden Response
- Secure Configuration Management

Testing Completed:

- User Registration ✅
- Password Hash Storage ✅
- User Login ✅
- JWT Token Generation ✅
- Protected API Access ✅
- Role Validation ✅

GitHub Workflow Completed:

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

## Day 18 - Patient Appointment Ownership & Authorization ✅

Enhanced AppointmentAPI with resource ownership and user-based authorization.

Learned:

- Resource Ownership
- User Based Data Filtering
- Claims Based Authorization
- Secure API Access Control

Implemented:

- UserId Mapping For Appointments
- User Specific Appointment Retrieval
- Appointment Ownership Validation
- Create Authorization
- Read Authorization
- Update Authorization
- Delete Authorization

Authorization Flow:

```text
User Login
      ↓
JWT Authentication
      ↓
Extract UserId From Claims
      ↓
Validate Appointment Owner
      ↓
Allow / Deny Request
```

Business Rules:

- Users can create only their own appointments
- Users can view only their own appointments
- Users cannot update another user's appointment
- Users cannot delete another user's appointment

Testing Completed:

- Appointment Ownership Validation ✅
- User Specific Appointment List ✅
- Unauthorized Read Blocked ✅
- Unauthorized Update Blocked ✅
- Unauthorized Delete Blocked ✅

GitHub Workflow Completed:

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

## Day 19 - User-Customer Relationship & Secure Self-Booking ✅

Learned

- One-to-One Entity Relationships
- Entity Relationships in EF Core
- Automatic Profile Creation
- Backend Driven Resource Resolution
- Secure Self-Booking Design

Implemented

- Linked User with Customer Profile
- Added CustomerId to User
- Configured EF Core Relationship
- Automatic Customer Creation During Patient Registration
- Automatic User-Customer Linking
- Removed Manual CustomerId Selection From Appointment API
- Backend Automatically Resolves CustomerId
- Updated Registration Flow
- Updated Appointment Creation Flow

### Registration Flow

```text
Patient Registration
        ↓
Create Customer Profile
        ↓
Create User Account
        ↓
Link User To Customer
        ↓
Generate JWT
        ↓
Patient Login
```

### Appointment Flow

```text
JWT Authentication
        ↓
Extract UserId
        ↓
Load User + Customer
        ↓
Resolve CustomerId
        ↓
Create Appointment
```

### Business Rules

- One Patient owns one Customer Profile
- Customer Profile created automatically during Patient Registration
- Patients cannot select another CustomerId
- CustomerId resolved automatically from authenticated user
- Backend enforces resource ownership
- Secure Self-Booking

### Testing Completed

- Patient Registration ✅
- Automatic Customer Creation ✅
- User-Customer Linking ✅
- Login ✅
- JWT Authentication ✅
- Appointment Self-Booking ✅
- CustomerId Not Accepted From Client ✅

### GitHub Workflow Completed

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

## Day 20 - Admin & Doctor Authorization ✅

Enhanced AppointmentAPI with Admin and Doctor role-based authorization.

Learned

- Admin Authorization
- Doctor Authorization
- Multi-Role Authorization
- Secure Role-Based API Design
- Separation of Business Responsibilities

Implemented

- Added DoctorId to Appointment
- Configured Doctor Relationship in EF Core
- Admin Can Assign Doctors To Patient Appointments
- Doctor Specific Appointment Retrieval
- Dedicated Doctor Appointment Endpoint
- Removed Doctor Assignment From Patient Update API

### Doctor Assignment Flow

```text
Admin Login
        ↓
JWT Authentication
        ↓
Assign Doctor
        ↓
Appointment Updated
```

### Doctor Appointment Flow

```text
Doctor Login
        ↓
JWT Authentication
        ↓
Extract UserId From Claims
        ↓
Load Assigned Appointments
        ↓
Return Doctor Schedule
```

### Business Rules

- Only Admin can assign doctors
- Doctors can view only their assigned appointments
- Patients cannot assign or change doctors
- Doctor assignment is handled through a dedicated endpoint
- JWT Role-Based Authorization enforced

### Testing Completed

- Patient APIs ✅
- Admin APIs ✅
- Doctor APIs ✅
- JWT Authorization ✅
- Role-Based Authorization ✅
- Swagger Testing ✅
- Postman Testing ✅
- SQL Server Verification ✅

### GitHub Workflow Completed

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

## Day 21 - Doctor Availability Management ✅

Enhanced AppointmentAPI with Doctor Availability Management.

Learned

- Availability Management
- Time Slot Validation
- Business Rule Validation
- Doctor Schedule Management
- Availability CRUD APIs

Implemented

- Created DoctorAvailability entity
- Configured EF Core relationship
- Created Availability Repository
- Created Availability Service
- Created Doctor Availability Controller
- Added Doctor Availability CRUD APIs
- Prevented past availability creation
- Prevented invalid time ranges
- Prevented overlapping availability

### Availability Flow

```text
Doctor Login
        ↓
JWT Authentication
        ↓
Extract UserId From Claims
        ↓
Create Availability
        ↓
Validate Business Rules
        ↓
Save Availability
```

### Business Rules

- Doctors manage only their own availability
- Start time must be earlier than end time
- Availability cannot be created in the past
- Overlapping availability is not allowed

### Testing Completed

- Availability Creation ✅
- Availability Retrieval ✅
- Availability Deletion ✅
- Invalid Time Validation ✅
- Past Date Validation ✅
- Overlap Validation ✅
- Swagger Testing ✅
- Postman Testing ✅
- SQL Server Verification ✅

### GitHub Workflow Completed

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

---

# Week 4 - Production Backend Development

---

## Day 22 - Appointment Workflow Management ✅

Enhanced AppointmentAPI with structured appointment workflow and business rule validation.

Learned

- Workflow Management
- State Transition Validation
- Business Process Enforcement
- Role-Based Workflow Operations

Implemented

- Appointment Status Constants
- Appointment Workflow Rules
- Workflow Validation
- Doctor Appointment Confirmation
- Doctor Appointment Completion
- Patient Appointment Cancellation

### Appointment Workflow

```text
Booked
    ↓
Confirmed
    ↓
Completed

Booked
    ↓
Cancelled

Confirmed
    ↓
Cancelled
```

### Business Rules

- Doctors can confirm only assigned appointments
- Doctors can complete only confirmed appointments
- Patients can cancel only their own appointments
- Invalid workflow transitions are blocked
- Completed appointments cannot be modified
- Cancelled appointments cannot be modified

### Testing Completed

- Appointment Confirmation ✅
- Appointment Completion ✅
- Appointment Cancellation ✅
- Workflow Validation ✅
- Invalid Transition Validation ✅
- Swagger Testing ✅
- Postman Testing ✅
- SQL Server Verification ✅

### GitHub Workflow Completed

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

## Day 23 - Appointment Search & Filtering ✅

Enhanced AppointmentAPI with flexible appointment search and filtering using role-based access control.

Learned

- Dynamic Query Filtering
- Optional Query Parameters
- Role-Based Data Filtering
- Search API Design

Implemented

- AppointmentSearchDto
- Dynamic Appointment Search
- Status Filtering
- Appointment Date Filtering
- Doctor Filtering
- Patient Filtering
- Service Filtering
- Combined Search Filters

### Search Flow

```text
Search Request
        ↓
Validate User Role
        ↓
Apply Role Filter
        ↓
Apply Search Filters
        ↓
Return Matching Appointments
```

### Business Rules

- Patients can search only their own appointments
- Doctors can search only their assigned appointments
- Administrators can search all appointments
- Multiple filters can be combined
- All search filters are optional

### Testing Completed

- Patient Search ✅
- Doctor Search ✅
- Admin Search ✅
- Status Filtering ✅
- Date Filtering ✅
- Doctor Filtering ✅
- Patient Filtering ✅
- Service Filtering ✅
- Combined Filtering ✅
- Swagger Testing ✅
- Postman Testing ✅
- SQL Server Verification ✅

### GitHub Workflow Completed

- Created GitHub Issue ✅
- Developed In Feature Branch ✅
- Created Pull Request ✅
- Code Review Completed ✅
- Merged Into Main ✅

---

# 🔥 Current Focus

Reviews & Ratings 🚀

Learning Next:
- Reviews & Ratings
- Dashboard APIs
- Pagination & Sorting
- API Versioning
- Health Checks
- React Frontend Integration

---

# 📌 Portfolio Projects

## Healthcare Appointment Booking Platform 🚀

Current Enterprise Project

```text
Completed:

Core Backend
────────────────────────
Console Application         ✅
SQL Database                ✅
EF Core Version             ✅
ASP.NET Core Web API        ✅

Architecture
────────────────────────
DTO Architecture            ✅
Service Layer               ✅
Repository Pattern          ✅
Async Programming           ✅
Global Exception Handling   ✅
API Response Wrapper        ✅

Security
────────────────────────
JWT Authentication          ✅
Password Hashing            ✅
Role Based Authorization    ✅
Secure API Endpoints        ✅

Enterprise Features
────────────────────────
Appointment Business Rules          ✅
Appointment Overlap Validation      ✅

User-Customer Relationship          ✅
Automatic Customer Profile Creation ✅
Automatic Customer Linking          ✅
Secure Self-Booking                 ✅

Patient Appointment Ownership       ✅
User Based Data Filtering           ✅

Admin Authorization                 ✅
Doctor Authorization                ✅
Doctor Assignment Workflow          ✅

Doctor Availability Management      ✅
Doctor Availability Validation      ✅

Appointment Workflow Management     ✅
Workflow Validation                 ✅

Appointment Search & Filtering      ✅
Role-Based Search                   ✅

Professional Workflow
────────────────────────
GitHub Issue Workflow        ✅
Feature Branch Development   ✅
Pull Request Workflow        ✅
```
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
Foundation
──────────────────────────────
C# Fundamentals             ✅
Object-Oriented Programming ✅
Collections & LINQ          ✅
Exception Handling          ✅
Git & GitHub                ✅

Database
──────────────────────────────
SQL Server                  ✅
Entity Framework Core       ✅
Database Relationships      ✅
Migrations                  ✅

Backend Development
──────────────────────────────
ASP.NET Core Web API        ✅
REST APIs                   ✅
DTO Pattern                 ✅
Dependency Injection        ✅
Service Layer               ✅
Repository Pattern          ✅
Async Programming           ✅
Global Exception Handling   ✅
API Response Wrapper        ✅

Authentication & Security
──────────────────────────────
JWT Authentication          ✅
Password Hashing            ✅
Role-Based Authorization    ✅
Claims-Based Authorization  ✅
Resource Ownership          ✅
Secure API Endpoints        ✅

Business Logic
──────────────────────────────
Appointment Validation      ✅
Appointment Ownership       ✅
User-Customer Relationship  ✅
Secure Self-Booking         ✅
Admin Authorization         ✅
Doctor Authorization        ✅
Doctor Availability         ✅
Availability Validation     ✅
Appointment Workflow        ✅
Workflow Validation         ✅
Appointment Search          ✅
Search & Filtering          ✅

Professional Workflow
──────────────────────────────
GitHub Issues               ✅
Feature Branch Workflow     ✅
Pull Requests               ✅
Code Reviews                ✅

Current Focus
──────────────────────────────
Reviews & Ratings 🚀

Next
──────────────────────────────
Reviews & Ratings
        ↓
Dashboard APIs
        ↓
Pagination & Sorting
        ↓
API Versioning
        ↓
Health Checks
        ↓
React Frontend
        ↓
Testing
        ↓
Docker
        ↓
Azure Deployment

---

# Learning Journey

```text
Learn → Build → Test → Refactor → Improve → Deploy 🚀
```
