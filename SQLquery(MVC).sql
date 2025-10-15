CREATE DATABASE Camp5db
USE Camp5db

-- Patient Registration

--Membership
CREATE TABLE Membership (
MembershipId INT IDENTITY(1,1) PRIMARY KEY,
MemberDescription NVARCHAR(100) NOT NULL,
InsuredAmount DECIMAL(10,2) NULL
);

--Patient
CREATE TABLE Patient (
PatientId INT IDENTITY(1,1) PRIMARY KEY,
RegistrationNo NVARCHAR(20) NOT NULL UNIQUE,
PatientName NVARCHAR(200) NOT NULL,
Dob DATE NULL,
Gender NVARCHAR(10) NULL,
Address NVARCHAR(500) NULL,
PhoneNo NVARCHAR(20) NULL,
MembershipId INT NULL,
CONSTRAINT FK_Patient_Membership FOREIGN KEY (MembershipId) REFERENCES Membership(MembershipId)
);
select * from Patient

-- Insert Membership data
INSERT INTO Membership (MemberDescription, InsuredAmount)
VALUES 
('Basic', 500.00),
('Silver', 1500.00),
('Gold', 5000.00);

-- Insert Patient data
INSERT INTO Patient (RegistrationNo, PatientName, Dob, Gender, Address, PhoneNo, MembershipId)
VALUES
('REG001', 'Anu', '1998-05-12', 'Female', 'Kochi', '9876543210', 2),
('REG002', 'Rahul', '1995-11-25', 'Male', 'Trivandrum', '9847012345', 3),
('REG003', 'Amaya', '2000-07-04', 'Female', 'Calicut', '8899001122', 1);

--List of patient
CREATE PROCEDURE sp_GetPatientList
AS
BEGIN
SELECT p.PatientId,p.RegistrationNo,p.PatientName,
p.Dob,p.Gender,p.Address,p.PhoneNo,m.MemberDescription,m.InsuredAmount
FROM Patient p
LEFT JOIN Membership m
ON p.MembershipId = m.MembershipId
END;

--Get all membership
CREATE PROCEDURE sp_GetAllMemberships
AS
BEGIN
SELECT MembershipId,MemberDescription,InsuredAmount
FROM Membership
END;

--Insert patient
CREATE PROCEDURE sp_InsertPatient
@RegistrationNo NVARCHAR(20),
@PatientName NVARCHAR(200),
@Dob DATE = NULL,
@Gender NVARCHAR(10) = NULL,
@Address NVARCHAR(500) = NULL,
@PhoneNo NVARCHAR(20) = NULL,
@MembershipId INT = NULL
AS
BEGIN
    INSERT INTO Patient(RegistrationNo,PatientName,Dob,Gender,Address,PhoneNo,MembershipId)
    VALUES(@RegistrationNo,@PatientName,@Dob,@Gender,@Address,@PhoneNo,@MembershipId);

    SELECT SCOPE_IDENTITY() AS NewPatientId;
END;

-- Get patient by Id
CREATE OR ALTER PROCEDURE sp_GetPatientById
    @PatientId INT
AS
BEGIN
    SELECT 
        p.PatientId,
        p.RegistrationNo,
        p.PatientName,
        p.Dob,
        p.Gender,
        p.Address,
        p.PhoneNo,
        p.MembershipId,
        m.MemberDescription,
        m.InsuredAmount
    FROM Patient p
    LEFT JOIN Membership m ON p.MembershipId = m.MembershipId
    WHERE p.PatientId = @PatientId;
END;


--Edit patient
CREATE PROCEDURE sp_EditPatient
    @PatientId INT,
    @RegistrationNo NVARCHAR(20),
    @PatientName NVARCHAR(200),
    @Dob DATE = NULL,
    @Gender NVARCHAR(10) = NULL,
    @Address NVARCHAR(500) = NULL,
    @PhoneNo NVARCHAR(20) = NULL,
    @MembershipId INT = NULL
AS
BEGIN
    UPDATE Patient
    SET
        RegistrationNo = @RegistrationNo,
        PatientName = @PatientName,
        Dob = @Dob,
        Gender = @Gender,
        Address = @Address,
        PhoneNo = @PhoneNo,
        MembershipId = @MembershipId
    WHERE PatientId = @PatientId;
