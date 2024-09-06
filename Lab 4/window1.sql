GO
USE CoffeeToGo
GO

SELECT * FROM Cafenele

GO
--1. dirty reads
BEGIN TRAN;
UPDATE Cafenele SET NumarMese=20 WHERE Nume='Starbucks';
WAITFOR DELAY '00:00:07';
ROLLBACK TRAN


--2. non-repeatable reads
BEGIN TRAN
WAITFOR DELAY '00:00:07'
UPDATE Cafenele SET adresa='Zorilor 23' WHERE Nume = 'Starbucks'
COMMIT TRAN

--restore old values
UPDATE Cafenele SET adresa='Eroilor 17' WHERE Nume = 'Starbucks'

--3. phantom reads
BEGIN TRAN
WAITFOR DELAY '00:00:10'
INSERT INTO Cafenele(IdCafenea, Nume, Adresa, DimensiuneMP, NumarMese, NumarAngajati, NumarClienti)
VALUES (8, 'Gloria', 'Teodor Mihali 10', 140, 15, 4, 82)
COMMIT TRAN

--restore old values
DELETE FROM Cafenele WHERE Nume = 'Gloria'

--4. deadlock 
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN;
UPDATE Cafenele SET Adresa='Florilor 13' WHERE IdCafenea=1;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-first resource-thread1', 'UPDATE', 'UPDATE', GETDATE());
WAITFOR DELAY '00:00:07';
UPDATE Furnizori SET ProduseLivrate='Consumabile' WHERE Nume='Hendi';
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-second-resource-thread1', 'UPDATE', 'UPDATE', GETDATE());
COMMIT TRAN;


SELECT * FROM Cafenele
SELECT * FROM Furnizori
--restore old values
UPDATE Cafenele SET Adresa = 'Vasile Alecsandri 39' WHERE IdCafenea=1;
UPDATE Furnizori SET ProduseLivrate='Cafea' WHERE Nume='Hendi'