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
    /// Interaction logic for HomeworkPage.xaml
    /// </summary>
    public partial class HomeworkPage : Page
    {
        private int _currentTeacher = 1; //change when login is added

        private List<QuestionTemplate> _questionBank = new List<QuestionTemplate>();
        private List<QuestionTemplate> _selectedQuestions = new List<QuestionTemplate>();
        private List<Class> _classesOfTeacher = new List<Class>();

        private QuestionTemplateManagement _questionTemplateManagement = new QuestionTemplateManagement();
        private ClassManagement _classManagement = new ClassManagement();

        public HomeworkPage()
        {
            InitializeComponent();

            FillQuestionBank();
            FillClassList(_currentTeacher);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Clear();

            foreach (var item in _questionBank)
            {
                lstQuestionBank.Items.Add(item);
            }

            foreach (var item in _selectedQuestions)
            {
                lstQuestionsInHomework.Items.Add(item);
            }

        }

        private void FillQuestionBank()
        {
            _questionBank = _questionTemplateManagement.SelectAllQuestionTemplates();
        }

        private void FillClassList(int id)
        {
            _classesOfTeacher = _classManagement.SelectAllClassesForATeacher(id);

            foreach (var item in _classesOfTeacher)
            {
                cbxSelectClass.Items.Add(item);
            }
        }

        private void Clear()
        {
            lstQuestionBank.Items.Clear();
            lstQuestionsInHomework.Items.Clear();
        }

        private void btnAddQuestionToHomework_Click(object sender, RoutedEventArgs e)
        {
            if (lstQuestionBank.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a question to add");
            }
            else
            {
                _selectedQuestions.Add(_questionBank[lstQuestionBank.SelectedIndex]);
                _questionBank.RemoveAt(lstQuestionBank.SelectedIndex);
            }
            UpdateDisplay();
        }

        private void btnRemoveQuestionFromHomework_Click(object sender, RoutedEventArgs e)
        {
            if (lstQuestionsInHomework.SelectedIndex < 0) 
            {
                MessageBox.Show("Please select a question to remove");
            }
            else
            {
                _questionBank.Add(_selectedQuestions[lstQuestionsInHomework.SelectedIndex]);
                _selectedQuestions.RemoveAt(lstQuestionsInHomework.SelectedIndex);
            }
            UpdateDisplay();
        }

        private void btnAssignHomeworkToClass_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestions.Count == 0)
            {
                MessageBox.Show("Please select at least one qustion to add to this homwork");
            }
            else if (cbxSelectClass.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a class to assign homework to");
            }
            else
            {

            }

        }


    }
}
