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
      
      
      
 测试项目:https://github.com/yika-aixi/JenkinsBuildTest
    库中的JenkinsProjectConfig目录下的Config.xml是Jenkins测试项目,复制到"xxx\Jenkins\jobs\项目名"目录中然后在Jenkins设置中点击 "	
读取设置" 即可看到项目

