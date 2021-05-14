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
    /// Interaction logic for ViewHomeworkPage.xaml
    /// </summary>
    public partial class ViewHomeworkPage : Page
    {
        private int _currentStudent = 1;//change when login is added
        private HomeworkManagement _homeworkManagement = new HomeworkManagement();
        private CompleteHomeworkPage _viewHomeworkPage;

        private List<Homework> _homeworkSelection = new List<Homework>();
        public ViewHomeworkPage()
        {
            InitializeComponent();

            FillCurrentlyAssignedHomeworks();
        }

        private void FillCurrentlyAssignedHomeworks()
        {
            List<Homework> studentsCurrentHomework = _homeworkManagement.SelectDueHomework(_currentStudent);

            //studentsCurrentHomework = _homeworkManagement.SelectDueHomework(_currentStudent);


            foreach (var item in studentsCurrentHomework)
            {
                _homeworkSelection.Add(item);
                lstAllPendingHomework.Items.Add(item);
            }
        }

        private void btnSelectHomeworkToComplete_Click(object sender, RoutedEventArgs e)
        {
            if (lstAllPendingHomework.SelectedIndex >= 0)
            {
                //_viewHomeworkPage = new CompleteHomeworkPage(_homeworkSelection[lstAllPendingHomework.SelectedIndex].HomeworkId);
                StudentWindow studentWindow = (HomeworkCompanionGUI.StudentWindow)App.Current.MainWindow;
                studentWindow.StudentFrame.Content = new CompleteHomeworkPage(_homeworkSelection[lstAllPendingHomework.SelectedIndex].HomeworkId);

            }
            else
            {
                MessageBox.Show("Please select a homework");
            }
        }



    }
}
