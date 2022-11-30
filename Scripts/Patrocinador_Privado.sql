USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Patrocinador_Privado]    Script Date: 30/11/2022 14:29:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patrocinador_Privado](
	[ID_Patrocinador] [int] NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Montante] [int] NOT NULL
) ON [PRIMARY]
GO

