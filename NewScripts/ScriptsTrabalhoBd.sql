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
		Nome nvarchar(200),
		Morada nvarchar(100),
		Email nvarchar(100),
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
		Nome nvarchar(70),
		Num_Funcionario int,
		ORCID nvarchar(40) unique,
		ID_Instituicao int NOT NULL,

		CONSTRAINT PK_ID_IVest PRIMARY KEY (ID),
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
		Nome nvarchar(100),
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
		Nome nvarchar(200),
		Short_Name nvarchar(100),
		Descricao nvarchar(300),
		ID_UC int NOT NULL,
		Max_Cost int,
		Total_Cost int,
		DOI nvarchar(40) UNIQUE,
		State_Proj nvarchar(20),
		Data_Init date default GetDate(),
		Data_Fin date default GetDate(),
		Cientific_Domain nvarchar(200),
		ID_IR int NOT NULL,

		CONSTRAINT PK_ID_PROJ PRIMARY KEY (ID),
		CONSTRAINT FK_ID_UC FOREIGN KEY (ID_UC) REFERENCES Unidade_de_Investigação(ID),
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
		PalavraChave nvarchar(100),
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
		Papel nvarchar(100),
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
		Area nvarchar(200),
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
		Nome nvarchar(100),
		Sigla nvarchar(50),
		Email nvarchar(100),
		Tel int,
		Morada nvarchar(100),
		URL_Patrocinio nvarchar(100) unique,
		Pais nvarchar(100),
		Designacao nvarchar(200),

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
		Nome nvarchar(100),
		Sigla nvarchar(50),
		Email nvarchar(100),
		Tel int,
		Morada nvarchar(100),
		URL_Patrocinio nvarchar(100) unique,
		Pais nvarchar(100),
		Designacao nvarchar(200),

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
		CONSTRAINT FK_ID_Pertence2 FOREIGN KEY (ID_UC) REFERENCES Unidade_de_Investigação(ID),
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
		CONSTRAINT FK_ID_Pertence21 FOREIGN KEY (ID_UC) REFERENCES Unidade_de_Investigação(ID),
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
		Titulo nvarchar(200),
		Descricao nvarchar(300),
		URL_Publicacao nvarchar(100),
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
INSERT INTO Unidade_de_Investigação VALUES('Instituto de Telecomunicações', 10);

INSERT INTO Projeto VALUES('Braço mecânico para industrias','Braço mecânico','Desenvolvimento de um braço mecânico com aplicação na industria para efeitos de automação', 1, 40000, 36000, 'abcdefg123', 'concluído', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 1);
INSERT INTO Projeto VALUES('Inteligencia artificial de reconhecimento facial','IA reconhecimento facial','Inteligencia artificial reconhecimento facial', 2, 30000, 26000, 'abcdefg124', 'aprovado', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 2);
INSERT INTO Projeto VALUES('Bicicleta elétrica para uso diário', 'Bicicleta elétrica', 'Bicicleta elétrica perfeita para uso diário',3 ,40000, 36000, 'abcdefg125', 'cancelado', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 3);
INSERT INTO Projeto VALUES('Reconhecimento do melhor caminho para ir de ponto a ponto', 'Reconhecimento de caminho','Reconhecimento do melhor caminho para ir de ponto a ponto',4 ,50000, 46000, 'abcdefg126', 'em curso', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 4);
INSERT INTO Projeto VALUES('Painel solar mais eficiente', 'Painel solar','Painel solar mais eficiente',5 ,40000, 36000, 'abcdefg127', 'encerrado', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 5);
INSERT INTO Projeto VALUES('Espelho que mostra informações que o utilizador possa querer', 'Espelho inteligente','Espelho que mostra informações que o utilizador possa querer',6 ,40000, 36000, 'abcdefg128', 'renovado', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 6);
INSERT INTO Projeto VALUES('Assistente virtual para uso diário', 'Assistente virtual','Assistente virtual para uso diário',7 ,40000, 36000, 'abcdefg129', 'em submissão', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 7);
INSERT INTO Projeto VALUES('Sistema de entretenimento para carros','Sistema de entretenimento','Sistema de entretenimento para carros',8 ,40000, 36000, 'abcdefg133', 'concluído', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 8);
INSERT INTO Projeto VALUES('Sistema que analisa e recomenda dependendo da analise psicológica do utilizador', 'Sistema de analise psicológica','Sistema que analisa e recomenda dependendo da analise psicológica do utilizador',9 ,40000, 36000, 'abcdefg134', 'concluído', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 9);
INSERT INTO Projeto VALUES('Robô para ajuda de médicos','Robô enfermeiro','Robô para ajuda de médicos',10 ,40000, 36000, 'abcdefg135', 'concluído', '2021-06-20', '2022-07-26', 'Sistemas de Automação e Robótica', 10);

