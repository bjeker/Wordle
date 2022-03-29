using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class GameLogic
    {
        public List<string> words = new List<string>();
        Random random = new Random();
        public string answer = "";
        public int numGuesses = 0;

        //read words from wordle file
        private void ReadWords()
        {
            words = File.ReadAllLines("words//wordle-answers-alphabetical.txt").ToList();
        }

        //get a random word
        public void RandWord()
        {
            int index = random.Next(words.Count);
            answer = words[index];
        }

        //starts the game
        public void StartGame()
        {
            ReadWords();
            RandWord();
            
            //REMOVE THIS TEST
            MessageBox.Show(answer);
        }
    }
}
