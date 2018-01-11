IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
WHERE tbl.name= 'MedcineNames' and col.name='IsDeleted')
BEGIN
		ALTER TABLE [MedcineNames]
		ADD IsDeleted BIT DEFAULT(0) NOT NULL	 
		 
		
END;
 

 GO


 IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
WHERE tbl.name= 'MedcineNames' and col.name='DeletedDateTime')
BEGIN
		ALTER TABLE [MedcineNames]		 
		Add DeletedDateTime DateTime

		
END;
 