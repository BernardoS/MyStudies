![capa do projeto](/repository-cover.png)

# My Studies
Projeto básico para registrar estudos avulsos e conseguir manipulá-los.

---

## Propósito

O propósito deste projeto é aprender e explorar um pouco das Minimal APIs do .NET.

## Rotas disponíveis

#### `Subjects`

- `GET /subjects`: Recupera todos os assuntos.
- `GET /subjects/{id}`: Recupera um assunto específico de acordo com o seu `Id`.
- `POST /subject`: Insere um novo assunto.
- `PUT /subjects/{id}`: Atualiza um assunto específico de acordo com o seu `Id`.
- `DELETE /subjects/{id}`: Remove um assunto específico de acordo com o seu `Id`.

## Construção do projeto

Esta seção serve como consulta para entender quais comandos foram executados para construir o projeto.


1 - Criação do projeto:
   
`dotnet new web -o MyStudies`

2 - Instalação do Entity Framework e ferramentas auxiliares

```
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0
```

3 -  Após a configuração executei um build

`dotnet build`

4 - Executar a primeira `migration` do EntityFramework

`dotnet ef migrations add InitialCreate`

OBS.: Tive que instalar a ferramenta de execução do entity antes de executar o comando, utilizei o comando abaixo para instalar:

`dotnet tool install --global dotnet-ef`

5 - Criando o banco de dados

`dotnet ef database update`

## Execução do projeto

Esta seção serve como consulta para entender quais passos são necessários para executar o projeto.


Comando para executar o projeto:

`dotnet run`


## Banco de dados

As tabelas do banco de dados são:

- Subjects (Id, Name, Descrption);
  - Exemplo de insert: `INSERT INTO Subjects (Name, Description) VALUES ("","");`

### Diagrama de entidades e relacionamentos

Neste diagrama podemos ver todas as tabelas que compõem o sistema e como estão relacionadas entre si.

![alt text](image.png)

OBS.: Diagrama desenvolvido utilizando o SqlDBM: https://sqldbm.com/