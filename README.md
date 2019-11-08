# WEB API Funcionarios
> O projeto é um sistema de WebAPI feito em ASPNETCORE que faz um CRUD com o banco de dados SQL Server.
## Instalação e Configuração para Desenvolvimento
### Banco de Dados
- Para a instalação do sistema deve ter instalado o Banco _SQL Server_ 
- Crie um Banco novo
- rode o SCRIPT:
```sql
USE [NOME DO SEU BANCO DE DADOS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_func] [int] NOT NULL,
	[endereco] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NULL,
	[Email] [varchar](25) NULL,
	[Telefone] [varchar](15) NULL,
	[Salario] [float] NULL,
	[DataCriacao] [datetime] NULL,
	[DataAlteracao] [datetime] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Funcionarios] FOREIGN KEY([id_func])
REFERENCES [dbo].[Funcionarios] ([Id])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Funcionarios]
GO
```
### Postman
- Ultilize a coleção para ver todas as Requisições do Projeto:
https://www.getpostman.com/collections/0ea190cfa6b78b5355bd

### Ambiente
- Para configurar o ambiente Acesse o arquivo na raiz do projeto _appsettings.json_ e insira no atributo *Conexao* a string de conexão do seu banco:
```json
{
  "ConnectionStrings": {
    "Conexao": "[SUA STRING DE CONEXÃO AQUI]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
## Mais informações

Felipe Atene Silva – [Twitter](https://twitter.com/felipetezin) – felipeatenesilva@gmail.com

## Contribuição

1. Faça o _fork_ do projeto (<https://github.com/felipeatene/API_Funcionario/fork>)
2. Crie uma _branch_ para sua modificação (`git checkout -b feature/fooBar`)
3. Faça o _commit_ (`git commit -am 'Add some fooBar'`)
4. _Push_ (`git push origin feature/fooBar`)
5. Crie um novo _Pull Request_
