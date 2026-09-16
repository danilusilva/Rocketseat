# 📚 Gerenciador de Livraria

Uma API RESTful completa para gerenciamento de livros, construída com ASP.NET Core 10 e seguindo boas práticas de desenvolvimento.

## 🎯 Sobre o Projeto

Este projeto demonstra um sistema completo de CRUD (Create, Read, Update, Delete) para gerenciar um catálogo de livros com:

- ✅ Validações robustas de dados
- ✅ Tratamento de erros padronizado
- ✅ Atualização parcial de recursos
- ✅ Prevenção de duplicação
- ✅ Documentação automática com Swagger/OpenAPI
- ✅ Timestamps de criação e atualização

## 🛠️ Tecnologias

- **Linguagem**: C# (.NET 10.0)
- **Framework**: ASP.NET Core
- **Documentação**: Swagger/OpenAPI (Swashbuckle)
- **Ambiente**: Visual Studio Community 2026

## 📋 Pré-requisitos

- .NET 10.0 SDK instalado ([download](https://dotnet.microsoft.com/download))
- Visual Studio 2026 (Community/Professional/Enterprise) ou VS Code com C# extension
- Git (opcional, para clonar o repositório)

## 🚀 Como Executar

### Opção 1: Com Visual Studio

1. Abra a solução `GerenciadorDeLivraria.slnx`
2. Configure o projeto `GerenciadorDeLivraria` como projeto de inicialização
3. Pressione `F5` ou clique em **Executar**
4. A API será iniciada em `http://localhost:5137`

### Opção 2: Com Terminal

```powershell
# Navegar até o diretório do projeto
cd D:\Rocketseat\GerenciadorDeLivraria

# Restaurar pacotes NuGet
dotnet restore

# Executar a aplicação
dotnet run

# A API estará disponível em:
# HTTP:  http://localhost:5137
# HTTPS: https://localhost:7112
```

## 📖 Acessando a Documentação

Após iniciar a API, acesse:

- **Swagger UI**: http://localhost:5137/swagger/index.html
- **OpenAPI JSON**: http://localhost:5137/swagger/v1/swagger.json

A documentação interativa permite testar todos os endpoints diretamente pelo navegador.

## 🔗 Endpoints da API

### 1. Health Check

```http
GET /api/test
```

Retorna status de funcionamento da API.

**Resposta (200):**
```json
"API ESTÁ FUNCIONANDO CORRETAMENTE, PROSSIGA!"
```

### 2. Listar Todos os Livros

```http
GET /api/books
```

Retorna a lista completa de livros cadastrados.

**Resposta (200):**
```json
[
  {
	"id": "550e8400-e29b-41d4-a716-446655440000",
	"titulo": "Clean Code",
	"autor": "Robert C. Martin",
	"genero": "Ficção",
	"preco": 89.90,
	"estoque": 15
  }
]
```

### 3. Obter Livro por ID

```http
GET /api/books/{id}
```

Obtém um livro específico pelo seu ID.

**Parâmetros:**
- `id` (path, obrigatório): UUID do livro

**Resposta (200):**
```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "titulo": "Clean Code",
  "autor": "Robert C. Martin",
  "genero": "Ficção",
  "preco": 89.90,
  "estoque": 15
}
```

**Respostas de erro:**
- `404 Not Found`: "Livro não encontrado!"

### 4. Criar Novo Livro

```http
POST /api/books
Content-Type: application/json

{
  "titulo": "Clean Code",
  "autor": "Robert C. Martin",
  "genero": "Ficção",
  "preco": 89.90,
  "estoque": 15
}
```

**Body (obrigatório):**
- `titulo` (string, 2-120 caracteres): Título do livro
- `autor` (string, 2-120 caracteres): Autor do livro
- `genero` (string): Um dos valores válidos: "Ficção", "Romance", "Mistério", "Fantasia", "Biografia"
- `preco` (decimal, >= 0): Preço do livro
- `estoque` (integer, >= 0): Quantidade em estoque

**Resposta (201 Created):**
```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "titulo": "Clean Code",
  "autor": "Robert C. Martin",
  "genero": "Ficção",
  "preco": 89.90,
  "estoque": 15
}
```

**Respostas de erro:**
- `400 Bad Request`: Validação falhou (título muito curto/longo, gênero inválido, preço negativo, etc.)
- `409 Conflict`: Já existe um livro com esse título e autor

### 5. Atualizar Livro (Parcial)

```http
PUT /api/books/{id}
Content-Type: application/json

{
  "preco": 79.90,
  "estoque": 20
}
```

Atualiza apenas os campos fornecidos, mantendo os demais intactos.

**Parâmetros:**
- `id` (path, obrigatório): UUID do livro

**Body (opcional, mas ao menos um campo necessário):**
- `titulo` (string, nullable, 2-120 caracteres)
- `autor` (string, nullable, 2-120 caracteres)
- `genero` (string, nullable)
- `preco` (decimal, nullable, >= 0)
- `estoque` (integer, nullable, >= 0)

**Resposta (204 No Content):** Sem corpo

**Respostas de erro:**
- `400 Bad Request`: Nenhum campo fornecido ou validação falhou
- `404 Not Found`: "Livro não encontrado!"
- `409 Conflict`: Duplicação de título + autor com outro livro

### 6. Deletar Livro

```http
DELETE /api/books/{id}
```

Remove um livro do sistema.

**Parâmetros:**
- `id` (path, obrigatório): UUID do livro

**Resposta (204 No Content):** Sem corpo

**Respostas de erro:**
- `404 Not Found`: "Livro não encontrado!"

## 🧪 Testando a API

### Usando REST Client (VS Code Extension)

1. Instale a extensão "REST Client" do VS Code
2. Abra o arquivo `GerenciadorDeLivraria.http`
3. Clique em "Send Request" acima de cada requisição

### Usando cURL

```bash
# Criar um livro
curl -X POST http://localhost:5137/api/books \
  -H "Content-Type: application/json" \
  -d '{
	"titulo": "Clean Code",
	"autor": "Robert C. Martin",
	"genero": "Ficção",
	"preco": 89.90,
	"estoque": 15
  }'

# Listar todos os livros
curl http://localhost:5137/api/books

# Obter um livro específico
curl http://localhost:5137/api/books/550e8400-e29b-41d4-a716-446655440000

# Atualizar um livro
curl -X PUT http://localhost:5137/api/books/550e8400-e29b-41d4-a716-446655440000 \
  -H "Content-Type: application/json" \
  -d '{"preco": 79.90}'

# Deletar um livro
curl -X DELETE http://localhost:5137/api/books/550e8400-e29b-41d4-a716-446655440000
```

### Usando Postman

1. Importe o arquivo `GerenciadorDeLivraria.http` ou crie uma coleção
2. Configure a variável `base_url` como `http://localhost:5137`
3. Execute as requisições conforme necessário

## 📁 Estrutura do Projeto

```
GerenciadorDeLivraria/
├── Attributes/
│   └── GeneroValidoAttribute.cs      # Validação customizada de gênero
├── Communication/
│   ├── Requests/
│   │   ├── RequestRegisterBookJson.cs   # DTO para criação de livro
│   │   └── RequestUpdateBookJson.cs     # DTO para atualização de livro
│   └── Responses/
│       ├── ResponseGetBookJson.cs       # DTO para resposta de GET
│       └── ResponseRegisterBookJson.cs  # DTO para resposta de POST
├── Controllers/
│   ├── BaseController.cs             # Controller base
│   ├── BookController.cs             # Endpoints de livros
│   └── TestController.cs             # Health check
├── Models/
│   └── Book.cs                       # Modelo de domínio
├── Repositories/
│   └── BookRepository.cs             # Acesso aos dados (em memória)
├── Properties/
│   └── launchSettings.json           # Configurações de launch
├── Program.cs                        # Configuração da aplicação
├── GerenciadorDeLivraria.http        # Testes REST Client
├── GerenciadorDeLivraria.csproj      # Arquivo de projeto
├── appsettings.json                  # Configurações gerais
├── appsettings.Development.json      # Configurações desenvolvimento
└── README.md                         # Este arquivo
```

## ✅ Validações Implementadas

### Criação de Livro (POST)

- ✓ Título obrigatório
- ✓ Título com 2-120 caracteres
- ✓ Autor obrigatório
- ✓ Autor com 2-120 caracteres
- ✓ Gênero obrigatório e válido
- ✓ Preço não-negativo
- ✓ Estoque não-negativo
- ✓ Prevenção de duplicação (título + autor)

### Atualização de Livro (PUT)

- ✓ Livro deve existir
- ✓ Ao menos um campo deve ser fornecido
- ✓ Campos opcionais com validação quando fornecidos
- ✓ Prevenção de duplicação ao atualizar título/autor
- ✓ Atualização automática de timestamp (UpdatedAt)

### Deleção de Livro (DELETE)

- ✓ Livro deve existir

## 🔍 Cenários de Teste

O arquivo `GerenciadorDeLivraria.http` contém exemplos de teste para:

1. ✅ Health check
2. ✅ Listar todos os livros (vazio)
3. ✅ Criar livro com sucesso
4. ✅ Criar segundo livro
5. ❌ Tentativa de duplicação
6. ❌ Título muito curto
7. ❌ Gênero inválido
8. ❌ Preço negativo
9. ✅ Obter livro por ID
10. ❌ Obter livro inexistente
11. ✅ Atualizar apenas um campo
12. ✅ Atualizar múltiplos campos
13. ❌ Atualização sem campos
14. ❌ Atualizar livro inexistente
15. ❌ Duplicação ao atualizar
16. ✅ Deletar livro
17. ❌ Deletar livro inexistente

## 🎓 Aprendizados

Este projeto demonstra:

- **Arquitetura limpa**: Separação clara de responsabilidades (Controllers, Models, DTOs, Repositories)
- **Validação de dados**: Uso de Data Annotations e atributos customizados
- **Tratamento de erros**: Retornos HTTP apropriados para cada cenário
- **Boas práticas RESTful**: Verbos HTTP corretos, status codes, padrão de rotas
- **Documentação automática**: Swagger/OpenAPI para descoberta de API
- **DTOs**: Separação entre modelos de domínio e comunicação

## 📝 Notas

- Os dados são armazenados em memória e serão perdidos ao reiniciar a aplicação
- Para dados persistentes, integre um banco de dados (SQL Server, PostgreSQL, etc.)
- O projeto está configurado para HTTPS em produção e HTTP em desenvolvimento

## 🤝 Contribuições

Este é um projeto de portfólio da Rocketseat. Fique à vontade para clonar e estudar!

## 📄 Licença

Projeto pessoal de aprendizado.

---

**Desenvolvido com ❤️ durante o bootcamp Rocketseat**
