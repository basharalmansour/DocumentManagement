using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common;
public class UniqueCode
{
    public UniqueCode(int codeLength, bool isDigital)
    {
        CreateUniqueCode(codeLength, isDigital);
    }
    public string CreateUniqueCode(int codeLength , bool isDigital)
    {
        Random rnd = new Random();
        string chars;
        if (!isDigital)
            chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        else
            chars = "0123456789";
        string code = "";
        for (int i = 0; i <= codeLength-1 ; i++)
        {
            code += chars[rnd.Next(chars.Length)];
        }
        return code;
    }
}