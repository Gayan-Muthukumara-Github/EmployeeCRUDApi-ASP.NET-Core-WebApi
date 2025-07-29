CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Employees;
END
GO

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Position NVARCHAR(100),
    Salary DECIMAL(18,2)
);
GO

