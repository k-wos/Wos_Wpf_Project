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
    /// Logika interakcji dla klasy PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        public List<Position> Databasepositions { get; set; }
        DataContext context = new DataContext();
        public PositionWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            var name = NameTextBox.Text;

            if(name != null)
            {
                context.Positions.Add(new Position { Name = name });
                context.SaveChanges();
            }
        }

        public void Update()
        {
            Position selectedPosition = PositionList.SelectedItem as Position;

            var name = NameTextBox.Text;

            if(name != null)
            {
                Position position = context.Positions.Find(selectedPosition.PositionId);
                position.Name = name;

                context.SaveChanges();
            }
        }
        public void Read()
        {
            Databasepositions = context.Positions.ToList();
            PositionList.ItemsSource = Databasepositions;
        }

        public void Delete()
        {
            Position selectedPosition = PositionList.SelectedItem as Position;
            if(selectedPosition != null)
            {
                Position position = context.Positions.Single(x => x.PositionId == selectedPosition.PositionId);
                context.Remove(position);
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
