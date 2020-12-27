using Authentication.Exceptions;
using System;

namespace Authentication.Model.UserModel
{
    public class UserID : IComparable
    {
        public long Id { get; set; }
        public char Code { get; set; }
        public int Number { get; set; }

        public static UserID defaultDoctor = new UserID("d0");
        public static UserID defaultPatient = new UserID("p0");
        public static UserID defaultSecretary = new UserID("s0");
        public static UserID defaultManager = new UserID("m0");

        public UserID() { }

        public UserID(string id)
        {
            if(id == null || id.Length < 2)
            {
                throw new InvalidUserIdException();
            }

            Code = id[0];
            try
            {
                Number = Convert.ToInt32(id.Substring(1));
            }
            catch(Exception e)
            {
                throw new InvalidUserIdException("Invalid User ID", e);
            }
        }

        public override string ToString()
        {
            return Code.ToString() + Number;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            UserID otherID = obj as UserID;
            if(Code == otherID.Code)
            {
                return Number.CompareTo(otherID.Number);
            }
            else
            {
                return 1;
            }
        }

        public override bool Equals(object obj)
        {
            UserID otherId = obj as UserID;
            return Code == otherId.Code && Number == otherId.Number;
        }

        public UserID Increment()
        {
            Number++;
            return this;
        }

        public UserType GetUserType()
        {
            return Code switch
            {
                'p' => UserType.PATIENT,
                'd' => UserType.DOCTOR,
                'm' => UserType.MANAGER,
                's' => UserType.SECRETARY,
                _ => throw new InvalidUserIdException(this.ToString()),
            };
        }

        public override int GetHashCode()
        {
            return 999769 * Code.GetHashCode() + Number.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}