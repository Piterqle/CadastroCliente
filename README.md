# 🚀 Cadastro de Clientes - .NET + DDD

Uma aplicação simples desenvolvida em **.NET**, utilizando **Domain-Driven Design (DDD)** para demonstrar uma arquitetura organizada, escalável e de fácil manutenção.

## 📌 Objetivo

Realizar o cadastro de clientes utilizando **SQLite** como banco de dados, aplicando boas práticas de separação de responsabilidades e arquitetura em camadas.

## 🏗️ Arquitetura

O projeto segue os princípios do **DDD**, organizado em camadas como:

* **Domain** → Entidades, regras de negócio e contratos.
* **Application** → Casos de uso e orquestração.
* **Infrastructure** → Persistência de dados com SQLite e implementação dos repositórios.
* **API** → Endpoints para comunicação com a aplicação.

## 🛠️ Tecnologias

* .NET
* ASP.NET Core
* Entity Framework Core
* SQLite
* Domain-Driven Design (DDD)

## ▶️ Executando o projeto

```bash
git clone <url-do-repositorio>

cd CadastroClientes

dotnet restore

dotnet run
```

Após iniciar a aplicação, a API estará disponível para realizar operações de cadastro de clientes.

## 📖 Objetivo do projeto

Este projeto possui caráter **didático**, servindo como exemplo de organização de uma aplicação em **DDD** utilizando **.NET** e **SQLite**.
