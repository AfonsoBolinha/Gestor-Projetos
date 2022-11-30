USE [TrabalhoBD]
GO

/****** Object:  Table [dbo].[AreaCientifica]    Script Date: 30/11/2022 14:28:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AreaCientifica](
	[Area] [nvarchar](50) NOT NULL,
	[ID_Projeto] [int] NOT NULL
) ON [PRIMARY]
GO

