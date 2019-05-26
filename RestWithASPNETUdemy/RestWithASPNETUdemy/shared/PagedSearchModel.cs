using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.shared
{
    public class PagedSearchModel<T> where T : BaseEntity
    {
        public PagedSearchModel(List<T> results, int totalResults)
        {
            Results = results;
            TotalResults = totalResults;
        }

        public List<T> Results { get; private set; }
        public int TotalResults { get; private set; }
    }
}
