USE [nfx]
GO

/*------------------------------------------------------------------------------------
Purpose: When handling messages being sent to multiple recipients, instead of having duplicate 
messages in the CustomerFiles table for each recipient, we use a more normalized approach 
by adding another table that holds the recipient's id and a reference to the CustomerFiles2 
table that contains the message.

Steps: 
Add column [MessageType] to [Notifications].[CustomerFiles2] table that will specify mulitple or 
single messages.

Add Table [Notifications].[MessageRecipients] to hold recipients of multiple messages.

Created Date: 06/13/2014
Created by Craig Taylor
------------------------------------------------------------------------------------*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DECLARE @ErrorMsg varchar(400), @ErrorSeverity int, @ErrorState	int

BEGIN TRY 
	PRINT 'Adding column [MessageType] to [Notifications].[CustomerFiles2] table'
	IF NOT EXISTS(SELECT * FROM sys.columns 
			WHERE [name] = N'MessageType' AND [object_id] = OBJECT_ID(N'[Notifications].[CustomerFiles2]'))
	BEGIN
		ALTER TABLE [Notifications].[CustomerFiles2]
		ADD [MessageType] [tinyint] NULL; 
	END
END TRY
BEGIN CATCH 	
	SELECT @ErrorMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR(@ErrorMsg, @ErrorSeverity, @ErrorState) 
	PRINT 'ERROR ***** Adding column [MessageType] to [Notifications].[CustomerFiles2] table'
	ROLLBACK 
END CATCH

BEGIN TRY 
	PRINT 'Creating [Notifications].[MessageRecipients] table'
	
	BEGIN TRANSACTION
		
		IF OBJECT_ID('[Notifications].[MessageRecipients]', 'U') IS NOT NULL
			DROP TABLE [Notifications].[MessageRecipients];

		CREATE TABLE [Notifications].[MessageRecipients](
			[Id] [bigint] IDENTITY(1,1) NOT NULL,
			[AccountId] [bigint] NOT NULL,
			[Recipient] [int] NOT NULL,
			[MessageId] [bigint] NOT NULL,
			[IsDeleted] [bit] NOT NULL,
			[IsUserReadNotification] [bit] NOT NULL,
		 CONSTRAINT [PK_Notification_MessageRecipients] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [Notifications].[MessageRecipients] ADD CONSTRAINT FK_Notifications_MessageRecipients_AccountId 
		FOREIGN KEY ([AccountId]) REFERENCES [Accounts].[CustomerAccounts]([AccountId])
		
		ALTER TABLE [Notifications].[MessageRecipients] ADD CONSTRAINT FK_Notifications_MessageRecipients_MessageId 
		FOREIGN KEY ([MessageId]) REFERENCES [Notifications].[CustomerFiles2]([MessageId])
		
		ALTER TABLE [Notifications].[MessageRecipients] ADD  CONSTRAINT [DF_Notifications_MessageRecipients_IsDeleted]  
		DEFAULT ((0)) FOR [IsDeleted]
		
		ALTER TABLE [Notifications].[MessageRecipients] ADD  CONSTRAINT [DF_Notifications_MessageRecipients_IsUserReadNotification]  
		DEFAULT ((0)) FOR [IsUserReadNotification]

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Row identifier.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'Id'

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Users Accound ID.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'AccountId'

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Users Recipient ID.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'Recipient'

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Identifier of the message in the CustomerFiles2 table.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'MessageId'

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Indicates if this record has been deleted.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'IsDeleted'

		EXEC sys.sp_addextendedproperty 
		@name=N'MS_Description', @value=N'Indicates if user has read this notification.' , 
		@level0type=N'SCHEMA',@level0name=N'Notifications', 
		@level1type=N'TABLE',@level1name=N'MessageRecipients', 
		@level2type=N'COLUMN', @level2name=N'IsUserReadNotification'
	COMMIT
END TRY
BEGIN CATCH 	
	SELECT @ErrorMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR(@ErrorMsg, @ErrorSeverity, @ErrorState) 
	PRINT 'ERROR ***** creating [Notifications].[MessageRecipients] table'
	ROLLBACK 
END CATCH

