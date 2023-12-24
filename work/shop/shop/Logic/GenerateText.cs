using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Logic
{
    static class GenerateText
    {
        static public string Generate(bool check)
        {
            Random random = new Random();
            string ret = "";
            string text = "";
            int count = 0;
            if(check)
            {
                text += "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
                ret += "login";
                count = 8;
            }
            else
            {
                text+= "wqertyuiop[]asdfghjkkll;lzxcnbmvb.,cvnbv23981903125%&*@#$(";
                count = 6;
            }
            for(int i =0;i<count;i++)
            {
                ret += text[random.Next(0, text.Length - 1)];
            }
            return ret;
        }
    }
}
