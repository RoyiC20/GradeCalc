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

namespace GradeCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = ""; // name of answerer
        string grade = ""; // grade of the answerer
        int n1; // first number
        int n2; // second number 
        int type = 0; //decides on the type of the exercise (+, -, *, /)
        int counter = 1; // counts the questions
        int expected = 0; // the answer that is expected
        int correctCounter = 0; // the number of correct answers
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void classComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = this.comboBox.SelectedItem as ComboBoxItem;

            this.grade = comboBoxItem.Content.ToString();

            checkStartEnabled();
        }

        private void checkStartEnabled()
        {
            // check if name exists and grade selected then enable
            if (nameOfAnswerer.Text.Length > 0 && this.grade.Length > 0)
            {
                startLearning.IsEnabled = true;
            }
            else
            {
                startLearning.IsEnabled = false;
            }
        }

        private void StartLearning_Click(object sender, RoutedEventArgs e) // the "start learning button"
        {
            
            prepareNextQuestion();
            this.name = nameOfAnswerer.Text;
            switchVisibility();
        }

        private void prepareNextQuestion() //makes the next question
        {
            modifyNumbers();
            answerTextBox.Text = "";
            question.Text = questionMaker();
            questionNumber.Text = ($"Question number {this.counter}");
            this.counter++;
        }

        
        private void modifyNumbers() // chooses the numbers randomly
        {

            Random rnd = new Random();
            if (this.grade == "Grade A")
            {
                // Grade A: Addition and Subtraction with numbers up to 20
                this.n1 = rnd.Next(0, 21);
                this.n2 = rnd.Next(0, 21);
            }
            else if (this.grade == "Grade B")
            {
                // Grade B: Addition and Subtraction with numbers up to 100
                this.n1 = rnd.Next(0, 101);
                this.n2 = rnd.Next(0, 101);
            }
            else if (this.grade == "Grade C")
            {
                // Grade C: Addition and Subtraction with numbers up to 1000 
                // Division with numbers up to 100 (the left side of division) and up to 10 (the right side), Multiplication up to 10

                Random rnd2 = new Random(); // makes it random between being a devision or multi, or being a addition or substraction
                this.type = rnd2.Next(0, 2);

                if (this.type == 0)
                {
                    this.n1 = rnd.Next(0, 1001);
                    this.n2 = rnd.Next(0, 1001);
                }
                else
                {
                    this.n1 = rnd.Next(0, 11);
                    this.n2 = rnd.Next(1, 11); // this is 1 because there cant be division by 0
                }
            }
            else if (this.grade == "Grade D")
            {
                // Grade D: Addition and Subtraction with numbers up to 10000
                // Division with numbers up to 2500 (the left side of division) and up to 50 (the right side), Multiplication up to 50

                Random rnd2 = new Random(); // makes it random between being a devision or multi, or being a addition or substraction
                this.type = rnd2.Next(0, 2);

                if (this.type == 0)
                {
                    this.n1 = rnd.Next(0, 10001);
                    this.n2 = rnd.Next(0, 10001);
                }
                else
                {
                    this.n1 = rnd.Next(0, 51);
                    this.n2 = rnd.Next(1, 51); // this is 1 because there cant be division by 0
                }
            }
        }




        private string signDecider() // decides on the sign of the question (+, -, *, /)
        {
            // + == 0
            // - == 1

            // * == 0
            // / == 1


            Random rnd = new Random();
            int num = rnd.Next(0, 2);

            if (this.type == 0)
            {
                if (num == 0)
                    return "+";
                else 
                    return "-";
            }
            else
            {
                if (num == 0)
                    return "*";
                else
                    return "/";
            }
        }



        private string questionMaker() // makes the question in string form and finds the answer in int
        {
            int n1 = this.n1;
            int n2 = this.n2;

            string currentSign = signDecider();
            if (currentSign == "+") // makes it a + exercise
            {
                this.expected = this.n1 + this.n2;
            }
            else if (currentSign == "-") // makes it a - exercise and puts the bigger number first
            {
                if (n1 > n2)
                {
                    this.expected = this.n1 - this.n2;
                }
                else
                {
                    this.expected = this.n2 - this.n1;
                    n2 = this.n1;
                    n1 = this.n2;
                }
            }
            else if (currentSign == "*") // makes it a * exercise
            {
                this.expected = this.n1 * this.n2;
            }
            else  // makes it a / exercise by doing (N1 * N2) / N2 to guarentee full numbers
            {
                this.expected = (this.n1 * this.n2) / this.n2;
                n1 = this.n1 * this.n2;
            }


            return ($"{n1} {currentSign} {n2}"); // returns the question in string
        }


        private void switchVisibility() // if the first panel is visible, it'll make the second panel visible and turn itself to collapsed and keeps going to the third panel
        {
            if (welcomePanel.Visibility == Visibility.Visible)
            {
                welcomePanel.Visibility = Visibility.Collapsed;
                answersPanel.Visibility = Visibility.Visible;
            }
            else if (answersPanel.Visibility == Visibility.Visible)
            {
                answersPanel.Visibility = Visibility.Collapsed;
                resultPanel.Visibility = Visibility.Visible;
            }   
        }


        private void nextQuestion_Click(object sender, RoutedEventArgs e)
        {

            if (answerTextBox.Text == this.expected.ToString()) //checks if the answer is right
            {
                this.correctCounter++;
            }
            if (this.counter == 10) // if the counter reaches 10 it changes thee text on the button
            {
                nextQuestion.Content = "Finish test and get results";
            }  
            else if (this.counter == 11) // after the last question, it shows the final good job screen
            {
                greatJob.Text = $"Great job {this.name}!";
                results.Text = $"{this.correctCounter * 10}/100";

                switchVisibility();

                return;
            }

            prepareNextQuestion();
        }

        private void nameOfAnswerer_TextChanged(object sender, TextChangedEventArgs e) 
        {
            checkStartEnabled(); // checks that a name has been written
        }
    }
}
