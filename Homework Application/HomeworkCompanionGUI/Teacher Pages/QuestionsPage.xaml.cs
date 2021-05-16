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
    /// Interaction logic for QuestionsPage.xaml
    /// </summary>
    public partial class QuestionsPage : Page
    {
        private int? _selectedQuestion = null;
        private QuestionTemplateManagement _QTManager = new QuestionTemplateManagement();
        List<QuestionTemplate> allQuestionTemplates = new List<QuestionTemplate>();

        public QuestionsPage()
        {
            InitializeComponent();

            PopulateQuestionTemplateList();
        }

        public void PopulateQuestionTemplateList()
        {
            Clear();
            lstAllQuestionTemplates.Items.Clear();

            allQuestionTemplates.Clear();
            //List<QuestionTemplate> allQuestionTemplates = new List<QuestionTemplate>();
            allQuestionTemplates = _QTManager.SelectAllQuestionTemplates();

            foreach (var item in allQuestionTemplates)
            {
                lstAllQuestionTemplates.Items.Add(item);
            }

        }

        private void btnAddQuestionTemplate_Click(object sender, RoutedEventArgs e)
        {
            string maxMarksInput = txtMaximumMarks.Text;
            bool maxMarksIsInt = (int.TryParse(maxMarksInput, out _));
            
            if (txtQuestion.Text != "" && txtAnswer.Text != "" && txtMaximumMarks.Text != "" && maxMarksIsInt == true)
            {
                if ((int)Convert.ToInt32(maxMarksInput) <= 0)
                {
                    maxMarksInput = "1"; //sets default maximum marks to 1
                }

                _QTManager.CreateQuestionTemplate(txtQuestion.Text, txtAnswer.Text, Convert.ToInt32(maxMarksInput));
            }
            else
            {
                MessageBox.Show("Invalid input, Please be sure that the maximum marks input is an intager");
            }

            PopulateQuestionTemplateList();
        }

        private void btnUpdateQuestionTemplate_Click(object sender, RoutedEventArgs e)
        {
            string maxMarksInput = txtMaximumMarks.Text;
            bool maxMarksIsInt = (int.TryParse(maxMarksInput, out _));

            if (_selectedQuestion == null)
            {
                MessageBox.Show("Please select a question to update");
            }
            else if (maxMarksIsInt == true)
            {
                _QTManager.UpdateQuestionTemplate(Convert.ToInt32(_selectedQuestion), txtQuestion.Text, txtAnswer.Text, Convert.ToInt32(maxMarksInput));
            }
            else if (maxMarksIsInt == false)
            {
                MessageBox.Show("Invalid input, Please be sure that the maximum marks input is an intager");
            }

            PopulateQuestionTemplateList();
        }

        private void btnDeleteQuestionTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null)
            {
                MessageBox.Show("Please select a question to delete");
            }
            else
            {
                _QTManager.DeleteQuestionTemplate(Convert.ToInt32(_selectedQuestion));
            }

            PopulateQuestionTemplateList();
        }

        private void lstAllQuestionTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstAllQuestionTemplates.SelectedIndex < 0)
            {
                Clear();
            }
            else
            {
                //select question template id
                var currentQuestionTemplate = allQuestionTemplates[lstAllQuestionTemplates.SelectedIndex];

                _selectedQuestion = currentQuestionTemplate.QuestionId;

                txtQuestion.Text = currentQuestionTemplate.QuestionText;
                txtAnswer.Text = currentQuestionTemplate.Answer;
                txtMaximumMarks.Text = currentQuestionTemplate.MaximumMarks.ToString();
            }


        }


        public void Clear()
        {
            _selectedQuestion = null;

            txtQuestion.Text = "";
            txtAnswer.Text = "";
            txtMaximumMarks.Text = "";
        }


    }
}
