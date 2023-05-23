using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums;
public enum DocumentFileType
{
    PDF,
    Word,
    TxtFile
}
public static class DocumentFileExtension
{
    public static string[] AcceptedExtensions = new[] { ".pdf", ".docx",".txt"  };
    public static List<string> ConvertToString(List<DocumentFileType> fileTypes)
    {
        List<string> result = new List<string>();
        foreach (var type in fileTypes)
        {
            if (type == DocumentFileType.PDF)
                result.Add(AcceptedExtensions[0]);
            else if (type == DocumentFileType.Word)
                result.Add(AcceptedExtensions[1]);
            else if (type == DocumentFileType.TxtFile)
                result.Add(AcceptedExtensions[2]);
        }
        return result;
    }
}