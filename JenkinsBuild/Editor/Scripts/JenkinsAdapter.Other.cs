using System;
using Jenkins.XmlConst;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
    {
        [MenuItem("Jenkins/Test Xml")]
        public static void _TestXml()
        {
            _getXmlVale(
                @"E:\Project\JenkinsBuildTest\Assets\Plugins\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config");
            _setBuildAndroidInfo();
            foreach (var pair in Config)
            {
                UnityEngine.Debug.Log("xml配置:key=" + pair.Key + ", Value=" + pair.Value.Value
                    +"描述："+pair.Value.XmlAttributes[XmlAttributeConst.Explain]);
            }
        }

        static T _stringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        static void _executeComplete(string errorMessage,string outPath)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine("Build Complete Path:" + outPath);
                EditorApplication.Exit(0);
            }
            else
            {
                Console.WriteLine("Build Error:" + errorMessage);
                EditorApplication.Exit(1);
            }
        }

        #region Get Build Path 

        static string GetIosBuildPath()
        {
            return "build/Ios";
        }

        static string GetAndroidPath()

        {
            return "build/Android.apk";
        }

        static string GetWindowsPath()
        {
            return "build/Win/Win.exe";
        }

        static string GetMacPath()
        {
            return "build/mac";
        }

        #endregion
    }
}