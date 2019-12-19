using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase, ICreationController<Category>
    {
        public ICrudService<Category> Service { get; set; }

        public CategoryController(ICrudService<Category> p_service)
        {
            Service = p_service;
        }

        public IActionResult Create([FromBody]Category p_entity)
        {
            Service.Create(p_entity);

            return Ok();
        }
    }
}