namespace Jenkins.XmlConst
{
    /// <summary>
    /// 个平台共有的标签
    /// </summary>
    public class ConfigNodeConst
    {
        /// <summary>
        /// 根
        /// </summary>
        public const string Root = "BuildInfo";
        /// <summary>
        /// 输出路径
        /// </summary>
        public const string Path = "Path";
        /// <summary>
        /// 场景集合
        /// </summary>
        public const string Scences = "Scences";
        /// <summary>
        /// 场景
        /// </summary>
        public const string Scence = "Scence";
        /// <summary>
        /// 包名
        /// </summary>
        public const string PackName = "PackName";
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public const string Version = "Version";
        /// <summary>
        /// 脚本运行环境
        /// </summary>
        public const string Scriptingimplementation = "Scriptingimplementation";
        /// <summary>
        /// Api 兼容等级
        /// </summary>
        public const string ApiCompatibilityLevel = "ApiCompatibilityLevel";
        /// <summary>
        /// 开发模式
        /// </summary>
        public const string Development = "Development";
        /// <summary>
        /// 性能分析器
        /// </summary>
        public const string ConnectProfiler = "ConnectProfiler";
        /// <summary>
        /// 脚本调试器
        /// </summary>
        public const string ScriptsDebuggers = "ScriptsDebuggers";
        /// <summary>
        /// 代码版本
        /// </summary>
        public const string BundleVersionCode = "BundleVersionCode";

        public const string ScriptingDefineSymbols = "ScriptingDefineSymbols";
    }

    /// <inheritdoc />
    /// <summary>
    /// 安卓和ios共有的标签
    /// </summary>
    public class AndroidAndIosConfigNodeConfig : ConfigNodeConst
    {
        /// <summary>
        /// 设备架构
        /// </summary>
        public const string TargetDevice = "TargetDevice";
        /// <summary>
        /// SDK版本
        /// </summary>
        public const string SdkVersions = "SdkVersions";
        /// <summary>
        /// 目标SDK版本
        /// </summary>
        public const string TargetSdkVersion = "TargetSdkVersion";
    }

    /// <inheritdoc />
    /// <summary>
    /// 安卓的标签
    /// </summary>
    public class AndroidConfigNodeConst: AndroidAndIosConfigNodeConfig
    {
        /// <summary>
        /// 联网
        /// </summary>
        public const string InternetAccess = "InternetAccess";

        /// <summary>
        /// 打包系统
        /// </summary>
        public const string AndroidBuildSystem = "AndroidBuildSystem";

        /// <summary>
        /// 贴图压缩
        /// </summary>
        public const string TextureCompression = "TextureCompression";

        /// <summary>
        /// 安卓设备不支持ETC压缩格式时的处理方式
        /// </summary>
        public const string ETC2Fallback = "ETC2Fallback";

        /// <summary>
        /// 安卓
        /// </summary>
        public const string Android = "Android";
    }

    /// <inheritdoc />
    /// <summary>
    /// ios的标签
    /// </summary>
    public class IosConfigNodeConst: AndroidAndIosConfigNodeConfig
    {
        /// <summary>
        /// IOS
        /// </summary>
        public const string IOS = "IOS";
    }
}