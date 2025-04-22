# Configuração do Ambiente Local

## Visão Geral

Este guia descreve os passos necessários para configurar e rodar a aplicação **Task Manager API** em seu ambiente local, dentro de um container docker.

---

## Requisitos

Certifique-se de que o ambiente de desenvolvimento possui os seguintes componentes instalados:

2. **Docker Desktop** (para container com banco de dados local)
   - [Download Docker](https://www.docker.com/products/docker-desktop/)

---

## Clonando o Repositório

1. Clone o repositório do projeto para sua máquina local:

   ```bash
   git clone https://github.com/mitczuck/TaskManager
   ```

2. Acesse o diretório do projeto:

   ```bash
   cd TaskManager
   ```

---

## Criando banco de dados local no Docker

1. Com o Docker Desktop já instalado na máquina execute o seguinte comando no **powershell** prompt, em modo **administrador**:

   ```bash
	docker pull mcr.microsoft.com/mssql/server:2022-latest

	docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Donothackme123!" -p 1433:1433 --name sql2 --hostname sql2 -d mcr.microsoft.com/mssql/server:2022-latest
   ```

2. Crie o banco de dados:

   ```bash
   docker exec -it sql2 /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "Donothackme123!" -C -d master -Q "CREATE DATABASE TaskManagerDB"
   ```

3. Executar migration para criar a estrutura do babco de dados:

   ```bash   
   dotnet tool update --global dotnet-ef   
   
   dotnet ef database update --startup-project src/TaskManager.API --project src/TaskManager.Infrastructure --connection "Server=localhost,1433;Database=TaskManagerDB;User=sa;Password=Donothackme123!;TrustServerCertificate=True"
   ```

4. Publicar a API em um container docker:

   ```bash   
   docker build -t task-manager:latest .
   
   docker run -d -p 4000:4000 task-manager:latest
   ```

5. Acessar a URL da API no localhost: 

   ```bash   
   http://localhost:4000/swagger/index.html
   ```

---

## Refinamento (Questões para o PO) 

1. Descrever

---

## Final (Melhorias)

** 1. Trocar Lazy Loading por Includes estratégicos **

Carregar só os dados necessários em cada endpoint, melhorando performance.

** 2. Padronizar todos os métodos como async **

Tornar a API mais escalável com processamento não-bloqueante.

** 3. Adicionar Redis para cache de consultas **

Reduzir a carga no banco para dados acessados com frequência.

** 4. Implementar validação nos DTOs **

Garantir dados corretos antes de processar, evitando erros.

** 5. Criar um sistema simples de Health Check **

Monitorar se o banco e serviços externos estão respondendo.

** 6. Colocaria a tabela de Historico da Tarefa em um DB NoSql **

Bancos NoSql são mais adequados para armazenar Logs e Dados históricos.

---

