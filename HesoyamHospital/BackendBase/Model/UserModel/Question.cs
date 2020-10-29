using SIMS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.UserModel
{
    public class Question : IIdentifiable<long>
    {
        private long _id;
        private string _text;

        public Question(long id) { _id = id; }

        public Question(long id, string text)
        {
            _id = id;
            _text = text;
        }

        public Question(string text) { _text = text; }

        public long Id { get => _id; set => _id = value; }
        public string Text { get => _text; set => _text = value; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Question q = obj as Question;
            return _id == q._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        
    }
}
