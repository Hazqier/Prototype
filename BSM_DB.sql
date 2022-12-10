-- Creating the Product Table.
CREATE TABLE products(
	ID int NOT NULL Primary Key IDENTITY(1,1),
	Name varChar(50),
	Price money,
	Description varChar(250),
	ImageDescription varchar(250),
	ImageData varBinary(MAX),
	SerialNumber varChar(14),
	Active bit
);

SELECT * FROM products; -- Checking Product Table.

DELETE FROM products; -- Deleting the entire row of Product Table data.

