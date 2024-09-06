GO
USE CoffeeToGo
GO

--Validators
GO
CREATE OR ALTER FUNCTION validateNume
(
	@nume varchar(50)
)
RETURNS BIT AS 
BEGIN
	IF @nume is not null
			RETURN 1;
    RETURN 0
END

GO
CREATE OR ALTER FUNCTION validateTelefon
(
	@telefon int
)
RETURNS BIT AS 
BEGIN
	IF @telefon is not null
			RETURN 1;
    RETURN 0
END

GO
CREATE OR ALTER FUNCTION validateAdresa
(
	@adresa varchar(50)
)
RETURNS BIT AS
	BEGIN
	DECLARE @lungime int
	SET @lungime = LEN(@adresa)

	DECLARE @contor int
	SET @contor = 1

	WHILE @contor <= @lungime
	BEGIN
		IF not SUBSTRING(@adresa, @contor, 1) like '%[a-zA-Z ,0-9]'
			RETURN 0

		SET @contor = @contor + 1
	END
    RETURN 1
END


GO
CREATE OR ALTER FUNCTION validateFormatSiteWeb
(
	@siteWeb varchar(50)
)
RETURNS BIT AS
BEGIN
	IF(@siteWeb is null)
		RETURN 0
	--verificam prima parte a sirului
	IF (not SUBSTRING(@siteWeb, 1, 12) like 'https://www.')
			RETURN 0
	--verificam a doua parte a sirului
	DECLARE @lungime int
	SET @lungime = LEN(@siteWeb)
	DECLARE @contor int
	SET @contor = 13
	WHILE @contor <= @lungime
	BEGIN
		IF not SUBSTRING(@siteWeb, @contor, 1) like '%[a-zA-Z_0-9@\.]'
			RETURN 0
		SET @contor = @contor + 1
	END
	RETURN 1
END


GO
CREATE OR ALTER FUNCTION validateProduseLivrate
(
	@produseLivrate varchar(50)
)
RETURNS BIT AS
BEGIN
	IF (@produseLivrate is not null AND @produseLivrate != 'Expresoare' AND @produseLivrate != 'Cafea' AND @produseLivrate != 'Consumabile')
		RETURN 0
    RETURN 1
END


GO
CREATE OR ALTER FUNCTION validatePretLunar
(
	@pret float
)
RETURNS BIT AS BEGIN
	IF @pret is not null AND @pret > 0
			RETURN 1;
    RETURN 0
END

GO
CREATE OR ALTER FUNCTION validateNumarMese
(
	@numar tinyint
)
RETURNS BIT AS BEGIN
	IF @numar is not null AND @numar > 0
			RETURN 1;
    RETURN 0
END

GO
CREATE OR ALTER FUNCTION validateNumarPozitiv
(
	@numar int
)
RETURNS BIT AS BEGIN
	IF @numar is not null AND @numar > 0
			RETURN 1;
    RETURN 0
END

------------------------------------------------
GO
DECLARE @var bit
EXEC @var=dbo.validatePretLunar -32.5
print(@var)
--------------------------------------------------

-- procedura cu full rollback
GO
CREATE OR ALTER PROCEDURE AddFullRollback @numeC varchar(50), @adresaC varchar(50), @dimensiuneMP int, @nrMese tinyint, @nrAngajati int, @nrClienti int, 
								 @numeF varchar(50), @telefon int, @adresaF varchar(50), @siteWeb varchar(50), @produseLivrate varchar(50), @pretLunar float
