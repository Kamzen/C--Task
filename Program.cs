using System;
using System.Collections.Generic;



// method to check if operator
bool IsOperator(string op, Dictionary<string, int> operators)
{
    return operators.ContainsKey(op);
}

// method to convert postfix to infix
string PostfixToInfix(string postfix, Dictionary<string, int> operators)
{
    Stack<string> stack = new Stack<string>();
    string[] postfixArray = postfix.Split(' ');

    foreach (var item in postfixArray)
    {
        // check if the item is operand, if so push into the stack
        if (!IsOperator(item, operators))
        {
            stack.Push(item);
        }
        // else the item is operator
        else
        {
            string op1 = stack.Pop();
            string op2 = stack.Pop();

            string expression = $"({op1} {item} {op2})";

            stack.Push(expression);
        }
    }

    return stack.Pop();
}


void Main()
{
    // initialise your operators to compare with
    Dictionary<string, int> operators = new Dictionary<string, int> {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "x", 2 }, // Treat "×" as multiplication
        { "/", 2 },
        { "^", 3 }
    };

    Console.WriteLine("Enter your postfix notation (space separated) : ");
    string inputValue = Console.ReadLine();
    Console.WriteLine("Input: " +  inputValue);
    Console.WriteLine("Output: " + PostfixToInfix(inputValue, operators));

}


// invoke the Main function
Main();