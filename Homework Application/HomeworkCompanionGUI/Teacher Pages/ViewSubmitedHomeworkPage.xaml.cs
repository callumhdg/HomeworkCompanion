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
    /// Interaction logic for ViewSubmitedHomeworkPage.xaml
    /// </summary>
    public partial class ViewSubmitedHomeworkPage : Page
    {
        private int _classID = 0, _teacherID;

        private ClassManagement _classManagement = new ClassManagement();
        private HomeworkManagement _homeworkManagement = new HomeworkManagement();

        private List<Homework> _homeworkOfClass = new List<Homework>();
        private List<Class> _classes = new List<Class>();

        public ViewSubmitedHomeworkPage(int classID, int teacherID)
        {
            InitializeComponent();

            _teacherID = teacherID;
            _classID = classID;
            PopulateClasses(_teacherID);

            lstClassesOfTeacher.SelectedIndex = 0;//select first class as default
        }

        public ViewSubmitedHomeworkPage(int teacherID)
        {
            InitializeComponent();

            _teacherID = teacherID;
            PopulateClasses(_teacherID);

            lstClassesOfTeacher.SelectedIndex = 0;//select first class as default
        }

        private void lstClassesOfTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _classID = _classes[lstClassesOfTeacher.SelectedIndex].ClassId;
            PopulateHomeworkToMark(_classID);
        }

        private void PopulateClasses(int teacherID)
        {
            List<Class> classes = _classManagement.SelectAllClassesForATeacher(teacherID);

            lstClassesOfTeacher.Items.Clear();

            foreach (var item in classes)
            {
                _classes.Add(item);
                lstClassesOfTeacher.Items.Add(item);
            }
        }

        private void btnSelectHomeworkToGrade_Click(object sender, RoutedEventArgs e)
        {
            if (lstHomeworkToMark.SelectedIndex >= 0)
            {
                int homeworkID = _homeworkOfClass[lstHomeworkToMark.SelectedIndex].HomeworkId;

                TeacherWindow teacherWindow = (HomeworkCompanionGUI.TeacherWindow)App.Current.MainWindow;
                teacherWindow.TeacherFrame.Content = new GradeHomeworkPage(_classID, homeworkID, _teacherID);
            }
            else
            {
                MessageBox.Show("Please select a homework to grade");
            }

        }

        private void PopulateHomeworkToMark(int classID)
        {
            _homeworkOfClass = _homeworkManagement.SelectHomeworksInClassToMark(classID);

            lstHomeworkToMark.Items.Clear();

            foreach (var item in _homeworkOfClass)
            {
                if (item.Marks != null)
                {
                    lstHomeworkToMark.Items.Add($"{item.Title} - Graded: {item.Marks}");
                }
                else
                {
                    string submited = item.SubmissionDate == null ? "Not Submitted" : "Submited";

                    lstHomeworkToMark.Items.Add($"{item.Title} - {submited}");
                }
            }
        }


    }
}
