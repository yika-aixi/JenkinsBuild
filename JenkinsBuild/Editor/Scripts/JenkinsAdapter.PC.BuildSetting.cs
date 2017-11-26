using System.Linq;
using JenkinsBuild.XmlEntity;
using UnityEditor;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
	{
        /// <summary>
        /// PC打包设置
        /// </summary>
	    private static void _setBuildPCInfo()
        {
            BuildInfoBuildTypePC pc = _getBuildType<BuildInfoBuildTypePC>();

            PlayerSettings.displayResolutionDialog = _stringToEnum<ResolutionDialogSetting>(
                pc.DisplayResolutionDialog.ToString());


            PlayerSettings.macFullscreenMode = _stringToEnum<MacFullscreenMode>(
                pc.MacFullscreenMode.ToString());

//            PlayerSettings.d3d9FullscreenMode = _stringToEnum<D3D9FullscreenMode>(
//                _getBuildType<BuildInfoBuildTypePC>().D3D9FullscreenMode.ToString());

            PlayerSettings.d3d11FullscreenMode = _stringToEnum<D3D11FullscreenMode>(
                pc.D3D11FullscreenMode.ToString());

            foreach (var aspectRatio in pc.SupportedAspectRations.AspectRatio)
            {
                PlayerSettings.SetAspectRatio(_stringToEnum <AspectRatio>(aspectRatio.Value.ToString()), aspectRatio.enable);
            }

            var iconPaths = ((BuildInfoIconsPC)BuildInfo.Icons.Item).Icon.Select(x => x.Value).ToArray();
            _setIcons(BuildTargetGroup.Standalone, iconPaths);

            _setCommonBuildInfo(BuildTargetGroup.Standalone);
	    }
    }
}