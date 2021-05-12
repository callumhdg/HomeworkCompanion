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
using BusinessLayer;
using HomeworkCompanion;

namespace HomeworkCompanionGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Content = new LoginPage();

            //PopulateListOfTeachers();
            //PopulateListOfStudents();
        }

        //public void PopulateListOfTeachers()
        //{
        //    lstTeachers.Items.Clear();

        //    var teacherManagement = new TeacherManagement();
        //    var allTeachers = teacherManagement.SelectAllTeachers();

        //    foreach (var item in allTeachers)
        //    {
        //        lstTeachers.Items.Add(item);
        //    }
        //}

        //public void PopulateListOfStudents()
        //{
        //    lstStudents.Items.Clear();

        //    var studentManagement = new StudentManagement();
        //    var allStudents = studentManagement.SelectAllStudent();

        //    foreach (var item in allStudents)
        //    {
        //        lstStudents.Items.Add(item);
        //    }
        //}

        //private void btnTeacherLogin_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btnStudentLogin_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
