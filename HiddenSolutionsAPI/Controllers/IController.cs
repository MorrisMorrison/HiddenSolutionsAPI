using System.Threading.Tasks;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    public interface ICrudController<T>
    {
        ICrudService<T> Service { get; set; }
        Task<IActionResult> Create([FromBody] T p_entity);
        Task<IActionResult> Get([FromQuery(Name = "id")] string p_id);
        IActionResult Update([FromBody] T p_entity);
        IActionResult Delete([FromQuery(Name = "id")] string p_id);
    }

}
