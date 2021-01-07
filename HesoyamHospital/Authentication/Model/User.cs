using Authentication.Util;
using System;
using System.Collections.Generic;

namespace Authentication.Model
{
    public class User : Person
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Deleted { get; set; }
        public virtual UserID Uid { get; set; }

        public User() : base() { }

        public User(long id) : base() {
            Id = id;
        }

        public User(string userName,
                    string password, 
                    DateTime dateCreated, 
                    string name, 
                    string surname, 
                    string middleName, 
                    string jmbg,
                    Sex sex, 
                    DateTime dateOfBirth, 
                    string uidn, 
                    Address address, 
                    string homePhone, 
                    string cellPhone, 
                    string email1, 
                    string email2) 
            : base(name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            UserName = userName;
            Password = password;
            DateCreated = dateCreated;
        }

        public User(string userName,
                    string password,
                    string name,
                    string surname,
                    string middleName,
                    string jmbg,
                    Sex sex,
                    DateTime dateOfBirth,
                    string uidn,
                    Address address,
                    string homePhone,
                    string cellPhone,
                    string email1)
            : base(name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1)
        {
            UserName = userName;
            Password = password;
        }

        public User(long id,
                    UserID uid,
                    string userName, 
                    string password, 
                    DateTime dateCreated, 
                    string name, 
                    string surname, 
                    string middleName, 
                    string jmbg,
                    Sex sex, 
                    DateTime dateOfBirth, 
                    string uidn, 
                    Address address, 
                    string homePhone, 
                    string cellPhone, 
                    string email1, 
                    string email2) 
            : base(name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Id = id;
            Uid = uid;
            UserName = userName;
            Password = password;
            DateCreated = dateCreated;
        }

        public User(string userName,
                    string password,
                    string name,
                    string surname,
                    string middleName,
                    string jmbg,
                    Sex sex,
                    DateTime dateOfBirth,
                    string uidn,
                    Address address,
                    string homePhone,
                    string cellPhone,
                    string email1,
                    string email2)
            : base(name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            UserName = userName;
            Password = password;
        }

        public User(long id,
                    UserID uid,
                    string username,
                    string password,
                    DateTime dateCreated,
                    bool deleted)
            : base()
        {
            Id = id;
            Uid = uid;
            UserName = username;
            Password = password;
            DateCreated = dateCreated;
            Deleted = deleted;
        }

        public UserType GetUserType()
            => Uid.GetUserType();

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            if (!(obj is User otherUser)) return false;
            return Id.Equals(otherUser.GetId());
        }

        public override int GetHashCode()
        {
            return 328612020 + EqualityComparer<UserID>.Default.GetHashCode(Uid);
        }
    }
}