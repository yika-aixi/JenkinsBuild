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
        private static void _setCommonBuildInfo(BuildTargetGroup target)
        {

            PlayerSettings.colorSpace = _stringToEnum<ColorSpace>(BuildInfo.ColorSpace.ToString());

            PlayerSettings.SetScriptingBackend(target,
                _stringToEnum<ScriptingImplementation>(BuildInfo.ScriptingBackend.ToString()));

            PlayerSettings.SetApiCompatibilityLevel(target, _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));

            PlayerSettings.strippingLevel = _stringToEnum<StrippingLevel>(BuildInfo.StrippingLevel.ToString());

            PlayerSettings.bundleVersion = BuildInfo.Version.Value;

            foreach (var loggingType in BuildInfo.Logging.Type)
            {
                PlayerSettings.SetStackTraceLogType(_stringToEnum<LogType>(loggingType.Value.ToString()),
                    _stringToEnum<StackTraceLogType>(loggingType.StackType.ToString()));
            }
 
#if UNITY_5_6_OR_NEWER

            PlayerSettings.applicationIdentifier = BuildInfo.PackNname;
           
            PlayerSettings.SetApiCompatibilityLevel(target,
                _stringToEnum<ApiCompatibilityLevel>(BuildInfo.APICompatibilityLevel.ToString()));

#endif
            EditorUserBuildSettings.development = BuildInfo.Development;
            EditorUserBuildSettings.connectProfiler = BuildInfo.ConnectProfiler;
            EditorUserBuildSettings.allowDebugging = BuildInfo.ScriptsDebuggers;

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
            var defaultOrientationValue = isIOS ? 
                _getBuildType<BuildInfoBuildTypeIOS>().AndroidAndIOS.DefaultOrientation.ToString() 
                : 
                _getBuildType<BuildInfoBuildTypeAndroid>().AndroidAndIOS.DefaultOrientation.ToString();

            PlayerSettings.defaultInterfaceOrientation = _stringToEnum<UIOrientation>(defaultOrientationValue);
        }
    }
}