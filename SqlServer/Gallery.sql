USE [Cedar]
GO

/****** Object:  Table [dbo].[Gallery]    Script Date: 10/26/2011 13:31:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Gallery](
	[GalleryId] [uniqueidentifier] NOT NULL,
	[CaptureDate] [datetime] NULL,
	[Code] [bigint] NULL,
	[Contents] [nvarchar](255) NULL,
	[PublishDate] [datetime] NULL,
	[Published] [bit] NULL,
	[AppearInHomePage] [bit] NULL,
	[Title] [nvarchar](255) NULL,
	[CreatorUser_Username] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[GalleryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


