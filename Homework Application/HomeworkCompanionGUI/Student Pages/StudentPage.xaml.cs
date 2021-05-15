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
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        private int _studentID;

        public StudentPage(int studentID)
        {
            InitializeComponent();

            _studentID = studentID;
            WelcomeMessage(_studentID);
        }

        private void WelcomeMessage(int id)
        {            
            StudentManagement studentManagement = new StudentManagement();
            Student selectedStudent = studentManagement.SelectSingleStudent(id);

            lblWelcome.Content = $"Welcome {selectedStudent.ToString()}";
        }

    }
}
