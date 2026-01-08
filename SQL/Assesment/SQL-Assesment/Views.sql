--- Views ---

/* 1. Create a view vw_LowStockProducts Show only products with stock < 5. View should be WITH SCHEMABINDING and Encrypted */

alter view dbo.vw_LowStockProducts
with schemabinding,Encryption
as
select ProductId,ProductName,Price,Stock from dbo.Products
where Stock < 15;

select * from dbo.vw_LowStockProducts;