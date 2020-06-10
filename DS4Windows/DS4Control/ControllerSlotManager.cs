using System;
using System.Collections.Generic;

namespace DS4Windows
{
    public class ControllerSlotManager
    {
        public List<DS4Device> ControllerColl { get; set; }
        public Dictionary<int, DS4Device> ControllerDict { get; }
        public Dictionary<DS4Device, int> ReverseControllerDict { get; }

        public ControllerSlotManager()
        {
            ControllerColl = new List<DS4Device>();
            ControllerDict = new Dictionary<int, DS4Device>();
            ReverseControllerDict = new Dictionary<DS4Device, int>();
        }

        public void AddController(DS4Device device, int slotIdx)
        {
            ControllerColl.Add(device);
            ControllerDict.Add(slotIdx, device);
            ReverseControllerDict.Add(device, slotIdx);
        }

        public void RemoveController(DS4Device device, int slotIdx)
        {
            ControllerColl.Remove(device);
            ControllerDict.Remove(slotIdx);
            ReverseControllerDict.Remove(device);
        }

        public void ClearControllerList()
        {
            ControllerColl.Clear();
            ControllerDict.Clear();
            ReverseControllerDict.Clear();
        }
    }
}
