using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using Jenkins.XmlConst;
using UnityEditor;
using UnityEngine;

namespace Jenkins
{
    public class JenkinsAdapter
    {
        public static List<string> Scenes = new List<string>();
        public static Dictionary<string,string> XmlConfig = new Dictionary<string, string>();
        [MenuItem("Jenkins/Test")]
        public static void _test()
        {
            UnityEngine.Debug.Log(Application.dataPath);
//            var buildInfo = JsonConvert.DeserializeObject<BuildSettingInfo>("{\"Scences\":\"Assets/Scence/main_scence_android.unity,Assets/Services/MaJiang/MajiangClientCore/Scenes/MajiangSuzhou.unity\",\"PackName\":\"com.fangqingsong.suzhoumajiang\",\"Version\":\"53\",\"BundleVersionCode\":\"1\",\"AndroidSdkVersions\":\"16\",\"TargetSdkVersion\":\"0\",\"TargetDevice\":\"ARMv7\",\"Scriptingimplementation\":\"Mono2x\",\"ApiCompatibilityLevel\":\"NET_2_0_Subset\",\"InternetAccess\":true,\"Development\":false,\"ConnectProfiler\":false,\"ScriptsDebuggers\":false}");
//            _setBuildAndroidInfo(buildInfo);
        }

        [MenuItem("Jenkins/Test Xml")]
        public static void _TestXml()
        {
            _getXmlVale(
                @"E:\Project\JenkinsBuildTest\Assets\Plugins\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config");
        }

        public static void XmlBuild()
        {

            Debug.Log("命令行参数个数:"+ Environment.GetCommandLineArgs().Length);
            foreach (var arg in Environment.GetCommandLineArgs())
            {
                Debug.Log("参数:"+arg);
            }
            var count = Environment.GetCommandLineArgs().Length;
            _getXmlVale(Environment.GetCommandLineArgs()[count - 1]);
        }

        private static void _getXmlVale(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            var root = xml.DocumentElement;
            _getScene(root);
            _getOther(root);
        }

        private static void _getOther(XmlElement xml)
        {
            foreach (XmlElement node in xml.GetElementsByTagName(XmlNodeConst.Root))
            {
                if (node.Name == XmlNodeConst.Scences)
                {
                    continue;
                }
                if (node.Attributes.GetNamedItem(XmlAttributeConst.Min) != null)
                {
                    _getSdkVersions(node);
                }
            }
        }

        private static void _getSdkVersions(XmlElement node)
        {
            //todo sdk 版本处理,需要判断是否大于,小于最大,然后进行设置
            int versions = 0;
            int.TryParse(node.InnerText,out versions);

        }

        private static void _getScene(XmlElement xml)
        {
            var scences = xml.GetElementsByTagName(XmlNodeConst.Scences);
            foreach (XmlNode childNode in scences[0].ChildNodes)
            {
                //explain="入口场景"
                var attributes = childNode.Attributes;
                Debug.Log("场景:" + childNode.InnerText + "描述:" +
                    (
                    attributes != null
                        ?
                        attributes.GetNamedItem(XmlAttributeConst.Explain) != null
                            ?
                        attributes.GetNamedItem(XmlAttributeConst.Explain).InnerText : "没有描述"
                   : "没有描述"));
                Scenes.Add(childNode.InnerText);
            }
        }

        [MenuItem("Jenkins/JenkinsBuildAndroid")]
        public static void CommandLineBuildAndroid()
        {
            var buildInfo = _analysisLineArgs();
            _setBuildAndroidInfo(buildInfo);
            //todo 输出路径需要需改为读取配置而不是写死
            var path = BuildPipeline.BuildPlayer(_getScenes(buildInfo.Scences), GetAndroidPath(), BuildTarget.Android, BuildOptions.None);
            Debug.Log("Build Complete Path:" + path);
        }

        private static void _setBuildAndroidInfo(BuildSettingInfo buildInfo)
        {
            PlayerSettings.Android.bundleVersionCode = int.Parse(buildInfo.BundleVersionCode);
            PlayerSettings.Android.minSdkVersion = _stringToEnum<AndroidSdkVersions>(buildInfo.AndroidSdkVersions);
            PlayerSettings.Android.targetSdkVersion = _stringToEnum<AndroidSdkVersions>(buildInfo.TargetSdkVersion);
            PlayerSettings.Android.targetDevice = _stringToEnum<AndroidTargetDevice>(buildInfo.TargetDevice);
            PlayerSettings.Android.forceInternetPermission = buildInfo.InternetAccess;
            _setBuildInfo(BuildTargetGroup.Android, buildInfo);
        }

