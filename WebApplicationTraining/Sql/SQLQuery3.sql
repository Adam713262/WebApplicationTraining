USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[CustOrdersDetail]    Script Date: 2/25/2025 4:08:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CustOrdersDetail] @OrderID int
AS
SELECT ProductName,
    UnitPrice=ROUND(Od.UnitPrice, 2),
    Quantity,
    Discount=CONVERT(int, Discount * 100), 
    ExtendedPrice=ROUND(CONVERT(money, Quantity * (1 - Discount) * Od.UnitPrice), 2)
FROM Products P, [Order Details] Od
WHERE Od.ProductID = P.ProductID and Od.OrderID = @OrderID
GO

--Join 
Create procedure p_CustomerOrders
AS
SELECT A.OrderID, A.CustomerID, B.CompanyName, A.Freight
From Orders A
JOIN Customers B 
ON A.CustomerID=B.CustomerID
GO




