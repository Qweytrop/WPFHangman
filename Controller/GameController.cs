using Forca.Model;
using Forca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Forca.Controller
{
    public class GameController
    {
        private WordRepository dictionary;
        private GameState gameState;

        public GameController()
        {
            dictionary = new WordRepository();
        }

        public GameState NewGame()
        {
            gameState = new(PickWord());
            return gameState;
        }

        private string PickWord()
        {
            Random rand = new Random();
            List<string> words = dictionary.WordList();
            string chosenWord = words[rand.Next(0, words.Count())];
            return chosenWord;
        }

        public GameState Guess(char guess)
        {
            if (gameState.ChosenWord.Contains(guess))
            {
                gameState.RightGuesses += guess;
            } else
            {
                gameState.Health--;
                gameState.WrongGuesses += guess;
            }

            

            return gameState;
        }
    }

}
