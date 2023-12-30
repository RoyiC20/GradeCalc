using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{

    public class Game
    {
        private int n1 = 0; // first number
        private int n2 = 0; // second number 
        private int type = 0; //decides on the type of the exercise (+, -, *, /)
        int expected = 0; // the answer that is expected



        public int getExpected()
        {
            return this.expected;
        }

        public void modifyNumbers(string grade) // chooses the numbers randomly
        {

            Random rnd = new Random();
            if (grade == "Grade A")
            {
                // Grade A: Addition and Subtraction with numbers up to 20
                this.n1 = rnd.Next(0, 21);
                this.n2 = rnd.Next(0, 21);
            }
            else if (grade == "Grade B")
            {
                // Grade B: Addition and Subtraction with numbers up to 100
                this.n1 = rnd.Next(0, 101);
                this.n2 = rnd.Next(0, 101);
            }
            else if (grade == "Grade C")
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
            else if (grade == "Grade D")
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

        public string signDecider() // decides on the sign of the question (+, -, *, /)
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

        public string questionMaker() // makes the question in string form and finds the answer in int
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




    }

}
