# Bookstore API

## Descrição

A Bookstore API é uma API simples desenvolvida para gerenciar informações de livros. Esta API permite realizar operações básicas como criar, listar, editar e excluir livros. O armazenamento dos dados é feito em memória, o que significa que os dados serão perdidos quando a aplicação for reiniciada. 

## Funcionalidades

- **Criar um Livro**: Adiciona um novo livro à lista. Se um livro com o mesmo título já existir, a quantidade de estoque é incrementada.
- **Listar Todos os Livros**: Retorna a lista de todos os livros armazenados na memória.
- **Editar um Livro**: Atualiza as informações de um livro existente com base no ID.
- **Excluir um Livro**: Remove um livro da lista com base no ID.

## Endpoints

### Criar um Livro

- **Método**: `POST`
- **URL**: `/book`
- **Corpo da Requisição**:
    ```json
    {
      "Title": "Título do Livro",
      "Author": "Autor do Livro",
      "Gender": "Gênero do Livro",
      "Price": 29.99,
      "StockQuantity": 10
    }
    ```
- **Resposta**:
    - `201 Created` - Se o livro for criado com sucesso.
    - `409 Conflict` - Se um livro com o mesmo título já existir e a quantidade de estoque for incrementada.

### Listar Todos os Livros

- **Método**: `GET`
- **URL**: `/book`
- **Resposta**:
    ```json
    [
      {
        "Id": 1,
        "Title": "Título do Livro",
        "Author": "Autor do Livro",
        "Gender": "Gênero do Livro",
        "Price": 29.99,
        "StockQuantity": 10
      }
    ]
    ```

### Editar um Livro

- **Método**: `PUT`
- **URL**: `/book/{id}`
- **Corpo da Requisição**:
    ```json
    {
      "Title": "Novo Título",
      "Author": "Novo Autor",
      "Gender": "Novo Gênero",
      "Price": 35.99,
      "StockQuantity": 15
    }
    ```
- **Resposta**:
    - `204 No Content` - Se o livro for atualizado com sucesso.
    - `404 Not Found` - Se o livro com o ID fornecido não for encontrado.

### Excluir um Livro

- **Método**: `DELETE`
- **URL**: `/book/{id}`
- **Resposta**:
    - `204 No Content` - Se o livro for excluído com sucesso.
    - `404 Not Found` - Se o livro com o ID fornecido não for encontrado.

## Como Executar

1. **Clone o Repositório**:
    ```bash
    git clone <URL_DO_REPOSITÓRIO>
    ```

2. **Navegue para o Diretório do Projeto**:
    ```bash
    cd <NOME_DO_DIRETÓRIO>
    ```

3. **Execute a Aplicação**:
    - **No Visual Studio**: Pressione `F5` para executar o projeto.
    - **No Terminal**: Execute o comando:
        ```bash
        dotnet run
        ```

4. **Acesse a API**:
    - A API estará disponível em `http://localhost:5000` (ou a porta configurada).

## Nota

Esta é uma API simples com armazenamento em memória para fins de desenvolvimento e testes. Para um ambiente de produção, recomenda-se a implementação de um banco de dados persistente.

## Licença

Este projeto é licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para detalhes.

