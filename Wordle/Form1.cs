namespace Wordle
{
	public partial class Form1 : Form
	{
		public TextBox[,] LetterArray = new TextBox[6, 5];
		public Form1()
		{
			InitializeComponent();
		}

		public void InstantiateArray()
		{
			for (int row = 0; row < LetterArray.GetLength(0); row++)
			{
				for (int col = 0; col < LetterArray.GetLength(1); col++)
				{
					TextBox temp = new TextBox;
					temp.Font.
				}
			}
		}
	}
}