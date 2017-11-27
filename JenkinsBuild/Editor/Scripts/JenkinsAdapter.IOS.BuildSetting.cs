using System.Linq;
using JenkinsBuild.XmlEntity;
using UnityEditor;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
	{
        /// <summary>
        /// IOS打包设置
        /// </summary>
	    private static void _setBuildIosInfo()
        {
            BuildInfoBuildTypeIOS ios = _getBuildType<BuildInfoBuildTypeIOS>();

            if (ios.StatusBarStyleSpecified)
            {
                PlayerSettings.iOS.statusBarStyle =
                    _stringToEnum<iOSStatusBarStyle>(ios.StatusBarStyle.ToString());
            }


            if (ios.TargetDeviceSpecified)
            {
                PlayerSettings.iOS.targetDevice =
                    _stringToEnum<iOSTargetDevice>(ios.TargetDevice.ToString());
            }

            if (ios.TargetSdKSpecified)
            {
                PlayerSettings.iOS.sdkVersion =
                    _stringToEnum<iOSSdkVersion>(ios.TargetSdK.ToString());
            }

            if (ios.BehaviorInBackgroundSpecified)
            {
                PlayerSettings.iOS.appInBackgroundBehavior =
                    _stringToEnum<iOSAppInBackgroundBehavior>(
                        ios.BehaviorInBackground.ToString());
            }
            if (ios.ShowLoadingIndicatorSpecified)
            {
                PlayerSettings.iOS.showActivityIndicatorOnLoading =
                    _stringToEnum<iOSShowActivityIndicatorOnLoading>(
                        ios.ShowLoadingIndicator.ToString());
            }
            if (ios.AccelerometerFrequencySpecified)
            {
                PlayerSettings.accelerometerFrequency = ios.AccelerometerFrequency;
            }

            if (ios.ArchitectureSpecified)
            {
                PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, ios.Architecture);
            }

            var iconPaths = ((BuildInfoIconsIOS)BuildInfo.Icons.Item).Icon.Select(x => x.Value).ToArray();
            _setIcons(BuildTargetGroup.iOS, iconPaths);

            _setCommonBuildInfo(BuildTargetGroup.iOS);
            _setIOSAndAndroidCommonBuildInfo(true);
        }
    }
}