using System.Linq;
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
            BuildInfoBuildTypeIOS ios = _getBuildType<BuildInfoBuildTypeIOS>();

            PlayerSettings.iOS.statusBarStyle =
                _stringToEnum<iOSStatusBarStyle>(ios.StatusBarStyle.ToString());

            PlayerSettings.iOS.targetDevice =
                _stringToEnum<iOSTargetDevice>(ios.TargetDevice.ToString());

            PlayerSettings.iOS.sdkVersion =
                _stringToEnum<iOSSdkVersion>(ios.TargetSdK.ToString());

            PlayerSettings.iOS.appInBackgroundBehavior =
                _stringToEnum<iOSAppInBackgroundBehavior>(
                    ios.BehaviorInBackground.ToString());
            PlayerSettings.iOS.showActivityIndicatorOnLoading =
                _stringToEnum<iOSShowActivityIndicatorOnLoading>(
                    ios.ShowLoadingIndicator.ToString());

            //ios
            PlayerSettings.accelerometerFrequency = ios.AccelerometerFrequency;

            //ios
            PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, ios.Architecture);

            var iconPaths = ((BuildInfoIconsIOS)BuildInfo.Icons.Item).Icon.Select(x => x.Value).ToArray();
            _setIcons(BuildTargetGroup.iOS, iconPaths);

            _setCommonBuildInfo(BuildTargetGroup.iOS);
            _setIOSAndAndroidCommonBuildInfo(true);
        }
    }
}