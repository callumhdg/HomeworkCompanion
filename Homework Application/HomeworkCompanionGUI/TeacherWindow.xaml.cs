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
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private int _teacherID = 0;
        public TeacherWindow(int teacherID)
        {
            InitializeComponent();

            _teacherID = teacherID;
            TeacherFrame.Content = new TeacherPage(_teacherID);
        }

        private void btnQuestions_Click(object sender, RoutedEventArgs e)
        {
            TeacherFrame.Content = new QuestionsPage();
        }

        private void btnTeacherLogout_Click(object sender, RoutedEventArgs e)
        {
            //TeacherWindow teacherWindow = (HomeworkCompanionGUI.TeacherWindow)App.Current.MainWindow;
            TeacherWindow teacherWindow = (HomeworkCompanionGUI.TeacherWindow)App.Current.MainWindow;
            teacherWindow.Visibility = System.Windows.Visibility.Hidden;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            App.Current.MainWindow = mainWindow;
        }

        private void btnClassesPage_Click(object sender, RoutedEventArgs e)
        {
            TeacherFrame.Content = new ClassPage(_teacherID);
        }

        private void btnAssignHomeworkPage_Click(object sender, RoutedEventArgs e)
        {
            TeacherFrame.Content = new HomeworkPage(_teacherID);
        }

        private void btnGradeHomeworkPage_Click(object sender, RoutedEventArgs e)
        {
            TeacherFrame.Content = new ViewSubmitedHomeworkPage(_teacherID);
        }
    }
}
