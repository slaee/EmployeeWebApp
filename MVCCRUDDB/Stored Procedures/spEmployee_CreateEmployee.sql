CREATE PROCEDURE [dbo].[spEmployee_CreateEmployee]
	@FirstName nvarchar(15),
	@LastName nvarchar(15),
	@Birthdate Date,
	@ContactNo numeric(11),
	@EmailAddress nvarchar(100)
AS
BEGIN
	-- Declare EmpNo
	DECLARE @EmpNo NVARCHAR(6)

	-- Generate a unique alphanumeric code
	SET @EmpNo = SUBSTRING(CONVERT(NVARCHAR(36), NEWID()), 1, 6)

	-- Check if the generated code is already used
	WHILE EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE [EmpNo] = @EmpNo)
	BEGIN
		SET @EmpNo = SUBSTRING(CONVERT(NVARCHAR(36), NEWID()), 1, 6)
	END
	
	-- Insert the new employee
	INSERT INTO [dbo].[Employee]
		([EmpNo]
		,[FirstName]
		,[LastName]
		,[Birthdate]
		,[ContactNo]
		,[EmailAddress])
	VALUES
		(@EmpNo
		,@FirstName
		,@LastName
		,@Birthdate
		,@ContactNo
		,@EmailAddress)
	SELECT SCOPE_IDENTITY()
END