
IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
WHERE tbl.name= 'Investigations' and col.name='CreatedDateTime')
BEGIN
		ALTER TABLE [Investigations]
		ADD CreatedDateTime DATE DEFAULT(Getdate()) NOT NULL
		 
END;