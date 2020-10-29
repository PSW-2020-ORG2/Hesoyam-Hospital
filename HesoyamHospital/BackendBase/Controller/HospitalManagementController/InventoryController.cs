// File:    InventoryController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class InventoryController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;

namespace SIMS.Controller.HospitalManagementController
{
    public class InventoryController : IController<Inventory, long>
    {

        public InventoryService inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        public Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
            => inventoryService.AddInventoryItem(inventory, item);

        public Inventory SetInventoryItem(InventoryItem inventoryItem)
            => inventoryService.SetInventoryItem(inventoryItem);

        public void RemoveInventoryItem(InventoryItem item)
            => inventoryService.RemoveInventoryItem(item);

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
            => inventoryService.GetInventoryItemsForRoom(room);

        public IEnumerable<Item> GetResupply()
            => inventoryService.GetResupply();

        public IEnumerable<InventoryItem> GetInventoryItems()
            => inventoryService.GetInventoryItems();

        public IEnumerable<Inventory> GetAll()
            => inventoryService.GetAll();

        public Inventory GetByID(long id)
            => inventoryService.GetByID(id);

        public Inventory Create(Inventory entity)
            => inventoryService.Create(entity);

        public void Update(Inventory entity)
            => inventoryService.Update(entity);

        public void Delete(Inventory entity)
            => inventoryService.Delete(entity);
    }
}