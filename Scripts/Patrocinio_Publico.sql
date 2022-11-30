USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[PatrocinioPublico]    Script Date: 30/11/2022 14:29:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatrocinioPublico](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sigla] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Tel] [int] NOT NULL,
	[Morada] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](50) NOT NULL,
	[Pais] [nvarchar](50) NOT NULL,
	[Designacao] [nvarchar](50) NULL,
 CONSTRAINT [PK_PatrocinioPublico] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

