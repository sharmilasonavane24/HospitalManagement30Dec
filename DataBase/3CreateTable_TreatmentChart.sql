USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[TreatmentChart]    Script Date: 1/16/2018 10:13:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TreatmentChart](
	[TreatmentChartId] [int] IDENTITY(1,1) NOT NULL,
	[OpeationDetailId] [int] NULL,
	[CreationDate] [date] NULL,
	[DayNumber] [int] NULL,
	[MedcineNamesId] [int] NULL,
 CONSTRAINT [PK_TreatmentChart] PRIMARY KEY CLUSTERED 
(
	[TreatmentChartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TreatmentChart]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentChart_OperationDetail] FOREIGN KEY([OpeationDetailId])
REFERENCES [dbo].[OperationDetail] ([OperationDetailId])
GO

ALTER TABLE [dbo].[TreatmentChart] CHECK CONSTRAINT [FK_TreatmentChart_OperationDetail]
GO


