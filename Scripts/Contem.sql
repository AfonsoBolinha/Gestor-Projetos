USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Contem]    Script Date: 30/11/2022 14:28:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contem](
	[ID_Projeto] [int] NOT NULL,
	[ID_Investigador] [int] NOT NULL,
	[Papel] [nvarchar](50) NOT NULL,
	[Tempo_Gasto] [int] NOT NULL,
	[Tempo_Limite] [int] NOT NULL
) ON [PRIMARY]
GO

