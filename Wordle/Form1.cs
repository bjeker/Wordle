namespace Wordle
{
	public partial class Form1 : Form
	{
		public TextBox[,] letterArray = new TextBox[6, 5];
		public Button guessBtn = new Button();
		public GameLogic game = new GameLogic();
		public string guess = "";

		//initializes the game
		public Form1()
		{
			InitializeComponent();
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.AutoSize = true;
			InstantiateArray();
			SetGuessButton();
			StartRow();
			game.StartGame();

		}

		//tab over when char is entered
		public void TabOver(object sender, EventArgs e)
		{
			//check if char is entered
			if (((TextBox)sender).TextLength == 1)
			{
				//tabs over
				SendKeys.Send("{TAB}");
			}
			else
			{
				//goes back
				SendKeys.Send("+{TAB}");
			}
		}

		//enable one row and disable the rest
		public void StartRow()
		{
			for (int row = 0; row < letterArray.GetLength(0); row++)
			{
				if (row == game.numGuesses)
				{
					//enables row
					for (int col = 0; col < letterArray.GetLength(1); col++)
					{
						letterArray[row, col].Enabled = true;
					}

				}
				else
				{
					//disables row
					for (int col = 0; col < letterArray.GetLength(1); col++)
					{
						letterArray[row, col].Enabled = false;
					}
				}
			}
		}

		//initialize the array and handles auto tab over when text entered
		public void InstantiateArray()
		{
			for (int row = 0; row < letterArray.GetLength(0); row++)
			{
				for (int col = 0; col < letterArray.GetLength(1); col++)
				{
					TextBox temp = new TextBox();
					temp.Size = new Size(32, 32);
					temp.MaxLength = 1;
					temp.TabIndex = row * letterArray.GetLength(1) + col;
					temp.Location = new Point(col * temp.Size.Width + 4, 48 + row * (temp.Size.Height + 8));
					letterArray[row, col] = temp;
					this.Controls.Add(temp);

					temp.TextChanged += TabOver;
				}
			}
		}

		//sets up guess button and handles when clicked
		public void SetGuessButton()
		{
			guessBtn.Size = new Size((letterArray[0, 0].Size.Width + 4) * letterArray.GetLength(1), 48);
			guessBtn.Location = new Point(0, 48 + (letterArray[0, 0].Size.Height + 8) * letterArray.GetLength(0));
			guessBtn.Text = "Guess";
			this.Controls.Add(guessBtn);
			guessBtn.Click += GuessButtonClicked;
		}

		//checks if word is right when guess button is clicked
		public void GuessButtonClicked(Object sender, EventArgs e)
		{
			int arrayLength = 5;
			guess = "";

			//add guess to string
			for (int i = 0; i < arrayLength; i++)
			{
				guess += letterArray[game.numGuesses, i].Text;
			}

			//check if valid guess
			if (game.words.Contains(guess))
            {
				CheckWord();
			}
            else
            {
				MessageBox.Show("Word not in list");
            }

			StartRow();

			if (game.numGuesses == 6)
            {
				MessageBox.Show(game.answer + " was the correct word", "Correct Word");
            }
		}

		//check if guess is right
		public void CheckWord()
		{
			//Checks if word is in list of valid words
			for (int i = 0; i < 5; i++)
			{
				//correct letter
				if (game.answer.Contains(guess[i]))
				{
					//correct letter and spot
					if (game.answer[i] == guess[i])
					{
						letterArray[game.numGuesses, i].BackColor = Color.LightGreen;
					}
					//correct letter and incorrect spot
					else
					{
						letterArray[game.numGuesses, i].BackColor = Color.Yellow;
					}
				}
			}
			//check if word is correct
			if (game.answer == guess)
			{
				MessageBox.Show("You got the word correct in " + (game.numGuesses + 1) + " guesses!");
				MessageBox.Show("The game will restart now.");
				Application.Restart();
			}
			game.numGuesses++;
		}
	}
}