AS
BEGIN
	DECLARE @idC INT, @idF INT
	BEGIN TRAN
		BEGIN TRY
		--Cafenele
		IF(dbo.validateNume(@numeC)<>1)
		BEGIN
			RAISERROR('Name must not be null',14,1)
		END
		IF(dbo.validateAdresa(@adresaC)<>1)
		BEGIN
			RAISERROR('Adresa should contain only letters and numbers',14,1)
		END
		IF(dbo.validateNumarPozitiv(@dimensiuneMP)<>1)
		BEGIN
			RAISERROR('DimensiuneMP should be a positive number',14,1)
		END
		IF(dbo.validateNumarPozitiv(@nrAngajati)<>1)
		BEGIN
			RAISERROR('NumarAngajati should be a positive number',14,1)
		END
		IF(dbo.validateNumarPozitiv(@nrClienti)<>1)
		BEGIN
			RAISERROR('NumarClienti should be a positive number',14,1)
		END
		--Furnizori
		IF(dbo.validateNume(@numeF)<>1)
		BEGIN
			RAISERROR('Name must not be null',14,1)
		END
		IF(dbo.validateTelefon(@telefon)<>1)
		BEGIN
			RAISERROR('Telefon must not be null',14,1)
		END
		IF(dbo.validateAdresa(@adresaF)<>1)
		BEGIN
			RAISERROR('Adresa should contain only letters and numbers',14,1)
		END
		IF(dbo.validateFormatSiteWeb(@siteWeb)<>1)
		BEGIN
			RAISERROR('SiteWeb should be like https://www.',14,1)
		END
		IF(dbo.validateProduseLivrate(@produseLivrate)<>1)
		BEGIN
			RAISERROR('ProduseLivrate should contain Expresoare/Cafea/Consumabile',14,1)
		END
		IF(dbo.validatePretLunar(@pretLunar)<>1)
		BEGIN
			RAISERROR('PretLunar should be a positive number',14,1)
		END
		
		SET @idC=(SELECT max(IdCafenea) FROM Cafenele)+1		
		SET @idF=(SELECT max(IdFurnizor) FROM Furnizori)+1
		INSERT INTO Cafenele (IdCafenea, Nume, Adresa, DimensiuneMP, NumarMese, NumarAngajati, NumarClienti) VALUES (@idC, @numeC, @adresaC, @dimensiuneMP, @nrMese, @nrAngajati, @nrClienti)
		INSERT INTO Furnizori(IdFurnizor, Nume, Telefon, Adresa, SiteWeb, ProduseLivrate, PretLunar) VALUES (@idF, @numeF, @telefon, @adresaF, @siteWeb, @produseLivrate, @pretLunar)
		INSERT INTO CafeneleFurnizori(IdCafenea, IdFurnizor) VALUES (@idC, @idF)

	COMMIT TRAN
	SELECT 'Transaction committed'
	INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddFullRollback', 'all tables', 'committed', GETDATE())
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Transaction rollbacked', ERROR_MESSAGE() AS Error
		INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddFullRollback', 'all tables', 'rollbacked', GETDATE())
	END CATCH
END


GO
CREATE OR ALTER PROCEDURE AddPartialRollback @numeC varchar(50), @adresaC varchar(50), @dimensiuneMP int, @nrMese tinyint, @nrAngajati int, @nrClienti int, 
								    @numeF varchar(50), @telefon int, @adresaF varchar(50), @siteWeb varchar(50), @produseLivrate varchar(50), @pretLunar float
AS
BEGIN
	DECLARE @idC INT, @idF INT
	--Cafenele
	BEGIN TRAN
	BEGIN TRY
		IF(dbo.validateNume(@numeC)<>1)
		BEGIN
			RAISERROR('Name must not be null',14,1)
		END
		IF(dbo.validateAdresa(@adresaC)<>1)
		BEGIN
			RAISERROR('Adresa should contain only letters and numbers',14,1)
		END
		IF(dbo.validateNumarPozitiv(@dimensiuneMP)<>1)
		BEGIN
			RAISERROR('DimensiuneMP should be a positive number',14,1)
		END
		IF(dbo.validateNumarPozitiv(@nrAngajati)<>1)
		BEGIN
			RAISERROR('NumarAngajati should be a positive number',14,1)
		END
		IF(dbo.validateNumarPozitiv(@nrClienti)<>1)
		BEGIN
			RAISERROR('NumarClienti should be a positive number',14,1)
		END
		SET @idC=(SELECT max(IdCafenea) FROM Cafenele)+1		
		INSERT INTO Cafenele (IdCafenea, Nume, Adresa, DimensiuneMP, NumarMese, NumarAngajati, NumarClienti) VALUES (@idC, @numeC, @adresaC, @dimensiuneMP, @nrMese, @nrAngajati, @nrClienti)
	COMMIT TRAN
	SELECT 'Add in Cafenele transaction committed'
	INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'Cafenele', 'committed', GETDATE())
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Add in Cafenele transaction rollbacked', ERROR_MESSAGE() AS Error
		INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'Cafenele', 'rollbacked', GETDATE())
	END CATCH

	--Furnizori
	BEGIN TRAN
	BEGIN TRY
		IF(dbo.validateNume(@numeF)<>1)
		BEGIN
			RAISERROR('Name must not be null',14,1)
		END
		IF(dbo.validateTelefon(@telefon)<>1)
		BEGIN
			RAISERROR('Telefon must not be null',14,1)
		END
		IF(dbo.validateAdresa(@adresaF)<>1)
		BEGIN
			RAISERROR('Adresa should contain only letters and numbers',14,1)
		END
		IF(dbo.validateFormatSiteWeb(@siteWeb)<>1)
		BEGIN
			RAISERROR('SiteWeb should be like https://www.',14,1)
		END
		IF(dbo.validateProduseLivrate(@produseLivrate)<>1)
		BEGIN
			RAISERROR('ProduseLivrate should contain Expresoare/Cafea/Consumabile',14,1)
		END
		IF(dbo.validatePretLunar(@pretLunar)<>1)
		BEGIN
			RAISERROR('PretLunar should be a positive number',14,1)
		END
		SET @idF=(SELECT max(IdFurnizor) FROM Furnizori)+1
		INSERT INTO Furnizori(IdFurnizor, Nume, Telefon, Adresa, SiteWeb, ProduseLivrate, PretLunar) VALUES (@idF, @numeF, @telefon, @adresaF, @siteWeb, @produseLivrate, @pretLunar)
	COMMIT TRAN
	SELECT 'Add in Furnizori transaction committed'
	INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'Furnizori', 'committed', GETDATE())
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Add in Furnizori transaction rollbacked', ERROR_MESSAGE() AS Error
		INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'Furnizori', 'rollbacked', GETDATE())

	END CATCH

	--CafeneleFurnizori
	BEGIN TRAN
	BEGIN TRY
			INSERT INTO CafeneleFurnizori(IdCafenea, IdFurnizor) VALUES (@idC, @idF)
	COMMIT TRAN
	SELECT 'Add in CafeneleFurnizori transaction committed'
	INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'CafeneleFurnizori', 'committed', GETDATE())
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT 'Add in CafeneleFurnizori transaction rollbacked', ERROR_MESSAGE() AS Error
		INSERT INTO LogTable(TypeOperation, TableOperation, StatusCommit, ExecutionDate) VALUES ('AddPartialRollback', 'CafeneleFurnizori', 'rollbacked', GETDATE())
	END CATCH
