# JenkinsBuild

1.1版本使用:https://www.youtube.com/watch?v=jCGui0DSWuo&feature=youtu.be

Jnekins使用教程:http://blog.csdn.net/yikalyosi/article/details/74616542 

文章对你有帮助记得点个赞噢,谢谢o(*￣▽￣*)ブ

目前XML的约定文件xsd会经常变动

Jenkins打包
 
 配置优先级:xml->json
 
  xml -- 基本完成，在完善
  
  json -- 未开始
  
Jenkisn所需插件  	
   Unity3d plugin
   
使用方法:
    在Jnekins中的	Global Tool Configuration 中配置好Unity路径后创建项目,勾上参数化构建->选择File Parameter,设置	File location 为 config
    然后就可以使用~
    其中的在Config目录下的AndroidBuildInfo.config这个文件请复制一份,然后打包的时候修改这个文件并上传即可实现不开启Unity也能修改打包设置,如何扩展修改内容,会在后面说明.

命令行为:
   -quit -batchmode -executeMethod Jenkins.JenkinsAdapter.CommandLineXmlBuildAndroid ${WORKSPACE}\config
   说明:
      命令行中的"config"为File Parameter参数的File location值
      
      
      
 测试项目:https://github.com/yika-aixi/JenkinsBuildTest
    库中的JenkinsProjectConfig目录下的Config.xml是Jenkins测试项目,复制到"xxx\Jenkins\jobs\项目名"目录中然后在Jenkins设置中点击 "	
读取设置" 即可看到项目

使用约定：
  用VS来编辑xml，在菜单栏的“XML”里面的“架构”，点击添加找到BuildInfo.xsd就可以使用

修改扩展:
  首先AndroidBuildInfo.config配置文件有1个约定格式的xsd文件名为"BuildInfo.xsd",其中还有一个是"EnumType.xsd"
   他们的关系:
      AndroidBuildInfo.config依赖->BuildInfo.xsd
      BuildInfo.xsd依赖-> EnumType.xsd
  2个xsd负责的事情:
    BuildInfo.xsd 负责的就是约定xxx.config文件中的规范,要增删改内容,首先需要修改BuildInfo.xsd文件,然后在修改xxx.config,这样能避免大部分的错误,但同时,如果xsd编写错误也将会带来错误~
    在代码中我是通过常量来获取标签,然后取配置进行修改
        脚本分别为:ConfigNodeConst.cs,XmlAttributeConst.cs
    EnumType.xsd 负责的就是约定打包设置中必要约定的枚举类型的值,如果不约定手写太难,所以事先约定好,这样就极大的避免了枚举转换失败的问题,需要增加选择类型的打包选项可以在这里增加,语法复制我写好的一份修改就行~
    
    最后修改JenkinsAdapter.cs脚本,这个基本里的函数会被Jenkins调用,同时解析xml,然后修改打包设置,等等一系列的操作,这个类后面会被分部话,不然体积会很庞大~
