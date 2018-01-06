

IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
WHERE tbl.name= 'Prescription' and col.name='TypeOfIntakeAdvId')
BEGIN
		ALTER TABLE  [dbo].[Prescription]
		ADD TypeOfIntakeAdvId INT DEFAULT(1) NOT NULL
		 

		ALTER TABLE  [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_TypeOfIntakeAdvId] FOREIGN KEY([TypeOfIntakeAdvId])
		REFERENCES [dbo].[TypeOfIntakeAdv] ([TypeOfIntakeAdvId])
		ON UPDATE CASCADE
		ON DELETE CASCADE
END;