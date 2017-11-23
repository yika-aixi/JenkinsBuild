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
	        if (Config.ContainsKey(IosConfigNodeConst.IOSTargetDevice))
	        {
	            PlayerSettings.iOS.targetDevice =
	                _stringToEnum<iOSTargetDevice>(_getNodeValue(IosConfigNodeConst.IOSTargetDevice));
	        }

            _setBuildInfo(BuildTargetGroup.iOS);
	    }
    }
}