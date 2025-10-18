using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudies.Model.Entities;

namespace MyStudies.Model.DTOs.Response
{
    public class UpdateStudyResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<SubjectResponse> Subjects { get; set; }

        public UpdateStudyResponse(Study study)
        {
            Id = study.Id;
            Title = study.Title;
            Description = study.Description;
            Content = study.Content;
            Subjects = study.Subjects.Select(s => new SubjectResponse(s.Id, s.Name)).ToList();
        }
        public record SubjectResponse(
            int Id,
            string Name
        );


    }
}