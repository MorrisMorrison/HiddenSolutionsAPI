using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class SolutionController:ControllerBase, ICrudController<Solution>
    {
        public ICrudService<Solution> Service { get; set; }

        public SolutionController(ICrudService<Solution> p_service)
        {
            Service = p_service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Solution p_entity)
        {
            Service.Create(p_entity);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name="id")]string p_id)
        {
            if (!string.IsNullOrEmpty(p_id))
            {
                Solution solution = await Service.Get(p_id);
                if (solution != null)
                {
                    return Ok(solution);
                }
                
                return NoContent();
            }
            else
            {
                IEnumerable<Solution> solution = await Service.GetAll();
                if (solution.ToList().Any())
                {
                    return Ok(solution);
                }

                return NoContent();
            }
        }

        [HttpPatch]
        public IActionResult Update([FromBody]Solution p_entity)
        {
            Service.Update(p_entity);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery(Name = "id")] string p_id)
        {
            Service.Delete(p_id);

            return Ok();
        }
    }
}