
use AddressBookService;

--Create Table AddressBook
CREATE TABLE Address_Book
(
ContactId int not null identity(1,1),
FirstName varchar(20) not null,
LastName varChar(20) not null,
Address varchar(100) not null,
City varchar(20) not null,
State varchar(20) not null,
Zip int not null,
Phone_Number varchar(12) not null,
Email varchar(20) not null,
PRIMARY KEY ("ContactID")
);

select * from Address_Book;

Insert into Address_Book values('krishnan','Nair','Beach Road,azhikkal','kannur','kerala',670001,'8899007766','k.nair@gm.com'),
('Rajeevan','Edakkad','Palm Tree Enclave','kannur','kerala',670002,'8899123766','raj@gm.com'),
('Shyamala','KV','chakkarakal','kannur','kerala',670011,'7899007766','shyama@gm.com'),
('John','Thomas','Whites Road','Chennai','Tamil nadu',600002,'8145007766','john@gm.com'),
('Rishikesh','Raj','Besant Nagar','Chennai','Tamil Nadu',670011,'8899004556','rishi@gm.com');

GO
CREATE OR ALTER PROCEDURE [dbo].[spAddress_Book]
(@FIRST_NAME VARCHAR(20),
@LAST_NAME VARCHAR(20),
@ADDRESS VARCHAR(100),
@CITY VARCHAR(20),
@STATE VARCHAR(20),
@ZIP_CODE INT,
@PHONE_NUMBER VARCHAR(12),
@EMAIL VARCHAR(20))
AS
BEGIN
INSERT INTO ADDRESS_BOOK VALUES(@FIRST_NAME,@LAST_NAME,@ADDRESS,@CITY,@STATE,@ZIP_CODE,@PHONE_NUMBER,@EMAIL)
END