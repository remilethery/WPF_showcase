using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDeLEnfer.ViewModel
{
    /*
    class Employee : INotifyPropertyChanged
    {
        private string _lastName;
        private string _firstName;
        private int _age;

        public Employee(string _lastName, string _firstName, int _age)
        {
            this._lastName = _lastName;
            this._firstName = _firstName;
            this._age = _age;
        }

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public int Age { get => _age; set => _age = value; }

    */

    // On implémente l'interface INotifyPropertyChanged pour bénéficier de l'event PropertyChangedEventHandler
    public class Employee : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        // Constructor
        public Employee(string _lastName, string _firstName, int _age)
        {
            this._lastName = _lastName;
            this._firstName = _firstName;
            this._age = _age;
        }
        // props
        private string _lastName;
        private string _firstName;
        private int _age;

        // nameof(property) permet d'envoyer à OnPropertyChanged() directement le nom de la propriété changée
        public string LastName
        {
            get { return _lastName; }
            set {
                _lastName = value;
                OnPropertyChanged(nameof(LastName)); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName)); }
        }

        public int Age
        {
            get { return _age; }
            set {
                _age = value;
                OnPropertyChanged(nameof(Age)); }
        }

    }


}
