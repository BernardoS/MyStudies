using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudies.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Study>? Studies { get; set; }
    }
}