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
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private int _teacherID;
        public TeacherPage(int teacherID)
        {
            InitializeComponent();

            _teacherID = teacherID;
            WelcomeMessage(_teacherID);
        }

        private void WelcomeMessage(int id)
        {
            TeacherManagement teacherManagement = new TeacherManagement();
            Teacher selectedTeacher = teacherManagement.SelectSingleTeacher(id);

            lblWelcome.Content = $"Welcome {selectedTeacher.ToString()}";
        }


    }
}
