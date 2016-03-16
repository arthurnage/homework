using System;

namespace MyWorks
{
	public class Tree
	{
		private string expression;
		private ITreeNode root;
		// constructor
		public Tree(string inputLine) 
		{
			expression = inputLine;
			int index = 0;
			var node = new Operator();
			Initialize(ref index, ref node);
			root = node;
		}

		// function for calculating an expression
		private void Initialize(ref int index, ref Operator node)
		{
			index += 2; // read '( '
			var treeNode = new Operator();
			switch (expression[index])
			{
			case '+':
				{
					treeNode = new OperatorPlus();
				}
				break;
			case '-':
				{
					treeNode = new OperatorMinus();
				}
				break;
			case '*':
				{
					treeNode = new OperatorMultiplicate();
				}
				break;
			case '/':
				{
					treeNode = new OperatorDivide();
				}
				break;
			default:
				{
					//
				}
				break;
			}
			index += 2; // read a sign
			if (expression[index] == '(')
			{
				var treeNodeLeft = new Operator();
				Initialize(ref index, ref treeNodeLeft);
				treeNode.Left = new Operator();
				treeNode.Left = treeNodeLeft;
			}
			else
			{
				var treeNodeLeft = new Operand((int)(expression[index] - '0'));
				treeNode.Left = treeNodeLeft;
				index += 2; // read a number
			}
			if (expression[index] == '(')
			{
				var treeNodeRight = new Operator();
				Initialize(ref index, ref treeNodeRight);
				treeNode.Right = new Operator();
				treeNode.Right = treeNodeRight;
			}
			else
			{
				var treeNodeRight = new Operand((int)(expression[index] - '0'));
				treeNode.Right = treeNodeRight;
				index += 2; // read a number
			}
			index += 2; // read spacebar
			node = treeNode;
		}

		// print all the tree
		public void Print()
		{
			root.Print();
		}

		// calculate the expression
		public int Calculate()
		{
			return root.Calculate();
		}
	}
}