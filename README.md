# 📌 Backend - API REST (ASP.NET Core)

Este é o projeto backend desenvolvido em **ASP.NET Core**, seguindo a **arquitetura limpa** e princípios **SOLID**.

## 🚀 Tecnologias Utilizadas
- **ASP.NET Core 6**
- **Entity Framework Core**
- **In-Memory Database** (banco de dados em memória para testes)
- **Swagger**
- **xUnit**
- **Moq**

## 📂 Estrutura do Projeto
```
Backend/
│── doc/                     # Contém a coleção para testes no Postman
│── src/                     # Contém todos os projetos da aplicação      
    │── Application/         # Camada de Aplicação (Interfaces de serviço)
    │── Domain/              # Camada de Entidades e Interfaces de repositórios
    │── Services/            # Camada de Implementação dos Serviços
    │── Infra/               # Camada de Implementação dos Repositórios
    │── API/                 # Camada de Apresentação (API REST)
    │── tests/               # Testes Unitários
```

A API estará disponível em: `http://localhost:7080`

## 📌 Endpoints Disponíveis
| Método | Rota | Descrição |
|--------|------|------------|
| GET    | /api/clients | Lista todos os clientes |
| POST   | /api/clients/create | Cria um novo cliente |
| PUT    | /api/clients/update/{id} | Atualiza um cliente |
| DELETE | /api/clients/delete/{id} | Exclui um cliente |
| GET    | /api/products | Lista todos os produtos |
| POST   | /api/products/create | Cria um novo produto |
| PUT    | /api/products/update/{id} | Atualiza um produto |
| DELETE | /api/products/delete/{id} | Exclui um produto |

### 3️⃣ **Acessar o Swagger**
Abra o navegador e acesse:
```
http://localhost:7080/swagger
```