using Jenkins.XmlConst;
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
	        if (Config.ContainsKey(AndroidConfigNodeConst.BundleVersionCode))
	        {
	            PlayerSettings.Android.bundleVersionCode = int.Parse(Config[ConfigNodeConst.BundleVersionCode]);
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.SdkVersions))
	        {
	            PlayerSettings.Android.minSdkVersion = _stringToEnum<AndroidSdkVersions>(Config[AndroidAndIosConfigNodeConfig.SdkVersions]);
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.TargetSdkVersion))
	        {
	            PlayerSettings.Android.targetSdkVersion =
	                _stringToEnum<AndroidSdkVersions>(Config[AndroidAndIosConfigNodeConfig.TargetSdkVersion]);
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.TargetDevice))
	        {
	            PlayerSettings.Android.targetDevice =
	                _stringToEnum<AndroidTargetDevice>(Config[AndroidAndIosConfigNodeConfig.TargetDevice]);
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.InternetAccess))
	        {
	            PlayerSettings.Android.forceInternetPermission = bool.Parse(Config[AndroidConfigNodeConst.InternetAccess]);
	        }

	        if (Config.ContainsKey(AndroidConfigNodeConst.AndroidBuildSystem))
	        {
	            EditorUserBuildSettings.androidBuildSystem = _stringToEnum<AndroidBuildSystem>(Config[AndroidConfigNodeConst.AndroidBuildSystem]);
	        }

	        if (Config.ContainsKey(AndroidConfigNodeConst.AndroidBuildSystem))
	        {
	            EditorUserBuildSettings.androidBuildSubtarget = _stringToEnum<MobileTextureSubtarget>(Config[AndroidConfigNodeConst.TextureCompression]);
	        }

#if UNITY_2017
	        if (Config.ContainsKey(AndroidConfigNodeConst.AndroidBuildSystem))
	        {
	            EditorUserBuildSettings.androidETC2Fallback = _stringToEnum<AndroidETC2Fallback>(Config[AndroidConfigNodeConst.ETC2Fallback]);
	        }
#endif

            _setBuildInfo(BuildTargetGroup.Android);
	    }
    }
}