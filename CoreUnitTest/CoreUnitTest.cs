using System;
using NUnit.Framework;

namespace CoreUnitTest
{
    [TestFixture]
    public class CoreUnitTest
    {
        [Test]
        public void Test20210901_001()
        {
            Console.WriteLine("hello world!");
        }

        [Test]
        public void Test20210901_002()
        {
            //https://stackoverflow.com/a/58504215/13338936
            var text = "<script>alert('o hai');</script>";

            var json = System.Text.Json.JsonSerializer.Serialize(new { Property = text });

            Console.WriteLine(json);
            //{"Property":"\u003Cscript\u003Ealert(\u0027o hai\u0027);\u003C/script\u003E"}
        }
    }
}
