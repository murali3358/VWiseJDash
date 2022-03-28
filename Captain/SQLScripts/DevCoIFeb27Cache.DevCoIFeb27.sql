IF NOT EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'DevCoIFeb27')) 
   ALTER DATABASE [DevCoIFeb27] 
   SET  CHANGE_TRACKING = ON
GO
