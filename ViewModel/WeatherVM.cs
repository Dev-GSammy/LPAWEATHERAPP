using LPAWEATHERAPP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPAWEATHERAPP.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set 
            { 
                query = value;
                OnPropertyChanged("Query");
            }
        }
        private CurrentCondition CurrentCondition;

        public CurrentCondition CurrentConditions
        {
            get { return CurrentCondition; }
            set { CurrentCondition = value; }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
