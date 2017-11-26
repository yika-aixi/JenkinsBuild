using JenkinsBuild;
using UnityEditor;

namespace Jenkins
{
    public partial class JenkinsAdapter
	{
        /// <summary>
        /// PC打包设置
        /// </summary>
	    private static void _setBuildPCInfo()
	    {
            //pc
            PlayerSettings.displayResolutionDialog = _stringToEnum<ResolutionDialogSetting>(
                _getBuildType<BuildInfoBuildTypePC>().DisplayResolutionDialog.ToString());


            PlayerSettings.macFullscreenMode = _stringToEnum<MacFullscreenMode>(
                _getBuildType<BuildInfoBuildTypePC>().MacFullscreenMode.ToString());

//            PlayerSettings.d3d9FullscreenMode = _stringToEnum<D3D9FullscreenMode>(
//                _getBuildType<BuildInfoBuildTypePC>().D3D9FullscreenMode.ToString());

            PlayerSettings.d3d11FullscreenMode = _stringToEnum<D3D11FullscreenMode>(
                _getBuildType<BuildInfoBuildTypePC>().D3D11FullscreenMode.ToString());

            _setCommonBuildInfo(BuildTargetGroup.Standalone);
	    }
    }
}