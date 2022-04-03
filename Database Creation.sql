create database VSFBank;
use VSFBank;
create table Customer (CustomerId numeric(12), FirstName varchar(40), MiddleName varchar(40), 
LastName varchar(40), FathersName varchar(40), MobileNumber numeric(10), EmailId varchar(40), 
DateOfBirth date, ResidentialAddress varchar(40), PermanentAddress varchar(40), 
OccupationType varchar(40), SourceOfIncome varchar(40), GrossAnnualIncome numeric(12,2), 
isDebitCardRequired varchar(40), EnableNetBanking varchar(40), 
AadharNumber numeric(16), Primary key(CustomerId));

create table CustomerAcc (AccountNumber numeric(12), CustomerId numeric(12), Primary Key(AccountNumber),
Constraint "fk_cust_ID" Foreign key(CustomerId) references Customer (CustomerId));

create table Banking(AccountNumber numeric(12), CustomerId numeric(12), Passwordd varchar(40), 
TransactionPassword varchar(40),Primary key(AccountNumber,CustomerId),
Constraint "fk_AccNum" Foreign key(AccountNumber) references CustomerAcc (AccountNumber));

create table AddPayee(BeneficiaryAccountNumber numeric(12), AccountNumber numeric(12), 
BeneficiaryName varchar(40) ,NickName varchar(40), Constraint "fk_AccNum_AddPay" Foreign key(AccountNumber) 
references CustomerAcc (AccountNumber));

create table ValidLogin (CustomerId numeric(12), Passwordd varchar(40), primary Key(CustomerId), 
Constraint "fk_Custid" Foreign key(CustomerId) references Customer (CustomerId));

create table TransactionDetail(TransactionId numeric(12), TransactionType varchar(40), 
ToAccountNumber numeric(12), AccountNumber numeric(12) , Maturityinstruct varchar(40), 
TransactionDate date, Primary key(TransactionId), 
Constraint "fk_AccNum_Tr" Foreign key(AccountNumber) references CustomerAcc (AccountNumber));