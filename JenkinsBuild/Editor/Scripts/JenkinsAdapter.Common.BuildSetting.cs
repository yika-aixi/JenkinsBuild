using UnityEditor;
using UnityEngine;

namespace JenkinsBuild
{
    public partial class JenkinsAdapter
    {
        /// <summary>
        /// 平台共有设置
        /// </summary>
        /// <param name="target"></param>
        private static void _setCommonBuildInfo(BuildTargetGroup target)
        {
            PlayerSettings.bundleVersion = BuildInfo.Version.Value;
            PlayerSettings.applicationIdentifier = BuildInfo.PackNname;
            EditorUserBuildSettings.development = BuildInfo.Development;
            EditorUserBuildSettings.connectProfiler = BuildInfo.ConnectProfiler;
            EditorUserBuildSettings.allowDebugging = BuildInfo.ScriptsDebuggers;

            PlayerSettings.companyName = string.IsNullOrEmpty(BuildInfo.CompanyName.Value)
                ? PlayerSettings.companyName
                : BuildInfo.CompanyName.Value;

            PlayerSettings.productName = string.IsNullOrEmpty(BuildInfo.ProductName.Value)
                ? PlayerSettings.productName
                : BuildInfo.ProductName.Value;

            if (BuildInfo.ColorSpaceSpecified)
            {
                PlayerSettings.colorSpace = _stringToEnum<ColorSpace>(BuildInfo.ColorSpace.ToString());
            }

            if (BuildInfo.ScriptingBackendSpecified)
            {
                PlayerSettings.SetScriptingBackend(target,
                    _stringToEnum<ScriptingImplementation>(BuildInfo.ScriptingBackend.ToString()));
            }

            if (BuildInfo.APICompatibilityLevelSpecified)
            {
                PlayerSettings.SetApiCompatibilityLevel(target, _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));
            }

            if (BuildInfo.StrippingLevelSpecified)
            {
                PlayerSettings.strippingLevel = _stringToEnum<StrippingLevel>(BuildInfo.StrippingLevel.ToString());
            }


            foreach (var loggingType in BuildInfo.Logging.Type)
            {
                PlayerSettings.SetStackTraceLogType(_stringToEnum<LogType>(loggingType.Value.ToString()),
                    _stringToEnum<StackTraceLogType>(loggingType.StackType.ToString()));
            }

#if UNITY_5_6_OR_NEWER
            if (BuildInfo.APICompatibilityLevelSpecified)
            {
                PlayerSettings.SetApiCompatibilityLevel(target,
                    _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));
            }
#endif
            if (BuildInfo.ScriptingDefineSymbols.IsAdd)
            {
                var oldScripting = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);
                PlayerSettings.SetScriptingDefineSymbolsForGroup(target,
                    oldScripting + ";" + BuildInfo.ScriptingDefineSymbols.Value);
            }
            else
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(target, BuildInfo.ScriptingDefineSymbols.Value);
            }

        }

        static void _setIOSAndAndroidCommonBuildInfo(bool isIOS)
        {
            if (!_getBuildType<BuildInfoBuildTypeIOS>().AndroidAndIOS.DefaultOrientationSpecified &&
                !_getBuildType<BuildInfoBuildTypeAndroid>().AndroidAndIOS.DefaultOrientationSpecified) return;

            var defaultOrientationValue = isIOS ?
                _getBuildType<BuildInfoBuildTypeIOS>().AndroidAndIOS.DefaultOrientation.ToString()
                :
                _getBuildType<BuildInfoBuildTypeAndroid>().AndroidAndIOS.DefaultOrientation.ToString();

            PlayerSettings.defaultInterfaceOrientation = _stringToEnum<UIOrientation>(defaultOrientationValue);
        }
    }
}