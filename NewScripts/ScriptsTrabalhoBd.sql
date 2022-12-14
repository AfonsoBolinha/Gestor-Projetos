/*------------------CREATE DB------------------*/
USE master
Go
IF NOT EXISTS(
	SELECT *
	FROM [dbo].[sysdatabases]
	WHERE name ='TrabalhoBd'
)
CREATE DATABASE TrabalhoBd
GO

/*------------------CREATE TABLES------------------*/

USE TrabalhoBd

/*--Tablela Instituição--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Instituição]') 
)
BEGIN

	CREATE TABLE Instituição(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		Morada nvarchar(40),
		Email nvarchar(40),
		Tel int,

		CONSTRAINT PK_ID_IV PRIMARY KEY (ID),
	);
END

/*--Tablela Investigador--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Investigador]') 
)
BEGIN
	CREATE TABLE Investigador(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		Num_Funcionario int,
		ORCID nvarchar(40) unique,
		ID_Instituicao int NOT NULL,

		CONSTRAINT PK_ID_IV PRIMARY KEY (ID),
		CONSTRAINT FK_ID_Investigador FOREIGN KEY (ID_Instituicao) REFERENCES Instituição(ID),
	);
END

/*--Tablela Unidade de Investigação--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Unidade_de_Investigação]') 
)
BEGIN
	CREATE TABLE Unidade_de_Investigação(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		ID_Instituicao int NOT NULL,

		CONSTRAINT PK_ID_UC PRIMARY KEY (ID),
		CONSTRAINT FK_ID_Instituicao FOREIGN KEY (ID_Instituicao) REFERENCES Instituição(ID),
	);
END

/*--Tablela Projeto--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Projeto]') 
)
BEGIN
	CREATE TABLE Projeto(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		Short_Name nvarchar(40),
		Descricao nvarchar(100),
		ID_UC int NOT NULL,
		Max_Cost int,
		Total_Cost int,
		DOI nvarchar(40) UNIQUE,
		State_Proj nvarchar(15),
		Data_Init date default GetDate(),
		Data_Fin date default GetDate(),
		Cientific_Domain nvarchar(40),
		ID_IR int NOT NULL,

		CONSTRAINT PK_ID_PROJ PRIMARY KEY (ID),
		CONSTRAINT FK_ID_UC FOREIGN KEY (ID_UC) REFERENCES Unidade_Curricular(ID),
		CONSTRAINT FK_ID_IR FOREIGN KEY (ID_IR) REFERENCES Investigador(ID)
	);
END

/*--Tablela Responsavel--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Responsavel]') 
)
BEGIN
	CREATE TABLE Responsavel(
		ID_Investigador int NOT NULL,
		ID_Projeto int NOT NULL,
		Tempo_Responsavel int,

		CONSTRAINT FK_ID_Responsavel FOREIGN KEY (ID_Investigador) REFERENCES Investigador(ID),
		CONSTRAINT FK_ID_Responsavel2 FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Instituição_proj--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Instituição_proj]') 
)
BEGIN

	CREATE TABLE Instituição_proj(
		ID_proj int NOT NULL,
		ID_inst int NOT NULL,
		percentagem int NOT NULL,

		CONSTRAINT FK_ID_inst_proj FOREIGN KEY (ID_Proj) REFERENCES Projeto(ID),
		CONSTRAINT FK_ID_inst_proj2 FOREIGN KEY (ID_Inst) REFERENCES Instituição(ID),
	);
END

/*--Tablela KeyWords--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[KeyWords]') 
)
BEGIN
	CREATE TABLE KeyWords(
		PalavraChave nvarchar(40),
		ID_Projeto int NOT NULL,

		CONSTRAINT FK_ID_Keyword FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Contem--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Contem]') 
)
BEGIN
	CREATE TABLE Contem(
		ID_Projeto int NOT NULL,
		ID_Investigador int NOT NULL,
		Papel nvarchar(40),
		Tempo_Gasto int,
		Tempo_Limite int,

		CONSTRAINT FK_ID_Contem FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
		CONSTRAINT FK_ID_Contem2 FOREIGN KEY (ID_Investigador) REFERENCES Investigador(ID),
	);
END

/*--Tablela AreaCientifica--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[AreaCientifica]') 
)
BEGIN
	CREATE TABLE AreaCientifica(
		Area nvarchar(40),
		ID_Projeto int NOT NULL,

		CONSTRAINT FK_ID_AreaCientifica FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela PatrocinioPublico--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[PatrocinioPublico]') 
)
BEGIN

	CREATE TABLE PatrocinioPublico(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		Sigla nvarchar(20),
		Email nvarchar(40),
		Tel int,
		Morada nvarchar(40),
		URL_Patrocinio nvarchar(40) unique,
		Pais nvarchar(20),
		Designacao nvarchar(100),

		CONSTRAINT PK_ID_PP PRIMARY KEY (ID),
	);
END

/*--Tablela Patrocina_Programa--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Patrocina_Programa]') 
)
BEGIN

	CREATE TABLE Patrocina_Programa(
		ID_Programa int NOT NULL,
		ID_Projeto int NOT NULL,
		Montante int,
		CONSTRAINT FK_ID_PP FOREIGN KEY (ID_Programa) REFERENCES PatrocinioPublico(ID),
		CONSTRAINT FK_ID_PP2 FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Patrocinador--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Patrocinador]') 
)
BEGIN

	CREATE TABLE Patrocinador(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		Sigla nvarchar(20),
		Email nvarchar(40),
		Tel int,
		Morada nvarchar(40),
		URL_Patrocinio nvarchar(40) unique,
		Pais nvarchar(20),
		Designacao nvarchar(100),

		CONSTRAINT PK_ID_P PRIMARY KEY (ID),
	);
END

/*--Tablela Patrocinador_Privado--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Patrocinador_Privado]') 
)
BEGIN

	CREATE TABLE Patrocinador_Privado(
		ID_Patrocinador int NOT NULL,
		ID_Projeto int NOT NULL,
		Montante int,
		CONSTRAINT FK_ID_PPriv FOREIGN KEY (ID_Patrocinador) REFERENCES Patrocinador(ID),
		CONSTRAINT FK_ID_PPriv2 FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Pertence1--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Pertence1]') 
)
BEGIN

	CREATE TABLE Pertence1(
		ID_Investigador int NOT NULL,
		ID_UC int NOT NULL,
		ID_Projeto int NOT NULL,
		CONSTRAINT FK_ID_Pertence FOREIGN KEY (ID_Investigador) REFERENCES Investigador(ID),
		CONSTRAINT FK_ID_Pertence2 FOREIGN KEY (ID_UC) REFERENCES Unidade_Curricular(ID),
		CONSTRAINT FK_ID_Pertence3 FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Pertence2--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Pertence2]') 
)
BEGIN

	CREATE TABLE Pertence2(
		ID_UC int NOT NULL,
		ID_Projeto int NOT NULL,
		CONSTRAINT FK_ID_Pertence21 FOREIGN KEY (ID_UC) REFERENCES Unidade_Curricular(ID),
		CONSTRAINT FK_ID_Pertence22 FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
	);
END

/*--Tablela Publicacao--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Publicacao]') 
)
BEGIN

	CREATE TABLE Publicacao(
		Titulo nvarchar(40),
		Descricao nvarchar(100),
		URL_Publicacao nvarchar(50),
		ID_Projeto int NOT NULL,
		ID_Investigador int NOT NULL,
		CONSTRAINT FK_ID_Publicacao FOREIGN KEY (ID_Projeto) REFERENCES Projeto(ID),
		CONSTRAINT FK_ID_Publicacao2 FOREIGN KEY (ID_Investigador) REFERENCES Investigador(ID),
	);
END


/*------------------Insert Values------------------*/

