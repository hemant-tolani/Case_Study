create database payxpert;
use payxpert;

create table Employee (
EmployeeID INT PRIMARY KEY,
FirstName VARCHAR(20),
LastName VARCHAR(20),
DateOfBirth DATE,
Gender VARCHAR(7),
Email VARCHAR(25),
PhoneNumber VARCHAR(15),
Address VARCHAR(50),
Position VARCHAR(20),
JoiningDate DATE,
TerminationDate DATE
);

select * from Employee;
create table Payroll (
PayrollID INT PRIMARY KEY,
EmployeeID INT,
PayPeriodStartDate DATE,
BasicSalary INT,
OvertimePay INT,
Deductions INT,
NetSalary INT,
CONSTRAINT emp_id FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
);
select * from Employee;

alter table Payroll
add PayPeriodEndDate DATE;

select * from FinancialRecord;
select * from Tax;
create table Tax (
TaxID INT PRIMARY KEY,
EmployeeID INT,
TaxYear INT,
TaxableIncome INT,
TaxAmount INT
CONSTRAINT e_id FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
);


create table FinancialRecord (
RecordID INT PRIMARY KEY,
EmployeeID INT,
RecordDate DATE,
Descriptions VARCHAR(20),
Amount INT,
RecordType VARCHAR(10),
CONSTRAINT em_id FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
);


select * from Tax;



INSERT INTO Employee (EmployeeID, FirstName, LastName, DateOfBirth, Gender, Email, PhoneNumber, Address, Position, JoiningDate)
VALUES (1, 'John', 'Doe', '1990-01-01', 'Male', 'john@example.com', '1234567890', 'Address', 'Manager', '2023-01-01');



insert into Payroll values (1, 1, '2023-03-31', 3000, 500, 250, 4500),
(2, 2, '2022-02-15', 4000, 450, 200, 6500),
(3, 3, '2019-04-30', 5000, 400, 150, 7500),
(4, 4, '2018-01-31', 6000, 300, 100, 9500);

insert into Tax values (1, 1, 2023, 1500, 2500),
(2, 2, 2022, 2000, 2450),
(3, 3, 2019, 2500, 2400),
(4, 4, 2018, 3000, 2300);

insert into Payroll values (1, 1, '2023-03-31', 'New', 1500, 'income'),
(2, 2, '2022-02-15', '1 year old', 2450, 'income'),
(3, 3, '2019-04-30', '4 year old', 3400, 'expense'),
(4, 4, '2018-01-31', '5 year old', 5300, 'tax');

]