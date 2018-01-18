using System.Collections.Generic;

namespace HospitalManagment.Models
{

    public class TypeOfRoomAndBedModel
    {

        public int TypeOfRoomAndBedId { get; set; }
        public string RoomName { get; set; }
        public short? BedNumber { get; set; }

        public ICollection<IPD> IPDs { get; set; }
    }
}
