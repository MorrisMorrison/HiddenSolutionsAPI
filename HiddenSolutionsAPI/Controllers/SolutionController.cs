using System.Security.Cryptography;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    public class SolutionController:ControllerBase, ICrudController<Solution>
    {
        public ICrudService<Solution> Service { get; set; }

        public SolutionController(ICrudService<Solution> p_service)
        {
            Service = p_service;
        }

        public IActionResult Create([FromBody] Solution p_entity)
        {
            Service.Create(p_entity);

            return Ok();
        }

        public async Task<IActionResult> Get([FromQuery(Name="id")]long p_id)
        {
            Solution solution = await Service.Get(p_id);

            if (solution != null)
            {
                return Ok(solution);
            }

            return BadRequest();
        }

        public IActionResult Update(Solution p_entity)
        {
            Service.Update(p_entity);

            return Ok();
        }

        public IActionResult Delete(long p_id)
        {
            Service.Delete(p_id);

            return Ok();
        }
    }
}