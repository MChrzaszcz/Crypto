using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Tools
    {
        static public string addSpaces(IEnumerable<int> indexSpaceList, string output)
        {
            foreach (int spaceIndex in indexSpaceList)
            {
                if (spaceIndex != -1)
                {
                    output = output.Insert(spaceIndex - 1, " ");
                }
            }
            return output;
        }

        static public IEnumerable<int> getSpaceIndexes(string text)
        {
            int i = 0;
           return text.ToCharArray().Select(c => { i += 1; return c == ' ' ? i : -1; }); // if space add index else add -1
        }
    }
}
