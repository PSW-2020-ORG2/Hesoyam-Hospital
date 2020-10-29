// File:    IDoctorRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IDoctorRepository

using System;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.UsersAbstractRepository
{
    public interface IDoctorRepository : IRepository<Doctor, UserID>
    {
        IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType);

        IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter);

    }
}