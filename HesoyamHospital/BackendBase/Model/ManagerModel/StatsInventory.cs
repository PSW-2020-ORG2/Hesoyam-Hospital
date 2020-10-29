// File:    StatsInventory.cs
// Author:  vule
// Created: 18. april 2020 17:13:16
// Purpose: Definition of Class StatsInventory

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class StatsInventory : Stats
    {
        private double _usage;

        private Medicine _medicine;
        private InventoryItem _inventoryItem;

        public double Usage { get { return _usage; } set { _usage = value; } }

        public Medicine Medicine { get { return _medicine; } set { _medicine = value; } }

        public InventoryItem InventoryItem { get { return _inventoryItem; } set { _inventoryItem = value; } }

        public StatsInventory(double usage, Medicine medicine, InventoryItem inventoryItem): base()
        {
            _usage = usage;
            _medicine = medicine;
            _inventoryItem = inventoryItem;
        }

        public StatsInventory(long id, double usage, Medicine medicine, InventoryItem inventoryItem) : base(id)
        {
            _usage = usage;
            _medicine = medicine;
            _inventoryItem = inventoryItem;
        }

        public StatsInventory(long id): base(id)
        {

        }
    }
}