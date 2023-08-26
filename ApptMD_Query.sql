CREATE DATABASE ApptMD;

CREATE TABLE Patients (
PatientID INT NOT NULL PRIMARY KEY,
Name VARCHAR(30),
Age Int,
Gender VARCHAR(2),
Diagnosis VARCHAR(5),
Appointment DATE,
PhysicianID INT NOT NULL);

CREATE TABLE Physicians (
PhysicianID INT NOT NULL PRIMARY KEY,
Name VARCHAR(30),
Specialty VARCHAR(4),
Location VARCHAR(30));

CREATE TABLE appointments (
AppointmentStart DateTime,
AppointmentEnd DateTime
PatientID INT,
PhysicianID INT);





