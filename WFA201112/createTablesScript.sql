--CREATE DATABASE jogastudio;
--USE jogastudio;

--CREATE TABLE tagok(
--id INT PRIMARY KEY IDENTITY,
--nev VARCHAR(50),
--mester BIT);

--CREATE TABLE pozok(
--id INT PRIMARY KEY IDENTITY,
--nev VARCHAR(50));

--CREATE TABLE beosztas(
--id INT PRIMARY KEY IDENTITY,
--idopont DATETIME,
--instruktor INT FOREIGN KEY REFERENCES tagok(id),
--diakok VARCHAR(50) NULL,
--tananyag INT FOREIGN KEY REFERENCES pozok(id));