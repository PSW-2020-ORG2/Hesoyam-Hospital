using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace GraphicEditor.DTOs
{
    public static class InvertoryItemMapper
    {
        public static List<InventoryItemDTO> ConvertFromIventoryItemToDTO(List<InventoryItem> inventoryItems)
        {
            List<InventoryItemDTO> result = new List<InventoryItemDTO>();
            foreach (InventoryItem i in inventoryItems)
            {
                InventoryItemDTO item = new InventoryItemDTO(i.Name, i.Room.RoomNumber, i.InStock);
                result.Add(item);
            }
            return result;
        }

        public static List<InventoryItemDTO> ConvertFromMedicineToDTO(List<Medicine> medicine, string roomName)
        {

            List<InventoryItemDTO> result = new List<InventoryItemDTO>();
            foreach (Medicine m in medicine)
            {
                InventoryItemDTO item = new InventoryItemDTO(m.Name, roomName, m.InStock);
                result.Add(item);
            }
            return result;

        }
    }
}
