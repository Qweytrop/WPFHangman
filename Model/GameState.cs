using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;

namespace Forca.Model
{
    public class GameState
    {
        public string ChosenWord {get; set;}
        public string VeiledWord { get; private set; }

        public bool IsAlive { get { return Health > 0; } }
        
        /*
        public bool IsAlive2 => Health > 0;

        public bool IsAlive3 { get => Health>0; }
        */

        public int Health { get; set; }

        public string rightGuesses;
        public string RightGuesses
        {
            get { return rightGuesses; }
            set { rightGuesses = value;
                  BuildVeiled();}
        }
        
        public string WrongGuesses { get; set; }

        public GameState(string word)
        {
            ChosenWord = word;
            Health = 5;
            RightGuesses = "";
            WrongGuesses = "";
        }

        private void BuildVeiled()
        {
            string shownWord = "";
            char x;

            for(int i = 0; i<ChosenWord.Length; i++)
            {
                x = ChosenWord[i];

                if (RightGuesses.Contains(x))
                {
                    shownWord += " " + x + " ";
                }
                else
                {
                    shownWord += " _ ";
                }
            }

            VeiledWord = shownWord;
        }
    }
}
