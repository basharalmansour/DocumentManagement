using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Common.Helpers;
public static class FileManager
{
    public static string Create(IFormFile file,string path=null, string fileName=null)
    {
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
        var filePath = Path.Combine(path, fileName);
        using (FileStream stream = System.IO.File.Create(filePath))
        {
            file.CopyTo(stream);
        }
        return string.Empty;
    }
    public static bool Delete(string path)
    {
        if (String.IsNullOrEmpty(path))
            return false;
        File.Delete(path);
        return true;
    }
    public static bool Replace(IFormFile file, string path)
    {
        Delete(path);
        Create(file);
        return true;
    }
}
