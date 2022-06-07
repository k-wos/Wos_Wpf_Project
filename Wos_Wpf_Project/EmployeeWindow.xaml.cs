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
using System.Windows.Shapes;
using Wos_Wpf_Project.data;

namespace Wos_Wpf_Project
{
    /// <summary>
    /// Logika interakcji dla klasy EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public List<Employee> DatabaseEmployees { get; private set; }
        public List<Position> DatabasePositions { get; private set; }
        DataContext context = new DataContext();
        public EmployeeWindow()
        {
            InitializeComponent();

            DatabasePositions = context.Positions.ToList();
            foreach (Position position in DatabasePositions)
            {
                PositionIdBox.Items.Add(position.PositionId);
            }
        }

        public void Create()
        {
            var name = NameTextBox.Text;
            var surname = NameTextBox.Text;
            var positionId = PositionIdBox.SelectedItem;

            if (name != null && surname != null)
            {
                context.Employees.Add(new Employee() { Name = name, Surname = surname, CurrentPositionId = (int) positionId });
                context.SaveChanges();
            }
        }
        public void Read()
        {
           
            DatabaseEmployees = context.Employees.ToList();
            EmployeeItemList.ItemsSource = DatabaseEmployees;
            
        }
        public void Delete()
        {
            Employee selectedemployee = EmployeeItemList.SelectedItem as Employee;

            if (selectedemployee != null)
            {
                Employee employee = context.Employees.Single(x => x.Id == selectedemployee.Id);

                context.Remove(employee);
                context.SaveChanges();
            }
        }
        public void Edit()
        {
            Employee selectedemployee = EmployeeItemList.SelectedItem as Employee;
            var name = NameTextBox.Text;
            var surname = SurnameTextBox.Text;
            var positionId = PositionIdBox.SelectedItem;
            

            if (name != null)
            {
                Employee employee = context.Employees.Find(selectedemployee.Id);
                employee.Name = name;
                employee.Surname = surname;
                employee.CurrentPositionId = (int)positionId;
                

                context.SaveChanges();
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
            Edit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
