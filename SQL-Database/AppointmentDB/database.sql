-- =========================
-- Day 8 SQL Fundamentals
-- Appointment Database
-- =========================

CREATE DATABASE AppointmentDB;

USE AppointmentDB;

CREATE TABLE Customers(
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name NVARCHAR (100) NOT NULL,
        Email NVARCHAR (150) NOT NULL,
        Phone NVARCHAR (20) NOT NULL
    );

CREATE TABLE Services(
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name NVARCHAR (100) NOT NULL,
        DurationMinutes INT NOT NULL,
        Price DECIMAL(10, 2) NOT NULL
    );

CREATE TABLE Appointments(
        Id INT PRIMARY KEY IDENTITY (1, 1),
        CustomerId INT NOT NULL,
        ServiceId INT NOT NULL,
        AppointmentDate DATETIME NOT NULL,
        Status NVARCHAR (50) NOT NULL,
        FOREIGN KEY (CustomerId) REFERENCES Customers (Id),
        FOREIGN KEY (ServiceId) REFERENCES Services (Id)
    );

INSERT INTO Customers (Name, Email, Phone) VALUES('Shyam', 'shyam@test.com', '7672666567');

INSERT INTO Services (Name, DurationMinutes, Price) VALUES('Hair Cut', 30, 50.00);

INSERT INTO Appointments (CustomerId, ServiceId, AppointmentDate, Status) VALUES(1, 1, '2026-06-28 10:30', 'Booked');

SELECT * FROM Customers;

SELECT * FROM Services;

SELECT * FROM Appointments;