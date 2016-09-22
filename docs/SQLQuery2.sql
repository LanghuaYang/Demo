CREATE TABLE dbo.Person
(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name varchar(255) NOT NULL,
Address1 varchar(255),
Address2 varchar(255),
City varchar(255)
)

CREATE TABLE dbo.OrderHeader
(
OrderId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
OrderDate datetime,
PersonId int NOT NULL FOREIGN KEY REFERENCES dbo.Person(Id)
)

CREATE TABLE dbo.Product
(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name varchar(255) NOT NULL,
Price float NOT NULL,
)

CREATE TABLE dbo.OrderDetail
(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
OrderId int NOT NULL FOREIGN KEY REFERENCES dbo.OrderHeader(OrderId),
ProductId int NOT NULL FOREIGN KEY REFERENCES dbo.Product(Id)
)

