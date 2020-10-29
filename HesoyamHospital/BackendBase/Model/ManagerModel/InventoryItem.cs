// File:    InventoryItem.cs
// Author:  vule
// Created: 18. april 2020 16:53:25
// Purpose: Definition of Class InventoryItem

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class InventoryItem : Item
    {
        private Room _room;

        public Room Room { get { return _room; } set { } }

        public InventoryItem(string name, int inStock, int minNumber, Room room) : base(name, inStock, minNumber)
        {
            _room = room;
        }

        public InventoryItem(long id,string name, int inStock, int minNumber, Room room) : base(id ,name, inStock, minNumber)
        {
            _room = room;
        }

        public InventoryItem(long id) : base(id) { }
    }
}