-- Database for Product Management System
CREATE DATABASE ProductManagement;
USE ProductManagement;

-- AdminUser Table
CREATE TABLE AdminUser (
    aid INT PRIMARY KEY AUTO_INCREMENT,
    aname VARCHAR(20) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Email VARCHAR(50) UNIQUE NOT NULL,
    Phone VARCHAR(15),
    Address VARCHAR(100)
);

-- Category Table
CREATE TABLE Category (
    cat_id INT PRIMARY KEY AUTO_INCREMENT,
    cat_name VARCHAR(50) NOT NULL
);

-- Attribute Table
CREATE TABLE Attribute (
    att_id INT PRIMARY KEY AUTO_INCREMENT,
    cat_id INT,
    att_name VARCHAR(50) NOT NULL,
    FOREIGN KEY (cat_id) REFERENCES Category(cat_id) ON DELETE CASCADE
);

-- Product Table
CREATE TABLE Product (
    prod_id INT PRIMARY KEY AUTO_INCREMENT,
    prod_name VARCHAR(50) NOT NULL,
    price DECIMAL(10,2),
    cat_id INT,
    FOREIGN KEY (cat_id) REFERENCES Category(cat_id) ON DELETE CASCADE
);

-- ProductAttributeValue Table
CREATE TABLE ProductAttributeValue (
    prod_att_value INT PRIMARY KEY AUTO_INCREMENT,
    prod_id INT,
    att_id INT,
    att_value VARCHAR(100),
    FOREIGN KEY (prod_id) REFERENCES Product(prod_id) ON DELETE CASCADE,
    FOREIGN KEY (att_id) REFERENCES Attribute(att_id) ON DELETE CASCADE
);
