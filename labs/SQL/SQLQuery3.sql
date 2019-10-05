--select CONCAT(A.FirstName,' ' ,  A.LastName)'Employee Reporting',
--A.ReportsTo, CONCAT(B.FirstName,' ' ,B.LastName)'Name' from Employees A, Employees B
--where A.ReportsTo = B.EmployeeID

--3.2 List all Suppliers with total sales (including discount) over $10,000 in the Order Details table.   
--Include the Company Name from the Suppliers Table and present as a horizontal bar graph as below: (5 Marks)

--select Suppliers.CompanyName, SUM([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) as 'Sales' from  Suppliers
--join Products on Suppliers.SupplierID = Products.SupplierID
--join [Order Details] on [Order Details].ProductID = Products.ProductID
--group by Suppliers.CompanyName
--having SUM([Order Details].UnitPrice * [Order Details].Quantity * (1 - [Order Details].Discount)) > 10000

--3.3 List the Top 10 Customers YTD for the latest year in the Orders file. 
--Based on total dollar amount of orders shipped. No Excel required. (10 Marks)


