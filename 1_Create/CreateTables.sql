CREATE DATABASE FaculdadeDB
GO

USE FaculdadeDB
GO

CREATE TABLE dbo.Alunos (
    Id          bigint        not null primary key,
    Nome        nvarchar(150) not null,
    DataNasc    date          not null,
    Celular     nvarchar(20)  not null,
    Email       nvarchar(50)  not null,
    DataCriacao date          not null default(getdate())
)
GO

CREATE TABLE dbo.Professores (
    Id          bigint        not null primary key,
    Nome        nvarchar(150) not null,
    Celular     nvarchar(20)  not null,
    Email       nvarchar(50)  not null,
    DataCriacao date          not null default(getdate())
)
GO

CREATE TABLE dbo.Cursos (
    Id          bigint        not null primary key,
    Nome        nvarchar(150) not null,
    DuracaoAnos numeric(2,1)  not null,
    ProfessorId bigint        ,
    DataCriacao date          not null default(getdate())    
)
GO

ALTER TABLE dbo.Cursos
ADD CONSTRAINT FK_PROFESSOR FOREIGN KEY (ProfessorId) REFERENCES dbo.Professores (Id)
GO

CREATE TABLE dbo.CursosAlunos (
    CursoId         bigint not null,
    AlunoId     bigint not null   
)
GO

ALTER TABLE dbo.CursosAlunos
ADD CONSTRAINT PK_Cursos_Alunos PRIMARY KEY (CursoId, AlunoId)
GO

ALTER TABLE dbo.CursosAlunos
ADD CONSTRAINT FK_Cursos_Alunos FOREIGN KEY (CursoId) REFERENCES dbo.Cursos (Id)
GO

ALTER TABLE dbo.CursosAlunos
ADD CONSTRAINT FK_Alunos_Cursos FOREIGN KEY (AlunoId) REFERENCES dbo.Alunos (Id)
GO