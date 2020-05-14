
CREATE TABLE Department(
	departmentID int PRIMARY KEY NOT NULL,
	departmentName varchar(255)
)

INSERT INTO Department
VALUES (1, 'Attraction Department'), (2, 'Maintenance Department'),
(3, 'Ride and Attraction Creative Department'), (4, 'Construction Department'),
(5, 'Dining Room Division'), (6, 'Kitchen Division'), (7, 'Purchasing Department'),
(8, 'Accounting and Finance Department'), (9, 'Front Office Division'), (10, 'House Keeping Division'),
(11, 'Sales and Marketing Department'), (12, 'Human Resource Department'), (13, 'Manager')

SELECT * FROM Department

DROP TABLE Department

CREATE TABLE Employee(
	employeeID int PRIMARY KEY NOT NULL,
	departmentID int FOREIGN KEY REFERENCES Department(departmentID) ON DELETE CASCADE ON UPDATE CASCADE,
	[name] varchar(255),
	[password] varchar(255),
	salary int,
	dateOfBirth date,
	[status] varchar(255)
)

DROP TABLE Employee

INSERT INTO Employee
VALUES (1, 12, 'Daniel', 'kuda', 1000, '2001-07-03', 'Active')

INSERT INTO Employee
VALUES (2, 13, 'Luis', 'chuardi', 1000, '2000-12-30', 'Active')

INSERT INTO Employee
VALUES (3, 10, 'Adrian', 'awai', 1000, '2001-01-24', 'Active')

INSERT INTO Employee
VALUES (4, 6, 'Kimmoe', 'kv', 1000, '2002-02-11', 'Active')

INSERT INTO Employee
VALUES (5, 1, 'Martin', 'ayamgeprek', 1000, '2002-02-11', 'Active')

SELECT * FROM Employee

UPDATE Employee
SET [status] = 'Active'

DELETE FROM Employee WHERE employeeID = 6

CREATE TABLE Request(
	requestID int PRIMARY KEY NOT NULL,
	departmentID int FOREIGN KEY REFERENCES Department(departmentID) ON DELETE CASCADE ON UPDATE CASCADE,
	[type] varchar(255),
	title varchar(255),
	[description] varchar(255),
	[response] varchar(255),
	[status] varchar(255)
)

INSERT INTO Request
VALUES(1, 3, 'Fund', 'AA', 'AA', '-', 'Pending')
INSERT INTO Request
VALUES(2, 3, 'Purchase', 'BB', 'BB', '-', 'Pending')

SELECT * FROM Request

DELETE FROM Request

DROP TABLE Request

CREATE TABLE PersonalRequest(
	requestID int PRIMARY KEY NOT NULL,
	departmentID int FOREIGN KEY REFERENCES Department(departmentID),
	employeeID int FOREIGN KEY REFERENCES Employee(employeeID),
	[type] varchar(255),
	title varchar(255),
	[description] varchar(255),
	[response] varchar(255),
	[status] varchar(255)
)

SELECT * FROM PersonalRequest

DELETE FROM PersonalRequest

DROP TABLE PersonalRequest

INSERT INTO PersonalRequest
VALUES (1, 13, 2,  'Leave', 'Chuardi', 'Chuardi ajak jalan jalan', 'Pending')

SELECT * FROM PersonalRequest

DELETE FROM PersonalRequest

CREATE TABLE HRRequest(
	requestID int PRIMARY KEY NOT NULL,
	employeeID int FOREIGN KEY REFERENCES Employee(employeeID),
	[type] varchar(255),
	title varchar(255),
	[description] varchar(255),
	[response] varchar(255),
	[status] varchar(255)
)

DROP TABLE HRRequest

CREATE TABLE AttractionOrRide(
	attractionID int PRIMARY KEY NOT NULL,
	[name] varchar(255),
	[type] varchar(255),
	[description] varchar(255),
	[status] varchar(255)
)

INSERT INTO AttractionOrRide
VALUES(1, 'Roller Coaster', 'Ride', 'aa', 'On Progress')

DROP TABLE AttractionOrRide

DELETE FROM AttractionOrRide

CREATE TABLE ConstructionProgress(
	progressID int primary key not null,
	attractionID int foreign key references AttractionOrRide(attractionID),
	title varchar(255),
	[description] varchar(255),
	progressDate date
)

