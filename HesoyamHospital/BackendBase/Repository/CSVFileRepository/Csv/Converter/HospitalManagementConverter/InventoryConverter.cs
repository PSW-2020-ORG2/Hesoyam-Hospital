// File:    InventoryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:08
// Purpose: Definition of Class InventoryConverter

using System;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class InventoryConverter : ICSVConverter<Inventory>
    {

        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";"; //Delimiter used for separating room IDs.

        public InventoryConverter(string delimiter, string listDelimiter)
        {
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
        }

        public string ConvertEntityToCSV(Inventory entity)
           => string.Join(_delimiter,
               entity.GetId(),
               GetInventoryItemIDSCSVstring(entity.InventoryItem),
               GetMedicineIDCSVstring(entity.Medicine));

        public Inventory ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            List<InventoryItem> dummyInventoryItems = (tokens[1] == "") ? new List<InventoryItem>() : GetDummyInventoryItems(SplitStringByDelimiter(tokens[1], _listDelimiter));
            List<Medicine> dummyMedicine = (tokens[2] == "") ? new List<Medicine>() : getDummyMedicine(SplitStringByDelimiter(tokens[2], _listDelimiter));



            return new Inventory(
                long.Parse(tokens[0]), 
                dummyInventoryItems, 
                dummyMedicine);
        }

        private string GetInventoryItemIDSCSVstring(IEnumerable<InventoryItem> inventoryItemList)
            => string.Join(_listDelimiter, inventoryItemList.Select(inventoryItem => inventoryItem.GetId()));
        private string GetMedicineIDCSVstring(IEnumerable<Medicine> medicines)
            => string.Join(_listDelimiter, medicines.Select(medicine => medicine.GetId()));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private List<InventoryItem> GetDummyInventoryItems(string[] ids)
            => ids.ToList().ConvertAll(x => new InventoryItem(long.Parse(x)));
        private List<Medicine> getDummyMedicine(string[] ids)
            => ids.ToList().ConvertAll(x => new Medicine(long.Parse(x)));
    }
}
 