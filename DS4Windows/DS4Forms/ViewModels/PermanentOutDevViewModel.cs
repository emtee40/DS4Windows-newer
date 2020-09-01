using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS4WinWPF.DS4Control;

namespace DS4WinWPF.DS4Forms.ViewModels
{
    public class PermanentOutDevViewModel
    {
        private DS4Windows.OutputSlotManager outSlotManager;

        public List<PermanentSlotDeviceEntry> SlotDeviceEntries { get; }

        public PermanentOutDevViewModel(DS4Windows.ControlService controlService,
            DS4Windows.OutputSlotManager outputMan)
        {
            SlotDeviceEntries = new List<PermanentSlotDeviceEntry>();

            outSlotManager = outputMan;
            foreach(OutSlotDevice tempDev in outputMan.OutputSlots)
            {
                //slotDeviceEntries.Add(new PermanentSlotDeviceEntry(tempDev));
            }

            outSlotManager.SlotAssigned += OutSlotManager_SlotAssigned;
            outSlotManager.SlotUnassigned += OutSlotManager_SlotUnassigned;
        }

        private void OutSlotManager_SlotUnassigned(DS4Windows.OutputSlotManager sender,
            int slotNum, OutSlotDevice _)
        {
            SlotDeviceEntries[slotNum].UpdateDevice();
        }

        private void OutSlotManager_SlotAssigned(DS4Windows.OutputSlotManager sender,
            int slotNum, OutSlotDevice _)
        {
            SlotDeviceEntries[slotNum].UpdateDevice();
        }
    }

    public class PermanentSlotDeviceEntry
    {
        private OutSlotDevice slotDevice;
        public OutSlotDevice SlotDevice { get => slotDevice; }

        public PermanentSlotDeviceEntry(OutSlotDevice slotDevice)
        {
            this.slotDevice = slotDevice;
        }

        public void UpdateDevice()
        {

        }
    }
}
