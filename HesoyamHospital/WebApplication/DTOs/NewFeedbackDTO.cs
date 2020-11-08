using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTOs
{
    public class NewFeedbackDTO
    {
        private string _comment;
        public string Comment { get => _comment; set => _comment = value; }

        private bool _anonymous;
        public bool Anonymous { get => _anonymous; set => _anonymous = value; }

        private bool _public;
        public bool Public { get => _public; set => _public = value; }

        public NewFeedbackDTO() { }

        public NewFeedbackDTO(string _comment, bool _anonymous, bool _public)
        {
            this._comment = _comment;
            this._anonymous = _anonymous;
            this._public = _public;
        }
    }
}
