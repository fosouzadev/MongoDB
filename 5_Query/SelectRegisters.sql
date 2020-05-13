USE FaculdadeDB
GO

-- 1
SELECT * FROM dbo.Cursos

-- 2
SELECT * FROM dbo.Cursos WHERE Valor = 2000

-- 3
SELECT * FROM dbo.Cursos WHERE Valor < 5000

SELECT * FROM dbo.Cursos WHERE Valor > 4000

SELECT * FROM dbo.Cursos WHERE Valor >= 5000

SELECT * FROM dbo.Cursos WHERE Valor <= 5000

-- 4
SELECT * FROM dbo.Cursos WHERE Valor BETWEEN 3000 AND 4000

-- 5
SELECT * FROM dbo.Cursos WHERE Nome LIKE 'A%'

-- 6
SELECT * FROM dbo.Cursos WHERE DuracaoAnos IN (2, 3, 4)

SELECT * FROM dbo.Cursos WHERE DuracaoAnos NOT IN (2, 3, 4)

-- 7
SELECT * FROM dbo.Cursos WHERE ProfessorId IS NULL

SELECT * FROM dbo.Cursos WHERE ProfessorId IS NOT NULL

-- 8
SELECT * FROM dbo.Cursos ORDER BY DuracaoAnos

SELECT * FROM dbo.Cursos ORDER BY DuracaoAnos DESC