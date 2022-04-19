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
using ClassLibrary;
using Task = ClassLibrary.Task;
using TaskList = ClassLibrary.TaskList;
using Application = ClassLibrary.Application;

namespace Eksamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskListBox.ItemsSource = Application.GetApplication().taskLists;
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TaskListBox.SelectedItem != null)
            {
                TaskBox.ItemsSource = Application.GetApplication().taskLists[TaskListBox.SelectedIndex].tasks;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Hidden;
            AddTextBox.Visibility = Visibility.Visible;
            AddTextBox.Focus();
        }

        private void AddTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Application.GetApplication().taskLists.Add(new TaskList(new List<Task>(), AddTextBox.Text));

                AddTextBox.Text = "";
                AddTextBox.Visibility = Visibility.Hidden;
                AddButton.Visibility = Visibility.Visible;

                TaskListBox.ItemsSource = new List<TaskList>();
                TaskListBox.ItemsSource = Application.GetApplication().taskLists;
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                AddTaskButton.Visibility = Visibility.Hidden;
                AddTaskTextBox.Visibility = Visibility.Visible;
                AddTaskTextBox.Focus();
            }
        }

        private void AddTaskTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                int id = TaskListBox.SelectedIndex;
                Application.GetApplication().taskLists[id].tasks.Add(new Task(AddTaskTextBox.Text,DateTime.Now));

                AddTaskTextBox.Text = ""; 
                AddTaskTextBox.Visibility = Visibility.Hidden;
                AddTaskButton.Visibility = Visibility.Visible;

                TaskBox.ItemsSource = new List<Task>();
                TaskBox.ItemsSource = Application.GetApplication().taskLists[id].tasks;
            }
        }

        private void DelTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string b_id = button.Tag.ToString();
            int id = TaskListBox.SelectedIndex;

            Task task = Application.GetApplication().taskLists[id].tasks.Where(t => t.TaskId.ToString() == b_id).FirstOrDefault();
            Application.GetApplication().taskLists[id].tasks.Remove(task);

            TaskBox.ItemsSource = new List<Task>();
            TaskBox.ItemsSource = Application.GetApplication().taskLists[id].tasks;
        }

        private void DelTaskListButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string b_id = button.Tag.ToString();

            TaskList taskList = Application.GetApplication().taskLists.Where(t => t.TaskListName.ToString() == b_id).FirstOrDefault();
            Application.GetApplication().taskLists.Remove(taskList);

            TaskListBox.ItemsSource = new List<TaskList>();
            TaskListBox.ItemsSource = Application.GetApplication().taskLists;
            TaskBox.ItemsSource = new List<Task>();
        }
    }
}
