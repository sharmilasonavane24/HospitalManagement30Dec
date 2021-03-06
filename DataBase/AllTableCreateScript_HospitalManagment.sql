/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2008 (10.0.1600)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [HospitalManagment]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[EmailId] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[StreetName] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Taluka] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[Pincode] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[Reminder] [varchar](500) NULL,
	[AllergyDetails] [varchar](500) NULL,
	[FirstTTInjection] [date] NULL,
	[SecondTTInjection] [date] NULL,
	[LMP] [date] NOT NULL,
	[EDD] [date] NOT NULL,
	[EDDCorrectedByUSG] [date] NOT NULL,
	[PersonId] [int] NULL,
	[HighRiskFactor] [varchar](500) NULL,
	[ObstetricHistory] [varchar](500) NULL,
	[PositiveFindings] [varchar](500) NULL,
	[Gravidity] [int] NULL,
	[Parity] [int] NULL,
	[LivingChildren] [int] NULL,
	[Abortions] [int] NULL,
	[Menorch] [int] NULL,
	[Menopause] [int] NULL,
	[ChiefComplains] [varchar](500) NULL,
	[CurrentCycles] [varchar](500) NULL,
 CONSTRAINT [HistoryId_PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedcineNames]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedcineNames](
	[MedcineNamesId] [int] IDENTITY(0,1) NOT NULL,
	[MedcineName] [varchar](100) NOT NULL,
	[MedicineWeight] [decimal](18, 0) NULL,
	[TypeOfMedicineId] [int] NOT NULL,
 CONSTRAINT [pk_MedcineNamesId] PRIMARY KEY CLUSTERED 
(
	[MedcineNamesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MedicineName_Weight] UNIQUE NONCLUSTERED 
(
	[MedcineName] ASC,
	[MedicineWeight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPD]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPD](
	[OPDId] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[TypeofCheckUp] [int] NOT NULL,
	[NextAppoinmentDate] [date] NULL,
	[Paid] [decimal](18, 0) NULL,
	[Weight] [decimal](18, 0) NOT NULL,
	[BP] [varchar](10) NULL,
	[Pulse] [int] NULL,
	[OPDNumber] [varchar](100) NOT NULL,
	[RsNCVS] [varchar](50) NULL,
	[PA] [varchar](50) NULL,
	[PS] [varchar](50) NULL,
	[PV] [varchar](50) NULL,
	[CNS] [varchar](50) NULL,
	[OPDDate] [datetime] NULL,
 CONSTRAINT [PK_OPD] PRIMARY KEY CLUSTERED 
(
	[OPDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[PaymentDetailsID] [int] IDENTITY(0,1) NOT NULL,
	[ConsultingFee] [decimal](18, 0) NOT NULL,
	[DeliveryFee] [decimal](18, 0) NOT NULL,
	[RoomChargesPerDay] [decimal](18, 0) NOT NULL,
	[VaccineFee] [decimal](18, 0) NOT NULL,
	[ECGFee] [decimal](18, 0) NOT NULL,
	[MedicineCost] [decimal](18, 0) NOT NULL,
	[MedicalTest] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PaymentDetails_PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[PaymentDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Height] [nvarchar](10) NULL,
	[RegisterDate]  AS (getdate()),
	[AdharCardNumber] [numeric](18, 0) NULL,
	[Profession] [nvarchar](50) NULL,
	[Age] [decimal](18, 0) NOT NULL,
	[Religion] [varchar](50) NULL,
	[ReferredBy] [varchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonDetails]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonDetails](
	[PersonDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[ContactID] [int] NOT NULL,
	[PersonTypeID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[SpouseID] [int] NOT NULL,
	[ChildIDs] [nvarchar](50) NULL,
 CONSTRAINT [FK_CotactID] PRIMARY KEY CLUSTERED 
(
	[PersonDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonTypes]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonTypes](
	[PersonTypeId] [int] IDENTITY(1,1) NOT NULL,
	[NameOfType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PersonTypes] PRIMARY KEY CLUSTERED 
(
	[PersonTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[PrescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[OpdID] [int] NOT NULL,
	[Dosage] [varchar](250) NOT NULL,
	[Quantity] [varchar](250) NOT NULL,
	[NumberOfDays] [int] NOT NULL,
	[comments] [varchar](200) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[MedcineNamesId] [int] NOT NULL,
	[NextAppoinmentDate] [datetime] NULL,
 CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[testException]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[testException](
	[opdid] [int] IDENTITY(1,1) NOT NULL,
	[opddate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeofCheckUp]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeofCheckUp](
	[TypeofCheckUpId] [int] IDENTITY(1,1) NOT NULL,
	[CheckupName] [varchar](150) NULL,
 CONSTRAINT [PK_TypeofCheckUp] PRIMARY KEY CLUSTERED 
(
	[TypeofCheckUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfMedcine]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfMedcine](
	[TypeOfMedicineId] [int] IDENTITY(0,1) NOT NULL,
	[TypeName] [varchar](100) NOT NULL,
 CONSTRAINT [pk_TypeOfMedicineId] PRIMARY KEY CLUSTERED 
(
	[TypeOfMedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_TypeOfMedcine] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/3/2017 10:30:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UsersID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[UserType] [varchar](20) NOT NULL,
	[IsActive] [bit] NULL,
	[Password] [varchar](10) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Users_ID] PRIMARY KEY CLUSTERED 
(
	[UsersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OPD] ADD  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[OPD] ADD  DEFAULT ('0') FOR [OPDNumber]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [ConsultingFee]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [DeliveryFee]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [RoomChargesPerDay]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [VaccineFee]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [ECGFee]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [MedicineCost]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ((0)) FOR [MedicalTest]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_Age]  DEFAULT ((0)) FOR [Age]
GO
ALTER TABLE [dbo].[Prescription] ADD  DEFAULT ((3)) FOR [NumberOfDays]
GO
ALTER TABLE [dbo].[Prescription] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [PersonID_FK] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [PersonID_FK]
GO
ALTER TABLE [dbo].[MedcineNames]  WITH CHECK ADD  CONSTRAINT [FK_TypeOfMedicine] FOREIGN KEY([TypeOfMedicineId])
REFERENCES [dbo].[TypeOfMedcine] ([TypeOfMedicineId])
GO
ALTER TABLE [dbo].[MedcineNames] CHECK CONSTRAINT [FK_TypeOfMedicine]
GO
ALTER TABLE [dbo].[OPD]  WITH CHECK ADD  CONSTRAINT [FK_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[OPD] CHECK CONSTRAINT [FK_Person]
GO
ALTER TABLE [dbo].[OPD]  WITH CHECK ADD  CONSTRAINT [FK_TypeofCheckUp] FOREIGN KEY([TypeofCheckUp])
REFERENCES [dbo].[TypeofCheckUp] ([TypeofCheckUpId])
GO
ALTER TABLE [dbo].[OPD] CHECK CONSTRAINT [FK_TypeofCheckUp]
GO
ALTER TABLE [dbo].[PersonDetails]  WITH CHECK ADD  CONSTRAINT [FK_Cotact_1_ContactID] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ContactId])
GO
ALTER TABLE [dbo].[PersonDetails] CHECK CONSTRAINT [FK_Cotact_1_ContactID]
GO
ALTER TABLE [dbo].[PersonDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonDetails_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonDetails] CHECK CONSTRAINT [FK_PersonDetails_Person]
GO
ALTER TABLE [dbo].[PersonDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonDetails_PersonTypes] FOREIGN KEY([PersonTypeID])
REFERENCES [dbo].[PersonTypes] ([PersonTypeId])
GO
ALTER TABLE [dbo].[PersonDetails] CHECK CONSTRAINT [FK_PersonDetails_PersonTypes]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_NameOfMedicine] FOREIGN KEY([MedcineNamesId])
REFERENCES [dbo].[MedcineNames] ([MedcineNamesId])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_NameOfMedicine]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_OPD] FOREIGN KEY([OpdID])
REFERENCES [dbo].[OPD] ([OPDId])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_OPD]
GO


USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[TypeOfIntakeAdv]    Script Date: 1/6/2018 4:14:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TypeOfIntakeAdv](
	[TypeOfIntakeAdvId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypeOfIntakeAdv] PRIMARY KEY CLUSTERED 
(
	[TypeOfIntakeAdvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
-- Add Default values 

 alter table [dbo].[Prescription] add  ManagementPlan varchar(250)
 

insert into [PersonTypes](NameOfType) values ('Patient')
insert into [PersonTypes](NameOfType) values ('Docter')

insert into [TypeOfMedcine](TypeName) values ('Injection')

 insert into [TypeOfMedcine](TypeName) values ('Capsule')
 insert into [TypeOfMedcine](TypeName) values ('Tablet')
 insert into [TypeOfMedcine](TypeName) values ('Ointment')
 insert into [TypeOfMedcine](TypeName) values ('Syrup')
  insert into [TypeOfMedcine](TypeName) values ('Sachet')

insert into [TypeOfMedcine](TypeName) values ('Creame')
insert into [TypeOfMedcine](TypeName) values ('Other')

insert into [dbo].[TypeofCheckUp] (CheckupName) values ('General')
insert into [dbo].[TypeofCheckUp] (CheckupName) values ('Obstetric')
insert into [dbo].[TypeofCheckUp] (CheckupName) values ('Gynaec')

INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('After Food')
INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('Before Food')
INSERT INTO [dbo].[TypeOfIntakeAdv] (TypeName) VALUES ('Before BedTime')
INSERT INTO [dbo].[TypeOfIntakeAdv] (TypeName) VALUES ('In The Morning After Get Up')
INSERT INTO [dbo].[TypeOfIntakeAdv] (TypeName) VALUES ('Not Applicable')

INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('2Tfs Thirce A Day With Glass Of Water')

INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('One Sachet Twice A Day With Glass Of Water')

INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('One Sachet Once A Week With Glass Of Milk Or Water')

INSERT INTO [dbo].[TypeOfIntakeAdv]  (TypeName) VALUES ('One Tablet Once A Week')