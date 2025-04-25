Use CoffeeShop
go 
create proc uspInsertSupplier
	@id varchar(20),
	@name nvarchar(100),
	@address nvarchar(200)
as
begin 
	insert into Supplier values(@id,@name,@address);
end
