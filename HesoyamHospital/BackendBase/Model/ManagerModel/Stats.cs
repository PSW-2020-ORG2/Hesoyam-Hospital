// File:    Stats.cs
// Author:  vule
// Created: 18. april 2020 17:15:32
// Purpose: Definition of Class Stats

using SIMS.Repository.Abstract;
using System;

namespace SIMS.Model.ManagerModel
{
    public abstract class Stats: IIdentifiable<long>
    {
        private long _id;

        public Stats(long id)
        {
            _id = id;
        }

        public Stats()
        {

        }

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            var stats = obj as Stats;
            return stats != null &&
                   _id == stats._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}