INSERT INTO Responsavel VALUES(1,1,20);
INSERT INTO Responsavel VALUES(2,2,20);
INSERT INTO Responsavel VALUES(3,3,20);
INSERT INTO Responsavel VALUES(4,4,20);
INSERT INTO Responsavel VALUES(5,5,20);
INSERT INTO Responsavel VALUES(6,6,20);
INSERT INTO Responsavel VALUES(7,7,20);
INSERT INTO Responsavel VALUES(8,8,20);
INSERT INTO Responsavel VALUES(9,9,20);
INSERT INTO Responsavel VALUES(10,10,20);


INSERT INTO Instituição_proj VALUES(1,1,100);
INSERT INTO Instituição_proj VALUES(2,2,25);
INSERT INTO Instituição_proj VALUES(2,3,75);
INSERT INTO Instituição_proj VALUES(3,4,100);
INSERT INTO Instituição_proj VALUES(4,5,100);
INSERT INTO Instituição_proj VALUES(5,6,100);
INSERT INTO Instituição_proj VALUES(6,7,100);
INSERT INTO Instituição_proj VALUES(7,8,100);
INSERT INTO Instituição_proj VALUES(8,9,100);
INSERT INTO Instituição_proj VALUES(9,10,100);
INSERT INTO Instituição_proj VALUES(10,3,100);

INSERT INTO KeyWords VALUES('Braço',1);
INSERT INTO KeyWords VALUES('Mecânico',1);
INSERT INTO KeyWords VALUES('Industria',1);
INSERT INTO KeyWords VALUES('IA',2);
INSERT INTO KeyWords VALUES('Reconhecimento',2);
INSERT INTO KeyWords VALUES('Facial',2);
INSERT INTO KeyWords VALUES('Bicicleta',3);
INSERT INTO KeyWords VALUES('Elétrica',3);
INSERT INTO KeyWords VALUES('Diario',3);
INSERT INTO KeyWords VALUES('Reconhecimento',4);
INSERT INTO KeyWords VALUES('Caminho',4);
INSERT INTO KeyWords VALUES('Melhor',4);
INSERT INTO KeyWords VALUES('Painel',5);
INSERT INTO KeyWords VALUES('Solar',5);
INSERT INTO KeyWords VALUES('Eficiente',5);
INSERT INTO KeyWords VALUES('Espelho',6);
INSERT INTO KeyWords VALUES('Inteligente',6);
INSERT INTO KeyWords VALUES('Informações',6);
INSERT INTO KeyWords VALUES('Assistente',7);
INSERT INTO KeyWords VALUES('Virtual',7);
INSERT INTO KeyWords VALUES('Diário',7);
INSERT INTO KeyWords VALUES('Sistema',8);
INSERT INTO KeyWords VALUES('Entertenimento',8);
INSERT INTO KeyWords VALUES('Carro',8);
INSERT INTO KeyWords VALUES('Sistema',9);
INSERT INTO KeyWords VALUES('Análise',9);
INSERT INTO KeyWords VALUES('Psicológica',9);
INSERT INTO KeyWords VALUES('Robô',10);
INSERT INTO KeyWords VALUES('Ajuda',10);
INSERT INTO KeyWords VALUES('Médico',10);

INSERT INTO Contem VALUES(1,1,'Responsável',35,100);
INSERT INTO Contem VALUES(1,2,'Investigador',15,100);
INSERT INTO Contem VALUES(1,3,'Investigador',15,100);
INSERT INTO Contem VALUES(2,2,'Responsável',35,100);
INSERT INTO Contem VALUES(2,3,'Investigador',15,100);
INSERT INTO Contem VALUES(2,4,'Investigador',15,100);
INSERT INTO Contem VALUES(3,3,'Responsável',35,100);
INSERT INTO Contem VALUES(3,5,'Investigador',15,100);
INSERT INTO Contem VALUES(3,7,'Investigador',15,100);
INSERT INTO Contem VALUES(4,4,'Responsável',35,100);
INSERT INTO Contem VALUES(4,9,'Investigador',15,100);
INSERT INTO Contem VALUES(4,10,'Investigador',15,100);
INSERT INTO Contem VALUES(5,5,'Responsável',35,100);
INSERT INTO Contem VALUES(5,4,'Investigador',15,100);
INSERT INTO Contem VALUES(5,3,'Investigador',15,100);
INSERT INTO Contem VALUES(6,6,'Responsável',35,100);
INSERT INTO Contem VALUES(6,1,'Investigador',15,100);
INSERT INTO Contem VALUES(6,5,'Investigador',15,100);
INSERT INTO Contem VALUES(7,7,'Responsável',35,100);
INSERT INTO Contem VALUES(7,9,'Investigador',15,100);
INSERT INTO Contem VALUES(7,8,'Investigador',15,100);
INSERT INTO Contem VALUES(8,8,'Responsável',35,100);
INSERT INTO Contem VALUES(8,2,'Investigador',15,100);
INSERT INTO Contem VALUES(8,1,'Investigador',15,100);
INSERT INTO Contem VALUES(9,9,'Responsável',35,100);
INSERT INTO Contem VALUES(9,10,'Investigador',15,100);
INSERT INTO Contem VALUES(9,4,'Investigador',15,100);
INSERT INTO Contem VALUES(10,10,'Responsável',35,100);
INSERT INTO Contem VALUES(10,9,'Investigador',15,100);
INSERT INTO Contem VALUES(10,7,'Investigador',15,100);

