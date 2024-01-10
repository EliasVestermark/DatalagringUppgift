DROP TABLE Bookings
DROP TABLE Locations
DROP TABLE Times
DROP TABLE Participants
DROP TABLE Clients
DROP TABLE Statuses

CREATE TABLE Statuses
(
	Id int not null identity primary key,
	StatusText nvarchar(20) not null unique
)

CREATE TABLE Clients
(
	Id int not null identity primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	PhoneNumber varchar(20) not null,
	Email varchar(100) not null
)

CREATE TABLE Participants
(
	Id int not null identity primary key,
	Amount varchar(7) not null unique
)

CREATE TABLE Times
(
	Id int not null identity primary key,
	StartTime char(4) not null,
	EndTime char(4) not null
)

CREATE TABLE Locations
(
	Id int not null identity primary key,
	Address nvarchar(50) not null,
	PostalCode char(6) not null,
	City nvarchar(50) not null
)

CREATE TABLE Bookings
(
	Id int not null identity primary key,
	Date char(10) not null,
	StatusId int not null references Statuses(Id),
	ClientId int not null references Clients(Id),
	ParticipantId int not null references Participants(Id),
	TimeId int not null references Times(Id),
	LocationId int not null references Locations(Id)
)