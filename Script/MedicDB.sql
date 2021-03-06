USE [MedicDB]
GO
/****** Object:  Table [dbo].[Circle]    Script Date: 22/04/2017 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Circle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CircleName] [varchar](50) NULL,
	[CircleDescription] [varchar](500) NULL,
 CONSTRAINT [PK_Circle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 22/04/2017 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](50) NULL,
	[PersonalEMail] [varchar](100) NULL,
	[PersonalPhone] [varchar](50) NULL,
	[PersonalMobile] [varchar](50) NULL,
	[BusinessPhone] [varchar](50) NULL,
	[BusinessMobile] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmergencyContact]    Script Date: 22/04/2017 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencyContact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[ContactID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 22/04/2017 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [varchar](1) NULL,
	[ContactID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonCircle]    Script Date: 22/04/2017 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCircle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[CircleID] [int] NULL,
 CONSTRAINT [PK_PersonCircle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK_EmergencyContact_Contact] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[EmergencyContact] CHECK CONSTRAINT [FK_EmergencyContact_Contact]
GO
ALTER TABLE [dbo].[EmergencyContact]  WITH CHECK ADD  CONSTRAINT [FK_EmergencyContact_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[EmergencyContact] CHECK CONSTRAINT [FK_EmergencyContact_Person]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Contact] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Contact]
GO
ALTER TABLE [dbo].[PersonCircle]  WITH CHECK ADD  CONSTRAINT [FK_PersonCircle_Circle] FOREIGN KEY([CircleID])
REFERENCES [dbo].[Circle] ([ID])
GO
ALTER TABLE [dbo].[PersonCircle] CHECK CONSTRAINT [FK_PersonCircle_Circle]
GO
ALTER TABLE [dbo].[PersonCircle]  WITH CHECK ADD  CONSTRAINT [FK_PersonCircle_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonCircle] CHECK CONSTRAINT [FK_PersonCircle_Person]
GO
