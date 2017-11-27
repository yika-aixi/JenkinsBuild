using System.Linq;
using UnityEditor;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
    {
        #region CommandLine call function

        public static void CommandLineXmlBuildAndroid()
        {
            //解析XML
            XmlBuild();
            _setBuildAndroidInfo();
            _build(BuildTarget.Android);
        }

        public static void CommandLineXmlBuildIOS()
        {
            //解析XML
            XmlBuild();
            _setBuildIosInfo();
            _build(BuildTarget.iOS);
        }

        public static void CommandLineXmlBuildWin32()
        {
            _buildPC(BuildTarget.StandaloneWindows);
        }

        public static void CommandLineXmlBuildWin64()
        {
            _buildPC(BuildTarget.StandaloneWindows64);
        }

        public static void CommandLineXmlBuildMac()
        {
#if UNITY_2017
            _buildPC(BuildTarget.StandaloneOSX);
#else
            _buildPC(BuildTarget.StandaloneOSXUniversal);
#endif
        }

#endregion



#region Private funation

        static void _buildPC(BuildTarget target)
        {
            //解析XML
            XmlBuild();
            _setBuildPCInfo();
            _build(target);
        }

        static void _build(BuildTarget target)
        {
            BuildPlayerOptions buildPlayer = new BuildPlayerOptions();
            buildPlayer.scenes = BuildInfo.Scences.Select(x => x.Value).ToArray();
            buildPlayer.locationPathName = BuildInfo.OutPath;
            buildPlayer.target = target;
            buildPlayer.options = BuildOptions.None;
            var error = BuildPipeline.BuildPlayer(buildPlayer);
            _executeComplete(error, buildPlayer.locationPathName);
        }

#endregion
    }

}


