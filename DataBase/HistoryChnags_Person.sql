/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [HistoryId]
      ,[Reminder]
      ,[AllergyDetails]
      ,[FirstTTInjection]
      ,[SecondTTInjection]
      ,[LMP]
      ,[EDD]
      ,[EDDCorrectedByUSG]
      ,[PersonId]
      ,[HighRiskFactor]
      ,[ObstetricHistory]
      ,[PositiveFindings]
      ,[Gravidity]
      ,[Parity]
      ,[LivingChildren]
      ,[Abortions]
      ,[Menorch]
      ,[Menopause]
      ,[ChiefComplains]
      ,[CurrentCycles]
  FROM [HospitalManagment].[dbo].[History]




  alter table [History]
  alter column [FirstTTInjection] nvarchar(50)

   alter table [History]
  alter column [SecondTTInjection] nvarchar(50)


 
  
  alter table [Person]
 add FatherOrSpouseProfession nvarchar(100)






