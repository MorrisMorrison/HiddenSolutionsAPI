using System.Threading.Tasks;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    public interface ICrudController<T>
    {
        ICrudService<T> Service { get; set; }

        IActionResult Create([FromBody] T p_entity);
        Task<IActionResult> Get([FromQuery(Name = "id")] long p_id);
        IActionResult Update([FromBody] T p_entity);
        IActionResult Delete([FromQuery(Name = "id")] long p_id);

    }

    public interface ICreationController<T>
    {
        ICrudService<T> Service { get; set; }

        IActionResult Create([FromBody] T p_entity);
    }
}