using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dtos
{
    public class FeedbackDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public bool Published { get; set; }

        public FeedbackDto() { }
    }
}
