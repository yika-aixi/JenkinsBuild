using System;
using System.Linq;
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
            PlayerSettings.Android.forceSDCardPermission = android.WriteSDCard;
            PlayerSettings.Android.bundleVersionCode = android.BundleVersionCode.Value;
            if (android.ShowLoadingIndicatorSpecified)
            {
                PlayerSettings.Android.showActivityIndicatorOnLoading = 
                    _stringToEnum<AndroidShowActivityIndicatorOnLoading>(android.ShowLoadingIndicator.ToString());
            }
            if (android.InstallLocationSpecified)
            {
                PlayerSettings.Android.preferredInstallLocation =
                    _stringToEnum<AndroidPreferredInstallLocation>(android.InstallLocation.ToString());
            }
            if (android.MinimumAPILevelSpecified)
            {
                PlayerSettings.Android.minSdkVersion =
                    _stringToEnum<AndroidSdkVersions>(android.MinimumAPILevel.ToString());
            }
#if UNITY_5_6_OR_NEWER
            if (android.TargetAPILevelSpecified)
            {
                PlayerSettings.Android.targetSdkVersion =
                    _stringToEnum<AndroidSdkVersions>(android.TargetAPILevel.ToString());
            }
#endif

#if UNITY_2017_3
            if (android.ETC2FallbackSpecified)
            {
                EditorUserBuildSettings.androidETC2Fallback = _stringToEnum<AndroidETC2Fallback>(android.ETC2Fallback.ToString());
            }
#endif
            if (android.InternetAccessSpecified)
            {
                PlayerSettings.Android.forceInternetPermission = android.InternetAccess;
            }
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
            var iconPaths = ((BuildInfoIconsAndroid)BuildInfo.Icons.Item).Icon.Select(x => x.Value).ToArray();
            _setIcons(BuildTargetGroup.Android, iconPaths);
            _setCommonBuildInfo(BuildTargetGroup.Android);
            _setIOSAndAndroidCommonBuildInfo(false);

        }
    }
}