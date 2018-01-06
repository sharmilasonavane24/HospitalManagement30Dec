IF EXISTS ( SELECT 1 FROM sys.tables  WHERE  name= 'testException' )
		BEGIN  

		DROP TABLE  [dbo].[testException]
		 END;