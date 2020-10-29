// File:    IFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:54:24
// Purpose: Definition of Interface IFeedbackRepository

using SIMS.Model.UserModel;
using System;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface IFeedbackRepository : IRepository<Feedback, long>
    {
    }
}