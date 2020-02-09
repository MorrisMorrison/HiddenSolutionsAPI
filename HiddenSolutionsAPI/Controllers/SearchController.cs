using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Model;
using HiddenSolutionsAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSolutionsAPI.Controllers
{
    
    
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController:ControllerBase
    {

        public ISearchService SearchService { get; set; }

        public SearchController(ISearchService p_searchService)
        {
            SearchService = p_searchService;
        }


        [HttpGet]
        public async Task<IActionResult> Search([FromQuery(Name="searchQuery")] string p_query)
        {
            return Ok( await SearchService.Search(p_query));
        }
        
        
    }
}