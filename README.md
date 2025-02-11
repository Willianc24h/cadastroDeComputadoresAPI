```markdown
# Cadastro de Computadores

Este repositório contém a implementação de uma API para o gerenciamento de cadastros de computadores. A API inclui operações de criação, leitura, atualização e exclusão (CRUD), além de funcionalidades específicas como inativação de cadastros.

## Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints](#endpoints)
  - [Criar Cadastro](#criar-cadastro)
  - [Excluir Cadastro](#excluir-cadastro)
  - [Listar Todos os Cadastros](#listar-todos-os-cadastros)
  - [Obter Cadastro por Tag](#obter-cadastro-por-tag)
  - [Inativar Cadastro](#inativar-cadastro)
  - [Atualizar Cadastro](#atualizar-cadastro)
  - [Login](#login)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Tecnologias Utilizadas

- **C#** com .NET
- **Entity Framework Core** para manipulação de banco de dados
- **SQL Server** como banco de dados
- **REST API**

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

```
CadastroDeComputadores
├── DataContext
│   └── AplicationDbContext.cs
├── Models
│   └── CadastroModel.cs
├── Services
│   └── CadastroService
│       ├── CadastroService.cs
│       └── ICadastroInterface.cs
└── Controllers
    └── CadastroController.cs
```

## Endpoints

### Criar Cadastro

**Descrição:** Cria um novo cadastro no sistema.

- **URL:** `/api/cadastro`
- **Método:** `POST`
- **Body:**
  ```json
  {
    "Tag": "string",
    "Nome": "string",
    "Ativo": true,
    "DataDeEntrada": "2024-12-01T12:00:00"
  }
  ```
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "Cadastro criado com sucesso",
    "dados": [
      {
        "Tag": "string",
        "Nome": "string",
        "Ativo": true,
        "DataDeEntrada": "2024-12-01T12:00:00"
      }
    ]
  }
  ```

---

### Excluir Cadastro

**Descrição:** Remove um cadastro existente com base na tag.

- **URL:** `/api/cadastro/{tag}`
- **Método:** `DELETE`
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "Deletado com sucesso",
    "dados": []
  }
  ```

---

### Listar Todos os Cadastros

**Descrição:** Retorna todos os cadastros do sistema.

- **URL:** `/api/cadastro`
- **Método:** `GET`
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "",
    "dados": [
      {
        "Tag": "string",
        "Nome": "string",
        "Ativo": true,
        "DataDeEntrada": "2024-12-01T12:00:00"
      }
    ]
  }
  ```

---

### Obter Cadastro por Tag

**Descrição:** Retorna um cadastro específico com base na tag fornecida.

- **URL:** `/api/cadastro/{tag}`
- **Método:** `GET`
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "",
    "dados": {
      "Tag": "string",
      "Nome": "string",
      "Ativo": true,
      "DataDeEntrada": "2024-12-01T12:00:00"
    }
  }
  ```

---

### Inativar Cadastro

**Descrição:** Marca um cadastro como inativo e define a data de saída.

- **URL:** `/api/cadastro/inativar/{tag}`
- **Método:** `PATCH`
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "Cadastro inativado com sucesso",
    "dados": []
  }
  ```

---

### Atualizar Cadastro

**Descrição:** Atualiza as informações de um cadastro existente.

- **URL:** `/api/cadastro`
- **Método:** `PUT`
- **Body:**
  ```json
  {
    "Tag": "string",
    "Nome": "string",
    "Ativo": true,
    "DataDeEntrada": "2024-12-01T12:00:00",
    "DataDeSaida": "2024-12-10T12:00:00"
  }
  ```
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "Cadastro atualizado com sucesso",
    "dados": []
  }
  ```

---

### Login

**Descrição:** Realiza o login do usuário, retornando um token de autenticação.

- **URL:** `/api/login`
- **Método:** `POST`
- **Body:**
  ```json
  {
    "usuario": "string",
    "senha": "string"
  }
  ```
- **Resposta:**
  ```json
  {
    "sucesso": true,
    "mensagem": "Login bem-sucedido",
    "token": "string"
  }
  ```

---

## Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/cadastro-de-computadores.git
   ```

2. Configure a string de conexão no arquivo `appsettings.json`.

3. Execute as migrações do Entity Framework:
   ```bash
   dotnet ef database update
   ```

4. Inicie a aplicação:
   ```bash
   dotnet run
   ```

## Contribuição

Contribuições são bem-vindas! Para contribuir, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch com sua feature: `git checkout -b minha-feature`.
3. Commit suas alterações: `git commit -m 'Minha nova feature'`.
4. Faça um push para a branch: `git push origin minha-feature`.
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
```

---

Agora, você tem a parte de **Login** incluída no seu `README.md`. Caso haja necessidade de ajustes, sinta-se à vontade para pedir!
