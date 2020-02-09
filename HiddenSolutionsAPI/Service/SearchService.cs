using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiddenSolutionsAPI.Persistence.Dao;
using HiddenSolutionsAPI.Persistence.Model;

namespace HiddenSolutionsAPI.Service
{

    public interface ISearchService
    {
        IDaoAsync<Solution> Dao { get; set; }

        Task<IList<Solution>> Search(string p_searchQuery);
    }
    public class SearchService:ISearchService
    {
        public IDaoAsync<Solution> Dao { get; set; }


        public SearchService(IDaoAsync<Solution> p_dao)
        {
            Dao = p_dao;
        }

        public async Task<IList<Solution>> Search(string p_searchQuery)
        {
            try
            {
                IEnumerable<Solution> task = await Dao.GetAllAsync();
                List<Solution> solutions = task.ToList();
                string[] searchKeywords = p_searchQuery.Split(" ");

                return solutions.Where(p_solution =>
                {
                    foreach (string searchKeyword in searchKeywords)
                    {
                        if (p_solution.Title.ToLower().Contains(searchKeyword.ToLower()))
                        {
                            return true;
                        }
                    }

                    return false;
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Solution>();
            }
        }
    }
}