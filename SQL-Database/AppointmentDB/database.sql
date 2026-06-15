-- =========================
-- Day 8 SQL Fundamentals
-- Appointment Database
-- =========================


CREATE DATABASE AppointmentDB;
USE AppointmentDB;

CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20) NOT NULL
);

CREATE TABLE Services(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    DurationMinutes INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Appointments(
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    ServiceId INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,

    FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY(ServiceId) REFERENCES Services(Id)
);

INSERT INTO Customers(
    Name,
    Email,
    Phone
)
VALUES(
    'Shyam',
    'shyam@test.com',
    '7672666567'
);

INSERT INTO Services(
    Name,
    DurationMinutes,
    Price
)
VALUES(
    'Hair Cut',
    30,
    50.00
);

INSERT INTO Appointments(
    CustomerId,
    ServiceId,
    AppointmentDate,
    Status
)
VALUES(
    1,
    1,
    '2026-06-28 10:30',
    'Booked'
);

SELECT * FROM Customers;
SELECT * FROM Services;
SELECT * FROM Appointments;


-- =========================
-- Day 9 SQL Queries
-- CRUD Operations
-- =========================


-- SELECT all data
SELECT * FROM Customers;

-- SELECT specific columns
SELECT Name,Email FROM Customers;

-- WHERE filtering
SELECT * FROM Customers WHERE Id = 1;
SELECT * FROM Appointments WHERE Status = 'Booked';

-- INSERT new customer
INSERT INTO Customers(Name,Email,Phone) VALUES('Raj','raj@test.com','8888888888');

-- INSERT new service
INSERT INTO Services(Name,DurationMinutes,Price) VALUES('Massage',60,100.00);

-- INSERT new appointment
INSERT INTO Appointments(CustomerId,ServiceId,AppointmentDate,Status) VALUES(2,2,'2026-07-01 15:30','Booked');

-- UPDATE data
UPDATE Customers SET Phone = '7777777777' WHERE Id = 1;

-- DELETE data example
DELETE FROM Appointments WHERE Id = 2;

-- ORDER BY
SELECT * FROM Appointments ORDER BY AppointmentDate ASC;

-- INNER JOIN

-- Show appointment details with customer and service
SELECT
    A.Id,
    C.Name AS CustomerName,
    S.Name AS ServiceName,
    A.AppointmentDate,
    A.Status
FROM Appointments A
INNER JOIN Customers C
ON A.CustomerId = C.Id
INNER JOIN Services S
ON A.ServiceId = S.Id;

-- Search appointment by customer
SELECT 
    A.Id,
    C.Name AS CustomerName,
    S.Name AS ServiceName,
    A.AppointmentDate,
    A.Status 
FROM Appointments A 
INNER JOIN Customers C 
ON A.CustomerId = C.Id 
INNER JOIN Services S 
ON A.ServiceId = S.Id 
WHERE C.Name = 'Shyam';

-- Cancel appointment
UPDATE Appointments SET Status = 'Cancelled' WHERE Id = 1;

SELECT * FROM Appointments;

-- =========================
-- Day 10 Advanced SQL
-- Database Rules & Functions
-- =========================


-- CHECK Constraint
-- Allow only valid appointment status values
ALTER TABLE Appointments
ADD CONSTRAINT CK_Appointment_Status

CHECK(
    Status IN(
        'Booked',
        'Cancelled',
        'Completed'
    )
);


-- Test CHECK Constraint
-- failed because Pending is not allowed

/*
INSERT INTO Appointments
(
    CustomerId,
    ServiceId,
    AppointmentDate,
    Status
)
VALUES
(
    1,
    1,
    '2026-08-01 10:00',
    'Pending'
);
*/


-- DEFAULT Constraint
-- Automatically set default status
ALTER TABLE Appointments
ADD CONSTRAINT DF_Appointment_Status
DEFAULT 'Booked'
FOR Status;

-- ALTER TABLE
-- Add CreatedAt column
ALTER TABLE Appointments
ADD CreatedAt DATETIME DEFAULT GETDATE();


-- Test DEFAULT Status
INSERT INTO Appointments(
    CustomerId,
    ServiceId,
    AppointmentDate
)
VALUES(
    1,
    1,
    '2026-08-02 11:00'
);

-- Check Appointments
SELECT *
FROM Appointments;

-- =========================
-- Aggregate Functions
-- =========================

-- COUNT
-- Total appointments
SELECT
    COUNT(*) AS TotalAppointments
FROM Appointments;


-- COUNT booked appointments
SELECT
    COUNT(*) AS BookedAppointments
FROM Appointments
WHERE Status = 'Booked';


-- SUM
-- Total revenue from appointments
SELECT
    SUM(S.Price) AS TotalRevenue
FROM Appointments A
INNER JOIN Services S
ON A.ServiceId = S.Id;

-- AVG
-- Average service price
SELECT
    AVG(Price) AS AverageServicePrice
FROM Services;

-- MAX
-- Highest service price
SELECT
    MAX(Price) AS HighestPrice
FROM Services;

-- MIN
-- Lowest service price
SELECT
    MIN(Price) AS LowestPrice
FROM Services;

-- =========================
-- GROUP BY
-- =========================

-- Count appointments by status
SELECT
    Status,
    COUNT(*) AS Total
FROM Appointments
GROUP BY Status;


-- Count appointments per customer
SELECT
    C.Name AS CustomerName,
    COUNT(A.Id) AS TotalAppointments
FROM Appointments A
INNER JOIN Customers C
ON A.CustomerId = C.Id
GROUP BY C.Name;

-- =========================
-- HAVING
-- =========================

-- Customers with one or more appointments
SELECT
    C.Name AS CustomerName,
    COUNT(A.Id) AS TotalAppointments
FROM Appointments A
INNER JOIN Customers C
ON A.CustomerId = C.Id
GROUP BY C.Name
HAVING COUNT(A.Id) >= 1;

-- =========================
-- INDEX
-- =========================

-- Improve appointment date searching performance
CREATE INDEX IX_Appointments_Date
ON Appointments(AppointmentDate);

-- Business Report Query
SELECT
    C.Name AS CustomerName,
    COUNT(A.Id) AS TotalBookings,
    SUM(S.Price) AS TotalSpent

FROM Appointments A

INNER JOIN Customers C
ON A.CustomerId = C.Id

INNER JOIN Services S
ON A.ServiceId = S.Id

GROUP BY C.Name;