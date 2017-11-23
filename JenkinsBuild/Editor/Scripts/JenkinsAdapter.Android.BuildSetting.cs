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
	            PlayerSettings.Android.bundleVersionCode = int.Parse(_getNodeValue(ConfigNodeConst.BundleVersionCode));
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.SdkVersions))
	        {
	            PlayerSettings.Android.minSdkVersion = _stringToEnum<AndroidSdkVersions>(_getNodeValue(AndroidAndIosConfigNodeConfig.SdkVersions));
	        }
#if UNITY_5_6_OR_NEWER
	        if (Config.ContainsKey(AndroidConfigNodeConst.TargetSdkVersion))
	        {
	            PlayerSettings.Android.targetSdkVersion =
	                _stringToEnum<AndroidSdkVersions>(_getNodeValue(AndroidAndIosConfigNodeConfig.TargetSdkVersion));
	        }
	        if (Config.ContainsKey(AndroidConfigNodeConst.AndroidTargetDevice))
	        {
	            PlayerSettings.Android.targetDevice =
	                _stringToEnum<AndroidTargetDevice>(_getNodeValue(AndroidConfigNodeConst.AndroidTargetDevice));
	        }
#endif
            if (Config.ContainsKey(AndroidConfigNodeConst.InternetAccess))
	        {
	            PlayerSettings.Android.forceInternetPermission = bool.Parse(_getNodeValue(AndroidConfigNodeConst.InternetAccess));
	        }

	        if (Config.ContainsKey(AndroidConfigNodeConst.AndroidBuildSystem))
	        {
	            EditorUserBuildSettings.androidBuildSystem = _stringToEnum<AndroidBuildSystem>(_getNodeValue(AndroidConfigNodeConst.AndroidBuildSystem));
	        }

	        if (Config.ContainsKey(AndroidConfigNodeConst.TextureCompression))
	        {
	            EditorUserBuildSettings.androidBuildSubtarget = _stringToEnum<MobileTextureSubtarget>(_getNodeValue(AndroidConfigNodeConst.TextureCompression));
	        }

#if UNITY_2017_3
	        if (Config.ContainsKey(AndroidConfigNodeConst.ETC2Fallback))
	        {
	            EditorUserBuildSettings.androidETC2Fallback = _stringToEnum<AndroidETC2Fallback>(_getNodeValue(AndroidConfigNodeConst.ETC2Fallback));
	        }
#endif

            _setBuildInfo(BuildTargetGroup.Android);
	    }
    }
}