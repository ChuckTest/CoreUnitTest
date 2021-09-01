using System;
using System.Text.Encodings.Web;
using System.Text.Json;
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

            var employee = new Employee();
            employee.FullName = text;
            var json = JsonSerializer.Serialize(employee);

            Console.WriteLine(json);
            //{"FullName":"\u003Cscript\u003Ealert(\u0027o hai\u0027);\u003C/script\u003E"}
        }

        [Test]
        public void Test20210901_003()
        {
            var text = "{\"FullName\":\"\\u003Cscript\\u003Ealert(\\u0027o hai\\u0027);\\u003C/script\\u003E\"}";

            var employee = JsonSerializer.Deserialize<Employee>(text);

            Console.WriteLine(employee?.FullName);
            //<script>alert('o hai');</script>
        }

        [Test]
        public void Test20210901_004()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                var text = "{\"FullName\":\"\\u003Cscript\\u003Ealert(\\u0027o hai\\u0027);\\u003C/script\\u003E\"}";

            var employee = JsonSerializer.Deserialize<Employee>(text);

            Console.WriteLine(employee?.FullName);
            //<script>alert('o hai');</script>
        }
    }
    public class Employee
    {
        public string FullName { get; set; }
    }
}
