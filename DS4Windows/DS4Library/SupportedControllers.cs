using System;
using System.ComponentModel;
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

    public class HexConverter : TypeConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
           Type sourceType) {

            return (sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
           CultureInfo culture, object value) {
            if (value is string) {
                return int.Parse((string) value, NumberStyles.AllowHexSpecifier);
            }
            return base.ConvertFrom(context, culture, value);
        }
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context,
           CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string)) {
                return ((int) value).ToString("X");
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class VidPidInfo : ConfigurationElement {

        [ConfigurationProperty("vid", IsRequired = true)]
        [TypeConverter(typeof(HexConverter))]
        public int VID { get { return (int) this["vid"]; } }

        [ConfigurationProperty("pid", IsRequired = true)]
        [TypeConverter(typeof(HexConverter))]
        public int PID { get { return (int) this["pid"]; } }

        // Explictly convert the string values to a consistent value for hashing
        public string ID { get { return (VID.ToString("X") + "_" + PID.ToString("X")); } }
        
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
