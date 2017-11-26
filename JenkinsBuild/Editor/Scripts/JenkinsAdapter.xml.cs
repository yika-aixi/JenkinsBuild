using System;
using System.IO;
using System.Xml.Serialization;
using JenkinsBuild.XmlEntity;

namespace JenkinsBuild
{
    /// <summary>
    /// Xml处理分部
    /// </summary>
    public partial class JenkinsAdapter
    {
        public static BuildInfo BuildInfo;
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
        /// 序列化xml
        /// </summary>
        /// <param name="path">xml所在路径</param>
        private static void _getXmlVale(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildInfo));
            BuildInfo = (BuildInfo) serializer.Deserialize(File.Open(path, FileMode.Open));
        }


        /// <summary>
        /// 获取构建平台设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T _getBuildType<T>() where T : IBuildType
        {
            return (T) BuildInfo.BuildType.Item;
        }

    }
}