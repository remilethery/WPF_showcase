using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InterfaceDeLEnfer.ViewModel
{
    /* Création d'un ViewModel comportant une liste d'employés à laquelle on va accéder par le datacontext dans le
     * code-behind. 
     * Dans le modèle MVVM:
     * Model : Employes
     * Viewmodel : Ce fichier
     * View : XAML + code behind
     */
    class MainViewModel
    {

        private ObservableCollection<Employee> m_List_employee;

        // Getter Setter sur la liste d'employés
        public ObservableCollection<Employee> List_employee 
        {
            get => m_List_employee; 
            set => m_List_employee = value; 
        }

        // On doit initialiser la liste d'employés sinon elle n'apparaîtra pas vide dans le controleur ListBox
        public void Init()
        {
            if (m_List_employee == null)
            {
                m_List_employee = new ObservableCollection<Employee>();

            }
        }

        // Méthode permettant d'ajouter un utilisateur, appelant la méthode de classe List.Add
        public void Add_Content(string _name, string _firstname, int _age)
        {
            m_List_employee.Add(new Employee(_name, _firstname, _age));
            
        }

        // Méthode permettant de supprimer un utilisateur, appelant la méthode de classe List.Remove
            public void Remove_Content(Employee employee)
        {
            m_List_employee.Remove(employee);
        }


        // Méthode permettant de modifier un employé sélectionné dans la liste
        public void Modify_Content(Employee employee, string lName, string fName, int eAge)
        {
            int index = m_List_employee.IndexOf(employee);
            m_List_employee[index].LastName = lName;
            m_List_employee[index].FirstName = fName;
            m_List_employee[index].Age = eAge;
        }

        // Chargement d'un document XML dans le viewmodel et dans la liste correspondante
        // S'affichera dans la listbox automatiquement grâce au INotified des éléments em
        public void PopulateEmployee()
        {
            // Chargement du document xml
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\stagiaire\Documents\WPF\InterfaceDeLEnfer-V3\employee.xml");
            // Recherche d'un noeud particulier
            XmlNodeList xnlNodes = doc.SelectNodes("/employees/employee");
            // Pour chaque noeud, on cherche les valeur des attributs et on les met dans des variables
            foreach (XmlNode xnlNode in xnlNodes)
            {
                string lname = xnlNode.Attributes["name"].Value;
                string Fname = xnlNode.Attributes["firstname"].Value;
                int age = Convert.ToInt32(xnlNode.Attributes["age"].Value);

                // m_List_employee.Add(new Employee (lname, Fname, age));
                // On utilise la méthode de la classe pour ajouter un élément dans la liste
                Add_Content(lname, Fname, age);
            }
        }
}
}
