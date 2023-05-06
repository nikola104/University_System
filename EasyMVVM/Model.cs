using System;
using System.Collections.ObjectModel;

namespace EasyMVVM
{
    public class Model
    {
        ObservableCollection<string> _data = new ObservableCollection<string>();
         
        public ObservableCollection<string> GetData()
        {
            _data.Add("First Entry");
            _data.Add("First Entry");
            _data.Add("First Entry");
            return _data;                                       
        }

    }
}