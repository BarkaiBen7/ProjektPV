create database obchod;
use obchod;

CREATE TABLE Customers (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Email VARCHAR(255),
    RegistrationDate DATETIME
);

CREATE TABLE Products (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Price FLOAT,
    InStock BIT
);

CREATE TABLE Orders (
    ID INT PRIMARY KEY IDENTITY,
    CustomerID INT,
    OrderDate DATETIME,
    Status VARCHAR(50),
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID)
);

CREATE TABLE OrderItems (
    ID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    FOREIGN KEY (ProductID) REFERENCES Products(ID)
);

CREATE TABLE Suppliers (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Phone VARCHAR(255)
);
