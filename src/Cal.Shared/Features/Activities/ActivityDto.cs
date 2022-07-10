using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cal.Shared.Features.Activities
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
