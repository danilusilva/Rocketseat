using GerenciadorDeLivraria.Communication.Requests;
using GerenciadorDeLivraria.Communication.Responses;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseGetBookJson>), StatusCodes.Status200OK)]
    public IActionResult GetAllLivros()
    {
        var livros = BookRepository.Books;
        var response = livros.Select(livro => new ResponseGetBookJson
        {
            Id  = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Genero = livro.Genero,
            Preco = livro.Preco,
            Estoque = livro.Estoque,
        }).ToList();
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseGetBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetLivro(Guid id)
    {
        var livro = BookRepository.Books.FirstOrDefault(b => b.Id == id);    

        if (livro is null)
            return NotFound("Livro não encontrado!");

        var response = new ResponseGetBookJson
        {
            Id = livro.Id,
            Autor = livro.Autor,
            Titulo = livro.Titulo,
            Genero = livro.Genero,
            Estoque = livro.Estoque,
            Preco = livro.Preco
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    public IActionResult AddLivro([FromBody] RequestRegisterBookJson requestLivro)
    {
        var duplicado = BookRepository.Books.Any(b => b.Titulo == requestLivro.Titulo && b.Autor == requestLivro.Autor);
        if (duplicado)
            return Conflict("Já existe um livro com esse título e autor!");
        var livro = new Book
        {
            Autor   = requestLivro.Autor,
            Titulo  = requestLivro.Titulo,
            Genero  = requestLivro.Genero,
            Estoque = requestLivro.Estoque,
            Preco   = requestLivro.Preco,
        };

        BookRepository.Books.Add(livro);

        var response = new ResponseRegisterBookJson
        {
            Id  =    livro.Id,
            Titulo = livro.Titulo,
            Autor = requestLivro.Autor,
            Genero = livro.Genero,
            Preco = livro.Preco,
            Estoque = livro.Estoque
        };
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    public IActionResult UpdateLivro([FromRoute] Guid id, [FromBody] RequestUpdateBookJson requestUpdate)
    {
        var livro = BookRepository.Books.FirstOrDefault(b => b.Id == id);
        if (livro is null)
            return NotFound("Livro não encontrado!");

        // Verificar se pelo menos um campo foi fornecido para atualização
        if (string.IsNullOrWhiteSpace(requestUpdate.Titulo) &&
            string.IsNullOrWhiteSpace(requestUpdate.Autor) &&
            string.IsNullOrWhiteSpace(requestUpdate.Genero) &&
            requestUpdate.Preco is null &&
            requestUpdate.Estoque is null)
            return BadRequest("Nenhum campo para atualizar foi fornecido!");

        // Verificar duplicação se Título ou Autor foram alterados
        if ((!string.IsNullOrWhiteSpace(requestUpdate.Titulo) || !string.IsNullOrWhiteSpace(requestUpdate.Autor)))
        {
            var novoTitulo = !string.IsNullOrWhiteSpace(requestUpdate.Titulo) ? requestUpdate.Titulo : livro.Titulo;
            var novoAutor = !string.IsNullOrWhiteSpace(requestUpdate.Autor) ? requestUpdate.Autor : livro.Autor;

            var duplicado = BookRepository.Books.Any(b => 
                b.Id != id && 
                b.Titulo == novoTitulo && 
                b.Autor == novoAutor);

            if (duplicado)
                return Conflict("Já existe um livro com esse título e autor!");
        }

        // Atualizar apenas os campos fornecidos
        if (!string.IsNullOrWhiteSpace(requestUpdate.Titulo))
            livro.Titulo = requestUpdate.Titulo;

        if (!string.IsNullOrWhiteSpace(requestUpdate.Autor))
            livro.Autor = requestUpdate.Autor;

        if (!string.IsNullOrWhiteSpace(requestUpdate.Genero))
            livro.Genero = requestUpdate.Genero;

        if (requestUpdate.Preco.HasValue)
            livro.Preco = requestUpdate.Preco.Value;

        if (requestUpdate.Estoque.HasValue)
            livro.Estoque = requestUpdate.Estoque.Value;

        // Atualizar timestamp de modificação
        livro.UpdatedAt = DateTime.Now;

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult DeleteLivro([FromRoute] Guid id)
    {
        var livro = BookRepository.Books.FirstOrDefault(b => b.Id == id);
        if (livro is null)
            return NotFound("Livro não encontrado!");

        BookRepository.Books.Remove(livro);

        return NoContent();
    }
}
