------------------------------------
     --Get Template
------------------------------------
IF OBJECT_ID('dbo.Get', 'P') IS NOT NULL
	DROP PROC dbo.Get;
GO

CREATE PROCEDURE dbo.Get
@Key uniqueidentifier
AS
BEGIN	
	SET NOCOUNT ON;
	SELECT 
	FROM dbo. WITH (NOLOCK)
	WHERE Key = @Key;
END;
GO
------------------------------------
     --Save Template
------------------------------------
IF OBJECT_ID('dbo.Save', 'P') IS NOT NULL
	DROP PROC dbo.Save;
GO

CREATE PROCEDURE dbo.Save
@
AS
BEGIN	
	DECLARE @SearchKeyCount int;
	SELECT @SearchKeyCount = COUNT(Key) FROM dbo. WHERE Key = @Key;

	IF(@SearchKeyCount = 0)
	BEGIN
		INSERT INTO dbo.
		(
			
		)
		Values
		(
			@
		);	
	END
	ELSE
		UPDATE dbo. SET 
			
			
		WHERE Key = @Key	
END
GO

