CREATE PROCEDURE [dbo].[spEmployee_UpdateEmployeeByID]
	@ID bigint,
	-- Only contact no. and email address can be updated for an employee
	@ContactNo nvarchar(11),
	@EmailAddress nvarchar(100)
AS
BEGIN 
	UPDATE [dbo].[Employee]
	SET [ContactNo] = @ContactNo,
		[EmailAddress] = @EmailAddress
	WHERE [ID] = @ID
END
