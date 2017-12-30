USE [HospitalManagment]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[EmailId]
           ,[PhoneNumber]
           ,[UserType]
           ,[IsActive]
           ,[Password]
           ,[CreatedDate])
     VALUES
           ('Mahesh','Shinde','doc.mahesh.1983@gmail.com',
		   '7911234567','Docter','1','khushi','2017-12-20 11:47:26.293')
GO


