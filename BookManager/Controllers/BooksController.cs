using BookManager.Model;
using BookManager.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository repository;
        private readonly ICostomLogRepository costomLogRepository;

        public BooksController(IBookRepository pRepository, ICostomLogRepository pCostomLogRepository)
        {
            repository = pRepository;
            costomLogRepository = pCostomLogRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var books = await repository.GetBooksAsync();
                if (books != null && books.Any())
                {
                    return Ok(books);
                }
                else
                {
                    return NotFound("Books not exiists");
                }
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpGet("skip/{skip:int}/take/{take:int}/name/{name}")]
        public async Task<IActionResult> GetFilter(
            [FromRoute] int skip,
            [FromRoute] int take,
            [FromRoute] string name)
        {
            try
            {
                var books = await repository.GetFilter(skip, take, name);
                if (books != null && books.Any())
                {
                    return Ok(books);
                }
                else
                {
                    return NotFound("Books not exiists");
                }
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var book = await repository.GetBooksByIdAsync(id);
                return book != null
                        ? Ok(book)
                        : BadRequest("Book not found");
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> put(Book book)
        {

            try
            {
                if (book == null) return BadRequest("Dados Inválidos");

                var bookDB = await repository.GetBooksByIdAsync(book.id);
                if (string.IsNullOrWhiteSpace(book.decription))
                {
                    bookDB.decription = book.decription;
                }
                if (string.IsNullOrWhiteSpace(book.author))
                {
                    bookDB.author = book.author;
                }
                if (string.IsNullOrWhiteSpace(book.name))
                {
                    bookDB.name = book.name;
                }
                if (string.IsNullOrWhiteSpace(book.isnb))
                {
                    bookDB.isnb = book.isnb;
                }
                repository.Update(bookDB);

                return await repository.SaveChangesAsync()
                    ? Ok("Book adicionado com sucesso")
                    : BadRequest("Erro ao salvar o book");
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete("id/{id:int}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var book = await repository.GetBooksByIdAsync(id);
                repository.Delete(book);

                return await repository.SaveChangesAsync()
                    ? Ok("Book excluido com sucesso.")
                    : BadRequest("Erro ao excluir o book.");
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            try
            {
                if (book == null ||
                string.IsNullOrWhiteSpace(book.name) ||
                string.IsNullOrWhiteSpace(book.decription) ||
                string.IsNullOrWhiteSpace(book.isnb) ||
                 string.IsNullOrWhiteSpace(book.author) ||
                  book.idCategory <= 0 ||
                  book.idPublisher <= 0 ||
                  book.year <= 0
                 )
                {
                    return BadRequest("Dados Inválidos");
                }

                var checkExists = await repository.bookCheckExists(book);
                if (checkExists)
                {
                    return BadRequest("Book exists.");
                }
                repository.Add(book);

                return await repository.SaveChangesAsync()
                    ? Ok("Book adicionado com sucesso")
                    : BadRequest("Erro ao salvar o book");
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }


        }

        [AllowAnonymous]
        [HttpGet("load/qtd/{qtd:int}")]
        public async Task<IActionResult> load(int qtd)
        {
            try
            {
                bool controle = false;
                if (qtd > 1000)
                    return BadRequest("Maximo 1000");

                int max = await repository.getMaxIdBook();
                for (int i = max + 1; i < (qtd + max + 1); i++)
                {
                    var book = new Book
                    {

                        name = $"Nome Book {i}",
                        decription = $"Description book {i}",
                        author = "author",
                        idCategory = 1,
                        isnb = $"9999{i}",
                        year = 2004,
                        idPublisher = 1,
                        exemplary = i
                    };
                    repository.Add(book);

                }
                controle = await repository.SaveChangesAsync();
                return controle
                    ? Ok("Load com sucesso")
                    : BadRequest("Erro");
            }
            catch (Exception ex)
            {
                logger("Get", ex.ToString());
                return BadRequest(ex.Message);
            }

        }

        private void logger(string pOperation, string pTrace)
        {
            try
            {
                var log = new CustomLog() { operation = pOperation, trace = pTrace, createAt = DateTime.Now };
                costomLogRepository.Add(log);
                costomLogRepository.SaveChangesAsync();
            }
            catch
            {
                //não sobe, grava no event viwer
            }


        }


    }
}