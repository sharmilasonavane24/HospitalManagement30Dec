USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[LabourDetail]    Script Date: 1/16/2018 10:14:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LabourDetail](
	[LabourDetailId] [int] IDENTITY(1,1) NOT NULL,
	[IPDId] [int] NULL,
	[DeliveryDate] [date] NULL,
	[DeliveryNote] [nvarchar](max) NULL,
 CONSTRAINT [PK_LabourDetail] PRIMARY KEY CLUSTERED 
(
	[LabourDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[LabourDetail]  WITH CHECK ADD  CONSTRAINT [FK_LabourDetail_IPD] FOREIGN KEY([IPDId])
REFERENCES [dbo].[IPD] ([IPDId])
GO

ALTER TABLE [dbo].[LabourDetail] CHECK CONSTRAINT [FK_LabourDetail_IPD]
GO


