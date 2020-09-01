using System;
using DS4Windows;

namespace DS4WinWPF.DS4Control
{
    public class OutSlotDevice
    {
        public enum AttachedStatus : uint
        {
            UnAttached = 0,
            Attached = 1,
        }

        public enum ReserveStatus : uint
        {
            Dynamic = 0,
            Permanent = 1,
        }

        public enum InputBound : uint
        {
            Unbound = 0,
            Bound = 1,
        }

        private ReserveStatus reserveStatus;
        private InputBound inputBound;
        private OutContType permanentType;

        private int index;
        public int Index => index;

        public AttachedStatus CurrentAttachedStatus { get; private set; }
        public OutputDevice OutputDevice { get; private set; }
        public ReserveStatus CurrentReserveStatus
        {
            get => reserveStatus;
            set
            {
                if (reserveStatus == value) return;
                reserveStatus = value;
                CurrentReserveStatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler CurrentReserveStatusChanged;

        public InputBound CurrentInputBound
        {
            get => inputBound;
            set
            {
                if (inputBound == value) return;
                inputBound = value;
                CurrentInputBoundChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler CurrentInputBoundChanged;

        public OutContType PermanentType
        {
            get => permanentType;
            set
            {
                if (permanentType == value) return;
                permanentType = value;
                PermanentTypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler PermanentTypeChanged;

        public OutContType CurrentType { get; set; }

        public OutSlotDevice(int idx)
        {
            this.index = idx;
            CurrentReserveStatusChanged += OutSlotDevice_CurrentReserveStatusChanged;
        }

        private void OutSlotDevice_CurrentReserveStatusChanged(object sender, EventArgs e)
        {
            if (reserveStatus == ReserveStatus.Dynamic)
            {
                PermanentType = OutContType.None;
            }
            else if (CurrentType != OutContType.None)
            {
                PermanentType = CurrentType;
            }
        }

        public void AttachedDevice(OutputDevice outputDevice, OutContType contType)
        {
            this.OutputDevice = outputDevice;
            CurrentAttachedStatus = AttachedStatus.Attached;
            CurrentType = contType;
            //desiredType = contType;
        }

        public void DetachDevice()
        {
            if (OutputDevice != null)
            {
                OutputDevice = null;
                CurrentAttachedStatus = AttachedStatus.UnAttached;
                CurrentType = OutContType.None;
                CurrentInputBound = InputBound.Unbound;

                if (reserveStatus == ReserveStatus.Dynamic)
                {
                    PermanentType = OutContType.None;
                }
            }
        }

        ~OutSlotDevice()
        {
            DetachDevice();
        }
    }
}
