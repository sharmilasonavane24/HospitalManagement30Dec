


IF NOT EXISTS (select 1 from sys.tables where name = 'Investigations' ) 
BEGIN
/****** Object:  Table [dbo].[Investigations]    Script Date: 12/29/2017 10:54:01 AM ******/
CREATE TABLE [dbo].[Investigations](
	[InvestigationId] [int] IDENTITY(1,1) NOT NULL,
	[OpdId] [int] NOT NULL,
	[BloodGroup] [varchar](10) NULL,
	[HB] [varchar](50) NULL,
	[RBS] [varchar](50) NULL,
	[HIV&II] [varchar](50) NULL,
	[HBSAvg] [varchar](50) NULL,
	[VDRL] [varchar](50) NULL,
	[UrineRM] [varchar](250) NULL,
	[Sr.Creat] [varchar](50) NULL,
	[Sr.Urea] [varchar](50) NULL,
	[Sr.TSH] [varchar](50) NULL,
	[HSG] [varchar](250) NULL,
	[SemenAnalysis] [varchar](250) NULL,
	[USG] [varchar](50) NULL,
	[Other] [varchar](250) NULL,
	[AllAttachmentinOnePDF] [varbinary](max) NULL,
 CONSTRAINT [PK_Investigations] PRIMARY KEY CLUSTERED 
(
	[InvestigationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[Investigations]  WITH NOCHECK ADD  CONSTRAINT [FK_Investigations_OPD] FOREIGN KEY([OpdId])
REFERENCES [dbo].[OPD] ([OPDId])
ON UPDATE CASCADE
ON DELETE CASCADE
NOT FOR REPLICATION 


ALTER TABLE [dbo].[Investigations] NOCHECK CONSTRAINT [FK_Investigations_OPD]

END