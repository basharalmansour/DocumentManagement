using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Application.UnitTests.Common.Helpers;
public class LanguageJsonFormatterTest
{
    [Test]
    public async Task ShouldSerializeLanguageObjectCorrectly()
    {
        LanguageString testObject = new LanguageString();
        testObject.Add(LanguageCode.tr, "su");
        testObject.Add(LanguageCode.en, "water");
        var result = LanguageJsonFormatter.SerializObject(testObject);
        var expected = "{\"tr\":\"su\",\"en\":\"water\"}";
        Assert.AreEqual(result, expected);
    }

    [Test]
    public async Task ShouldDeserializeLanguageObjectCorrectly()
    {
        var input = "{\"tr\":\"su\",\"en\":\"water\"}";
        LanguageString testObject = new LanguageString();
        testObject.Add(LanguageCode.tr, "su");
        testObject.Add(LanguageCode.en, "water");
        var result = LanguageJsonFormatter.DeserializObject(input);
        LanguageString expected = new LanguageString();
        testObject.Add(LanguageCode.tr, "su");
        testObject.Add(LanguageCode.en, "water");
        Assert.AreEqual(result.Count, expected.Count);
    }
}
