# JenkinsBuild
Jenkins打包
 
 配置优先级:xml->json
 
  xml -- 完成
  
  json -- 未开始
  
Jenkisn所需插件  	
   Unity3d plugin
   
使用方法:
    在Jnekins中的	Global Tool Configuration 中配置好Unity路径后创建项目,勾上参数化构建->选择File Parameter,设置	File location 为 config
    然后就可以使用~

命令行为:
   -quit -batchmode -executeMethod Jenkins.JenkinsAdapter.CommandLineXmlBuildAndroid ${WORKSPACE}\config
   说明:
      命令行中的"config"为File Parameter参数的File location值
     
 

