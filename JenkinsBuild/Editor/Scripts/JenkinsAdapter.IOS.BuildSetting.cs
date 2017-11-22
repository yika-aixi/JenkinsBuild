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
	        _setBuildInfo(BuildTargetGroup.Android);
	    }
    }
}