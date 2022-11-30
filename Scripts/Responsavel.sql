USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Responsavel]    Script Date: 30/11/2022 14:30:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Responsavel](
	[ID_Investigador] [int] NOT NULL,
	[ID_Projeto] [int] NOT NULL,
	[Tempo_Responsavel] [int] NOT NULL
) ON [PRIMARY]
GO