INSERT INTO Instituição VALUES ('Universidade da Beira Interior','R. Marquês de Ávila e Bolama' ,'ubiserct@ubi.pt' ,275319700);
INSERT INTO Instituição VALUES ('Universidade de Aveiro','Campus Universitário de Santiago' ,'reitoria@ua.pt' ,234370200);
INSERT INTO Instituição VALUES ('Universidade do Porto','Praça Marquês de Pombal,30-44' ,'fims@reit.up.pt' ,225518578);
INSERT INTO Instituição VALUES ('Instituto de Sistemas e Robótica','Rua Silvio Lima- Polo II' ,'iactwithpain@uc.pt' ,239796201);
INSERT INTO Instituição VALUES ('Universidade do Minho','Largo do paço' ,'gcii@reitoria.uminho.pt' ,253601100);
INSERT INTO Instituição VALUES ('Universidade de Coimbra','Rua Larga Edifício Faculdade de Medicina' ,'gabadmin@uc.pt' ,239859900);
INSERT INTO Instituição VALUES ('Instituto Superior de Estatística e Gestão de Informação - NOVA Information Management School','Travessa Estêvão Pinto' ,'magic@novaims.unl.pt' , 213880382);
INSERT INTO Instituição VALUES ('Universidade Aberta','Rua Almirante Barroso, nº38' ,'gcri@uab.pt' ,300002812);
INSERT INTO Instituição VALUES ('Instituto Politécnico de Bragança','Campus de Santa Apolónia' ,'saipb@ipb.pt' ,273330850);
INSERT INTO Instituição VALUES ('Instituto de Telecomunicações','Campus Universitário de Santiago' ,'it@lx.it.pt' ,234377900);

