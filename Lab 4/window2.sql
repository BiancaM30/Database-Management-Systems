GO
USE CoffeeToGo
GO

CREATE TABLE Logger(
	id int PRIMARY KEY IDENTITY,
	issue VARCHAR(255),
	operation_thread1 VARCHAR(255),
	operation_thread2 VARCHAR(255),
	currentTime DATETIME,
)
DROP TABLE Logger;
DELETE FROM Logger;

--dirty reads
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRAN;
SELECT * FROM Cafenele;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('dirty reads', 'UPDATE', 'SELECT - before ROLLBACK', GETDATE());
WAITFOR DELAY '00:00:10'
SELECT * FROM Cafenele;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('dirty reads', 'UPDATE', 'SELECT - after ROLLBACK', GETDATE());
COMMIT TRAN;


--dirty reads solved
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRAN;
SELECT * FROM Cafenele;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('dirty reads-solved', 'UPDATE', 'SELECT - before ROLLBACK', GETDATE());
WAITFOR DELAY '00:00:10'
SELECT * FROM Cafenele;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('dirty reads-solved', 'UPDATE', 'SELECT - after ROLLBACK', GETDATE());
COMMIT TRAN;


--non-repeatable reads
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('non-repeatable reads', 'UPDATE', 'SELECT - before commit', GETDATE());
WAITFOR DELAY '00:00:10'
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('non-repeatable reads', 'UPDATE', 'SELECT - after commit', GETDATE());
COMMIT TRAN

--non-repeatable reads solved
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('non-repeatable reads-solved', 'UPDATE', 'SELECT - before commit', GETDATE());
WAITFOR DELAY '00:00:10'
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('non-repeatable reads-solved', 'UPDATE', 'SELECT - before commit', GETDATE());
COMMIT TRAN

--phantom reads
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('phantom reads', 'INSERT', 'SELECT - before delay', GETDATE());
WAITFOR DELAY '00:00:12'
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('phantom reads', 'INSERT', 'SELECT - after delay', GETDATE());
COMMIT TRAN

--phantom reads solved
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('phantom reads-solved', 'INSERT', 'SELECT - before delay', GETDATE());
WAITFOR DELAY '00:00:12'
SELECT * FROM Cafenele
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('phantom reads-solved', 'INSERT', 'SELECT - after delay', GETDATE());
COMMIT TRAN

--deadlock -- random victim
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN;
UPDATE Furnizori SET ProduseLivrate='Expresoare' WHERE Nume='Hendi';
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-first resource-thread2', 'UPDATE', 'UPDATE', GETDATE());
WAITFOR DELAY '00:00:07';
UPDATE Cafenele SET Adresa='Mihai Eminescu 15' WHERE IdCafenea=1;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-second-resource-thread2', 'UPDATE', 'UPDATE', GETDATE());
COMMIT TRAN;


--deadlock -- if transaction 2 has higher priority 
SET DEADLOCK_PRIORITY HIGH
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN;
UPDATE Furnizori SET ProduseLivrate='Expresoare' WHERE Nume='Hendi';
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-first resource-thread2-HIGH', 'UPDATE', 'UPDATE', GETDATE());
WAITFOR DELAY '00:00:07';
UPDATE Cafenele SET Adresa='Mihai Eminescu 15' WHERE IdCafenea=1;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-first resource-thread2-HIGH', 'UPDATE', 'UPDATE', GETDATE());
COMMIT TRAN;


--deadlock solved
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRAN;
UPDATE Cafenele SET Adresa='Mihai Eminescu 15' WHERE IdCafenea=1;
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-first resource-thread2', 'UPDATE', 'UPDATE', GETDATE());
WAITFOR DELAY '00:00:07';
UPDATE Furnizori SET ProduseLivrate='Expresoare' WHERE Nume='Hendi';
INSERT INTO Logger(issue, operation_thread1, operation_thread2, currentTime) VALUES('deadlock-second-resource-thread2', 'UPDATE', 'UPDATE', GETDATE());
COMMIT TRAN;


SELECT * FROM Logger;


