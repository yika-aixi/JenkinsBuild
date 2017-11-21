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
                PlayerSettings.bundleVersion = Config[ConfigNodeConst.Version];
            }

            if (Config.ContainsKey(ConfigNodeConst.PackName))
            {
                PlayerSettings.applicationIdentifier = Config[ConfigNodeConst.PackName];
            }

            if (Config.ContainsKey(ConfigNodeConst.Scriptingimplementation))
            {
                PlayerSettings.SetScriptingBackend(target,
                    _stringToEnum<ScriptingImplementation>(Config[ConfigNodeConst.Scriptingimplementation]));

            }

            if (Config.ContainsKey(ConfigNodeConst.ApiCompatibilityLevel))
            {
                PlayerSettings.SetApiCompatibilityLevel(target,
                    _stringToEnum<ApiCompatibilityLevel>(Config[ConfigNodeConst.ApiCompatibilityLevel]));
            }

            if (Config.ContainsKey(ConfigNodeConst.Development))
            {
                EditorUserBuildSettings.development = bool.Parse(Config[ConfigNodeConst.Development]);
            }

            if (Config.ContainsKey(ConfigNodeConst.ConnectProfiler))
            {
                EditorUserBuildSettings.connectProfiler = bool.Parse(Config[ConfigNodeConst.ConnectProfiler]);
            }

            if (Config.ContainsKey(ConfigNodeConst.ScriptsDebuggers))
            {
                EditorUserBuildSettings.allowDebugging = bool.Parse(Config[ConfigNodeConst.ScriptsDebuggers]);
            }
        }
    }
}