-- =========================
-- Day 8 SQL Fundamentals
-- Appointment Database
-- =========================


CREATE DATABASE AppointmentDB;


USE AppointmentDB;


CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    Name NVARCHAR(100) NOT NULL,

    Email NVARCHAR(150) NOT NULL,

    Phone NVARCHAR(20) NOT NULL
);


CREATE TABLE Services
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    Name NVARCHAR(100) NOT NULL,

    DurationMinutes INT NOT NULL,

    Price DECIMAL(10,2) NOT NULL
);


CREATE TABLE Appointments
(
    Id INT PRIMARY KEY IDENTITY(1,1),

    CustomerId INT NOT NULL,

    ServiceId INT NOT NULL,

    AppointmentDate DATETIME NOT NULL,

    Status NVARCHAR(50) NOT NULL,


    FOREIGN KEY(CustomerId)
        REFERENCES Customers(Id),


    FOREIGN KEY(ServiceId)
        REFERENCES Services(Id)
);


INSERT INTO Customers
(
    Name,
    Email,
    Phone
)
VALUES
(
    'Shyam',
    'shyam@test.com',
    '7672666567'
);


INSERT INTO Services
(
    Name,
    DurationMinutes,
    Price
)
VALUES
(
    'Hair Cut',
    30,
    50.00
);


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
SELECT A.Id,C.Name AS CustomerName,S.Name AS ServiceName,A.AppointmentDate,A.Status FROM Appointments A INNER JOIN Customers C ON A.CustomerId = C.Id INNER JOIN Services S ON A.ServiceId = S.Id;

-- Search appointment by customer
SELECT A.Id,C.Name AS CustomerName,S.Name AS ServiceName,A.AppointmentDate,A.Status FROM Appointments A INNER JOIN Customers C ON A.CustomerId = C.Id INNER JOIN Services S ON A.ServiceId = S.Id WHERE C.Name = 'Shyam';

-- Cancel appointment
UPDATE Appointments SET Status = 'Cancelled' WHERE Id = 1;

SELECT * FROM Appointments;