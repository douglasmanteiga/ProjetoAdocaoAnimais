--Criação das tabelas
CREATE TABLE [dbo].[Adocao] (
    [AdocaoId] [int] NOT NULL IDENTITY,
    [DataAdocao] [datetime] NOT NULL,
    [DataHoraCadastro] [datetime] NOT NULL,
    [AdocaoSituacaoId] [int] NOT NULL,
    [PessoaId] [int] NOT NULL,
    [AnimalId] [int] NOT NULL,
    [UsuarioId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Adocao] PRIMARY KEY ([AdocaoId])
);

CREATE TABLE [dbo].[AdocaoSituacao] (
    [AdocaoSituacaoId] [int] NOT NULL IDENTITY,
    [Descricao] [varchar](250) NOT NULL,
    CONSTRAINT [PK_dbo.AdocaoSituacao] PRIMARY KEY ([AdocaoSituacaoId])
);

CREATE TABLE [dbo].[Animal] (
    [AnimalId] [int] NOT NULL IDENTITY,
    [Nome] [varchar](250) NOT NULL,
    [Raca] [varchar](250) NOT NULL,
    [Cor] [varchar](250) NOT NULL,
    [SexoId] [int] NOT NULL,
	[Peso] [varchar](250) NOT NULL,
    [DataEntrada] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Animal] PRIMARY KEY ([AnimalId])
);

CREATE TABLE [dbo].[AnimalSexo] (
    [SexoId] [int] NOT NULL IDENTITY,
    [Sexo] [varchar](250) NOT NULL,
    CONSTRAINT [PK_dbo.AnimalSexo] PRIMARY KEY ([SexoId])
);

CREATE TABLE [dbo].[Pessoa] (
    [PessoaId] [int] NOT NULL IDENTITY,
    [Nome] [varchar](500) NOT NULL,
    [RG] [varchar](20),
    [CPF] [varchar](20),
    [Email] [varchar](250) NOT NULL,
    [DataHoraCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Pessoa] PRIMARY KEY ([PessoaId])
);

CREATE TABLE [dbo].[Usuario] (
    [UsuarioId] [int] NOT NULL IDENTITY,
    [Login] [varchar](250) NOT NULL,
    [Senha] [varchar](250) NOT NULL,
    CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY ([UsuarioId])
);

--Criação dos indices para melhorar o desempenho das consultas
CREATE INDEX [IX_AdocaoSituacaoId] ON [dbo].[Adocao]([AdocaoSituacaoId])
CREATE INDEX [IX_PessoaId] ON [dbo].[Adocao]([PessoaId])
CREATE INDEX [IX_AnimalId] ON [dbo].[Adocao]([AnimalId])
CREATE INDEX [IX_UsuarioId] ON [dbo].[Adocao]([UsuarioId])
CREATE INDEX [IX_SexoId] ON [dbo].[Animal]([SexoId])

--Adição de chave estrangeira

ALTER TABLE [dbo].[Adocao] ADD CONSTRAINT [FK_dbo.Adocao_dbo.AdocaoSituacao_AdocaoSituacaoId] FOREIGN KEY ([AdocaoSituacaoId]) REFERENCES [dbo].[AdocaoSituacao] ([AdocaoSituacaoId])
ALTER TABLE [dbo].[Adocao] ADD CONSTRAINT [FK_dbo.Adocao_dbo.Animal_AnimalId] FOREIGN KEY ([AnimalId]) REFERENCES [dbo].[Animal] ([AnimalId])
ALTER TABLE [dbo].[Adocao] ADD CONSTRAINT [FK_dbo.Adocao_dbo.Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [dbo].[Pessoa] ([PessoaId])
ALTER TABLE [dbo].[Adocao] ADD CONSTRAINT [FK_dbo.Adocao_dbo.Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
ALTER TABLE [dbo].[Animal] ADD CONSTRAINT [FK_dbo.Animal_dbo.AnimalSexo_SexoId] FOREIGN KEY ([SexoId]) REFERENCES [dbo].[AnimalSexo] ([SexoId])