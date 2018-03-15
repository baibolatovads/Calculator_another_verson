using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Brain brain = new Brain();
        public Form1()
        {
            InitializeComponent();
            brain.invoker = ShowMessage;
        }
        
        public void ShowMessage(string msg)
        {
            display.Text = msg;
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);

        }

        /*
    private void resultBtnClck(object sender, EventArgs e)
    {
        Button operationBtn = sender as Button;
        calc.currentState = CalcStates.FirstNumber;
        calc.secondNumber = double.Parse(display.Text);

        switch (calc.currentOperation)
        {
            case OperationsState.Plus:
                calc.resultNumber = calc.firstNumber + calc.secondNumber;
                break;
            case OperationsState.Minus:
                calc.resultNumber = calc.firstNumber - calc.secondNumber;
                break;
            case OperationsState.OVERX:
                calc.resultNumber = (1/calc.firstNumber);
                break;
            case OperationsState.Square:
                calc.resultNumber = calc.firstNumber * calc.firstNumber;
                break;
            case OperationsState.Multiplication:
                calc.resultNumber = calc.firstNumber * calc.secondNumber;
                break;
            case OperationsState.Division:
                calc.resultNumber = calc.firstNumber / calc.secondNumber;
                break;
            case OperationsState.SquareRoot:
                calc.resultNumber = Math.Sqrt(calc.firstNumber);
                break;

            default:
                break;
        }


        display.Text = calc.resultNumber.ToString();
    }

    private void operationBtnClck(object sender, EventArgs e)
    {
        Button operationBtn = sender as Button;

        if (operationBtn.Text == "+")
        {
            calc.currentOperation = OperationsState.Plus;
        }
        else if (operationBtn.Text == "-")
        {
            calc.currentOperation = OperationsState.Minus;
        }
        else if (operationBtn.Text == "1/x")
        {
            calc.currentOperation = OperationsState.OVERX;
        }
        else if (operationBtn.Text == "x^2")
        {
            calc.currentOperation = OperationsState.Square;
        } else if (operationBtn.Text == "x")
        {
            calc.currentOperation = OperationsState.Multiplication;
        }else if (operationBtn.Text == "/")
        {
            calc.currentOperation = OperationsState.Division;
        }

        calc.currentState = CalcStates.SecondNumber;

        if (calc.resultNumber != 0)
        {
            calc.firstNumber = calc.resultNumber;
        }
        else
        {
            calc.firstNumber = double.Parse(display.Text);
        }

        display.Text = "0";
    }

    //+
    private void dgtBtnClck(object sender, EventArgs e)
    {
        Button dgtBtn = sender as Button;

        if(dgtBtn.Text == ",")
        {
            if (!display.Text.Contains(","))
            {
                display.Text += dgtBtn.Text;
            }

        }

        else if(dgtBtn.Text != ",")
        {
            if(display.Text == "0")
            {
                display.Text = dgtBtn.Text;
            }
            else
            {
                display.Text += dgtBtn.Text;
            }
        }

    }

    private void Delete_Click(object sender, EventArgs e)
    {
        display.Text = display.Text.Remove(display.Text.Length - 1, 1);
        if (display.Text.Length == 0)
        {
            display.Text = "0";
        }
    }

    */
    }
}
