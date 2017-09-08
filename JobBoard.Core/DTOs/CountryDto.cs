using System.Collections.Generic;

namespace JobBoard.Core.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public ICollection<StateDto> States { get; set; }
    }
}
