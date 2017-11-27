using System.Linq;
using JenkinsBuild.XmlEntity;
using UnityEditor;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
	{
	    /// <summary>
	    /// 安卓打包设置
	    /// </summary>
	    private static void _setBuildAndroidInfo()
	    {
            BuildInfoBuildTypeAndroid android = _getBuildType<BuildInfoBuildTypeAndroid>();

            PlayerSettings.Android.showActivityIndicatorOnLoading = AndroidShowActivityIndicatorOnLoading.DontShow;
            PlayerSettings.Android.preferredInstallLocation = AndroidPreferredInstallLocation.Auto;
	        if (android.InternetAccessSpecified)
	        {
                PlayerSettings.Android.forceInternetPermission = android.InternetAccess;
            }
            PlayerSettings.Android.forceSDCardPermission = android.WriteSDCard;
	        PlayerSettings.Android.bundleVersionCode = android.BundleVersionCode.Value;
	        PlayerSettings.Android.minSdkVersion =
	            _stringToEnum<AndroidSdkVersions>(
	                _getSdkVersion(android.MinimumAPILevel.@default, android.MinimumAPILevel.Min,
	                    android.MinimumAPILevel.Max, android.MinimumAPILevel.Value).ToString());
	        if (android.DeveiceFilterSpecified)
	        {
                PlayerSettings.Android.targetDevice = _stringToEnum<AndroidTargetDevice>(android.DeveiceFilter.ToString());
            }
	        if (android.BuildSystemSpecified)
	        {
                EditorUserBuildSettings.androidBuildSystem = _stringToEnum<AndroidBuildSystem>(android.BuildSystem.ToString());
            }
	        if (android.BuildSubtargetSpecified)
	        {
	            EditorUserBuildSettings.androidBuildSubtarget = _stringToEnum<MobileTextureSubtarget>(android.BuildSubtarget.ToString());
            }
#if UNITY_5_6_OR_NEWER
            PlayerSettings.Android.targetSdkVersion =
	            _stringToEnum<AndroidSdkVersions>(_getSdkVersion(android.TargetAPILevel.@default,
	                android.TargetAPILevel.Min, android.TargetAPILevel.Max, android.TargetAPILevel.Value).ToString());
#endif
	            
#if UNITY_2017_3
        if (android.ETC2FallbackSpecified)
	    {
            EditorUserBuildSettings.androidETC2Fallback = _stringToEnum<AndroidETC2Fallback>(android.ETC2Fallback.ToString());
        }

#endif

            var iconPaths = ((BuildInfoIconsAndroid)BuildInfo.Icons.Item).Icon.Select(x => x.Value).ToArray();
	        _setIcons(BuildTargetGroup.Android, iconPaths);
            _setCommonBuildInfo(BuildTargetGroup.Android);
	        _setIOSAndAndroidCommonBuildInfo(false);

	    }

	    private static int _getSdkVersion(int @default, int min, int max, int value)
	    {
	        if (value == @default || (value >= min && value <= max))
	        {
	            return value;
	        }

	        return value < min ? min : max;
	    }
	}
}