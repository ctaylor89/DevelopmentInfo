USE AFEX_DW;
GO 

/*
drop table FeeAssumedCostMap

select * from sys.objects 
where type = 'U' and name = 'FeeAssumedCostMap'
*/


------------------------------------------------------------------ FeeAssumedCostMap
DECLARE @ErrorMsg varchar(400), @ErrorSeverity int, @ErrorState	int

BEGIN TRY 
	PRINT 'Creating dbo.FeeAssumedCostMap table'
	
	BEGIN TRANSACTION

		CREATE TABLE dbo.FeeAssumedCostMap (
			  FeeAssumedCostMapID		 bigint			 NOT NULL	IDENTITY(1,1)
			, FeeID						 int			 NOT NULL 	  
			, AssumedCostMatrixID		 int			 NULL 
			, CreateDate				 datetime		 NOT NULL	CONSTRAINT DF_FeeAssumedCostMap_CreateDate DEFAULT(GETDATE())
			, CreatedBy					 varchar(50)	 NOT NULL	CONSTRAINT DF_FeeAssumedCostMap_Createdby DEFAULT(SUSER_SNAME())
		) ON [PRIMARY]

		ALTER TABLE dbo.FeeAssumedCostMap
		   ADD CONSTRAINT PKFeeAssumedCostMap PRIMARY KEY CLUSTERED (FeeAssumedCostMapID) 
	   ON [PRIMARY]

		CREATE UNIQUE INDEX IX_FeeAssumedCostMap_FeeID_AssumedCostMatrixID ON dbo.FeeAssumedCostMap(FeeID, AssumedCostMatrixID)
		WITH (FILLFACTOR = 80); 

		PRINT 'dbo.FeeAssumedCostMap table creation successful' 
	COMMIT
END TRY

BEGIN CATCH 	
	SELECT @ErrorMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR(@ErrorMsg, @ErrorSeverity, @ErrorState) 
	PRINT 'ERROR ***** creating dbo.FeeAssumedCostMap table'
	ROLLBACK 
END CATCH

GO

