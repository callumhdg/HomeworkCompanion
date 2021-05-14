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
    /// Interaction logic for CompleteHomeworkPage.xaml
    /// </summary>
    public partial class CompleteHomeworkPage : Page
    {
        private int _selectedID = 0;

        private List<AssignedQuestion> _allCurrentQuestions = new List<AssignedQuestion>();

        private AssignedQuestionManagement _aqManagement = new AssignedQuestionManagement();

        public CompleteHomeworkPage(int id)
        {
            InitializeComponent();
            _selectedID = id;

            InitaliseQuestionsInHomework();
        }


        private void InitaliseQuestionsInHomework()
        {
            _allCurrentQuestions = _aqManagement.SelectAllQuestionsInHomework(_selectedID);

            for (int i = 0; i < _allCurrentQuestions.Count; i++)
            {
                //lstQuestionsInHomework.Items.Add($"{i} - {_allCurrentQuestions[i].QuestionText} - Max Marks: {_allCurrentQuestions[i].MaximumMarks}");
                lstQuestionsInHomework.Items.Add($"{i} - {_allCurrentQuestions[i].QuestionText}");
            }

        }

        private void btnSubmitHomework_Click(object sender, RoutedEventArgs e)
        {
            _aqManagement.SubmitHomework(_allCurrentQuestions);

            StudentWindow studentWindow = (HomeworkCompanionGUI.StudentWindow)App.Current.MainWindow;
            studentWindow.StudentFrame.Content = new ViewHomeworkPage();
        }

        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lstQuestionsInHomework.SelectedIndex >= 0)
            {
                _allCurrentQuestions[lstQuestionsInHomework.SelectedIndex].SubmitedAnswer = txtAnswer.Text;    
            }
        }

        private void lstQuestionsInHomework_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtQuestion.Text = _allCurrentQuestions[lstQuestionsInHomework.SelectedIndex].QuestionText;
            txtAnswer.Text = _allCurrentQuestions[lstQuestionsInHomework.SelectedIndex].SubmitedAnswer;
        }

        private void btnSaveAsDraft_Click(object sender, RoutedEventArgs e)
        {
            _aqManagement.SaveDraftHomework(_allCurrentQuestions);
        }



    }
}
