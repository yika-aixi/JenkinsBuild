using Jenkins.XmlConst;
using UnityEditor;

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
            if (Config.ContainsKey(ConfigNodeConst.Version))
            {
                PlayerSettings.bundleVersion = _getNodeValue(ConfigNodeConst.Version);
            }

            if (Config.ContainsKey(ConfigNodeConst.PackName))
            {
                PlayerSettings.applicationIdentifier = _getNodeValue(ConfigNodeConst.PackName);
            }

            if (Config.ContainsKey(ConfigNodeConst.Scriptingimplementation))
            {
                PlayerSettings.SetScriptingBackend(target,
                    _stringToEnum<ScriptingImplementation>(_getNodeValue(ConfigNodeConst.Scriptingimplementation)));

            }

            if (Config.ContainsKey(ConfigNodeConst.ApiCompatibilityLevel))
            {
                PlayerSettings.SetApiCompatibilityLevel(target,
                    _stringToEnum<ApiCompatibilityLevel>(_getNodeValue(ConfigNodeConst.ApiCompatibilityLevel)));
            }

            if (Config.ContainsKey(ConfigNodeConst.Development))
            {
                EditorUserBuildSettings.development = bool.Parse(_getNodeValue(ConfigNodeConst.Development));
            }

            if (Config.ContainsKey(ConfigNodeConst.ConnectProfiler))
            {
                EditorUserBuildSettings.connectProfiler = bool.Parse(_getNodeValue(ConfigNodeConst.ConnectProfiler));
            }

            if (Config.ContainsKey(ConfigNodeConst.ScriptsDebuggers))
            {
                EditorUserBuildSettings.allowDebugging = bool.Parse(_getNodeValue(ConfigNodeConst.ScriptsDebuggers));
            }

            if (Config.ContainsKey(ConfigNodeConst.ScriptingDefineSymbols))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(target, _getNodeValue(ConfigNodeConst.ScriptingDefineSymbols));
            }

        }
    }
}