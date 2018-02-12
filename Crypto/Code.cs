using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    interface Code
    {
       string encode(string text);
       string decode(string text);
    }
}
