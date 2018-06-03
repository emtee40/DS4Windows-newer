using System.Configuration;
using System.Globalization;

namespace DS4Windows {
    public class SupportedControllers : ConfigurationSection {

        [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
        [ConfigurationCollection(typeof(ControllersCollection), AddItemName = "Controller")]
        public ControllersCollection Controllers {
            get { return base[""] as ControllersCollection; }
            set { base[""] = value; }
        }
    }

    public class ControllersCollection : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new VidPidInfo();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((VidPidInfo) element).ID;
        }
    }

    public class VidPidInfo : ConfigurationElement {

        [ConfigurationProperty("vid", IsRequired = true)]
        private string _vid { get { return (string) this["vid"]; } }

        [ConfigurationProperty("pid", IsRequired = true)]
        private string _pid { get { return (string) this["pid"]; } }

        // Explictly convert the string values to a consistent value for hashing
        private string _ID = null;
        public string ID { get { return (null == _ID ? _ID = VID.ToString("X") + "_" + PID.ToString("X") : _ID); } }

        private int _VID = -1;
        public int VID { get { return (-1 == _VID ? _VID = int.Parse(_vid, NumberStyles.AllowHexSpecifier) : _VID); } }

        private int _PID = -1;
        public int PID { get { return (-1 == _PID ? _PID = int.Parse(_pid, NumberStyles.AllowHexSpecifier) : _PID);  } }

        /** Returns true if the vidpid details match those of the specified HidDevice **/
        public bool matchesHid(HidDevice hidDevice) {
            return (hidDevice != null && hidDevice.Attributes != null && hidDevice.Attributes.VendorId == VID && hidDevice.Attributes.ProductId == PID);
        }

        public override bool Equals(object obj) {
            VidPidInfo target = obj as VidPidInfo;
            return (null != target && ID.Equals(target.ID));
        }

        public override int GetHashCode() {
            return ID.GetHashCode();
        }
    }
}
