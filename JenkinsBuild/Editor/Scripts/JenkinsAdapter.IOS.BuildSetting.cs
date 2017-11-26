using JenkinsBuild;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
	{
        /// <summary>
        /// IOS打包设置
        /// </summary>
	    private static void _setBuildIosInfo()
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

            _setCommonBuildInfo(BuildTargetGroup.iOS);
            _setIOSAndAndroidCommonBuildInfo(true);
        }
    }
}