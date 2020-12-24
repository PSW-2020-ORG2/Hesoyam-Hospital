using Backend.Model.UserModel;
using System.Collections.Generic;

namespace GraphicEditor.DTOs
{
    public static class RoomMapper
    {
        public static List<RoomDTO> ConvertFromRoomToDTO(List<Room> rooms)
        {
            List<RoomDTO> roomDTOs = new List<RoomDTO>();

            foreach (Room r in rooms)
                roomDTOs.Add(new RoomDTO(r.RoomNumber, r.RoomType, r.Floor););
           
            return roomDTOs;
        }
    }
}
