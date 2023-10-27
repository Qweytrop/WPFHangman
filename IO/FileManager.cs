using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.IO
{
    class FileManager
    {
        public static string ReadFile(){
            return Resources.WordList;
        }
    }
}