INSERT INTO AreaCientifica VALUES('Ciências Físicas',1);
INSERT INTO AreaCientifica VALUES('Ciências Físicas',2);
INSERT INTO AreaCientifica VALUES('Ciências Físicas',3);
INSERT INTO AreaCientifica VALUES('Ciências Físicas',4);
INSERT INTO AreaCientifica VALUES('Ciências Tecnológicas',5);
INSERT INTO AreaCientifica VALUES('Ciências Tecnológicas',6);
INSERT INTO AreaCientifica VALUES('Ciências Físicas',7);
INSERT INTO AreaCientifica VALUES('Ciências Tecnológicas',8);
INSERT INTO AreaCientifica VALUES('Ciências Tecnológicas',9);
INSERT INTO AreaCientifica VALUES('Ciências Físicas',10);

INSERT INTO PatrocinioPublico VALUES('Portugal 2020','PT2020','EmailPT2020',123456789,'MoradaPT2020','URL','Portugal','Portugal 2020');
INSERT INTO PatrocinioPublico VALUES('Horizon2020','H2020','EmailH2020',0080067891011,'MoradaH2020','URL','EU','Horizon2020');
INSERT INTO PatrocinioPublico VALUES('EEA Grants','EEA','EmailEEA',213456786,'MoradaEEA','URL','Islândia','EEA Grants');
INSERT INTO PatrocinioPublico VALUES('Cleansky','Cleansky','EmailCleansky',325654324,'MoradaCleansky','URL','EU','Cleansky');
INSERT INTO PatrocinioPublico VALUES('Programa Operacional Madeira-Açores-Canárias','MAC','EmailMAC',315547655,'MoradaMAC','URL','Portugal','Programa Operacional Madeira-Açores-Canárias');
INSERT INTO PatrocinioPublico VALUES('INTERREG Atlantic Area','INTERREG','EmailINTERREG',756234685,'MoradaINTERREG','URL','TRANSNATIONAL','INTERREG Atlantic Area');
INSERT INTO PatrocinioPublico VALUES('Programa Operacional para o Mediterrâneo','MED','EmailMED',384677325,'MoradaMED','URL','TRANSNATIONAL','Programa Operacional para o Mediterrâneo');
INSERT INTO PatrocinioPublico VALUES('Programa Operacional Sudoeste Europeu','SUDOE','EmailSUDOE',574125434,'MoradaSUDOE','URL','TRANSNATIONAL','Programa Operacional Sudoeste Europeu');
INSERT INTO PatrocinioPublico VALUES('Programa ESPON','ESPON','EmailESPON',347634563,'MoradaESPON','URL','EU','Programa ESPON');
INSERT INTO PatrocinioPublico VALUES('COST','COST','EmailCOST',675823432,'MoradaCOST','URL','EU','COST');

INSERT INTO Patrocina_Programa VALUES(1,1,1000);
INSERT INTO Patrocina_Programa VALUES(2,2,1000);
INSERT INTO Patrocina_Programa VALUES(3,3,1000);
INSERT INTO Patrocina_Programa VALUES(4,4,1000);
INSERT INTO Patrocina_Programa VALUES(5,5,1000);
INSERT INTO Patrocina_Programa VALUES(6,6,1000);
INSERT INTO Patrocina_Programa VALUES(7,7,1000);
INSERT INTO Patrocina_Programa VALUES(8,8,1000);
INSERT INTO Patrocina_Programa VALUES(9,9,1000);
INSERT INTO Patrocina_Programa VALUES(10,10,1000);

