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
    /// Logika interakcji dla klasy EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        public List<Hall> DatabaseHalls { get;  set; }
        public List<Events> DatabaseEvents { get; private set; }
        public EventWindow()
        {
            InitializeComponent();


            using (DataContext context = new DataContext())
            {
                DatabaseHalls = context.Halls.ToList();
                foreach(Hall hall in DatabaseHalls)
                {
                    HallComboBox.Items.Add(hall.Name);
                }

            }
        }

        public void Create()
        {
            using(DataContext context = new DataContext())
            {
                var name = NameTextBox.Text;
                var artist = ArtistTextBox.Text;
                var eventDate = DatePicker.Text;
                var hall = HallComboBox.SelectedItem;

                if (name != null )
                {
                    context.EventList.Add(new Events() { Name = name, Artist = artist, EventDate = eventDate, HallName = (string)hall}); 
                    context.SaveChanges();
                }
            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseEvents = context.EventList.ToList();
                EventItemList.ItemsSource = DatabaseEvents;
            }
        }
        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Events selectedEvent = EventItemList.SelectedItem as Events;

                if (selectedEvent != null)
                {
                    Events events = context.EventList.Single(x => x.Id == selectedEvent.Id);

                    context.Remove(events);
                    context.SaveChanges();
                }
            }
        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Events selectedEvent = EventItemList.SelectedItem as Events;
                var name = NameTextBox.Text;
                var artist = ArtistTextBox.Text;
                var eventDate = DatePicker.Text;
                var hall = HallComboBox.SelectedItem;

                if (name != null) { 
                    Events events = context.EventList.Find(selectedEvent.Id);
                    events.Name = name;
                    events.Artist = artist;
                    events.EventDate= eventDate;
                    events.HallName = (string)hall;

                    context.SaveChanges();
                }


            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }
    }
}
