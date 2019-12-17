using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Resources;
using Todo.Api.Validations;
using Todo.Core.Models;
using Todo.Services;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TodoTaskController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            this._mapper = mapper;
            this._todoTaskService = todoTaskService;
        }

        // GET: api/TodoTask
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TodoTaskResource>>> Get([FromQuery]int? CategoryID, [FromQuery]string? Description, [FromQuery]bool? IsActive)
        {
            var todoTasks = await _todoTaskService.GetByParams(CategoryID, Description, IsActive);
            var todoTaskResources = _mapper.Map<IEnumerable<TodoTask>, IEnumerable<TodoTaskResource>>(todoTasks);

            return Ok(todoTaskResources);
        }



        // POST: api/TodoTask
        [HttpPost]
        public async Task<ActionResult<TodoTaskResource>> Post([FromForm]TodoTaskResource saveTodoTaskResource)
        {
            var validator = new SaveTodoTaskResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTodoTaskResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var todoTaskToCreate = _mapper.Map<TodoTaskResource, TodoTask>(saveTodoTaskResource);
            todoTaskToCreate.IsActive = true;
            todoTaskToCreate.CreationDate = DateTime.Now;
            todoTaskToCreate.LastModifiedDate = DateTime.Now;
            var newTodoTask = await _todoTaskService.CreateTodoTask(todoTaskToCreate);

            var todoTask = await _todoTaskService.GetTodoTaskById(newTodoTask.TodoTaskID);
            var todoTaskResource = _mapper.Map<TodoTask, TodoTaskResource>(todoTask);

            return Ok(todoTaskResource);

        }

        // PUT: api/TodoTask/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoTaskResource>> Put(int id, [FromBody]TodoTaskResource saveTodoTaskResource)
        {
            var validator = new SaveTodoTaskResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTodoTaskResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var taskTodoToBeUpdate = await _todoTaskService.GetTodoTaskById(id);

            if (taskTodoToBeUpdate == null)
                return NotFound();

            var todoTask = _mapper.Map<TodoTaskResource, TodoTask>(saveTodoTaskResource);
            todoTask.LastModifiedDate = DateTime.Now;
            await _todoTaskService.UpdateStatusTodoTask(taskTodoToBeUpdate, todoTask);

            var updatedTodoTask = await _todoTaskService.GetTodoTaskById(id);
            var updatedTodoTaskResource = _mapper.Map<TodoTask, TodoTaskResource>(updatedTodoTask);

            return Ok(updatedTodoTaskResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTaskResource>> GetById(int id)
        {
            var todotask = await _todoTaskService.GetTodoTaskById(id);
            var todoTaskResource = _mapper.Map<TodoTask, TodoTaskResource>(todotask);
            todoTaskResource.FileContent = todotask.FileContent;
            return Ok(todoTaskResource);
        }
    }
}
