USE FaculdadeDB
GO

-- A
SELECT
    cu.Id CursoId,
    cu.Nome Curso,
    cu.DuracaoAnos,
    cu.Valor,
    cu.ProfessorId,
    pr.Nome Professor,
    pr.Email ProfessorEmail
FROM
    dbo.Cursos cu INNER JOIN dbo.Professores pr
    ON cu.ProfessorId = pr.Id

-- B
SELECT
    cu.Id CursoId,
    cu.Nome Curso,
    cu.DuracaoAnos,
    cu.Valor,
    cu.ProfessorId,
    pr.Nome Professor,
    pr.Email ProfessorEmail
FROM
    dbo.Cursos cu LEFT JOIN dbo.Professores pr
    ON cu.ProfessorId = pr.Id

-- C
SELECT * FROM dbo.Cursos cu 
WHERE cu.ProfessorId IN (SELECT Id FROM dbo.Professores)

-- D
SELECT * FROM dbo.Cursos cu 
WHERE EXISTS (SELECT Id FROM dbo.Professores pr WHERE pr.Id = cu.ProfessorId)

-- E
SELECT * FROM dbo.Cursos cu 
WHERE NOT EXISTS (SELECT Id FROM dbo.Professores pr WHERE pr.Id = cu.ProfessorId)

-- F
SELECT 
    ca.CursoId,
    cu.Nome Curso,
    ca.AlunoId,
    al.Nome Aluno,
    cu.ProfessorId,
    pr.Nome Professor
FROM 
    dbo.CursosAlunos ca 
    INNER JOIN dbo.Cursos cu
        ON ca.CursoId = cu.Id
    INNER JOIN dbo.Alunos al
        ON ca.AlunoId = al.Id
    INNER JOIN dbo.Professores pr
        ON cu.ProfessorId = pr.Id
    
-- G
SELECT 
    ca.CursoId,
    cu.Nome Curso,
    ca.AlunoId,
    al.Nome Aluno,
    cu.ProfessorId,
    pr.Nome Professor
FROM 
    dbo.CursosAlunos ca 
    INNER JOIN dbo.Cursos cu
        ON ca.CursoId = cu.Id
    INNER JOIN dbo.Alunos al
        ON ca.AlunoId = al.Id
    LEFT JOIN dbo.Professores pr
        ON cu.ProfessorId = pr.Id