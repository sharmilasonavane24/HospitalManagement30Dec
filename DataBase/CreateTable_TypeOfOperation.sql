USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[TypeOfIntakeAdv]    Script Date: 1/10/2018 1:05:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TypeOfOperation](
	[TypeOfOperationId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
 CONSTRAINT [PK_TypeOfOperation] PRIMARY KEY CLUSTERED 
(
	[TypeOfOperationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Normal Delivery')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Forecops assisted delivery')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Ventouse Assisted delivery')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Sequential Assorted delivery')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('LSCS')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Abdominal Hysterectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Vaginal Hysterectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Anterior colporrhaphy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Posterior colpoperineorrhaphy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Vaginal Hysterectomy and anterior colporrhaphy and posterior colpoperineorrhaphy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Appendectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Total laparoscopic hysterectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Laparoscopic myomectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Laparoscopic cystectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Diagnostic hysterolaparoscopy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Laparoscopic tubal occlusion')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Laparoscopic tubal occlusion')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Laparoscopic salpingectomy')
INSERT INTO [dbo].[TypeOfOperation]  (TypeName) VALUES ('Other')

