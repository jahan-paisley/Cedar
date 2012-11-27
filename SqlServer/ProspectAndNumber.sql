USE [Cedar]
GO

/****** Object:  Table [dbo].[Prospect]    Script Date: 11/09/2011 12:10:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prospect](
	[ProspectId] [uniqueidentifier] NOT NULL,
	[NationalNo] [bigint] NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstNameInEnglish] [nvarchar](255) NULL,
	[LastNameInEnglish] [nvarchar](255) NULL,
	[IdentityNo] [nvarchar](255) NULL,
	[Gender] [int] NULL,
	[MobileNo] [nvarchar](255) NULL,
	[EMail] [nvarchar](255) NULL,
	[RegistrationDate] [datetime] NULL,
	[PreferredModeOfCommunication] [int] NULL,
	[PreferredPickPointSimCard] [int] NULL,
	[FollowupCode] [nvarchar](255) NULL,
	[Address_Province] [nvarchar](255) NULL,
	[Address_City] [nvarchar](255) NULL,
	[Address_Ave] [nvarchar](255) NULL,
	[Address_Description] [nvarchar](255) NULL,
	[Address_BuildingNo] [nvarchar](255) NULL,
	[Address_Tel] [nvarchar](255) NULL,
	[Address_TelCode] [nvarchar](255) NULL,
	[Address_PostalCode] [nvarchar](255) NULL,
	[Address_Fax] [nvarchar](255) NULL,
	[Address_Unit] [nvarchar](255) NULL,
 CONSTRAINT [PK__Prospect__95CA0CE463A3C44B] PRIMARY KEY CLUSTERED 
(
	[ProspectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Prospect__E9AA1A65668030F6] UNIQUE NONCLUSTERED 
(
	[NationalNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Cedar]
GO

/****** Object:  Table [dbo].[Number]    Script Date: 11/09/2011 12:10:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Number](
	[NumberId] [uniqueidentifier] NOT NULL,
	[MSISDN] [nvarchar](255) NULL,
	[LastSaveUpdateDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[State] [int] NULL,
	[Prospect_ProspectId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__Number__0BED0EBB6A50C1DA] PRIMARY KEY CLUSTERED 
(
	[NumberId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Number]  WITH CHECK ADD  CONSTRAINT [FK800F63032F0F6A0D] FOREIGN KEY([Prospect_ProspectId])
REFERENCES [dbo].[Prospect] ([ProspectId])
GO

ALTER TABLE [dbo].[Number] CHECK CONSTRAINT [FK800F63032F0F6A0D]
GO


