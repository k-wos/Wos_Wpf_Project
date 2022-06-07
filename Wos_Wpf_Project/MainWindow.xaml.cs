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
using Wos_Wpf_Project.data;

namespace Wos_Wpf_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Hall> DatabaseHalls { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            using(DataContext context = new DataContext())
            {
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;
                var phoneNumber = PhoneNumberTextBox.Text;
                var webAddress = WebAddressTextBox.Text;

                if(name != null && address != null && phoneNumber != null && webAddress != null)
                {
                    context.Halls.Add(new Hall() { Name = name, Address = address, PhoneNumber = phoneNumber, WebAddress = webAddress });
                    context.SaveChanges();
                }
            }
        }

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseHalls = context.Halls.ToList();
                ItemList.ItemsSource = DatabaseHalls;
            }
        }

        public void Update()
        {
            using(DataContext context = new DataContext())
            {
                Hall selectedHall = ItemList.SelectedItem as Hall;

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;
                var phoneNumber = PhoneNumberTextBox.Text;
                var webAddress = WebAddressTextBox.Text;

                if (name != null && address != null && phoneNumber != null && webAddress != null)
                {
                    Hall hall = context.Halls.Find(selectedHall.Id);
                    hall.Name = name;
                    hall.Address = address;
                    hall.PhoneNumber = phoneNumber;
                    hall.WebAddress = webAddress;

                    context.SaveChanges();
                }


            }
        }

        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Hall selectedHall = ItemList.SelectedItem as Hall;

                if(selectedHall != null)
                {
                    Hall hall = context.Halls.Single(x => x.Id == selectedHall.Id);

                    context.Remove(hall);
                    context.SaveChanges();
                }
            }
            }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
    }
}
