using System;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
    {
        [MenuItem("Jenkins/Test Xml")]
        public static void _TestXml()
        {
            _getXmlVale(
                @"I:\GitHubProject\JenkinsBuildTest\Assets\Plugins\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config");
            _setBuildAndroidInfo();
        }

        static T _stringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
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