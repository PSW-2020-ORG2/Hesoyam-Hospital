// File:    InventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:37
// Purpose: Definition of Class InventoryRepository

using SIMS.Exceptions;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class InventoryRepository : CSVRepository<Inventory, long>, IInventoryRepository, IEagerCSVRepository<Inventory, long>
    {
        private const string ENTITY_NAME = "Inventory Repository";
        private IInventoryItemRepository _inventoryItemRepository;
        private IMedicineRepository _medicineRepository;
        public InventoryRepository(ICSVStream<Inventory> stream, ISequencer<long> sequencer, IInventoryItemRepository inventoryItemRepository, IMedicineRepository medicineRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Inventory>())
        {
            _inventoryItemRepository = inventoryItemRepository;
            _medicineRepository = medicineRepository;
        }

        private void BindInventoryWithMedicine(IEnumerable<Inventory> inventories, IEnumerable<Medicine> medicines)
        { 
            foreach(Inventory inventory in inventories) { 
                for(int i = 0; i < inventory.Medicine.Count - 1; i++)
                {
                    inventory.Medicine[i] = GetMedicineById(medicines, inventory.Medicine[i].GetId());
                }
            }
        }

        private Medicine GetMedicineById(IEnumerable<Medicine> medicines, long id)
            => medicines.SingleOrDefault(medicine => medicine.GetId() == id);

        private void BindInventoryWithItems(IEnumerable<Inventory> inventories, IEnumerable<InventoryItem> items)
        {
            foreach (Inventory inventory in inventories)
            {
                for (int i = 0; i < inventory.InventoryItem.Count - 1; i++)
                {
                    inventory.InventoryItem[i] = GetInventoryItemById(items, inventory.InventoryItem[i].GetId());
                }
            }
        }

        private InventoryItem GetInventoryItemById(IEnumerable<InventoryItem> items, long id)
            => items.SingleOrDefault(item => item.GetId() == id);

        public void Bind(IEnumerable<Inventory> inventories, IEnumerable<InventoryItem> inventoryItems, IEnumerable<Medicine> medicine)
        {
            BindInventoryWithItems(inventories, inventoryItems);
            BindInventoryWithMedicine(inventories, medicine);
        }

        public Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public Inventory SetInventoryItem(InventoryItem inventoryItem)
        {

            Inventory toUpdate = GetAll().SingleOrDefault(inventory => inventory.inventoryItem.Contains(inventoryItem));
            InventoryItem original = GetItemById(toUpdate.InventoryItem, inventoryItem.GetId());
            if(original != null)
            {
                original = inventoryItem;
                Update(toUpdate);

            } else
            {
                throw new EntityNotFoundException();
            }

            return toUpdate;
        }

        private InventoryItem GetItemById(IEnumerable<InventoryItem> items, long id)
            => items.SingleOrDefault(item => item.GetId() == id);

        public void RemoveInventoryItem(InventoryItem inventoryItem)
        {
            Inventory toUpdate = GetAll().SingleOrDefault(inventory => inventory.inventoryItem.Contains(inventoryItem));
            InventoryItem original = GetItemById(toUpdate.InventoryItem, inventoryItem.GetId());
            if (original != null)
            {
                toUpdate.inventoryItem.Remove(inventoryItem);
                Update(toUpdate);

            }
            else
            {
                throw new EntityNotFoundException();
            }

        }


        public Inventory GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(inventory => inventory.GetId() == id);

        public IEnumerable<Inventory> GetAllEager()
        {
            IEnumerable<Inventory> inventories = GetAll();
            IEnumerable<InventoryItem> items = _inventoryItemRepository.GetAll();
            IEnumerable<Medicine> meds = _medicineRepository.GetAll();
            Bind(inventories, items, meds);

            return inventories;
        }

        public MedicineRepository medicineRepository;
    }
}