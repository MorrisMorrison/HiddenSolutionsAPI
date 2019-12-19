using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    public class TagController:ControllerBase, ICreationController<Tag>
    {
        public ICrudService<Tag> Service { get; set; }

        public TagController(ICrudService<Tag> p_service)
        {
            Service = p_service;
        }

        public IActionResult Create([FromBody] Tag p_entity)
        {
            Service.Create(p_entity);

            return Ok();
        }
    }
}