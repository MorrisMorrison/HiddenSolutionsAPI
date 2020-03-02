using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:ControllerBase, ICrudController<Category>
    {
        public ICrudService<Category> Service { get; set; }

        public CategoryController(ICrudService<Category> p_service)
        {
            Service = p_service;
        }

        [HttpPost]
        public async Task<IActionResult>   Create([FromBody]Category p_entity)
        {
            Category category = await Service.Create(p_entity);

            if (!string.IsNullOrEmpty(category.Id))
            {
                return Ok(category);
                
            }

            return NoContent();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name="id")]string p_id)
        {
            if (!string.IsNullOrEmpty(p_id))
            {
                Category category = await Service.Get(p_id);
                if (category != null)
                {
                    return Ok(category);
                }
                
                return NoContent();
            }
            else
            {
                IEnumerable<Category> categories = await Service.GetAll();
                if (categories.ToList().Any())
                {
                    return Ok(categories);
                }

                return NoContent();
            }
            

        }

        [HttpPatch]
        public IActionResult Update([FromBody]Category p_entity)
        {
            Service.Update(p_entity);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery(Name = "id")]string p_id)
        {
            Service.Delete(p_id);

            return Ok();
        }
    }
}