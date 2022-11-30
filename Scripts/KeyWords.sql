USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[KeyWords]    Script Date: 30/11/2022 14:28:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KeyWords](
	[PalavraChave] [char](10) NOT NULL,
	[ID_Projeto] [int] NOT NULL
) ON [PRIMARY]
GO

