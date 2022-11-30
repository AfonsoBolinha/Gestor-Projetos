USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Investigador]    Script Date: 30/11/2022 14:28:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Investigador](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Num_Funcionario] [int] NOT NULL,
	[ORCID] [nvarchar](50) NOT NULL,
	[ID_Instituicao] [int] NOT NULL,
	[Tempo_Total] [int] NULL,
 CONSTRAINT [PK_Investigadors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

