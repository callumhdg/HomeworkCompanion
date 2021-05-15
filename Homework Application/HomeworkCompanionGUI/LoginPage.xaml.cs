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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private List<Teacher> _allTeachers = new List<Teacher>();
        private List<Student> _allStudents = new List<Student>();

        public LoginPage()
        {
            InitializeComponent();

            PopulateListOfTeachers();
            PopulateListOfStudents();
        }


        public void PopulateListOfTeachers()
        {
            lstTeachers.Items.Clear();

            var teacherManagement = new TeacherManagement();
            var allTeachers = teacherManagement.SelectAllTeachers();

            foreach (var item in allTeachers)
            {
                _allTeachers.Add(item);
                lstTeachers.Items.Add(item);
            }
        }

        public void PopulateListOfStudents()
        {
            lstStudents.Items.Clear();

            var studentManagement = new StudentManagement();
            var allStudents = studentManagement.SelectAllStudent();

            foreach (var item in allStudents)
            {
                _allStudents.Add(item);
                lstStudents.Items.Add(item);
            }
        }

        private void btnTeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            //Select Teacher ID
            if (lstTeachers.SelectedIndex >= 0)
            {
                int id = _allTeachers[lstTeachers.SelectedIndex].TeacherId;

                TeacherWindow teacherWindow = new TeacherWindow(id);
                teacherWindow.Show();

                HideMainWindow();

                App.Current.MainWindow = teacherWindow;
            }
            else
            {
                MessageBox.Show("Please select a teacher");
            }
            
        }

        private void btnStudentLogin_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedIndex >= 0)
            {
                int id = _allStudents[lstStudents.SelectedIndex].StudentId;

                StudentWindow studentWindow = new StudentWindow(id);
                studentWindow.Show();

                HideMainWindow();

                App.Current.MainWindow = studentWindow;
            }
            else
            {
                MessageBox.Show("Please select a student");
            }

        }


        private void HideMainWindow()
        {
            MainWindow window = (HomeworkCompanionGUI.MainWindow)App.Current.MainWindow;
            window.Visibility = System.Windows.Visibility.Hidden;
        }

    }
}
