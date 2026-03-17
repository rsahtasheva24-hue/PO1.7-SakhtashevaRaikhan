CREATE DATABASE IF NOT EXISTS fitnesClub; 
USE fitnesClub;

CREATE TABLE Membershiptypes
(
    MembershipType_ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    name_member VARCHAR(50) UNIQUE NOT NULL,
    duration_month INT NOT NULL CHECK (duration_month >= 0),
    price DECIMAL(10,2) NOT NULL,
    access_level VARCHAR(50)
);

-- Добавлена точка с запятой в конце строки
ALTER TABLE Membershiptypes CHANGE access_level access_level VARCHAR(50) DEFAULT 'Standard'; 

INSERT IGNORE INTO Membershiptypes(name_member, price, duration_month) 
VALUES
('Basic', 50.00, 1),
('Silver', 130.00, 2),
('Gold', 240.00, 3),
('Platinum', 450.00, 4),
('Trial', 10.00, 5);

SELECT * FROM Membershiptypes;

CREATE TABLE IF NOT EXISTS Members
(
Member_id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
date_of_birth DATE NOT NULL,
gender CHAR(1) DEFAULT 'O',
phone VARCHAR(20),
registration_date DATE DEFAULT (CURRENT_DATE),
membership_id INT NOT NULL,
CONSTRAINT fk_membership FOREIGN KEY (membership_id) REFERENCES Membershiptypes(MembershipType_ID)

);

ALTER TABLE Members ADD status_type CHAR(1) NOT NULL check (status_type IN ('U', 'P'));
ALTER TABLE Members MODIFY COLUMN phone VARCHAR(20) UNIQUE;

INSERT INTO Members(first_name, last_name, date_of_birth, gender, phone, registration_date, status_type, membership_id)
VALUES
('Sultan', 'Ahmetov', '1992-05-15', 'M', '+77015551234', '2025-01-10', 'U', 1),
('Elena', 'Ivanova', '1988-11-03', 'F', '+77074449876', '2025-02-15', 'P', 2),
('Dmitry', 'Kim', '1995-07-20', 'M', '+77473332155', '2025-03-01', 'P', 3),
('Aigerim', 'Serikova', '2000-02-14', 'F', '+77021110022', '2025-03-15', 'P', 4),
('Ivan', 'Petrov', '1990-12-25', 'M', '+77779998877', '2025-03-20', 'U', 5);

SELECT * FROM Members;

CREATE TABLE IF NOT EXISTS Invoice
(
invoice_id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
member_id INT NOT NULL,
total_amount DECIMAL(10,2) NOT NULL CHECK (total_amount > 0),
status_type CHAR(1) NOT NULL DEFAULT 'U' CHECK (status_type IN ('U', 'P')),
CONSTRAINT fk_member_id FOREIGN KEY (member_id) REFERENCES Members(Member_id)

);

INSERT INTO Invoice(member_id, total_amount, status_type)
VALUES
(1, 50.00, 'P'),
(2, 130.00, 'U'),
(3, 240.00, 'P'),
(4, 450.00, 'U'),
(5, 10.00, 'P');

SELECT 
    m.first_name, 
    m.last_name, 
    mt.name_member AS plan_name, 
    i.total_amount AS bill_sum, 
    i.status_type AS payment_status
FROM Members m
JOIN Membershiptypes mt ON m.membership_id = mt.MembershipType_ID
JOIN Invoice i ON m.Member_id = i.member_id;
