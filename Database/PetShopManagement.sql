-- Create the PetShopManagement database
CREATE DATABASE PetShopManagement
GO

-- Use the PetShopManagement database
USE PetShopManagement
GO

-- Create Customer table
CREATE TABLE Customer (
    CustID INT IDENTITY(1,1) PRIMARY KEY,
    CustName VARCHAR(50) NOT NULL,
    CustAddress VARCHAR(100) NOT NULL,
    CustPhone VARCHAR(10) NOT NULL
);

-- Create Employee table
CREATE TABLE Employee (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    EmpAddress VARCHAR(100) NOT NULL,
    EmpDOB DATE NOT NULL,
    EmpPhone VARCHAR(10) NOT NULL,
    EmpPass VARCHAR(255) NOT NULL
);

-- Create Product table
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(50) NOT NULL,
    Category VARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    Price INT NOT NULL
);

-- Create Bill table
CREATE TABLE Bill (
    BillID INT IDENTITY(1,1) PRIMARY KEY,
    CustID INT NOT NULL,
    EmpID INT NOT NULL,
    BillDate DATE NOT NULL,
    CustName VARCHAR(50) NOT NULL,
    EmpName VARCHAR(50) NOT NULL,
    Amt INT NOT NULL,
    FOREIGN KEY (CustID) REFERENCES Customer(CustID),
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID)
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    BillID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price INT NOT NULL,
    FOREIGN KEY (BillID) REFERENCES Bill(BillID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
