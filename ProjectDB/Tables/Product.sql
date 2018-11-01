CREATE TABLE [dbo].[Product]
(
	[product_id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[name] NVARCHAR(128) NOT NULL, 
    [price] DECIMAL(18, 2) NOT NULL,

)
