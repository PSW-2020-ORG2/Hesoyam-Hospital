﻿using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Documents.Service.Abstract
{
    public interface IDoctorService : IService<Doctor, long>
    {
        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);
    }
}
