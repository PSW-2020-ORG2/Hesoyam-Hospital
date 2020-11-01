// File:    TimeTable.cs
// Author:  Geri
// Created: 18. april 2020 19:37:52
// Purpose: Definition of Class TimeTable

using Backend.Repository.Abstract;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Model.UserModel
{
    public class TimeTable : IIdentifiable<long>
    {
        public long id { get; set; }
        [NotMapped]
        private Dictionary<WorkingDaysEnum, TimeInterval> _workingHours;
        [NotMapped]
        public Dictionary<WorkingDaysEnum, TimeInterval> WorkingHours { get => _workingHours; set => _workingHours = value; }

        public TimeTable(Dictionary<WorkingDaysEnum, TimeInterval> workingHours)
        {
            _workingHours = workingHours;
        }

        public TimeTable(long id, Dictionary<WorkingDaysEnum, TimeInterval> workingHours)
        {
            id = id;
            _workingHours = workingHours;
        }

        public TimeTable()
        {
            _workingHours = new Dictionary<WorkingDaysEnum, TimeInterval>();
        }

        public TimeTable(long id)
        {
            id = id;
        }

        public bool Edit()
        {
            throw new NotImplementedException();
        }

        public Dictionary<WorkingDaysEnum, TimeInterval> getWorkingHours()
        {
            return _workingHours;
        }

        public void setWorkingHours(WorkingDaysEnum workingDaysEnum, TimeInterval timeInterval)
        {
            if (_workingHours.ContainsKey(workingDaysEnum))
            {
                _workingHours[workingDaysEnum] = timeInterval;
            }
            else
            {
                _workingHours.Add(workingDaysEnum, timeInterval);
            }
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            id = id;
        }

        public override bool Equals(object obj)
        {
            var table = obj as TimeTable;
            return table != null &&
                   id == table.id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + id.GetHashCode();
        }
    }
}