using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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
        int counter = 1; // counts the questions
        int correctCounter = 0; // the number of correct answers

        Game game = new Game();

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
            game.modifyNumbers(this.grade);
            answerTextBox.Text = "";
            question.Text = game.questionMaker();
            questionNumber.Text = ($"Question number {this.counter}");
            this.counter++;
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


            if (answerTextBox.Text == game.getExpected().ToString()) //checks if the answer is right
            {
                

                this.correctCounter++;


                SoundPlayer playsound = new SoundPlayer("Sounds/success.wav"); // plays success sound
                playsound.Load();
                playsound.Play();

            }
            else
            {
                SoundPlayer playsound = new SoundPlayer("Sounds/error.wav");  // plays error sound
                playsound.Load();
                playsound.Play();
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
