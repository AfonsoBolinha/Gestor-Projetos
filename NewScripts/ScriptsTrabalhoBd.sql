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

/*--Tablela Institui��o--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Institui��o]') 
)
BEGIN

	CREATE TABLE Institui��o(
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
		CONSTRAINT FK_ID_Investigador FOREIGN KEY (ID_Instituicao) REFERENCES Institui��o(ID),
	);
END

/*--Tablela Unidade de Investiga��o--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Unidade_de_Investiga��o]') 
)
BEGIN
	CREATE TABLE Unidade_de_Investiga��o(
		ID int NOT NULL IDENTITY(1,1),
		Nome nvarchar(40),
		ID_Instituicao int NOT NULL,

		CONSTRAINT PK_ID_UC PRIMARY KEY (ID),
		CONSTRAINT FK_ID_Instituicao FOREIGN KEY (ID_Instituicao) REFERENCES Institui��o(ID),
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

/*--Tablela Institui��o_proj--*/
IF NOT EXISTS (
	SELECT * FROM dbo.sysobjects
	WHERE id = object_id(N'[dbo].[Institui��o_proj]') 
)
BEGIN

	CREATE TABLE Institui��o_proj(
		ID_proj int NOT NULL,
		ID_inst int NOT NULL,
		percentagem int NOT NULL,

		CONSTRAINT FK_ID_inst_proj FOREIGN KEY (ID_Proj) REFERENCES Projeto(ID),
		CONSTRAINT FK_ID_inst_proj2 FOREIGN KEY (ID_Inst) REFERENCES Institui��o(ID),
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

INSERT INTO Institui��o VALUES ('Universidade da Beira Interior','R. Marqu�s de �vila e Bolama' ,'ubiserct@ubi.pt' ,275319700);
INSERT INTO Institui��o VALUES ('Universidade de Aveiro','Campus Universit�rio de Santiago' ,'reitoria@ua.pt' ,234370200);
INSERT INTO Institui��o VALUES ('Universidade do Porto','Pra�a Marqu�s de Pombal,30-44' ,'fims@reit.up.pt' ,225518578);
INSERT INTO Institui��o VALUES ('Instituto de Sistemas e Rob�tica','Rua Silvio Lima- Polo II' ,'iactwithpain@uc.pt' ,239796201);
INSERT INTO Institui��o VALUES ('Universidade do Minho','Largo do pa�o' ,'gcii@reitoria.uminho.pt' ,253601100);
INSERT INTO Institui��o VALUES ('Universidade de Coimbra','Rua Larga Edif�cio Faculdade de Medicina' ,'gabadmin@uc.pt' ,239859900);
INSERT INTO Institui��o VALUES ('Instituto Superior de Estat�stica e Gest�o de Informa��o - NOVA Information Management School','Travessa Est�v�o Pinto' ,'magic@novaims.unl.pt' , 213880382);
INSERT INTO Institui��o VALUES ('Universidade Aberta','Rua Almirante Barroso, n�38' ,'gcri@uab.pt' ,300002812);
INSERT INTO Institui��o VALUES ('Instituto Polit�cnico de Bragan�a','Campus de Santa Apol�nia' ,'saipb@ipb.pt' ,273330850);
INSERT INTO Institui��o VALUES ('Instituto de Telecomunica��es','Campus Universit�rio de Santiago' ,'it@lx.it.pt' ,234377900);

INSERT INTO Investigador VALUES('Jo�o', 1, 'abcd123', 1);
INSERT INTO Investigador VALUES('Jos�', 2, 'abcd456', 1);
INSERT INTO Investigador VALUES('Maria', 3, 'abcd789', 2);
INSERT INTO Investigador VALUES('Manuel', 4, 'efg123', 3);
INSERT INTO Investigador VALUES('Joana', 5, 'efg456', 3);
INSERT INTO Investigador VALUES('Pedro', 6, 'efg789', 3);
INSERT INTO Investigador VALUES('Francisco', 7, 'hij123', 4);
INSERT INTO Investigador VALUES('Ana', 8, 'hij456', 5);
INSERT INTO Investigador VALUES('Catarina', 9, 'hij789', 7);
INSERT INTO Investigador VALUES('Andr�', 10, 'klm123', 9);

INSERT INTO Unidade_de_Investiga��o VALUES('Centro de Investiga��o em Sistemas Electromecatr�nicos', 1);
INSERT INTO Unidade_de_Investiga��o VALUES('Instituto de Engenharia Eletr�nica e Inform�tica de Aveiro', 2);
INSERT INTO Unidade_de_Investiga��o VALUES('Laborat�rio de Intelig�ncia Artificial e Ci�ncia de Computadores', 3);
INSERT INTO Unidade_de_Investiga��o VALUES('Instituto de Sistemas de Rob�tica-ISR-Coimbra', 4);
INSERT INTO Unidade_de_Investiga��o VALUES('Centro de Investiga��o ALGORITMI', 5);
INSERT INTO Unidade_de_Investiga��o VALUES('Centro de Inform�tica e Sistemas da Universidade de Coimbra', 6);
INSERT INTO Unidade_de_Investiga��o VALUES('Centro de Investiga��o em Gest�o de Informa��o', 7);
INSERT INTO Unidade_de_Investiga��o VALUES('Laborat�rio de Educa��o a Dist�ncia e Elearning', 8);
INSERT INTO Unidade_de_Investiga��o VALUES('Centro de Investiga��o em Digitaliza��o e Rob�tica Inteligente', 9);
INSERT INTO Unidade_de_Investiga��o VALUES('Instituto de Telecomonica��es', 10);

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


INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();
INSERT INTO Institui��o_proj VALUES();

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