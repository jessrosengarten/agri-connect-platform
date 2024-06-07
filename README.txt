************************************************************************
	ST10153811 
	PROG7311 POE Task 2
		
	README to setup and run the AgriConnectPlatform application
************************************************************************

************************************************************************
*  CONTENTS:
************************************************************************

This document contains the following sections:

1.  Overview
2.  System Requirements
3.  Installing/Configuring the Software 

************************************************************************
* 1.  OVERVIEW
************************************************************************

   ==> Application structure:
    = ASP.NET MVC - .NET 6.0
	= utilizes Microsoft Sql Server (see section 3!) and SSMS
	= Code First Approach
	
	The AgriConnectPlatform application allows employees to add farmers and 
	subsequently farmers can add products.

    The application has been provisioned for two types of users:
	- Employees
	- Farmers
	
	Only logged in users are able to see data.
	
	Employee are able to login and see the list of all farmers loaded on the
	application. 
	The employee can add a new farmer to the database. The creation date
	is automatically generated.
	
	The employee can see a list of all products loaded into the system.
	The employee does this by clicking "View Products" on the employee home page. 
	Alternatively,
	The employee can choose to filter the products by category.
	This is done by clicking the "Filter" button in the View Products 
	section of the employee page.
	
	Once a farmer has signed in, they can view a list of only the products in their profile.
		

************************************************************************
* 2.  SYSTEM REQUIREMENTS
************************************************************************

1.  The system must be running on one of the following
    operating systems:
    
    - Microsoft Windows 10
   
2. The following operating systems are not supported:

    Any version of the following Microsoft operating systems:
    - MS-DOS
    - Windows 3.1
    - Windows NT 3.51
    - Windows 95
    - Windows 98
    - Windows NT 4.0

    Any version of the following operating systems:
    - Linux 

3.  The system should contain at least the minimum system 
    memory required by the operating system.

4. The following additional software is required 
 
	Microsoft Visual Studio Community 2019 Version 16.9.4
    Microsoft.NET Framework Version 6.0 
	Microsoft SQL Server
	Microsoft SQL Server Management Studio (SSMS)

************************************************************************
* 3.  INSTALLING/CONFIGURING THE SOFTWARE
************************************************************************

1. Unzip the folder 
   (Right click on folder and then select extract all)
   - included in this folder:
	= AgriConnectPlatform (Visual Studio Application files)
	= SQL Script (file with the scripts to add prepopulated data to the database) [SEE Step 5]

   NOTE: you will need a sub directory / file-path of this folder to update the output directory (see below)

2. Open file in Visual Studio
    - Open the folder

	 
3. Open Microsoft SQL Server Management Studio
	= copy the local server name (E.g. (LocalDB)\MSSQLLocalDB )

4. In Visual Studio the Solution Explorer (right hand side), double click on the "appsettings.json"

	= You will need to update the connection string, paste the local server name in the string like below:
	
	Example: (remove <>
	
	    "DefaultConnection": "Server=<INPUT SERVER NAME HERE>;Database=AgriEnergyConnectDB;Trusted_Connection=True;"

	NOTE: remove the <>
	
	EG For this project:
	"DefaultConnection": "Server=(LocalDB)\\MSSQLLocalDB;Database=AgriEnergyConnectDB;Trusted_Connection=True;"

	 FALIURE TO UPDATE THIS MAY RESULT IN CONNECTION ERRORS
	
5.  Write the script in SSMS:
	= The SQL script will be shown in a separate folder. Add this to SSMS and run this to populate the data.
	
6. Configuration complete, run application
	- In Visual Studio, click RUN (green play icon) to compile and run the program

7. POPULATED USER PASSWORDS
	 - Employee: Email - joy@gmail.com : Password - abc 
	 - Employee: Email - h@gmail.com : Password - a1b2
	 - Farmer: Email - jess@gmail.com : Password 123
	 - Farmer: Email - l@gmail.com : Password 1223
	 - Farmer: Email - sandy@gmail.com : Password - sandy2

These can be used to log in to the application
