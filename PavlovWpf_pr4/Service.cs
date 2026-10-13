using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PavlovWpf_pr4
{
    public class Service : INotifyPropertyChanged
    {
        private int _id;
        private string _name = "Название услуги";
        private string _executor = "Исполнитель";
        private decimal _hourPrice = 1000;
        private int _hours = 1;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public string Executor
        {
            get { return _executor; }
            set
            {
                if (_executor != value)
                {
                    _executor = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal HourPrice
        {
            get { return _hourPrice; }
            set
            {
                if (_hourPrice != value)
                {
                    _hourPrice = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

       
        public decimal TotalPrice
        {
            get { return HourPrice * Hours; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}