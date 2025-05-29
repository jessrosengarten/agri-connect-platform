# AgriConnect Platform

A simple and effective ASP.NET MVC web application designed to support small-scale agricultural businesses through secure data entry, user access control, and product management. Built using the .NET 6.0 framework with SQL Server integration, the AgriConnect Platform streamlines how employees manage farmers, and how farmers manage their products.

---

## Overview

The AgriConnect Platform is built using:

* **ASP.NET MVC** (.NET 6.0)
* **SQL Server** (with SQL Server Management Studio)
* **Code-First Entity Framework**

### Core Functionality

* **Employee Role**

  * Login to view and manage registered farmers
  * Add new farmers (auto-generates registration date)
  * View all product listings or filter by category

* **Farmer Role**

  * Login to manage their own product listings
  * View only their products securely

All access and data visibility is restricted to authenticated users, with different views and permissions based on user roles.

---

## System Requirements

### Supported Operating System

* Windows 10 or later

### Required Software

* **Visual Studio 2019 or later** (Community Edition is fine)
* **.NET 6.0 SDK**
* **Microsoft SQL Server**
* **SQL Server Management Studio (SSMS)**

---

## Getting Started

### 1. Clone or Download the Repository

Extract the zipped folder or clone this repository to your local machine.

The project contains:

* AgriConnectPlatform solution files (Visual Studio)
* A SQL script to pre-populate the database with sample data

### 2. Open the Project in Visual Studio

* Launch Visual Studio
* Open the solution folder

### 3. Configure SQL Server

* Open SQL Server Management Studio (SSMS)
* Copy your local SQL server name (e.g., `(LocalDB)\MSSQLLocalDB`)

### 4. Update `appsettings.json`

Update the connection string in `appsettings.json` with your local SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(LocalDB)\\MSSQLLocalDB;Database=AgriEnergyConnectDB;Trusted_Connection=True;"
}
```

> Be sure to remove angle brackets and enter your correct local server.

### 5. Create and Seed the Database

* Open SSMS and run the provided SQL script to pre-populate the database with test data.

### 6. Run the Application

In Visual Studio:

* Press the green play button (`Run`) or press `F5`
* This will build the solution and launch the application in your browser

---

## Sample Login Credentials (for demo/testing)

### Employees

* **[joy@gmail.com](mailto:joy@gmail.com)** : `abc`
* **[h@gmail.com](mailto:h@gmail.com)** : `a1b2`

### Farmers

* **[jess@gmail.com](mailto:jess@gmail.com)** : `123`
* **[l@gmail.com](mailto:l@gmail.com)** : `1223`
* **[sandy@gmail.com](mailto:sandy@gmail.com)** : `sandy2`

Use these accounts to explore both employee and farmer features.

---

## Why This Project?

This application was built as a practical exploration of:

* Role-based access control
* Secure data connection and management
* Entity Framework (Code-First)
* Structured data flow and separation of concerns within ASP.NET MVC

It demonstrates a clean separation between different user types and provides a working model for managing domain-specific data securely.

---

Feel free to fork, explore, or contact me if you'd like to collaborate or know more about this project!
