using DocumentFormat.OpenXml.Wordprocessing;
using InterfaceDeLEnfer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace InterfaceDeLEnfer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainViewModel mainViewModel = new MainViewModel();
        // Déclaration d'un media player à utiliser ultérieurement
        private MediaPlayer _mediaPlayer = new MediaPlayer();


        // Création d'une liste d'employés manipulable disponible sur toute l'appli
        // List<Employee> listEmployee = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            /* Permet de définir comme Datacontext la fenêtre MainWindow et ainsi de passer les informations
             * au XAML => Taille de la fenêtre, etc.
            this.DataContext = this; */


            /* Permet de définir un employé de la classe employé comme datacontent et de s'en servir dans les 
             * contrôles
            //    Employee employee1 = new Employee ("Beubar", "Bobby", 55);
            // this.DataContext = employee1;
            */

            /*

            listEmployee.Add(new Employee("Beubar", "Bobby", 55));
            listEmployee.Add(new Employee("Martin", "Marie", 30));
            listEmployee.Add(new Employee("Majax", "Gérard", 45));
            listEmployee.Add(new Employee("Phoque", "Bibi", 10));

            // On charge la listEmployee dans le datacontexte pour l'utiliser dans la listbox du xaml
            this.DataContext = listEmployee;
            /*
             mainViewModel.Add_Content("Beubar", "Bobby", 55);
             mainViewModel.Add_Content("Martin", "Marie", 30);
             mainViewModel.Add_Content("Majax", "Gérard", 45);
             mainViewModel.Add_Content("Phoque", "Bibi", 10);
            */

            // On charge le viewmodel dans le datacontext, pour aller chercher la liste d'employés
            this.DataContext = mainViewModel;
            // On initialise la liste à zéro pour qu'elle puisse s'afficher même vide dans la listbox
            mainViewModel.Init();
            // On va chercher les données dans un fichier XML par la méthode PopulateEmployee
            mainViewModel.PopulateEmployee();


        }


        private void btnSimpleMessageBox_Click(object sender, RoutedEventArgs e)
        {

            // Chargement d'un fichier mp3 dans le média player, puis lecture
            _mediaPlayer.Open(new Uri("/Sons/rire.mp3", UriKind.Relative));
            _mediaPlayer.Play();


            // Affichage du nom en typant le contexte comme classe employé
            /*
            MessageBox.Show((this.DataContext as Employee).LastName);
            */

            // MessageBox.Show((this.DataContext as Employee).Age.ToString());

            

            e.Handled = true;
            /* Ce snipet permet d'ouvrir un fichier particulier, ici un fichier mp3 pour l'ouvrir avec un 
             * objet de la classe mediaPlayer qu'on a déclaré dans la classe
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == true)
                       {
                            mediaPlayer.Open(new Uri(openFileDialog.FileName));
                            mediaPlayer.Play();
                       }
            */
        }

        // Cette méthode permet d'attribuer directement un âge à un objet de type employé à condition qu'on ait
        // chargé un employé dans le contexte 
        //    Employee employee1 = new Employee ("Beubar", "Bobby", 55);
        //    this.DataContext = employee1;
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Employee).Age = 50;
        }


        //Handler de méthode permettant d'ajouter un élément à partir des champs sous la liste
        // On pourrait aussi utiliser un binding, à chercher ?
        private void Button_Click_AddEmployee(object sender, RoutedEventArgs e)
        {            
            mainViewModel.Add_Content(LName.Text, FName.Text, Convert.ToInt32(EAge.Text));
        }

        //Handler de méthode permettant de supprimer un élément sélectionné dans la liste
        // On pourrait aussi utiliser un binding, à chercher ?
        private void Button_Click_RemoveEmployee(object sender, RoutedEventArgs e)
        {
            mainViewModel.Remove_Content((Employee)listBoxEmployees.SelectedItem);
        }

        // Handler de méthode pour modifier un employé prenant un élément sélectionné d'une listbox
        // et prenant les éléments notés en dessous
        // On peut aussi utiliser un databinding plus propre (voix xaml) pour lier les champs à la listbox
        private void Button_Click_ModifyEmployee(object sender, RoutedEventArgs e)
        {
            mainViewModel.Modify_Content((Employee)listBoxEmployees.SelectedItem, LName.Text, FName.Text, Convert.ToInt32(EAge.Text));
        }

        /*

    private void btnSimpleMessageBox_Click(object sender, RoutedEventArgs e)
        {

            /*
            //Crée un message qui permet de tracer la route des évènements
            var message =
                //         Qui a déclenché le gestionnaire d'évènement
                //                             Qu'est-ce qui l'a déclenché
                //                                                      D'où vient le clic
                $"Sender: {sender.ToString()}\r\nSource: {e.Source}\r\nOriginal Source: {e.OriginalSource}";

            // Affiche le message (+ un titre = "event !")
            MessageBox.Show(message, "event !");

            // Permet de ne pas remonter la chaîne des évènements
            e.Handled = true;
            */

        /* Solution simple pour récupérer un message cherchant dans le dictionnaire de ressources
        string message = (string)Application.Current.FindResource("msgPleaseEnterServerName");

        MessageBox.Show(message, "event !");
        */

        /*
        // On peut utiliser un dictionnaire de ressource déclaré en variable interne qu'on a lancé au startup de l'application
        // On peut aussi utiliser cette technique pour aller chercher une variable globale au programme
        var message = App.Localized["msgPleaseEnterServerName"];
        MessageBox.Show(message, "On a créé une variable contenant le dictionnaire de ressouce au startup de l'application");

     }
     */


    }
}
