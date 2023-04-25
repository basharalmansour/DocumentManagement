using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Helpers;
public static class LanguageJsonFormatter
{
    /// <summary>
    /// This function is responsible for serializing objects
    /// input : [{key:"tr",value:"su"},{key:"en",value:"water"}]
    /// output : {"tr":"su","en":"water"}
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string SerializObject(LanguageString obj)
    {
        string jsonString = JsonSerializer.Serialize(obj);
        return jsonString;
    }

    /// <summary>
    /// This function is responsible for deserializing strings to objects
    /// output : [{key:"tr",value:"su"},{key:"en",value:"water"}]
    /// input : {"tr":"su","en":"water"}
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static LanguageString DeserializObject(string str)
    {
        LanguageString obj = JsonSerializer.Deserialize<LanguageString>(str);
        return obj;
    }
}

/// <summary>
/// this class will be used instead of strings in cases of multi languages
/// </summary>
public class LanguageString: Dictionary<LanguageCode, string>
{
    //you can add additional methods to dictionary here 

    /// <summary>
    /// It deletes all the languages except the chosen one
    /// </summary>
    public void KeepOneLanguage(LanguageCode languageCode)
    {
        var value = this[languageCode];
        foreach(var record in this)
            if(record.Key != languageCode)
                this.Remove(record.Key);
    }
}

/// <summary>
/// This enum is presenting all codes of languages which is used in this application
/// </summary>
public enum LanguageCode
{
    tr = 1,
    en
}