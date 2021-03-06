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
using BusinessLayer;
using HomeworkCompanion;

namespace HomeworkCompanionGUI
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private int _studentID = 0;
        public StudentWindow(int studentID)
        {
            InitializeComponent();

            _studentID = studentID;
            StudentFrame.Content = new StudentPage(_studentID);
        }

        private void btnStudentLogout_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = (HomeworkCompanionGUI.StudentWindow)App.Current.MainWindow;
            studentWindow.Visibility = System.Windows.Visibility.Hidden;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            App.Current.MainWindow = mainWindow;
        }

        private void btnHomeworkPage_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new ViewHomeworkPage(_studentID);
        }



    }
}
