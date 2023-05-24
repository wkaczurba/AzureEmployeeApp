# AzureEmployeeApp
Azure C# employee web app.
You need to create a Azure SQL DB + add connection string into app configuration as 

# Azure SQL Database contents:

```
CREATE TABLE Employees (
	EmployeeID int,
	LastName varchar(200),
	FirstName varchar(200),
	Primary Key(EmployeeId)
)

insert into Employees(EmployeeID, LastName, FirstName) values (1, 'Fitzpatrick', 'John');
insert into Employees(EmployeeID, LastName, FirstName) values (2, 'OSullivan', 'Siobhan');
insert into Employees(EmployeeID, LastName, FirstName) values (3, 'Smith', 'Jack');

select EmployeeID, LastName, FirstName from Employees;
commit;
```