INSERT INTO Patrocinador VALUES('João','J','EmailJ',326745763,'MoradaJ','URL','Portugal','João');
INSERT INTO Patrocinador VALUES('Manel','M','EmailM',124532532,'MoradaM','URL','Portugal','Manel');
INSERT INTO Patrocinador VALUES('Ze','Z','EmailZ',436213342,'MoradaZ','URL','Portugal','Ze');
INSERT INTO Patrocinador VALUES('Rui','R','EmailR',643342133,'MoradaR','URL','Portugal','Rui');
INSERT INTO Patrocinador VALUES('Richard','Rc','EmailRc',436534234,'MoradaRc','URL','Inglaterra','Richard');
INSERT INTO Patrocinador VALUES('Alicia','A','EmailA',567345242,'MoradaA','URL','Inglaterra','Alicia');
INSERT INTO Patrocinador VALUES('Robin','Rb','EmailRb',675345423,'MoradaRb','URL','Inglaterra','Robin');
INSERT INTO Patrocinador VALUES('Yan','Y','EmailY',784633522,'MoradaY','URL','China','Yan');
INSERT INTO Patrocinador VALUES('Li','Li','EmailLi',987654562,'MoradaLi','URL','China','Li');
INSERT INTO Patrocinador VALUES('Chun','C','EmailC',435643453,'MoradaC','URL','China','Chun');

INSERT INTO Patrocinador_Privado VALUES(1,1,1000);
INSERT INTO Patrocinador_Privado VALUES(2,2,1000);
INSERT INTO Patrocinador_Privado VALUES(3,3,1000);
INSERT INTO Patrocinador_Privado VALUES(4,4,1000);
INSERT INTO Patrocinador_Privado VALUES(5,5,1000);
INSERT INTO Patrocinador_Privado VALUES(6,6,1000);
INSERT INTO Patrocinador_Privado VALUES(7,7,1000);
INSERT INTO Patrocinador_Privado VALUES(8,8,1000);
INSERT INTO Patrocinador_Privado VALUES(9,9,1000);
INSERT INTO Patrocinador_Privado VALUES(10,10,1000);

INSERT INTO Pertence1 VALUES(1,1,1);
INSERT INTO Pertence1 VALUES(2,2,2);
INSERT INTO Pertence1 VALUES(3,3,3);
INSERT INTO Pertence1 VALUES(4,4,4);
INSERT INTO Pertence1 VALUES(5,5,5);
INSERT INTO Pertence1 VALUES(6,6,6);
INSERT INTO Pertence1 VALUES(7,7,7);
INSERT INTO Pertence1 VALUES(8,8,8);
INSERT INTO Pertence1 VALUES(9,9,9);
INSERT INTO Pertence1 VALUES(10,10,10);

INSERT INTO Pertence2 VALUES(1,1);
INSERT INTO Pertence2 VALUES(2,2);
INSERT INTO Pertence2 VALUES(3,3);
INSERT INTO Pertence2 VALUES(4,4);
INSERT INTO Pertence2 VALUES(5,5);
INSERT INTO Pertence2 VALUES(6,6);
INSERT INTO Pertence2 VALUES(7,7);
INSERT INTO Pertence2 VALUES(8,8);
INSERT INTO Pertence2 VALUES(9,9);
INSERT INTO Pertence2 VALUES(10,10);

INSERT INTO Publicacao VALUES('Braço mecânico','Braço mecânico para industrias','URL',1,1);
INSERT INTO Publicacao VALUES('Inteligencia artificial reconhecimento facial','Inteligencia artificial de reconhecimento facial','URL',2,2);
INSERT INTO Publicacao VALUES('Bicicleta elétrica','Bicicleta elétrica para uso diário','URL',3,3);
INSERT INTO Publicacao VALUES('Reconhecimento de caminho','Reconhecimento do melhor caminho para ir de ponto a ponto','URL',4,4);
INSERT INTO Publicacao VALUES('Painel solar','Painel solar mais eficiente','URL',5,5);
INSERT INTO Publicacao VALUES('Espelho inteligente','Espelho que mostra informações que o utilizador possa querer','URL',6,6);
INSERT INTO Publicacao VALUES('Assistente virtual','Assistente virtual para uso diário','URL',7,7);
INSERT INTO Publicacao VALUES('Sistema de entretenimento','Sistema de entretenimento para carros','URL',8,8);
INSERT INTO Publicacao VALUES('Sistema de analise psicológica','Sistema que analisa e recomenda dependendo da analise psicológica do utilizador','URL',9,9);
INSERT INTO Publicacao VALUES('Robô enfermeiro','Robô para ajuda de médicos','URL',10,10);