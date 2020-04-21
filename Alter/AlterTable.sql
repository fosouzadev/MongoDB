USE FaculdadeDB
GO

ALTER TABLE dbo.Cursos ADD Valor numeric(16,2) not null default(0)
GO