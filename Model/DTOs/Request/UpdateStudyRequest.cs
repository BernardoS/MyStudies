using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudies.Model.DTOs.Request
{
    public class UpdateStudyRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int[] SubjectsIds { get; set; }
    }
}