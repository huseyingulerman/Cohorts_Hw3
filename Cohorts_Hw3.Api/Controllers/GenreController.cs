using AutoMapper;
using Cohorts_Hw3.Api.Aplications.GenreOperations.Commands;
using Cohorts_Hw3.Api.Aplications.GenreOperations.Queries;
using Cohorts_Hw3.Api.Validator.Genre;
using Cohorts_Hw3.DataAccess.Context;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_Hw3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_dbContext, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public ActionResult GetGenres(int id)
        {
            GetGenreDetailsQuery query = new GetGenreDetailsQuery(_dbContext, _mapper);
            query.Id = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_dbContext);
            command.Model = newGenre;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenreModel)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_dbContext);
            command.Model = updateGenreModel;
            command.GenreId = id;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);
            command.Id = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