        private static void _setBuildIosInfo(BuildSettingInfo buildInfo)
        {
            PlayerSettings.iOS.buildNumber = buildInfo.BundleVersionCode;
            PlayerSettings.iOS.targetDevice = _stringToEnum<iOSTargetDevice>(buildInfo.TargetDevice);
            PlayerSettings.iOS.targetOSVersionString = buildInfo.TargetSdkVersion;
//            PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK
           //            PlayerSettings.Android.minSdkVersion = _stringToEnum<AndroidSdkVersions>(buildInfo.AndroidSdkVersions);
           //            PlayerSettings.Android.targetSdkVersion = _stringToEnum<AndroidSdkVersions>(buildInfo.TargetSdkVersion);
           //            PlayerSettings.Android.targetDevice = _stringToEnum<AndroidTargetDevice>(buildInfo.TargetDevice);
            PlayerSettings.Android.forceInternetPermission = buildInfo.InternetAccess;
            _setBuildInfo(BuildTargetGroup.Android, buildInfo);
        }

        private static void _setBuildInfo(BuildTargetGroup target,BuildSettingInfo buildInfo)
        {
            PlayerSettings.bundleVersion = buildInfo.Version;
            PlayerSettings.applicationIdentifier = buildInfo.PackName;
            PlayerSettings.SetScriptingBackend(target, _stringToEnum<ScriptingImplementation>(buildInfo.Scriptingimplementation));
            PlayerSettings.SetApiCompatibilityLevel(target, _stringToEnum<ApiCompatibilityLevel>(buildInfo.ApiCompatibilityLevel));
            
            EditorUserBuildSettings.development = buildInfo.Development;
            EditorUserBuildSettings.connectProfiler = buildInfo.ConnectProfiler;
            EditorUserBuildSettings.allowDebugging = buildInfo.ScriptsDebuggers;

        }

        static T _stringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        [MenuItem("Jenkins/JenkinsBuildIos")]
        public static void CommandLineBuildIos()
        {
//            BuildPipeline.BuildPlayer(_analysisLineArgs(), GetIosBuildPath(), BuildTarget.iOS, BuildOptions.None);
            Debug.Log("Build Complete Path:" + GetIosBuildPath());
        }

        [MenuItem("Jenkins/JenkinsBuildWindows")]
        public static void CommandLineBuildWin()
        {
//            BuildPipeline.BuildPlayer(_analysisLineArgs(), GetWindowsPath(), BuildTarget.StandaloneWindows, BuildOptions.None);
            Debug.Log("Build Complete Path:" + GetWindowsPath());
        }

        /// <summary>
        /// 切割场景路径信息
        /// </summary>
        /// <param name="scenes"></param>
        /// <returns></returns>
        static string[] _getScenes(string scenes)
        {
            return scenes.Split(',');
        }
        /// <summary>
        /// 解析命令行参数，获取json数据
        /// 只会使用第一个json，因为不是我要的 (❤ ω ❤)
        /// </summary>
        /// <returns></returns>
        static BuildSettingInfo _analysisLineArgs()
        {
//            Regex _regex = new Regex(@"{.*}");
//
//            var match = _regex.Match(Environment.CommandLine);
//
//            XmlDocument xml = new XmlDocument();
//
//
//            var json = match.Value;
//
//            if (string.IsNullOrEmpty(json))
//            {
//                throw new Exception("在命令行中没有发现符合对象结构的json数据，结构为{json数据},不要树状的，不能换行，命令行：\n"+ Environment.CommandLine);
//            }
//
//            Debug.Log("Json数据:"+json);
//
//            var info = JsonConvert.DeserializeObject<BuildSettingInfo>(json);
//
//            Debug.Log(info);
//            return info;
            return null;
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

    public class BuildSettingInfo
    {
        public string Scences { get; set; }
        public string PackName { get; set; }
        public string Version { get; set; }
        public string BundleVersionCode { get; set; }
        public string AndroidSdkVersions { get; set; }
        public string TargetSdkVersion { get; set; }
        public string TargetDevice { get; set; }
        public string Scriptingimplementation { get; set; }
        public string ApiCompatibilityLevel { get; set; }
        public bool InternetAccess { get; set; }
        public bool Development { get; set; }
        public bool ConnectProfiler { get; set; }
        public bool ScriptsDebuggers { get; set; }

        public override string ToString()
        {
            return string.Format("打包信息：\n" +
                                 "构建场景：{0}\n" +
                                 "包名：{1}\n" +
                                 "版本：{2}\n" +
                                 "代码版本：{3}\n" +
                                 "Sdk版本：{4}\n" +
                                 "目标sdk版本：{5}\n" +
                                 "设备架构：{6}\n" +
                                 "脚本运行环境：{7}\n" +
                                 "APi兼容等级：{8}\n" +
                                 "是否联网：{9}\n" +
                                 "开发者模式：{10}\n" +
                                 "使用性能分析器：{11}\n" +
                                 "使用脚本调试器：{12}",Scences,PackName,Version,BundleVersionCode,
                                 AndroidSdkVersions,TargetSdkVersion,TargetDevice,Scriptingimplementation,ApiCompatibilityLevel
                                 ,InternetAccess,Development,ConnectProfiler,ScriptsDebuggers);
        }
    }

}


