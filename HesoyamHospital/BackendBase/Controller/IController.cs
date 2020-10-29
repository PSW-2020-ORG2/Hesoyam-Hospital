// File:    IController.cs
// Author:  Geri
// Created: 20. maj 2020 12:00:24
// Purpose: Definition of Interface IController

using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IController<T,ID>
   {
      IEnumerable<T> GetAll();
      
      T GetByID(ID id);
      
      T Create(T entity);
      
      void Update(T entity);
      
      void Delete(T entity);
   
   }
}