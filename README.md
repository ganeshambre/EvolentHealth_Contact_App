# EvolentHealth_Contact_App
Application Folder structure
1. EvolentHealth_Contact_App 		-	Web API project
2. EvolentHealth_Contact_App.BL	-   Business Logic / Domain services project
3. EvolentHealth_Contact_App.DAL		- Data Access Layer project 
4. EvolentHealth_Contact_App.Entities	- Project for Entities used in the application
5. EvolentHealth_Contact_App.Repository - Repository Layer project
6. EvolentHealth_Contact_App.Utilities  - Common utilities (e.g. Logger) project
7. EvolentHealth_Contact_App.Tests		- Unit Testing Project

The application has been hosted on Azure as Azure App service. Databse used is Azure SQL database. (connection string can be found in the EvolentHealth_Contact_App project web.config file)
Please find below the hosted link: <br />
<b> Application publicily avaiable hosted link : https://evolenthealthcontactapp.azurewebsites.net </b> <br/>
<b> Sample API Url : https://evolenthealthcontactapp.azurewebsites.net/api/user/all </b> <br/>
<b> API documentation link : https://evolenthealthcontactapp.azurewebsites.net/swagger/ui/index </b> <br/>

# Important:
This application has basic Authentication in place. To make an API call add below Header in the api request

---------------------------------------------------
Header Name  	| 	Value
---------------------------------------------------
Authorization	|	Basic Z2FuZXNoOmV2b2xlbnQxMjM=
---------------------------------------------------
Base64Encoded value(Z2FuZXNoOmV2b2xlbnQxMjM) for ganesh:evolent123
username : ganesh
password : evolent123

# Libraries/packages used in the solution
1. Unity : IOC container framework
2. Swagger : API documentation generation
3. EntityFramework : Code first approach and database used is Zure SQL server
4. MsTest : Unit Testing framework


