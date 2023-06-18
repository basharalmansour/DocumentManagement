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
    public static string ConvertToString(this DocumentFileType type)
    {
        switch (type)
        {
            case DocumentFileType.PDF: return AcceptedExtensions[0];
            case DocumentFileType.Word: return AcceptedExtensions[1];
            case DocumentFileType.TxtFile: return AcceptedExtensions[2];
            default:return string.Empty;
        }
    }
}