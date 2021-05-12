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
    /// Interaction logic for ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
        private int? _selectedClass = 1; //set default to null
        private StudentManagement _studentManagement = new StudentManagement();
        private StudentsInClassManagement _studentsInClassManagement = new StudentsInClassManagement();

        private List<Student> _inClassStudents = new List<Student>();
        private List<Student> _notInClassStudents = new List<Student>();

        public ClassPage()
        {
            InitializeComponent();

            UpdateDisplay((int)_selectedClass);

            btnAddToClass.Content = "<- Add --";
            btnRemoveFromClass.Content = "-- Remove ->";
        }

        public void UpdateDisplay(int classID)
        {
            Clear();

            //System.Threading.Thread.Sleep(1000);

            _notInClassStudents = _studentManagement.SelectAllStudentsNotInAClass(classID);

            foreach (var item in _notInClassStudents)
            {
                lstNotInCurrentClass.Items.Add(item);
            }


            _inClassStudents = _studentManagement.SelectAllStudentsInAClass(classID);

            foreach (var item in _inClassStudents)
            {
                lstCurrentInClass.Items.Add(item);
            }
        }


        public void PopulateListOfAllStudentsNotInAClass(int classID)
        {
            lstNotInCurrentClass.Items.Clear();

            //var allStudents = _studentManagement.SelectAllStudentsNotInAClass(classID);
            _notInClassStudents = _studentManagement.SelectAllStudentsNotInAClass(classID);

            foreach (var item in _notInClassStudents)
            {
                lstNotInCurrentClass.Items.Add(item);
            }
            
        }


        public void PopulateListOfAllStudentsInAClass(int classID)
        {
            lstCurrentInClass.Items.Clear();

            //var allStudents = _studentManagement.SelectAllStudentsInAClass(classID);
            _inClassStudents = _studentManagement.SelectAllStudentsInAClass(classID);

            foreach (var item in _inClassStudents)
            {
                lstCurrentInClass.Items.Add(item);
            }

        }

        private void btnAddToClass_Click(object sender, RoutedEventArgs e)
        {
            if (lstNotInCurrentClass.SelectedIndex >= 0) //&& selected class != null
            {
                int selectedStudentID = _notInClassStudents[lstNotInCurrentClass.SelectedIndex].StudentId;

                _studentsInClassManagement.AddStudentToClass((int)_selectedClass, selectedStudentID);
            }

            //PopulateListOfAllStudentsNotInAClass((int)_selectedClass); //change to classID
            //PopulateListOfAllStudentsInAClass((int)_selectedClass); //change to classID
            UpdateDisplay((int)_selectedClass);
        }

        private void btnRemoveFromClass_Click(object sender, RoutedEventArgs e)
        {
            if (lstCurrentInClass.SelectedIndex >= 0) //&& selected class != null
            {
                int selectedStudentID = _inClassStudents[lstCurrentInClass.SelectedIndex].StudentId;

                _studentsInClassManagement.RemoveStudentFromClass((int)_selectedClass, selectedStudentID);
            }

            //PopulateListOfAllStudentsNotInAClass((int)_selectedClass); //change to classID
            //PopulateListOfAllStudentsInAClass((int)_selectedClass); //change to classID
            UpdateDisplay((int)_selectedClass);
        }


        private void Clear()
        {
            lstNotInCurrentClass.Items.Clear();
            lstNotInCurrentClass.Items.Clear();
        }
    }
}
