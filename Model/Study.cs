using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudies.Model
{
    public class Study
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Subject>? Subjects { get; set; } = new List<Subject>();
        public List<FlashCard>? FlashCards { get; set; } = new List<FlashCard>();
    }
}