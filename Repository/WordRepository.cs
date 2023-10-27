using Forca.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Repository
{
    class WordRepository
    {
        public List<string> WordList()
        {
            List<string> list = new List<string>();
            list = FileManager.ReadFile().ToUpper().Split("\r\n").ToList();
            
            for(int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Trim();
            }

            return list;
        }
    }
}
