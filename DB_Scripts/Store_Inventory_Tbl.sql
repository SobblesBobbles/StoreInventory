
begin tran
create table Store_Inventory_Tbl (
  ID int IDENTITY(1,1)   not null primary key, 
  Price decimal(19,10) not null,
  Date DateTime not null
 

);

drop table Store_Inventory_Tbl

commit

insert into Store_Inventory_Tbl (Price, Date) values (4.99, GETDATE())

select * from Store_Inventory_Tbl