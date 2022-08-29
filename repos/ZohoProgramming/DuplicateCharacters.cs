using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoProgramming
{
    public class DuplicateCharacters
    {
    public void Main()
    {
        string s = "Codingg code";
        char[] ch = new Char[s.length];
        
        for(int i=0;i<s.length;i++)
        {
            ch[i] = s[i];
        }
        for(int i =0;i<s.length-1;i++)
        {
            for(int j=i+1;j<s.length;j++)
            {
              if(ch[i]==ch[j])
              {
                Console.WriteLine(ch[j]);
                
              }
            }
          
        }
    }
    }
}
