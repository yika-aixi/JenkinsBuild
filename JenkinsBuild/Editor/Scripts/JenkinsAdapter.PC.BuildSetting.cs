using JenkinsBuild;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
	{
        /// <summary>
        /// PC打包设置
        /// </summary>
	    private static void _setBuildPCInfo()
	    {
            PlayerSettings.iOS.statusBarStyle =
                _stringToEnum<iOSStatusBarStyle>(_getBuildType<BuildInfoBuildTypeIOS>().StatusBarStyle.ToString());

            PlayerSettings.iOS.targetDevice =
                _stringToEnum<iOSTargetDevice>(_getBuildType<BuildInfoBuildTypeIOS>().TargetDevice.ToString());

            PlayerSettings.iOS.sdkVersion =
                _stringToEnum<iOSSdkVersion>(_getBuildType<BuildInfoBuildTypeIOS>().TargetSdK.ToString());

            PlayerSettings.iOS.appInBackgroundBehavior =
                _stringToEnum<iOSAppInBackgroundBehavior>(
                    _getBuildType<BuildInfoBuildTypeIOS>().BehaviorInBackground.ToString());
            PlayerSettings.iOS.showActivityIndicatorOnLoading =
                _stringToEnum<iOSShowActivityIndicatorOnLoading>(
                    _getBuildType<BuildInfoBuildTypeIOS>().ShowLoadingIndicator.ToString());

            //ios
            PlayerSettings.accelerometerFrequency = _getBuildType<BuildInfoBuildTypeIOS>().AccelerometerFrequency;

            //ios
            PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, _getBuildType<BuildInfoBuildTypeIOS>().Architecture);

            if (Config.ContainsKey(IosConfigNodeConst.IOSTargetDevice))
	        {
	            PlayerSettings.iOS.targetDevice =
	                _stringToEnum<iOSTargetDevice>(_getNodeValue(IosConfigNodeConst.IOSTargetDevice));
	        }

            _setBuildInfo(BuildTargetGroup.iOS);
	    }
    }
}