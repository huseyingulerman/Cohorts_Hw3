using AutoMapper;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Commands;
using Cohorts_Hw3.Api.Aplications.AuthorOperations.Queries;
using Cohorts_Hw3.Api.Validator.Author;
using Cohorts_Hw3.DataAccess.Context;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_Hw3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_dbContext, _mapper);
            var author = query.Handle();
            return Ok(author);
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetByIdAuthorQuery query = new GetByIdAuthorQuery(_dbContext, _mapper);
            query.Id = id;

            GetByIdAuthorValidator validation = new GetByIdAuthorValidator();
            validation.ValidateAndThrow(query);

            var author = query.Handle();
            return Ok(author);
        }
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AddAuthorViewModel author)
        {
            AddAuthorCommand command = new AddAuthorCommand(_dbContext, _mapper);
            command.Model = author;

            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorViewModel author)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);
            command.Model = author;
            command.Id = id;

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            command.Id = id;

            DeleteAuthorValidator validation = new DeleteAuthorValidator();
            validation.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
