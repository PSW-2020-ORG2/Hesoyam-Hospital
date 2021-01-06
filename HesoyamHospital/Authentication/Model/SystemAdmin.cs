﻿using Authentication.Util;
using System;

namespace Authentication.Model
{
    public class SystemAdmin : User
    {
        public SystemAdmin(long id) : base(id)
        {
        }

        public SystemAdmin(string userName,
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
                : base(userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }
    }
}
