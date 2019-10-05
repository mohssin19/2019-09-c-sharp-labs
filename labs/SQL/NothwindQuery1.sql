--select top 5 * from Customers order by CustomerID desc
--/*  */
--select * from products
--update products set UnitsInStock = 200 where ProductID=31 
--select * from products where UnitsInStock <10 and Discontinued=0
--order by UnitsInStock desc

--select country from customers order by Country
--select distinct country from customers order by country

--select * from products where ProductName like '%ch%'
--select * from products where ProductName like 'ch%'
--select * from products where ProductName not like 'ch%'

--select distinct region from Customers
--select * from customers where Region in ('ak','bc','ca')

--select * from products where UnitPrice between 10 and 15 order by unitprice 

/* COUNT CITY, COUNTRY   */
/* Average price min max price*/
/*sum of units on stock*/

--select COUNT(City) as 'Cities', count (distinct country) as 'Countries' from Customers
--select COUNT(distinct Country) from Customers

--select avg (unitPrice) as 'average price' from products
--select min (unitPrice) as 'min price' from products
--select max (unitPrice) as 'maxe price' from products

--select min (unitprice) as 'minprice' from products
--select max (unitprice) as 'maxprice' from products

--select sum (unitsinstock) as 'StockTotal' from products

--products, price, discount, price including discount

 
--select * from [Order Details]
--select ProductName, [Order Details].UnitPrice, Discount,
--([Order Details].UnitPrice*(1-Discount)) as 'Discount Price' from [Order Details]
--inner join Products on products.productid = [order details].ProductID
--order by 'Discount Price' Desc

--select 
--sum (unitprice*quantity) as 'gross sales',
--sum (unitprice*quantity*(1-discount)) as 'discounted sales',
--(sum (unitprice*quantity) - sum (unitprice*quantity*(1-discount))) as 'money lost'

--from [Order Details]

--select * from products 

--select supplierId, sum(unitsonorder) as 'totalUnitsOnOrder' from products
--group by SupplierID
--having sum(unitsonorder) = 0
--order by 'totalUnitsOnOrder' desc

select * from customers where customerId not in 
(select customerid from orders)



