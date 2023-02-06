using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XMLSerialization.Helpers
{
    public static class XMLHelper
    {
        public static void ToXML<T>(this T objectValue, string filePath) where T : class
        {
            var serializer = new XmlSerializer(objectValue.GetType());
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, objectValue);
            }
        }

        public static T ToObject<T>(this T objectValue, string filePath) where T : class
        {
            var serializer = new XmlSerializer(objectValue.GetType());
            using (var reader = new StreamReader(filePath))
            {
                return serializer.Deserialize(reader) as T;
            }
        }

        public static string ToXML<T>(this T objectValue) where T : class
        {
            var serializer = new XmlSerializer(objectValue.GetType());
            using (var writer = new Utf8StringWriter())
            {
                //Remove Namespace
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                serializer.Serialize(writer, objectValue, ns);
                return writer.ToString();
            }
        }

        public static T ToObject<T>(this string xmlValue) where T : class, new()
        {
            var t = new T();

            var serializer = new XmlSerializer(t.GetType());
            using (var reader = new StringReader(xmlValue))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
