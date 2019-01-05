using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDesc.Models
{
    public class TechnicalTask
    {
        public Guid Id { get; set; }
        public ApplicationUser TaskCreator { get; set; }
        public ApplicationUser TaskPerformer { get; set; }
        public DateTime CreationDate { get; set; }
        public string Cabinet { get; set; }
        public string Comment { get; set; }
        public bool IsComplete { get; set; }

        public TechnicalTask()
        {

        }

        public TechnicalTask(ApplicationUser creator, string cabinet, string comment)
        {
            Id = Guid.NewGuid();
            TaskCreator = creator;
            CreationDate = DateTime.Now;
            Cabinet = cabinet;
            Comment = comment;
            IsComplete = false;
        }
    }
}