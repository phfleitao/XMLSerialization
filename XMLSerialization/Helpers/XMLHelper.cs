using System.Data.SqlTypes;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XMLSerialization.Helpers
{
    public static class XMLHelper
    {
        public static void ToXmlFile<T>(this T objectValue, string filePath) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, objectValue);
            }
        }

        public static T? ToObject<T>(this T objectValue, string filePath) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return serializer.Deserialize(reader) as T;
            }
        }

        public static string ToXmlString<T>(this T objectValue) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new Utf8StringWriter())
            {
                //Remove Namespace
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                serializer.Serialize(writer, objectValue, ns);
                return writer.ToString();
            }
        }

        public static string ToXmlString(this XmlNodeList nodeList)
        {
            var sb = new StringBuilder();
            if(nodeList != null)
            {
                foreach(XmlNode node in nodeList)
                {
                    sb.Append(node.OuterXml);
                }
            }
            return sb.ToString();
        }

        public static XmlDocument ToXmlDocument<T>(this T objectValue) where T : class
        {
            var xmlString = objectValue.ToXmlString();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            return xmlDocument;
        }

        public static T? ToObject<T>(this string xmlValue) where T : class, new()
        {
            var serializer = new XmlSerializer(typeof(T));
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
