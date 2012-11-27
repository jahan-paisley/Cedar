USE [Cedar2]
GO

/****** Object:  Table [dbo].[TenderApplication]    Script Date: 05/05/2012 17:36:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TenderApplication](
	[TenderApplicationId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[RegistrationNo] [nvarchar](255) NULL,
	[EconomicCode] [nvarchar](255) NULL,
	[ActivityDomain] [nvarchar](255) NULL,
	[FollowupCode] [nvarchar](255) NULL,
	[RasmiDoc_AttachmentId] [uniqueidentifier] NULL,
	[TaxPayersRegistrationDoc_AttachmentId] [uniqueidentifier] NULL,
	[SHCIRatingDoc_AttachmentId] [uniqueidentifier] NULL,
	[ISO9001Doc_AttachmentId] [uniqueidentifier] NULL,
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
PRIMARY KEY CLUSTERED 
(
	[TenderApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TenderApplication]  WITH CHECK ADD  CONSTRAINT [FK2D16C6CE5BA8EB3D] FOREIGN KEY([TaxPayersRegistrationDoc_AttachmentId])
REFERENCES [dbo].[Attachment] ([AttachmentId])
GO

ALTER TABLE [dbo].[TenderApplication] CHECK CONSTRAINT [FK2D16C6CE5BA8EB3D]
GO

ALTER TABLE [dbo].[TenderApplication]  WITH CHECK ADD  CONSTRAINT [FK2D16C6CE7EEDD661] FOREIGN KEY([SHCIRatingDoc_AttachmentId])
REFERENCES [dbo].[Attachment] ([AttachmentId])
GO

ALTER TABLE [dbo].[TenderApplication] CHECK CONSTRAINT [FK2D16C6CE7EEDD661]
GO

ALTER TABLE [dbo].[TenderApplication]  WITH CHECK ADD  CONSTRAINT [FK2D16C6CEBE0E1EBF] FOREIGN KEY([ISO9001Doc_AttachmentId])
REFERENCES [dbo].[Attachment] ([AttachmentId])
GO

ALTER TABLE [dbo].[TenderApplication] CHECK CONSTRAINT [FK2D16C6CEBE0E1EBF]
GO

ALTER TABLE [dbo].[TenderApplication]  WITH CHECK ADD  CONSTRAINT [FK2D16C6CEF2CAD95] FOREIGN KEY([RasmiDoc_AttachmentId])
REFERENCES [dbo].[Attachment] ([AttachmentId])
GO

ALTER TABLE [dbo].[TenderApplication] CHECK CONSTRAINT [FK2D16C6CEF2CAD95]
GO


