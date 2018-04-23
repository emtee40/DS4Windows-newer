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

        public VidPidInfo() { }

        private readonly int vid, pid;

        public VidPidInfo(int vid, int pid) {
            this.vid = vid;
            this.pid = pid;
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name { get { return (string) this["name"]; } }

        [ConfigurationProperty("vid", IsRequired = true)]
        private string _vid { get { return vid != 0 ? vid.ToString("X") : (string) this["vid"]; } }

        [ConfigurationProperty("pid", IsRequired = true)]
        private string _pid { get { return pid != 0 ? pid.ToString("X") : (string) this["pid"]; } }

        // Explictly convert the string values to a consistent value for hashing
        public string ID { get { return VID.ToString("X") + "_" + PID.ToString("X");  } }

        public int VID { get { return vid != 0 ? vid : int.Parse(_vid, NumberStyles.AllowHexSpecifier); } }

        public int PID { get { return pid != 0 ? pid : int.Parse(_pid, NumberStyles.AllowHexSpecifier); } }

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
