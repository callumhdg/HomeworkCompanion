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
        private int? _selectedClass = null; //set default to null
        private int _currentTeacher = 1; //change when login is added
        private StudentManagement _studentManagement = new StudentManagement();
        private StudentsInClassManagement _studentsInClassManagement = new StudentsInClassManagement();
        private ClassManagement _classManagement = new ClassManagement();

        private List<Student> _inClassStudents = new List<Student>();
        private List<Student> _notInClassStudents = new List<Student>();
        private List<Class> _classesOfTeacher = new List<Class>();

        public ClassPage()
        {
            InitializeComponent();

            btnAddToClass.Content = "<- Add --";
            btnRemoveFromClass.Content = "-- Remove ->";

            fillListOfClasses(_currentTeacher);
            cbxSelectClass.SelectedIndex = 1;
        }

        public void UpdateListBoxes()
        {
            Clear();

            foreach (var item in _notInClassStudents)
            {
                lstNotInCurrentClass.Items.Add(item);
            }

            foreach (var item in _inClassStudents)
            {
                lstCurrentInClass.Items.Add(item);
            }
        }

        public void CreateLocalListsOfStudents(int classID)
        {
            Clear();

            if (_selectedClass >= 0)
            {
                _inClassStudents = _studentManagement.SelectAllStudentsInAClass(classID);
                _notInClassStudents = _studentManagement.SelectAllStudentsNotInAClass(classID);

                UpdateListBoxes();

            }
            
        }


        private void btnAddToClass_Click(object sender, RoutedEventArgs e)
        {
            if (lstNotInCurrentClass.SelectedIndex >= 0)
            {
                int selectedStudentID = _notInClassStudents[lstNotInCurrentClass.SelectedIndex].StudentId;

                _studentsInClassManagement.AddStudentToClass((int)_selectedClass, selectedStudentID);

                _inClassStudents.Add(_notInClassStudents[lstNotInCurrentClass.SelectedIndex]);
                _notInClassStudents.RemoveAt(lstNotInCurrentClass.SelectedIndex);
                UpdateListBoxes();
            }
            else
            {
                MessageBox.Show("Please select a student to add");
            }
            
        }

        private void btnRemoveFromClass_Click(object sender, RoutedEventArgs e)
        {
            if (lstCurrentInClass.SelectedIndex >= 0) 
            {
                int selectedStudentID = _inClassStudents[lstCurrentInClass.SelectedIndex].StudentId;

                _studentsInClassManagement.RemoveStudentFromClass((int)_selectedClass, selectedStudentID);

                _notInClassStudents.Add(_inClassStudents[lstCurrentInClass.SelectedIndex]);
                _inClassStudents.RemoveAt(lstCurrentInClass.SelectedIndex);
                UpdateListBoxes();
            }
            else
            {
                MessageBox.Show("Please select a student to remove");
            }

        }


        private void fillListOfClasses(int teacherID)
        {
            cbxSelectClass.Items.Clear();
            _classesOfTeacher = _classManagement.SelectAllClassesForATeacher(teacherID);

            foreach (var item in _classesOfTeacher)
            {
                cbxSelectClass.Items.Add(item);
            }
            
        }

        private void Clear()
        {
            lstCurrentInClass.Items.Clear();
            lstNotInCurrentClass.Items.Clear();
        }

        private void cbxSelectClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();

            if (cbxSelectClass.SelectedIndex < 0)
            {
                _selectedClass = null;

                MessageBox.Show("No class selected");
            }
            else
            {
                _selectedClass = _classesOfTeacher[cbxSelectClass.SelectedIndex].ClassId;

                CreateLocalListsOfStudents((int)_selectedClass);

            }

        }


    }
}
