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

        public static Dictionary<string, string> Config = new Dictionary<string, string>();

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

                if (node.Attributes.GetNamedItem(XmlAttributeConst.Min) != null)
                {
                    _getSdkVersions(node);
                    continue;
                }

                if (node.Name == AndroidAndIosConfigNodeConfig.TargetDevice)
                {
                    _getTargetDevice(node);
                }

                string value = node.InnerText;
                if (string.IsNullOrEmpty(node.InnerText))
                {
                    value = node.GetAttribute(XmlAttributeConst.Default);
                }
                Config.Add(node.Name, value);
            }
        }

        private static void _getTargetDevice(XmlElement node)
        {
            Config.Add(node.Name, node.ChildNodes[0].InnerText);
        }

        /// <summary>
        /// 特殊处理的sdk版本
        /// </summary>
        /// <param name="node"></param>
        private static void _getSdkVersions(XmlElement node)
        {
            int minVersions = int.Parse(node.GetAttribute(XmlAttributeConst.Min));
            int maxVersions = int.Parse(node.GetAttribute(XmlAttributeConst.Max));
            int defaultVersions = int.Parse(node.GetAttribute(XmlAttributeConst.Default));

            int currenVersions = 0;

            if (string.IsNullOrEmpty(node.InnerText))
            {
                currenVersions = int.Parse(node.GetAttribute(XmlAttributeConst.Default));
            }
            //如果不是等于默认值的话就进行判断
            if (currenVersions != defaultVersions)
            {
                //如果大于最大的版本设置为最大
                if (currenVersions > maxVersions)
                {
                    currenVersions = maxVersions;
                }

                //如果小于最小版本设置成最小
                if (currenVersions < minVersions)
                {
                    currenVersions = minVersions;
                }
            }
            Config.Add(node.Name, currenVersions.ToString());
        }

        /// <summary>
        /// 特殊处理的场景信息获取
        /// </summary>
        /// <param name="xml"></param>
        private static void _getScene(XmlElement xml)
        {
            var scences = xml.GetElementsByTagName(ConfigNodeConst.Scences);
            foreach (XmlNode childNode in scences[0].ChildNodes)
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
    }
}