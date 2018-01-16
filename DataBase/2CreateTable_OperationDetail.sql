USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[OperationDetail]    Script Date: 1/16/2018 10:11:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OperationDetail](
	[OperationDetailId] [int] IDENTITY(1,1) NOT NULL,
	[IPDId] [int] NULL,
	[OperationDate] [date] NULL,
	[TypeOfOperationId] [int] NULL,
	[OpeationNote] [nvarchar](max) NULL,
	[PostOpDirection] [nvarchar](max) NULL,
 CONSTRAINT [PK_OperationDetail] PRIMARY KEY CLUSTERED 
(
	[OperationDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[OperationDetail]  WITH CHECK ADD  CONSTRAINT [FK_OperationDetail_IPD] FOREIGN KEY([IPDId])
REFERENCES [dbo].[IPD] ([IPDId])
GO

ALTER TABLE [dbo].[OperationDetail] CHECK CONSTRAINT [FK_OperationDetail_IPD]
GO

ALTER TABLE [dbo].[OperationDetail]  WITH CHECK ADD  CONSTRAINT [FK_OperationDetail_TypeOfOperation] FOREIGN KEY([TypeOfOperationId])
REFERENCES [dbo].[TypeOfOperation] ([TypeOfOperationId])
GO

ALTER TABLE [dbo].[OperationDetail] CHECK CONSTRAINT [FK_OperationDetail_TypeOfOperation]
GO


