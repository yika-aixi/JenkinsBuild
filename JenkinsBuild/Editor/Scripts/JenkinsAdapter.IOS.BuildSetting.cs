using Jenkins.XmlConst;
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

            if (Config.ContainsKey(IosConfigNodeConst.BundleVersionCode))
	        {
	            PlayerSettings.iOS.buildNumber = _getNodeValue(ConfigNodeConst.BundleVersionCode);
	        }
//	        if (Config.ContainsKey(IosConfigNodeConst.SdkVersions))
//	        {
//	            PlayerSettings.iOS.scriptCallOptimization = _stringToEnum<AndroidSdkVersions>(_getNodeValue(AndroidAndIosConfigNodeConfig.SdkVersions));
//	        }
//	        if (Config.ContainsKey(IosConfigNodeConst.TargetSdkVersion))
//	        {
//	            PlayerSettings.iOS.targetSdkVersion =
//	                _stringToEnum<AndroidSdkVersions>(Config[AndroidAndIosConfigNodeConfig.TargetSdkVersion]);
//	        }
//	        if (Config.ContainsKey(IosConfigNodeConst.TargetDevice))
//	        {
//	            PlayerSettings.iOS.targetDevice =
//	                _stringToEnum<AndroidTargetDevice>(Config[AndroidAndIosConfigNodeConfig.TargetDevice]);
//	        }

            _setBuildInfo(BuildTargetGroup.Android);
	    }
    }
}