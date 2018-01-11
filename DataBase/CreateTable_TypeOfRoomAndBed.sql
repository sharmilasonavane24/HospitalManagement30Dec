USE [HospitalManagment]
GO

/****** Object:  Table [dbo].[[TypeOfRoomAndBed]]    Script Date: 1/10/2018 1:05:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TypeOfRoomAndBed](
	[TypeOfRoomAndBedId] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](100) NULL,
		[BedNumber] [smallint] NULL,

 CONSTRAINT [PK_TypeOfRoomAndBed] PRIMARY KEY CLUSTERED 
(
	[TypeOfRoomAndBedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('General',1)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('General',2)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('General',3)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('General',4)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('General',5)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('SemiSpecial',6)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('SemiSpecial',7)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('Special',8)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('Special',9)

INSERT INTO [dbo].[TypeOfRoomAndBed]  (RoomName,BedNumber) VALUES ('Special',10)


