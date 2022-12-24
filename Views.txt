CREATE VIEW Project_State AS 
	SELECT Nome, State, Total_Cost, Max_Cost, QTD AS Pessoas FROM Projeto
	INNER JOIN (SELECT ID_Projeto, COUNT(*) AS QTD FROM Contem
GROUP BY ID_Projeto) AS qtd ON qtd.ID_Projeto=Projeto.ID


CREATE VIEW Investigador_Instituicao AS 
	SELECT Investigador.Nome, Instituição.Nome, Instituição.ID FROM Instituição
	INNER JOIN Investigador ON Investigador.ID_Instituicao=Instituição.ID


CREATE VIEW Patrocinios_Privados AS 
	SELECT Nome, Montante FROM (SELECT * FROM Patrocinador_Privado
	INNER JOIN Patrocinador ON Patrocinador.ID=Patrocinador_Privado.ID_Patrocinador) AS Q1


CREATE VIEW Patrocinios_Privados AS 
	SELECT Nome, Montante FROM (SELECT * FROM Patrocinador_Privado
	INNER JOIN Patrocinador ON Patrocinador.ID=Patrocinador_Privado.ID_Patrocinador) AS Q1


CREATE VIEW Investigador_Projeto AS 
	SELECT Investigador.Nome AS NomeInvestigador, Projeto.Nome AS NomeProjeto,ORCID FROM Investigador
	INNER JOIN Contem ON Contem.ID_Investigador=Investigador.ID
	INNER JOIN Projeto ON Contem.ID_Projeto=Projeto.ID


CREATE VIEW Publicacao_Projeto AS 
	SELECT Projeto.ID,Projeto.Nome AS Nome_Investigador,Investigador.Nome AS Nome_Projeto, Titulo, URL FROM Publicacao
	INNER JOIN Projeto ON Projeto.ID=Publicacao.ID_Projeto
	INNER JOIN Investigador ON Investigador.ID=Publicacao.ID_Investigador


CREATE VIEW RatingProj AS
	SELECT Nome,Total_Cost,Participantes,NumPublicacoes FROM (SELECT Nome, Total_Cost,ID FROM Projeto) AS Q1
	INNER JOIN (SELECT ID_Projeto,COUNT(*)AS Participantes FROM Contem
GROUP BY ID_Projeto) AS Q2 ON Q2.ID_Projeto=Q1.ID
	INNER JOIN (SELECT ID_Projeto,COUNT(*) AS NumPublicacoes FROM Publicacao
GROUP BY ID_Projeto)AS Q3 ON Q3.ID_Projeto=Q1.ID


CREATE VIEW ProjetoPatrocinioPrivado AS
	SELECT Projeto.Nome AS NomeProj,Patrocinador.Nome AS NomePatrocinio, Montante FROM Projeto
	INNER JOIN Patrocinador_Privado ON Projeto.ID=Patrocinador_Privado.ID_Projeto
	INNER JOIN Patrocinador ON Patrocinador.ID=Patrocinador_Privado.ID_Patrocinador


CREATE VIEW ProjetoPatrocinioPrograma AS
	SELECT Projeto.Nome AS NomeProj,PatrocinioPublico.Nome AS NomePatrocinio, Montante FROM Projeto
	INNER JOIN Patrocina_Programa ON Projeto.ID=Patrocina_Programa.ID_Projeto
	INNER JOIN PatrocinioPublico ON PatrocinioPublico.ID=Patrocina_Programa.ID_Programa_Patrocinador


ALTER VIEW InvestigadorStatus AS
	Select Investigador.Nome,Papel,Tempo_Gasto,Tempo_Total As NomeInvestigador FROM Investigador
	INNER JOIN Contem ON Investigador.ID=Contem.ID_Investigador
	INNER JOIN Projeto ON Contem.ID_Projeto=Projeto.ID


CREATE VIEW UCRank AS
	SELECT Unidade_Curricular.Nome,COUNT(ID_Investigador) AS NumPessoas FROM Contem
	INNER JOIN Projeto ON Projeto.ID=Contem.ID_Projeto
	INNER JOIN Unidade_Curricular ON Unidade_Curricular.ID=Projeto.ID_UC
	GROUP BY Unidade_Curricular.Nome
