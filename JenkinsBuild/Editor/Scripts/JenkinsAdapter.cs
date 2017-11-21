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
            string outPath;
            Config.TryGetValue(ConfigNodeConst.Path, out outPath);
            if(string.IsNullOrEmpty(outPath))
            {
                outPath = GetAndroidPath();
            }
            var path = BuildPipeline.BuildPlayer(Scenes.ToArray(), outPath, BuildTarget.Android, BuildOptions.None);
            Console.WriteLine ("Build Complete Path:" + path);
        }

        //        public static void CommandLineBuildIos()
        //        {
        ////            BuildPipeline.BuildPlayer(_analysisLineArgs(), GetIosBuildPath(), BuildTarget.iOS, BuildOptions.None);
        //            Debug.Log("Build Complete Path:" + GetIosBuildPath());
        //        }

        //        public static void CommandLineBuildWin()
        //        {
        ////            BuildPipeline.BuildPlayer(_analysisLineArgs(), GetWindowsPath(), BuildTarget.StandaloneWindows, BuildOptions.None);
        //            Debug.Log("Build Complete Path:" + GetWindowsPath());
        //        }
    }

}


