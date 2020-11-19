using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Feedback
{
    public class FeedbackDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public bool Published { get; set; }
    }
}
