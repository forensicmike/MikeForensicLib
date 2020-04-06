using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib
{
    public class SmartSize : INotifyPropertyChanged, IComparable<SmartSize>, IComparer<SmartSize>
    {
        public SmartSize()
        {

        }

        public SmartSize(long sizeBytes)
        {
            SizeBytes = sizeBytes;
        }

        private long _sizeBytes;
        public long SizeBytes
        {
            get { return _sizeBytes; }
            set
            {
                _sizeBytes = value;
                NotifyPropertyChanged("SizeBytes");
                NotifyPropertyChanged("SizeKB");
                NotifyPropertyChanged("SizeMB");
                NotifyPropertyChanged("SizeGB");
            }
        }


        public float SizeKB
        {
            get
            {
                return (float)(SizeBytes / (long)1000);
            }
        }

        public float SizeMB
        {
            get
            {
                return (float)(SizeBytes / (long)1000000);
            }
        }

        public float SizeGB
        {
            get
            {
                return (float)(SizeBytes / (long)1000000000);
            }
        }

        public string Description
        {
            get
            {
                if (SizeGB > 0)
                {
                    return SizeGB.ToString("N2") + " GB";
                }
                else if (SizeMB > 0)
                {
                    return SizeMB.ToString("N2") + " MB";
                }
                else if (SizeKB > 0)
                {
                    return SizeKB.ToString("N2") + " KB";
                }
                else return SizeBytes.ToString() + " bytes";
            }
        }

        public override string ToString()
        {
            return Description;
        }

        #region Standard INotifyPropertyChanged Implementation

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static SmartSize operator +(SmartSize a, SmartSize b)
        {
            SmartSize ret = new SmartSize();
            ret.SizeBytes = a.SizeBytes + b.SizeBytes;
            return ret;
        }

        public int CompareTo(SmartSize other)
        {
            if (SizeBytes == other.SizeBytes)
                return 0;
            else if (SizeBytes <= other.SizeBytes)
                return -1;
            else
                return 1;
        }

        public int Compare(SmartSize x, SmartSize y)
        {
            return (int)(x.SizeBytes - y.SizeBytes);
        }

        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };
        #endregion


    }
}
