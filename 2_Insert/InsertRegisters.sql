USE FaculdadeDB
GO

INSERT INTO dbo.Alunos (Nome, DataNasc, Celular, Email) VALUES
('Maria Aparecida de Santos', '1989-07-13', '(11) 97845-4512', 'maria@dev.com.br'),
('João Mendes de Fibini', '1989-07-13', '(11) 97845-4512', 'joão@dev.com.br'),
('José Pinto', '1989-07-13', '(11) 97845-4512', 'josé@dev.com.br'),
('Juliana Alencar', '1989-07-13', '(11) 97845-4512', 'juliana@dev.com.br'),
('Patricia Brito', '1989-07-13', '(11) 97845-4512', 'patricia@dev.com.br'),
('Luiza Kaori Sato', '1989-07-13', '(11) 97845-4512', 'luiza@dev.com.br'),
('Sabrina Santos de Souza', '1989-07-13', '(11) 97845-4512', 'sabrina@dev.com.br'),
('Felipe Oliveira de Souza', '1989-07-13', '(11) 97845-4512', 'felipe@dev.com.br')
GO

INSERT INTO dbo.Professores (Nome, Celular, Email) VALUES
('Mariana Jujuba', '(11) 97845-4512', 'mariana@dev.com.br'),
('Marcos Cesar Augustos', '(11) 97845-4512', 'marcos@dev.com.br'),
('Marcelo Xavier', '(11) 97845-4512', 'marcelo@dev.com.br'),
('Ana Maria Bunda', '(11) 97845-4512', 'ana@dev.com.br'),
('Roneiva Runiania', '(11) 97845-4512', 'roneiva@dev.com.br'),
('Cecilia Batista', '(11) 97845-4512', 'cecilia@dev.com.br'),
('Paulo Fabiosi', '(11) 97845-4512', 'paulo@dev.com.br'),
('Luciana Murilais', '(11) 97845-4512', 'luciana@dev.com.br')
GO

INSERT INTO dbo.Cursos (Nome, DuracaoAnos, ProfessorId) VALUES
('Gastronomia', 6.5, 1),
('Contabilidade', 4.5, 1),
('Fisioterapia', 2, 2),
('Radiologia', 1.5, 2),
('Análise de Sistemas', 4, 3),
('Banco de dados', 4.5, 4),
('Arquiteto de software', 8, 4),
('Engenharia de software', 6, 4),
('Psicologia', 3, 5),
('Pedagogia', 2, 6),
('Administração', 2, 6),
('Engenharia', 7, 7)
GO

INSERT INTO dbo.CursosAlunos (AlunoId, CursoId) VALUES
(1, 2 ),
(2, 2 ),
(3, 2 ),
(4, 2 ),
(1, 3 ),
(5, 3 ),
(6, 3 ),
(2, 4 ),
(7, 4 ),
(8, 4 ),
(3, 5 ),
(4, 5 ),
(5, 5 ),
(6, 6 ),
(7, 6 ),
(8, 7 ),
(2, 8 ),
(3, 8 ),
(4, 8 ),
(5, 8 ),
(6, 8 ),
(2, 9 ),
(8, 9 ),
(7, 10),
(6, 10),
(5, 11),
(1, 11),
(4, 12),
(3, 12)
GO