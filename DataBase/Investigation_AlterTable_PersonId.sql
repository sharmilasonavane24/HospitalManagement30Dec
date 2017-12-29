

IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
WHERE tbl.name= 'Investigations' and col.name='PersonId')
BEGIN
		ALTER TABLE [Investigations]
		ADD PersonId INT DEFAULT(0) NOT NULL
		 

		ALTER TABLE  [dbo].[Investigations]  WITH CHECK ADD  CONSTRAINT [FK_Investigations_PersonId] FOREIGN KEY([PersonId])
		REFERENCES [dbo].[Person] ([PersonId])
		ON UPDATE CASCADE
		ON DELETE CASCADE
END;