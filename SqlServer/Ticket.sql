USE [Cedar]
GO

/****** Object:  Table [dbo].[Ticket]    Script Date: 04/22/2012 11:00:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ticket](
	[TicketId] [uniqueidentifier] NOT NULL,
	[MSISDN] [nvarchar](255) NULL,
	[FollowupCode] [nvarchar](255) NULL,
	[ApplicationDate] [datetime] NULL,
	[IssueType] [int] NULL,
	[SimType] [int] NULL,
	[IssueDesc] [nvarchar](255) NULL,
	[IssueStatus] [int] NULL,
	[UserId] [uniqueidentifier] NULL,
	[FollowupCode2] [nvarchar](255) NULL,
	[SequenceNum] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_aspnet_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO

ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_aspnet_Users]
GO


