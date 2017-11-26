using JenkinsBuild;
using UnityEditor;
using UnityEngine;

namespace Jenkins
{
    public partial class JenkinsAdapter
    {
        /// <summary>
        /// 平台共有设置
        /// </summary>
        /// <param name="target"></param>
        private static void _setBuildInfo(BuildTargetGroup target)
        {
            
            //安卓,IOS
            PlayerSettings.defaultInterfaceOrientation =
                _stringToEnum<UIOrientation>(
                    _getBuildType<BuildInfoBuildTypeAndroid>().AndroidAndIOS.DefaultOrientation.ToString());


            //pc
            PlayerSettings.displayResolutionDialog = _stringToEnum<ResolutionDialogSetting>(
                _getBuildType<BuildInfoBuildTypePC>().DisplayResolutionDialog.ToString());


            PlayerSettings.macFullscreenMode = _stringToEnum<MacFullscreenMode>(
                _getBuildType<BuildInfoBuildTypePC>().MacFullscreenMode.ToString());
            PlayerSettings.d3d9FullscreenMode = _stringToEnum<D3D9FullscreenMode>(
                _getBuildType<BuildInfoBuildTypePC>().D3D9FullscreenMode.ToString());

            PlayerSettings.d3d11FullscreenMode = _stringToEnum<D3D11FullscreenMode>(
                _getBuildType<BuildInfoBuildTypePC>().D3D11FullscreenMode.ToString());

            //需要修改xsd
//            PlayerSettings.SetAspectRatio(_getBuildType<BuildInfoBuildTypePC>()AspectRatio.Aspect16by10, true);

            

            PlayerSettings.colorSpace = _stringToEnum<ColorSpace>(BuildInfo.ColorSpace.ToString());

            PlayerSettings.SetScriptingBackend(target,
                _stringToEnum<ScriptingImplementation>(BuildInfo.ScriptingBackend.ToString()));

            PlayerSettings.SetApiCompatibilityLevel(target, _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));

            PlayerSettings.strippingLevel = _stringToEnum<StrippingLevel>(BuildInfo.StrippingLevel.ToString());

            PlayerSettings.bundleVersion = BuildInfo.Version.Value;

            //需要修改xsd
            //PlayerSettings.SetStackTraceLogType(LogType.Log, StackTraceLogType.Full);


            //            if (Config.ContainsKey(ConfigNodeConst.Version))
            //            {
            //                PlayerSettings.bundleVersion = _getNodeValue(ConfigNodeConst.Version);
            //            }
#if UNITY_5_6_OR_NEWER

            //todo 根据平台设置 或者 修改xsd吧报名抽出来
            //            if (Config.ContainsKey(ConfigNodeConst.PackName))
            //            {
            //                PlayerSettings.applicationIdentifier = _getNodeValue(ConfigNodeConst.PackName);
            //            }

            //
            PlayerSettings.SetApiCompatibilityLevel(target,
                _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));

#endif
            EditorUserBuildSettings.development = BuildInfo.Development;
            EditorUserBuildSettings.connectProfiler = BuildInfo.ConnectProfiler;
            EditorUserBuildSettings.allowDebugging = BuildInfo.ScriptsDebuggers;

            //todo 需要修改xsd 增加 isAdd 属性
            //PlayerSettings.SetScriptingDefineSymbolsForGroup(target, BuildInfo.ScriptingDefineSymbols.Value);
            
        }
    }
}