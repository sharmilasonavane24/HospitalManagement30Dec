USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[ConservativeDetail]    Script Date: 1/16/2018 10:14:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConservativeDetail](
	[ConservativeDetailId] [int] IDENTITY(1,1) NOT NULL,
	[IPDId] [int] NULL,
	[CreationDate] [date] NULL,
	[DayNumber] [int] NULL,
 CONSTRAINT [PK_ConservativeDetail] PRIMARY KEY CLUSTERED 
(
	[ConservativeDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ConservativeDetail]  WITH CHECK ADD  CONSTRAINT [FK_ConservativeDetail_IPD] FOREIGN KEY([IPDId])
REFERENCES [dbo].[IPD] ([IPDId])
GO

ALTER TABLE [dbo].[ConservativeDetail] CHECK CONSTRAINT [FK_ConservativeDetail_IPD]
GO


