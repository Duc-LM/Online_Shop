create table Role(
Id int identity(1,1) primary key not null,
Name nvarchar(255) not null
);

create table [User](
Id int identity(1,1) primary key not null,
User_name nvarchar(255)not null,
Password nvarchar(255) not null,
Name nvarchar(255) not null,
Email nvarchar(255) not null,
Address nvarchar(255) not null,
Avatar nvarchar(Max) not null,
Gender varchar(100) not null,
Phone_number varchar(100) not null,
Role_id int foreign key references Role(Id) on delete set null,
Dob date not null
);
create table Category(
Id int identity(1,1) primary key not null,
Name nvarchar(255) not null,
Short_desc nvarchar(255) not null,
);
create table Product (
Id int identity(1,1) primary key not null,
Name nvarchar(255) not null,
Images nvarchar(Max) not null,
Price decimal(18,0) not null,
Quantity int not null,
Short_desc nvarchar(Max) not null,
Created_at date not null,
Updated_at date not null,
Category_id int foreign key references Category(Id) on delete set null
);

create table Spec(
Id int identity(1,1) primary key not null,
CPU nvarchar(255) not null,
GPU nvarchar(255) not null,
Screen nvarchar(255) not null,
Ports nvarchar(255) not null,
RAM nvarchar(255) not null,
Storage nvarchar(255) not null,
Connectivity nvarchar(255) not null,
Size nvarchar(255) not null,
Weight nvarchar(255) not null,
Battery nvarchar(255) not null,
Manufacturer nvarchar(255) not null,
Product_id int foreign key references Product(Id) on delete set null,
);

create table Promotion(
Id int identity(1,1) primary key not null,
Name nvarchar(255) not null,
Short_desc nvarchar(255) not null,
Begin_date date not null,
End_date date not null,
Percent_discount int not null,
Quantity_left int not null
);
create table [Order](
Id int identity(1,1) primary key not null,
Customer_name nvarchar(255) not null,
Phone_number nvarchar(255) not null,
Place_of_receipt nvarchar(255) not null,
Note nvarchar(255) not null,
Payment_method nvarchar(255) not null,
Total_Price decimal(18,0) not null,
Delivery_status nvarchar(255) not null,
Is_paid int not null,
Ship_price decimal(18,0) not null,
Created_date date not null,
Is_customer int not null,
Promotion_id int foreign key references Promotion(Id) on delete set null
);
create table Order_Product (
Id int identity(1,1) primary key not null,
Order_id int foreign key references [Order](Id) on delete set null,
Product_id int foreign key references Product(Id) on delete set null,
Quantity int not null,
Price decimal(18,0) not null,
Created_at date not null,
User_id int foreign key references [User](Id) on delete set null
);