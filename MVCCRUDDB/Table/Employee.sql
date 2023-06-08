CREATE TABLE [dbo].[Employee]
(
	[ID] BIGINT NOT NULL PRIMARY KEY, 
    [EmpNo] NVARCHAR(6) NOT NULL UNIQUE, 
    [FirstName] NVARCHAR(15) NOT NULL, 
    [LastName] NVARCHAR(15) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [ContactNo] NUMERIC(11) NOT NULL, 
    [EmailAddress] NVARCHAR(100) NOT NULL,
)
