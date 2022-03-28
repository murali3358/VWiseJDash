IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[CASEMST]')) 
   ALTER TABLE [dbo].[CASEMST] 
   DISABLE  CHANGE_TRACKING
GO
