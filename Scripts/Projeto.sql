USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[Projeto]    Script Date: 30/11/2022 14:30:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projeto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Short_Name] [nchar](10) NOT NULL,
	[Descricao] [nvarchar](50) NULL,
	[ID_UC] [int] NOT NULL,
	[Max_Cost] [int] NOT NULL,
	[Total_Cost] [int] NOT NULL,
	[DOI] [nvarchar](50) NOT NULL,
	[State] [nchar](10) NOT NULL,
	[Data_Init] [date] NOT NULL,
	[Data_Fin] [date] NULL,
	[Cientific_Domain] [nvarchar](50) NOT NULL,
	[ID_IR] [int] NOT NULL,
 CONSTRAINT [PK_Projeto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