INSERT INTO ConstructionProgress
VALUES (1, 1, 'aa', 'bb', '01-01-2001')

DELETE FROM ConstructionProgress

CREATE TABLE MaintenanceSchedule(
	scheduleID int PRIMARY KEY NOT NULL,
	attractionID int FOREIGN KEY REFERENCES AttractionOrRide(attractionID),
	scheduleDate date,
	[status] varchar(255)
)

DROP TABLE MaintenanceSchedule

CREATE TABLE MaintenanceLog(
	maintenanceLogID int PRIMARY KEY NOT NULL,
	scheduleID int FOREIGN KEY REFERENCES MaintenanceSchedule(scheduleID),
	employeeID int FOREIGN KEY REFERENCES Employee(employeeID),
	title varchar(255),
	[description] varchar(255)
)

DELETE FROM MaintenanceLog

DROP TABLE MaintenanceLog

CREATE TABLE Customer(
	customerID int PRIMARY KEY NOT NULL,
	idCardNumber varchar(255),
	[name] varchar(255),
	dateOfBirth date,
	[address] varchar(255),
	gender varchar(255),
	[status] varchar(255)
)

SELECT * FROM Customer

INSERT INTO Customer
VALUES(1, '1212', 'Bambang', '01-01-2001', 'abc', 'Male', 'Active')

DELETE FROM Customer

INSERT INTO Customer
VALUES(0, '000000', 'Anonymous', '01-01-1970', 'None', '-', 'Active')

CREATE TABLE Feedback(
	feedbackID int PRIMARY KEY NOT NULL,
	customerID int FOREIGN KEY REFERENCES Customer(customerID),
	receiver varchar(255),
	title varchar(255),
	[description] varchar(255)
)

SELECT * FROM Feedback

DELETE FROM Feedback

CREATE TABLE HotelTransaction(
	transactionID int PRIMARY KEY NOT NULL,
	customerID int FOREIGN KEY REFERENCES Customer(customerID),
	employeeID int FOREIGN KEY REFERENCES Employee(employeeID),
	roomID int FOREIGN KEY REFERENCES Room(roomID),
	checkInDate date,
	checkOutDate date
)

SELECT * FROM HotelTransaction

DELETE FROM HotelTransaction

INSERT INTO HotelTransaction
VALUES (1, 1, 1, '01-01-2001')

DROP TABLE HotelTransaction

CREATE TABLE Room(
	roomID int PRIMARY KEY NOT NULL,
	price int,
	[status] varchar(255)
)

SELECT * FROM Room

UPDATE Room
SET status = 'Available'

INSERT INTO Room
VALUES(3, 1000, 'Available')

CREATE TABLE CleaningSchedule(
	scheduleID int PRIMARY KEY,
	roomID int FOREIGN KEY REFERENCES Room(roomID),
	cleaningDate date,
	[status] varchar(255)
)

SELECT * FROM CleaningSchedule

DELETE FROM CleaningSchedule

DROP TABLE CleaningSchedule

CREATE TABLE Reservation(
	reservationID int PRIMARY KEY NOT NULL,
	customerID int FOREIGN KEY REFERENCES Customer(customerID),
	roomID int FOREIGN KEY REFERENCES Room(roomID),
	checkInDate date,
	checkOutDate date,
	[status] varchar(255)
)

SELECT * FROM Reservation

INSERT INTO Reservation
VALUES(1, 1, 1, '01-01-2001', '02-02-2001', 'Active')

DELETE FROM Reservation

CREATE TABLE CleaningLog(
	cleaningLogID int PRIMARY KEY NOT NULL,
	roomID int FOREIGN KEY REFERENCES Room(roomID),
	[description] varchar(255),
	cleaningDate date
)

SELECT * FROM CleaningLog

DROP TABLE CleaningLog

CREATE TABLE Advertisement(
	advertisementID int PRIMARY KEY NOT NULL,
	title varchar(255),
	[description] varchar(255)
)

DELETE FROM Advertisement

CREATE TABLE TicketTransaction(
	transactionID int primary key not null,
	employeeID int foreign key references Employee(employeeID),
	ticketID int foreign key references Ticket(ticketID),
	purchaseDate date,
)

