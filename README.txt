# AgriConnectPlatform

A .NET 6.0 MVC web application for managing farmers and agricultural products in a secure and structured environment. This system allows employees to register farmers, and enables farmers to add and manage their products.

---

## Contents

1. [Overview](#overview)  
2. [System Requirements](#system-requirements)  
3. [Installing & Running the Application](#installing--running-the-application)

---

## 1. Overview

**Application structure:**

- Built with ASP.NET MVC (.NET 6.0)
- Uses Microsoft SQL Server and SQL Server Management Studio (SSMS)
- Follows the Code First approach

**User roles:**

- **Employees** can:
  - Log in
  - View a list of all registered farmers
  - Add new farmers to the system (creation date is auto-generated)
  - View and filter products by category

- **Farmers** can:
  - Log in
  - View products associated with their profile

Only authenticated users can view or interact with data.

---

## 2. System Requirements

### Supported OS:

- Microsoft Windows 10

### Not Supported:

- MS-DOS  
- Windows 3.1  
- Windows NT 3.51 / 4.0  
- Windows 95 / 98  
- Linux

### Additional Software:

- Visual Studio Community 2019 Version 16.9.4 or later  
- .NET 6.0 SDK  
- Microsoft SQL Server  
- SQL Server Management Studio (SSMS)

---

## 3. Installing & Running the Application

### Step 1: Unzip the Folder

Includes:

- `AgriConnectPlatform` (Visual Studio project files)
- SQL script to prepopulate the database

### Step 2: Open in Visual Studio

- Open the solution folder in Visual Studio

### Step 3: Configure SQL Server

1. Open SQL Server Management Studio (SSMS)  
2. Copy your local server name (e.g., `(LocalDB)\MSSQLLocalDB`)

### Step 4: Update Connection String

1. In Visual Studio, open `appsettings.json`
2. Replace the server name in the connection string:

```json
"DefaultConnection": "Server=(LocalDB)\MSSQLLocalDB;Database=AgriEnergyConnectDB;Trusted_Connection=True;"
```


### Step 5: Run SQL Script

- Open the SQL script in SSMS and execute it to populate the database with sample data.

### Step 6: Run the Application

- In Visual Studio, click the green “Run” button or press `F5`.

---

## Default Users (for testing)

### Employees

| Email           | Password    |
|------------------|-------------|
| joy@gmail.com     | abc         |
| h@gmail.com       | a1b2        |

### Farmers

| Email              | Password    |
|---------------------|-------------|
| jess@gmail.com       | 123         |
| l@gmail.com          | 1223        |
| sandy@gmail.com      | sandy2      |

---

## Notes

- The app uses Entity Framework Core with Code First Migration.
- User passwords are securely hashed.
- All data is protected through authentication and role-based authorization.
