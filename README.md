# Product-Management-System
ASP.NET project for managing categories, products, and attributes with admin panel.

# 🛠️ Admin Dashboard - ASP.NET Project

## 📌 Overview
This project is an **Admin Dashboard** built with **ASP.NET (C#)** and **SQL Server**.  
It allows the admin to manage categories, products, and attributes, along with their relationships.  

The system provides:
- User authentication (Admin login/logout)
- Category management
- Product management
- Attribute and product attribute value management
- Reports showing products with their attributes

---

## 🚀 Features
- **Admin Login/Logout**
- **Manage Categories**
  - Add, Update, Delete, List
- **Manage Products**
  - Add, Update, Delete, List
- **Manage Attributes**
  - Add, Update, Delete, List
- **Product Attribute Values**
  - Assign attributes to products
- **Reports**
  - List products with their attribute values

---

## 🗄️ Database Design
- Database schema is included in `database.sql`.
- Tables:
  - `AdminUser` – Stores admin details.
  - `Category` – Stores product categories.
  - `Product` – Stores products under categories.
  - `Attribute` – Stores attribute types.
  - `ProductAttributeValue` – Stores values of attributes for each product.

---

## 📦 Class Design
- **Class Diagram** available in `/Diagrams/ClassDiagram.png`.
- **ERD (Database Diagram)** available in `/Diagrams/DatabaseDiagram.png`.

---

## ⚙️ Setup Instructions
1. Clone this repository.
2. Open solution in **Visual Studio**.
3. Import database by running `database.sql` in **SQL Server**.
4. Update connection string in `Web.config` with your SQL Server details.
5. Run the project (F5).

---

## 📸 Screenshots
Screenshots are available in `/Screenshots/`:
- Admin Dashboard
- Manage Categories
- Manage Products
- Reports Page

---

## 👩‍💻 Author
- **Sakthi Priya**
- Built as part of an interview project task.
