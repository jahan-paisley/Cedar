USE [Cedar]
GO

/****** Object:  Table [dbo].[AttachmentToGallery]    Script Date: 10/26/2011 13:31:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AttachmentToGallery](
	[Gallery_id] [uniqueidentifier] NOT NULL,
	[Attachment_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AttachmentToGallery]  WITH CHECK ADD  CONSTRAINT [FKDDB3857D34E091A7] FOREIGN KEY([Attachment_id])
REFERENCES [dbo].[Attachment] ([AttachmentId])
GO

ALTER TABLE [dbo].[AttachmentToGallery] CHECK CONSTRAINT [FKDDB3857D34E091A7]
GO

ALTER TABLE [dbo].[AttachmentToGallery]  WITH CHECK ADD  CONSTRAINT [FKDDB3857D9E4BB589] FOREIGN KEY([Gallery_id])
REFERENCES [dbo].[Gallery] ([GalleryId])
GO

ALTER TABLE [dbo].[AttachmentToGallery] CHECK CONSTRAINT [FKDDB3857D9E4BB589]
GO