SELECT * FROM TicketTransaction

DELETE FROM TicketTransaction

DROP TABLE TicketTransaction

CREATE TABLE Ticket(
	ticketID int primary key not null,
	dateCreated date
)

SELECT * From Ticket

DELETE FROM Ticket

INSERT INTO Ticket
VALUES(1, '05/13/2020'), (2, '05/14/2020')

CREATE TABLE DetailTicketTransaction(
	transactionID int foreign key REFERENCES TicketTransaction(transactionID),
	ticketID int foreign key REFERENCES Ticket(ticketID),
	status varchar(255)
	PRIMARY KEY(transactionID, ticketID)
)

SELECT * FROM DetailTicketTransaction

DROP TABLE DetailTicketTransaction

CREATE TABLE Seat(
	seatID int primary key not null,
	chairQuantity int,
	status varchar(255)
)

INSERT INTO Seat
VALUES (1, 4, 'Available'), (2, 2, 'Available'),(3, 4, 'Available'), (4, 2, 'Available')

SELECT * FROM Seat

CREATE TABLE RestaurantTransaction(
	transactionID int primary key not null,
	employeeID int foreign key references Employee(employeeID),
	seatID int foreign key references Seat(seatID),
	purchaseDate date
)

SELECT * FROM RestaurantTransaction

DELETE FROM RestaurantTransaction

DROP TABLE RestaurantTransaction

CREATE TABLE Food(
	foodID int primary key not null,
	[name] varchar(255),
	price int
)

INSERT INTO Food
VALUES (1, 'Indomie', 10000), (2, 'Nasi Goreng', 15000), (3, 'Kambing Bakar', 30000), (4, 'Burger', 20000), 
(5, 'Bakso', 15000)

SELECT * FROM Food

CREATE TABLE DetailRestaurantTransaction(
	transactionID int foreign key references RestaurantTransaction(transactionID),
	foodID int foreign key references Food(foodID),
	quantity int
	PRIMARY KEY (transactionID, foodID)
)

SELECT * FROM DetailRestaurantTransaction

DELETE FROM DetailRestaurantTransaction

DROP TABLE DetailRestaurantTransaction

CREATE TABLE [Order](
	orderID int primary key not null,
	seatID int foreign key references Seat(seatID),
	status varchar(255)
)

SELECT * FROM [Order]

INSERT INTO [Order]
VALUES (1, 1, 'Waiting'), (2, 2, 'Waiting')

INSERT INTO [Order]
VALUES (3, 4, 'Finished')

SELECT * FROM [Order]

DELETE FROM [Order]
WHERE orderID = 3

DELETE FROM [Order]
DELETE FROM OrderDetail

UPDATE [Order]
SET [status] = 'Waiting'
WHERE orderID = 3

CREATE TABLE OrderDetail(
	orderID int foreign key references [Order](orderID),
	foodID int foreign key references Food(foodID),
	quantity int,
	PRIMARY KEY (orderID, foodID)
)

SELECT * FROM OrderDetail

INSERT INTO OrderDetail
VALUES (2, 5, 1)

CREATE TABLE Idea(
	ideaID int primary key not null,
	[name] varchar(255),
	[description] varchar(255),
	response varchar(255),
	[type] varchar(255),
	[category] varchar(255),
	[status] varchar(255)
)

INSERT INTO Idea
VALUES(1, 'a', 'a', '-', 'Pending')

SELECT * FROM Idea

DELETE FROM Idea

DROP TABLE Idea

CREATE TABLE Task(
	taskID int primary key not null,
	ideaID int foreign key references Idea(ideaID),
	[status] varchar(255),
	[taskDescription] varchar(255)
)

SELECT * FROM Task

DELETE FROM Task

DROP TABLE Task

CREATE TABLE Ingredient(
	ingredientID int primary key not null,
	[name] varchar(255),
	quantity int
)

INSERT INTO Ingredient
VALUES (1, 'Bakmi', 100), (2, 'Roti', 100), (3, 'Daging Kambing', 50)

CREATE TABLE PurchaseLog(
	purchaseLogID int primary key not null,
	title varchar(255),
	[description] varchar(255),
	purchaseDate date,
	totalPrice int
)

DELETE FROM PurchaseLog

DROP TABLE PurchaseLog
