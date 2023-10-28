using EvenTech.Models;

namespace EvenTech.Dtos
{
    public class OverviewDto
    {
        public uint EventId { get; set; }

        public ICollection<OverviewItemDto>? Items { get; set; }
    }
}
