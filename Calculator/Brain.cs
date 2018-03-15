using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    delegate void Delegate(string msg);

    public enum State
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        ComputeWithPending,
        ComputeWithoutPending,
        ShowResult,
        ShowError
    }

    class Brain
    {
        string[] all_digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] non_zero_digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] zero_digits = { "0" };

        string[] operations = { "+", "-", "x", "/", "1/x" };
        string[] equals = { "=" };
        string[] separators = { "," };

        State state;
        public Delegate invoker;
        string currentNum;
        string firstNum;
       // string secondNum;
        string result;

        public Brain()
        {
            state = State.Zero;
            currentNum = "0";
        }

        public void Process(string msg)
        {
            switch (state)
            {
                case State.Zero:
                    Zero(false, msg);
                    break;
                case State.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;
                case State.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, msg);
                    break;
                case State.ComputeWithPending:
                    ComputeWithPending(false, msg);
                    break;
                case State.ComputeWithoutPending:
                    ComputeWithoutPending(false, msg);
                    break;
                case State.ShowResult:
                    ShowResult(false, msg);
                    break;
                case State.ShowError:
                    break;
                default:
                    break;
            }
            invoker.Invoke(currentNum);
        }

        public void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                invoker.Invoke("0");
                Zero(true, msg);
            }
            else
            {
                currentNum = "";
                if (non_zero_digits.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (zero_digits.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (operations.Contains(msg))
                {
                    Compute(true, msg);
                }
                
            }
        }
        public void AccumulateDigits(bool isInput, string msg)
        {
            
            if (isInput)
            {
                currentNum += msg;
                invoker.Invoke(msg);
                state = State.AccumulateDigits;
            }
            else if (operations.Contains(msg))
            {
                Compute(true, msg);
            }

        }
        public void AccumulateDigitsWithDecimal(bool isInput, string info)
        {

        }
        public void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                ShowResult(true, msg);   
            }
            else
            {
                if (all_digits.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }
            }
        }

        public void ComputeWithPending(bool isInput, string info)
        {

        }

        public void ComputeWithoutPending(bool isInput, string info)
        {

        }


        public void ShowResult(bool isInput, string msg)
        {
            if (isInput)
            {
                switch (msg)
                {
                    case "+":
                        result = (int.Parse(firstNum) + int.Parse(currentNum)).ToString();
                        break;
                    case "-":
                        result = (int.Parse(firstNum) - int.Parse(currentNum)).ToString();
                        break;
                    case "x":
                        result = (int.Parse(firstNum) * int.Parse(currentNum)).ToString();
                        break;
                    case "/":
                        result = (int.Parse(firstNum) / int.Parse(currentNum)).ToString();
                        break;
                    case "x^2":
                        result = (int.Parse(firstNum) * int.Parse(firstNum)).ToString();
                        break;
                }
                firstNum = "";
                currentNum = result;
                invoker.Invoke(result);
                state = State.ShowResult;
            }
            else
            {
                if (zero_digits.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (operations.Contains(msg))
                {
                    Compute(true, msg);
                }
            }
        }

        public void ShowError(bool isInput, string info)
        {

        }
    }
}
