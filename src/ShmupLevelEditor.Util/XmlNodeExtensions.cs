using System.Xml;

namespace ShmupLevelEditor.Util
{
    public static class XmlNodeExtensions
    {
        public static string GetAttribute(this XmlNode n, string att)
        {
            if (n != null && n.Attributes != null && n.Attributes[att] != null)
                return n.Attributes[att].InnerText;
            
            return string.Empty;
        }
    }
}
