-- Creating the Product Table.
CREATE TABLE products(
	ID int NOT NULL Primary Key IDENTITY(1,1),
	Name varChar(50),
	Price money,
	Description varChar(250)
);
ALTER TABLE Products ADD Active bit
ALTER TABLE Products ADD ImageDescription varchar(250), ImageData varBinary(MAX)

SELECT * FROM products; -- Checking Product Table.
DELETE FROM products; -- Deleting the entire row of Product Table data.
