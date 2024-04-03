# StockProject

Título do Projeto: Sistema de Gerenciamento de Inventário E-commerce

Descrição Geral:
Este projeto é um sistema de gerenciamento de inventário completo para uma plataforma de e-commerce, composto por uma API RESTful desenvolvida com .NET 8 e C#, e uma interface de usuário construída com Angular. O sistema permite operações CRUD em produtos, autenticação de usuário e visualização de estoque.

Recursos:

Operações CRUD de produtos
Registro de usuários e login
Autenticação JWT no backend e no frontend
Visualização de inventário para usuários autenticados
Tecnologias Utilizadas:

Backend: .NET 8, C#, Entity Framework para interação com SQL Server.
Frontend: Angular para uma SPA interativa.
Autenticação: JWT para segurança na comunicação entre cliente e servidor.
Documentação da API: Swagger para documentação interativa e fácil compreensão dos endpoints.
Instalação e Configuração:

Pré-requisitos: .NET 8 SDK, SQL Server, Node.js, Angular CLI.
Backend:
Configure a string de conexão do SQL Server no appsettings.json.
Use dotnet ef database update para aplicar as migrações do banco de dados.
Execute dotnet run para iniciar o servidor.
Frontend:
Utilize npm install para instalar as dependências.
Execute ng serve para rodar o aplicativo Angular.
Estrutura do Projeto:

Controllers: Contém os controladores que gerenciam as requisições e respostas da API.
Models: Definições de modelos de dados para o Entity Framework.
Services: Lógica de negócio e serviços de autenticação.
ClientApp: Aplicativo Angular com componentes, serviços e módulos.
Endpoints da API:

CRUD de Produtos: /api/Product
Registro de Usuário: /api/User/register
Login de Usuário: /api/User/login
Pacotes e Ferramentas Adicionais:

Entity Framework: Usado para ORM e migrações de banco de dados.
AutoMapper: Utilizado para mapear entre modelos de domínio e modelos de transferência de dados (DTOs).
JWT Middleware: Para validar e gerar tokens JWT para autenticação.
