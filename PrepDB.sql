USE Airport;

CREATE TABLE Passengers(Id INT IDENTITY(1,1) PRIMARY KEY, FullName VARCHAR(40), Age INT, Email VARCHAR(40), PhoneNumber VARCHAR(10), ReservationNumber INT, FlightNumber INT);

CREATE TABLE Airplanes(Id INT IDENTITY(1,1) PRIMARY KEY, Model VARCHAR(40), FlightNumber INT, Destination VARCHAR(100), TimeDepart TIME, Capacity INT);


INSERT INTO Airplanes (Model, FlightNumber, Destination, TimeDepart, Capacity)
VALUES
('Boeing 777', 3155,'Zimbabwe', '23:20:00',200);

INSERT INTO Passengers (FullName, Age, Email, PhoneNumber, ReservationNumber, FlightNumber)
VALUES
('Jared Flow', 42, 'jflow@email.com',1234567890,135235,3155);

INSERT INTO Passengers (FullName, Age, Email, PhoneNumber)
VALUES
('Bo Jackson', 30, 'Bo@email.com', 8881394321);


SELECT * FROM Airplanes;
SELECT * FROM Passengers;

DELETE FROM Airplanes WHERE Id = 

