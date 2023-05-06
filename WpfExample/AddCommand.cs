using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class AddCommand : ICommand
    {
        public void Execute(object parameter)
        {
            var nameList = parameter as NamesList;
            var newName = string.Format("{0} {1}", nameList.FirstName,
            nameList.LastName);
            nameList.Names.Add(newName);

            nameList.FirstName = nameList.LastName = "";
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
}
