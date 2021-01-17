using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XInspector.Attributes;
using XInspector.Converters;
using XInspector.SampleModels.Annotations;

namespace XInspector.SampleModels
{
    public enum Force
    {
        Friend,
        Enemy,
        Civil,
        Unknown,
    }
    
    public class Simple : INotifyPropertyChanged
    {
       
        public string StringValue
        {
            get;
            set;
        }

        [Bound(40,50)]
        public int IntValue
        {
            get;
            set;
        }

        [DecimalCount(2)]
        [Unit("Toto")]
        public double DoubleValue
        {
            get;
            set;
        }

        public bool BooleanValue
        {
            get;
            set;
        }

        public string StringValueNoSet
        {
            get;
        }

        public int IntValueNoSet
        {
            get;
        }

        public double DoubleValueNoSet
        {
            get;
        }

        public bool BooleanValueNoSet
        {
            get;
        }

        public Force Side
        {
            get;
            set;
        }

        [Browsable(false)]
        public double NotBrowsable
        {
            get;
            set;
        }

        [ReadOnly(true)]
        public double DoubleValueReadonlyTrue
        {
            get;
            set;
        }

        [ReadOnly(false)]
        public double DoubleValueReadonlyFalse
        {
            get;
            set;
        }

        public Point1 Position
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
