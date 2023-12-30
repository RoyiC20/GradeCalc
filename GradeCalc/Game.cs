using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
    internal class Game
    {
    }

    public class game
    {
        private string name = ""; // name of answerer
        private string grade = ""; // grade of the answerer
        private int n1 = 0; // first number
        private int n2 = 0; // second number 
        private int type = 0; //decides on the type of the exercise (+, -, *, /)
        private int counter = 1; // counts the questions
        private int expected = 0; // the answer that is expected
        private int correctCounter = 0; // the number of correct answers




        private string getName()
        {
            return this.name;
        }

        private string getGrade()
        {
            return this.grade;
        }

        private int getN1()
        {
            return this.n1;
        }
        private int getN2()
        {
            return this.n2;
        }
        private int getType()
        {
            return this.type;
        }
        private int getCounter()
        {
            return this.counter;
        }
        private int getExpected()
        {
            return this.expected;
        }
        private int getCorrectCounter()
        {
            return this.correctCounter;
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



    }

}
