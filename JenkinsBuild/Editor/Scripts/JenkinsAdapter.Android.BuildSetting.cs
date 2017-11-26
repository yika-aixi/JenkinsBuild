using JenkinsBuild;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
	{
	    /// <summary>
	    /// 安卓打包设置
	    /// </summary>
	    private static void _setBuildAndroidInfo()
	    {
	        BuildInfoBuildTypeAndroid android = _getBuildType<BuildInfoBuildTypeAndroid>();
            //todo 增加icon设置
//            BuildInfoIconsAndroid icon = (BuildInfoIconsAndroid) BuildInfo.Icons.Item;
//            foreach (var icon1 in icon.Icon)
//            {
//            }
//            PlayerSettings.SetIconsForTargetGroup();

            PlayerSettings.Android.showActivityIndicatorOnLoading = AndroidShowActivityIndicatorOnLoading.DontShow;
            PlayerSettings.Android.preferredInstallLocation = AndroidPreferredInstallLocation.Auto;
            PlayerSettings.Android.forceInternetPermission = android.InternetAccess;
            //todo 修改xsd 修改为bool类型 名字改为WriteSDCard --
            //PlayerSettings.Android.forceSDCardPermission = _getBuildType<BuildInfoBuildTypeAndroid>().WritePermission.ItemElementName.;

	        PlayerSettings.Android.bundleVersionCode = android.BundleVersionCode.Value;

            //todo 修改xsd 默认值是int 不是stirng
            //PlayerSettings.Android.minSdkVersion = _stringToEnum<AndroidSdkVersions>(_getSdkVersion(android.MinimumAPILevel.@default,android.MinimumAPILevel.Min,android.MinimumAPILevel.Max,android.MinimumAPILevel.Value));

	        PlayerSettings.Android.targetDevice = _stringToEnum<AndroidTargetDevice>(android.DeveiceFilter.ToString());

#if UNITY_5_6_OR_NEWER
            //todo 修改xsd 默认值是int 不是stirng
            //	        PlayerSettings.Android.targetSdkVersion =
            //	            _stringToEnum<AndroidSdkVersions>(_getSdkVersion(android.TargetAPILevel.@default,
            //	                android.TargetAPILevel.Min, android.TargetAPILevel.Max, android.TargetAPILevel.Value));
#endif
            //todo xsd中 忘记添加 androidBuildSystem
            // EditorUserBuildSettings.androidBuildSystem = _stringToEnum<AndroidBuildSystem>(android.

            //todo xsd中 忘记添加 androidBuildSubtarget
            // EditorUserBuildSettings.androidBuildSubtarget = _stringToEnum<MobileTextureSubtarget>(android.

#if UNITY_2017_3
            //todo xsd中 忘记添加 androidETC2Fallback
//            if (Config.ContainsKey(AndroidConfigNodeConst.ETC2Fallback))
//	        {
//	            EditorUserBuildSettings.androidETC2Fallback = _stringToEnum<AndroidETC2Fallback>(_getNodeValue(AndroidConfigNodeConst.ETC2Fallback));
//	        }
#endif

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