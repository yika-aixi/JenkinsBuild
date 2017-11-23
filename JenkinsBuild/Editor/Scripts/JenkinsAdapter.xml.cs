using System;
using System.Collections.Generic;
using System.Xml;
using Jenkins.XmlConst;

namespace Jenkins
{
    /// <summary>
    /// Xml处理分部
    /// </summary>
    public partial class JenkinsAdapter
    {
        public static List<string> Scenes = new List<string>();

        public static Dictionary<string, XmlNodeStruct> Config = new Dictionary<string, XmlNodeStruct>();

        /// <summary>
        /// 解析命令行传过来的xml
        /// </summary>
        public static void XmlBuild()
        {

            Console.WriteLine("命令行参数个数:" + Environment.GetCommandLineArgs().Length);
            foreach (var arg in Environment.GetCommandLineArgs())
            {
                Console.WriteLine("参数:" + arg);
            }
            var count = Environment.GetCommandLineArgs().Length;
            _getXmlVale(Environment.GetCommandLineArgs()[count - 1]);

        }

        /// <summary>
        /// 获取xml的值
        /// </summary>
        /// <param name="path">xml所在路径</param>
        private static void _getXmlVale(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            var root = xml.DocumentElement;
            _getScene(root);
            _getOther(root);
            foreach (var pair in Config)
            {
                Console.WriteLine("xml配置:key=" + pair.Key + ", Value=" + pair.Value);
            }
        }

        /// <summary>
        /// 获取除了场景外的所有配置
        /// </summary>
        /// <param name="xml"></param>
        private static void _getOther(XmlElement xml)
        {
            Config.Clear();
            foreach (XmlElement node in xml)
            {
                //因为场景是单独处理所以跳过
                if (node.Name == ConfigNodeConst.Scences)
                {
                    continue;
                }

                var xmlstruct = new XmlNodeStruct
                {
                    XmlAttributes = new Dictionary<string, string>(),
                };

                foreach (XmlAttribute attribute in node.Attributes)
                {
                    xmlstruct.XmlAttributes.Add(attribute.Name,attribute.InnerText);
                }

                xmlstruct.Value = node.InnerText;
                
                Config.Add(node.Name, xmlstruct);
            }
        }

        /// <summary>
        /// 特殊处理的场景信息获取
        /// </summary>
        /// <param name="xml"></param>
        private static void _getScene(XmlElement xml)
        {
            var scences = xml.GetElementsByTagName(ConfigNodeConst.Scences);
            foreach (XmlNode childNode in scences)
            {
                //explain="入口场景"
                var attributes = childNode.Attributes;
                Console.WriteLine("场景:" + childNode.InnerText + "描述:" +
                                  (
                                      attributes != null
                                          ?
                                          attributes.GetNamedItem(XmlAttributeConst.Explain) != null
                                              ?
                                              attributes.GetNamedItem(XmlAttributeConst.Explain).InnerText : "没有描述"
                                          : "没有描述"));
                Scenes.Add(childNode.InnerText);
            }

            if (Scenes.Count == 0)
            {
                throw new Exception("配置中没有发现场景配置项，打包失败！");
            }
        }

        static string _getOutPath(string defaultPath)
        {
            XmlNodeStruct outPath;

            Config.TryGetValue(ConfigNodeConst.Path, out outPath);

            if (outPath == null || string.IsNullOrEmpty(outPath.Value))
            {
                return defaultPath;
            }

            return outPath.Value;
        }

        static string _getNodeValue(string nodeName)
        {
            if (Config.ContainsKey(nodeName))
            {
                if (string.IsNullOrEmpty(Config[nodeName].Value))
                {
                    return Config[nodeName].XmlAttributes[XmlAttributeConst.Default];
                }
                else
                {
                    return Config[nodeName].Value;
                }
            }
            else
            {
                throw new Exception("没有找到:"+ nodeName + "节点~");
            }
        }

        public class XmlNodeStruct
        {
            public Dictionary<string, string> XmlAttributes;
            public string Value;
        }

    }
}