END

--Testare		
GO
DELETE FROM CafeneleFurnizori WHERE (IdCafenea=7 AND IdFurnizor=5) OR (IdCafenea=8 AND IdFurnizor=6)
DELETE FROM Furnizori WHERE IdFurnizor=5 OR IdFurnizor=6 or IdFurnizor=7
DELETE FROM Cafenele WHERE IdCafenea=7 OR IdCafenea=8 or IdCafenea=9

SELECT * FROM Cafenele
SELECT * FROM Furnizori
SELECT * FROM CafeneleFurnizori


EXEC AddFullRollback 'Starbucks', 'Eroilor 17', 150, 10, 3, 70, 
					 'StarDelivery', 780345675, 'Calea Victoriei 3','https://www.stardelivery.ro', 'Expresoare', 980.5
EXEC AddFullRollback 'Starbucks', 'Eroilor$$ 17', 150, '', 3, 70, 
					 'StarDelivery', 780345675, 'Calea Victoriei 3','https://www.stardelivery.ro', 'Expresoare', 980.5
EXEC AddFullRollback 'Starbucks', 'Eroilor 17', 150, 10, 3, 70, 
					 'StarDelivery', 780345675, 'Calea Victoriei 3','https://www.stardelivery.ro', 'Dulciuri', 980.5
EXEC AddFullRollback 'Starbucks', 'Eroilor 17', -150, 10, 3, '', 
					 'StarDelivery', 780345675, 'Calea Victoriei 3','aaa', 'Expresoare', 980.5

EXEC AddPartialRollback 'Gloria', 'Dorobantilor 16', 150, 10, 3, 70, 
					 'Metro', 780345675, 'Calea Victoriei 3','https://www.metro.ro', 'Consumabile', 980.5
EXEC AddPartialRollback null, 'Dorobantilor 16', 150, 10, 3, 70, 
					 'Metro', 780345675, 'Calea Victoriei 3','https://www.stardelivery.ro', 'Dulciuri', 980.5
EXEC AddPartialRollback 'Gloria', 'Dorobantilor$$ 16', 150, '', 3, 70, 
					 'TedExpress', 780345675, 'Calea Victoriei 3','https://www.tedexpress.ro', 'Expresoare', 980.5
EXEC AddPartialRollback 'CoffeeBreak', 'Florilor 20', 100, 10, 3, 100, 
					 'Metro', 780345675, 'Calea Victoriei 3','aaa', 'Consumabile', 980.5

SELECT * FROM LogTable
delete from LogTable