END;


-- Professor Registration

CREATE TABLE Department (
    DeptNo INT PRIMARY KEY IDENTITY(1,1),
    DeptName NVARCHAR(100),
    HOD NVARCHAR(100)
);

CREATE TABLE Professor (
    ProfessorId INT PRIMARY KEY IDENTITY(1,1),
    ManagerId INT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DeptNo INT FOREIGN KEY REFERENCES Department(DeptNo),
    Salary DECIMAL(10,2),
    JoiningDate DATE,
    DateOfBirth DATE,
    Gender NVARCHAR(10)
);

--Insert into Department
INSERT INTO Department (DeptName, HOD)
VALUES 
('Computer Science', 'Anitha'),
('Electronics and Communication', 'Rajesh'),
('Mechanical Engineering', 'Suresh'),
('Civil Engineering', 'Priya'),
('Electrical Engineering', 'Vivek');

--Insert into professor
INSERT INTO Professor (ManagerId, FirstName, LastName, DeptNo, Salary, JoiningDate, DateOfBirth, Gender)
VALUES
(101, 'John', 'Mathew', 1, 75000.00, '2018-06-15', '1985-03-10', 'Male'),
(102, 'Anjali', 'Krishnan', 2, 82000.00, '2019-08-01', '1988-11-25', 'Female'),
(103, 'Vivek', 'Menon', 3, 90000.00, '2017-01-10', '1982-05-15', 'Male'),
(104, 'Divya', 'Nair', 4, 78000.00, '2020-03-05', '1990-02-20', 'Female'),
(105, 'Arun', 'Ramesh', 5, 85000.00, '2016-09-12', '1984-07-30', 'Male');

-- Professor list
CREATE PROCEDURE sp_GetProfessorList
AS
BEGIN
SELECT P.ProfessorId,P.ManagerId,P.FirstName,P.LastName,
D.DeptName,P.Salary,P.JoiningDate,P.DateOfBirth,P.Gender
FROM Professor P
INNER JOIN Department D 
ON P.DeptNo = D.DeptNo
END;

--Get all department
CREATE PROCEDURE sp_GetAllDepartments
AS
BEGIN
    SELECT DeptNo, DeptName FROM Department;
END;

--Insert a new professor
CREATE PROCEDURE sp_InsertProfessor
    @ManagerId INT = NULL,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DeptNo INT,
    @Salary DECIMAL(10,2),
    @JoiningDate DATE,
    @DateOfBirth DATE,
    @Gender NVARCHAR(10)
AS
BEGIN
    INSERT INTO Professor (ManagerId, FirstName, LastName, DeptNo, Salary, JoiningDate, DateOfBirth, Gender)
    VALUES (@ManagerId, @FirstName, @LastName, @DeptNo, @Salary, @JoiningDate, @DateOfBirth, @Gender);
END;

-- Getprofessor by id
CREATE PROCEDURE sp_GetProfessorById
    @ProfessorId INT
AS
BEGIN
    SELECT 
        P.ProfessorId,
        P.ManagerId,
        P.FirstName,
        P.LastName,
        P.DeptNo,
        D.DeptName,
        P.Salary,
        P.JoiningDate,
        P.DateOfBirth,
        P.Gender
    FROM Professor P
    INNER JOIN Department D ON P.DeptNo = D.DeptNo
    WHERE P.ProfessorId = @ProfessorId;
END;

--Update professor
CREATE PROCEDURE sp_UpdateProfessor
    @ProfessorId INT,
    @ManagerId INT = NULL,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DeptNo INT,
    @Salary DECIMAL(10,2),
    @JoiningDate DATE,
    @DateOfBirth DATE,
    @Gender NVARCHAR(10)
AS
BEGIN
UPDATE Professor
    SET
        ManagerId = @ManagerId,
        FirstName = @FirstName,
        LastName = @LastName,
        DeptNo = @DeptNo,
        Salary = @Salary,
        JoiningDate = @JoiningDate,
        DateOfBirth = @DateOfBirth,
        Gender = @Gender
    WHERE ProfessorId = @ProfessorId;
END;

