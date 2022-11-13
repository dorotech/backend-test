﻿using APIBook.Model;
using APIBook.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly JwtAuth _jwtAuthentication;
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository, JwtAuth auth)
        {
            _bookRepository = bookRepository;
            _jwtAuthentication = auth;
        }



        // Qualquer usuario logado ou não pode utilizar
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var b = await _bookRepository.Get(); // Pegando a lista de livros representado por b
            return b.OrderBy(x => x.Title);   // Ordenar a ordem em Acresente pelo TITULO como julgado no teste
        }


        // Apenas usuarios autenticados podem usar
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            Book? book = await _bookRepository.GetById(id);  // irar chamar a função de get by ID e procurar na DB

            if (book == null)   // Se nesse caso retornar nenhum livro a variavel nomeada book sera nulla nesse caso deve se esperar o retorno NotFound codigo 404
                return NotFound();

            return book; // Caso contrario e encontrar algum livro do ID em questão é necessario retornar o objeto ao usuario
        }


        [Authorize (Roles = "admin,user")]
        [HttpGet("(Title){Title}")] // Esse argumento (Title) vai ser o indentificador da função para diferenciar a do ID
        public async Task<IEnumerable<Book>> GetBook(string Title)
        {
            var b = await _bookRepository.GetByName(Title); // Irar procurar na db qualquer livro que contem esse titulo sendo inteiro ou em pedaços
            return b;
        }






        // Apenas o ADMIN pode usar para postar, atualizar e deletar, respeite o admin. https://youtu.be/yxq0ZnjEENs
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var books = await _bookRepository.Get();
            Book? new_book = new Book();
            bool found = false;
            foreach (Book b in books)
            {
                if (b.Date == book.Date && b.Title.ToLower() == book.Title.ToLower())
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                new_book = await _bookRepository.Create(book);
                return CreatedAtAction(nameof(GetBook), new { id = new_book.Id }, new_book);

            }


            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult?> Delete(int id)
        {
            Book? book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();

            await _bookRepository.Delete(id);

            return NoContent();
        }


        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult?> PutBooks(int id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                await _bookRepository.Update(book);
                return Ok(book);
            }


            return NoContent();
        }

        // Qualquer anonimo pode autorizar
        [AllowAnonymous]
        [HttpPost("Auth")]

        public async Task<ActionResult<dynamic>> AuthUser([FromBody] User user)
        {
            string? token = _jwtAuthentication.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();

            return new {

                usuario = user.Username,
                tokken = token
            };

        }
    }

}
