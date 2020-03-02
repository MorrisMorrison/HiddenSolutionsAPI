using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController:ControllerBase, ICrudController<Tag>
    {
        public ICrudService<Tag> Service { get; set; }

        public TagController(ICrudService<Tag> p_service)
        {
            Service = p_service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tag p_entity)
        {
            Tag tag = await Service.Create(p_entity);

            if (!string.IsNullOrEmpty(tag.Id))
            {
                return Ok(tag);
                
            }

            return NoContent();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "id")]string p_id)
        {
            if (!string.IsNullOrEmpty(p_id))
            {
                Tag tag = await Service.Get(p_id);
                if (tag != null)
                {
                    return Ok(tag);
                }
                
                return NoContent();
            }
            else
            {
                IEnumerable<Tag> tags = await Service.GetAll();
                if (tags.ToList().Any())
                {
                    return Ok(tags);
                }

                return NoContent();
            }
        }

        [HttpPatch]
        public IActionResult Update([FromBody]Tag p_entity)
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