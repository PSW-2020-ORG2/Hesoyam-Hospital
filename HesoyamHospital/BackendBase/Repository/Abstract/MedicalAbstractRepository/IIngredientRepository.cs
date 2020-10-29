// File:    IIngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:23:32
// Purpose: Definition of Interface IIngredientRepository

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface IIngredientRepository : IRepository<Ingredient, long>
    {
    }
}