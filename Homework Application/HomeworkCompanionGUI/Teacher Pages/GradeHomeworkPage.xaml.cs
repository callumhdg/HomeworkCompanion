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
    /// Interaction logic for GradeHomeworkPage.xaml
    /// </summary>
    public partial class GradeHomeworkPage : Page
    {
        private int _classID, _homeworkID, _teacherID;

        private AssignedQuestionManagement _assignedQuestionManagement = new AssignedQuestionManagement();
        private HomeworkManagement _homeworkManagement = new HomeworkManagement();

        private List<AssignedQuestion> _questionsInHomework = new List<AssignedQuestion>();

        public GradeHomeworkPage(int classID, int homeworkID, int teacherID)
        {
            InitializeComponent();

            _classID = classID;
            _homeworkID = homeworkID;
            _teacherID = teacherID;

            PopulateQuestions(_homeworkID);
            lstQuestionsInHomework.SelectedIndex = 0;//selects first question by default
        }

        private void lstQuestionsInHomework_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtQuestion.Text = _questionsInHomework[lstQuestionsInHomework.SelectedIndex].QuestionText;
            txtAnswer.Text = _questionsInHomework[lstQuestionsInHomework.SelectedIndex].TeachersAnswer;
            txtStudentAnswer.Text = _questionsInHomework[lstQuestionsInHomework.SelectedIndex].SubmitedAnswer;

            int currentQuestionMarks = (_questionsInHomework[lstQuestionsInHomework.SelectedIndex].AwardedMarks == null) ? 0 : (int)_questionsInHomework[lstQuestionsInHomework.SelectedIndex].AwardedMarks;

            txtMarks.Text = currentQuestionMarks.ToString();

            ////change marked homework colour in listbox
            //for (int i = 0; i < lstQuestionsInHomework.Items.Count; i++)            
            //{
            //    if (_questionsInHomework[i].AwardedMarks != null)
            //    {
            //        lstQuestionsInHomework.Items[i]
            //    }
            //}
        }

        private void btnSubmitMarkedHomework_Click(object sender, RoutedEventArgs e)
        {            
            int allMaxMarks = 0, allAwardedMarks = 0;

            for (int i = 0; i < _questionsInHomework.Count; i++)
            {
                if (_questionsInHomework[i].AwardedMarks == null)
                {
                    _questionsInHomework[i].AwardedMarks = 0;
                }
                else if (_questionsInHomework[i].AwardedMarks > _questionsInHomework[i].MaximumMarks)
                {
                    _questionsInHomework[i].AwardedMarks = _questionsInHomework[i].MaximumMarks;
                }
            }

            foreach (var item in _questionsInHomework)
            {
                allMaxMarks += item.MaximumMarks;
                allAwardedMarks += (int)item.AwardedMarks;
            }

            int persentageGrade = (int)Math.Round((double)(100 * allAwardedMarks) / allMaxMarks);
            string marks = $"{allAwardedMarks} / {allMaxMarks} - {persentageGrade}%";

            _homeworkManagement.AssignMarksToHomework(_homeworkID, marks, _questionsInHomework);

            TeacherWindow teacherWindow = (HomeworkCompanionGUI.TeacherWindow)App.Current.MainWindow;
            teacherWindow.TeacherFrame.Content = new ViewSubmitedHomeworkPage(_classID, _teacherID);
        }

        private void txtMarks_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMarks.Text == "")
            {

            }
            else
            {
                bool inputIsInt = int.TryParse(txtMarks.Text, out _);

                if (inputIsInt == true)
                {
                    if (Convert.ToInt32(txtMarks.Text) >= _questionsInHomework[lstQuestionsInHomework.SelectedIndex].MaximumMarks)
                    {
                        _questionsInHomework[lstQuestionsInHomework.SelectedIndex].AwardedMarks = _questionsInHomework[lstQuestionsInHomework.SelectedIndex].MaximumMarks;
                    }
                    else
                    {
                        _questionsInHomework[lstQuestionsInHomework.SelectedIndex].AwardedMarks = Convert.ToInt32(txtMarks.Text);
                    }
                }
                else
                {
                    string removeLastChar = txtMarks.Text, invalidInput = "";
                    invalidInput = removeLastChar.Substring((removeLastChar.Length - 1), 1);
                    removeLastChar = removeLastChar.Substring(0, (removeLastChar.Length - 1));

                    MessageBox.Show($"{invalidInput} is not a valid input, please only input an intager number");

                    txtMarks.Text = removeLastChar;
                }
            }
        }

        private void PopulateQuestions(int homeworkID)
        {
            _questionsInHomework = _assignedQuestionManagement.SelectAllQuestionsInHomework(homeworkID);

            lstQuestionsInHomework.Items.Clear();

            for (int i = 0; i < _questionsInHomework.Count; i++)
            {
                lstQuestionsInHomework.Items.Add($"{i} - {_questionsInHomework[i].QuestionText} - Maximum Marks:{_questionsInHomework[i].MaximumMarks}");
            }
        }


    }
}
