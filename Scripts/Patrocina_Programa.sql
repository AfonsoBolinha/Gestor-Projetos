USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Patrocina_Programa]    Script Date: 30/11/2022 14:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patrocina_Programa](
	[ID_Programa_Patrocinador] [int] NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Montante] [int] NOT NULL
) ON [PRIMARY]
GO