INSERT INTO Investigador VALUES('João', 1, 'abcd123', 1);
INSERT INTO Investigador VALUES('José', 2, 'abcd456', 1);
INSERT INTO Investigador VALUES('Maria', 3, 'abcd789', 2);
INSERT INTO Investigador VALUES('Manuel', 4, 'efg123', 3);
INSERT INTO Investigador VALUES('Joana', 5, 'efg456', 3);
INSERT INTO Investigador VALUES('Pedro', 6, 'efg789', 3);
INSERT INTO Investigador VALUES('Francisco', 7, 'hij123', 4);
INSERT INTO Investigador VALUES('Ana', 8, 'hij456', 5);
INSERT INTO Investigador VALUES('Catarina', 9, 'hij789', 7);
INSERT INTO Investigador VALUES('André', 10, 'klm123', 9);

INSERT INTO Unidade_de_Investigação VALUES('Centro de Investigação em Sistemas Electromecatrónicos', 1);
INSERT INTO Unidade_de_Investigação VALUES('Instituto de Engenharia Eletrónica e Informática de Aveiro', 2);
INSERT INTO Unidade_de_Investigação VALUES('Laboratório de Inteligência Artificial e Ciência de Computadores', 3);
INSERT INTO Unidade_de_Investigação VALUES('Instituto de Sistemas de Robótica-ISR-Coimbra', 4);
INSERT INTO Unidade_de_Investigação VALUES('Centro de Investigação ALGORITMI', 5);
INSERT INTO Unidade_de_Investigação VALUES('Centro de Informática e Sistemas da Universidade de Coimbra', 6);
INSERT INTO Unidade_de_Investigação VALUES('Centro de Investigação em Gestão de Informação', 7);
INSERT INTO Unidade_de_Investigação VALUES('Laboratório de Educação a Distância e Elearning', 8);
INSERT INTO Unidade_de_Investigação VALUES('Centro de Investigação em Digitalização e Robótica Inteligente', 9);
INSERT INTO Unidade_de_Investigação VALUES('Instituto de Telecomonicações', 10);

INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();
INSERT INTO Projeto VALUES();

INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();
INSERT INTO Responsavel VALUES();


INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();
INSERT INTO Instituição_proj VALUES();

INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();
INSERT INTO KeyWords VALUES();

INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();
INSERT INTO Contem VALUES();

INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();
INSERT INTO AreaCientifica VALUES();

INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();
INSERT INTO PatrocinioPublico VALUES();

INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();
INSERT INTO Patrocina_Programa VALUES();

INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();
INSERT INTO Patrocinador VALUES();

INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();
INSERT INTO Patrocinador_Privado VALUES();

INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();
INSERT INTO Pertence1 VALUES();

INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();
INSERT INTO Pertence2 VALUES();