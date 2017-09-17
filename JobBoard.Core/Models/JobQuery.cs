using JobBoard.Core.DTOs;

namespace JobBoard.Core.Models
{
    public class JobQuery : IQueryObject
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
