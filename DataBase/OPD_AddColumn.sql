 
  
		IF EXISTS ( SELECT 1 FROM sys.tables tbl
		INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
		WHERE tbl.name= 'OPD' and col.name='RsCVS')
		BEGIN  
				ALTER TABLE OPD
				DROP COLUMN RsCVS   
		END

		IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
		INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
		WHERE tbl.name= 'OPD' and col.name='CVS')
		BEGIN  
				ALTER TABLE OPD
				ADD   CVS VARCHAR(50)   
		END

		IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
		INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
		WHERE tbl.name= 'OPD' and col.name='Rs')
		BEGIN  
				ALTER TABLE OPD
				ADD  Rs VARCHAR(50)  
		END

		IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
		INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
		WHERE tbl.name= 'OPD' and col.name='OtherGeneralFindings')
		BEGIN  
				ALTER TABLE OPD
				ADD  OtherGeneralFindings VARCHAR(250)  
		END
  
		IF NOT EXISTS ( SELECT 1 FROM sys.tables tbl
		INNER JOIN sys.columns col ON tbl.object_id = col.object_id 
		WHERE tbl.name= 'OPD' and col.name='BMI')
		BEGIN  
				ALTER TABLE OPD
				ADD  BMI VARCHAR(50)  
		END
 