USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[MonitoringChat]    Script Date: 1/11/2018 9:51:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MonitoringChart](
	[MonitoringChartId] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDateTime] [date] NOT NULL,
	[BP] [varchar](10) NULL,
	[Pulse] [int] NULL, 
	[RsNCVS] [varchar](50) NULL,
	[PA] [varchar](50) NULL,
	[PV] [varchar](50) NULL,
	[Input] [varchar](500) NULL,
	[Output] [varchar](500) NULL,
 CONSTRAINT [PK_MonitoringChart] PRIMARY KEY CLUSTERED 
(
	[MonitoringChartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


