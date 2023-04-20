using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common;
public static class UniqueCode
{
    public static string CreateUniqueCode(int codeLength , bool isDigital, string specialInitial= "")
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
        if (specialInitial != string.Empty)
            code = specialInitial + code;
        return code;
    }
}