using Jenkins.XmlConst;
using System;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
    {
        public static void CommandLineXmlBuildAndroid()
        {
            //解析XML
            XmlBuild();
            _setBuildAndroidInfo();
            _build(BuildTarget.Android, GetAndroidPath());
        }

        public static void CommandLineXmlBuildIOS()
        {
            //解析XML
            XmlBuild();
            _setBuildIosInfo();
            _build(BuildTarget.iOS, GetIosBuildPath());
        }

        //        public static void CommandLineBuildWin()
        //        {
        ////            BuildPipeline.BuildPlayer(_analysisLineArgs(), GetWindowsPath(), BuildTarget.StandaloneWindows, BuildOptions.None);
        //            Debug.Log("Build Complete Path:" + GetWindowsPath());
        //        }

        static void _build(BuildTarget target,string defaultPath)
        {
            var outPath = _getOutPath(defaultPath);
            var error = BuildPipeline.BuildPlayer(Scenes.ToArray(), outPath, target, BuildOptions.None);
            _executeComplete(error, outPath);
        }
    }

}


