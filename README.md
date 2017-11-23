# JenkinsBuild

目前支持的打包平台:安卓,IOS

安卓能设置比较多,IOS较少,pc的还没开启

平台的设置会在后面的更新中加入,等不及的也可以自行加入,写约定文件是个蛋疼的事情 ",,ԾㅂԾ,,"

Jnekins使用教程:http://blog.csdn.net/yikalyosi/article/details/74616542 

文章对你有帮助记得点个赞噢,谢谢o(*￣▽￣*)ブ

在1.0分支的最后一个更新解除了命令行中xml路径参数限制在最后一个的问题,解决方案是需要使用" -xml "xml路径" "来解决顺序依赖的问题

在1.1分支我会整理iso,安卓,pc上的同用设置

目前Master分支会经常变动，目前1.0分支可以使用，但是能修改的不是很多~

Jenkins打包
 
 配置优先级:xml->json
 
  xml -- 基本完成，在完善
  
  json -- 未开始,在2.0版本加入
  
Jenkisn所需插件，可选的，没有插件可以写shell或bat来调用  	
   Unity3d plugin
   
使用方法:
    在Jnekins中的	Global Tool Configuration 中配置好Unity路径后创建项目,勾上参数化构建->选择File Parameter,设置	File location 为 config然后就可以使用~
    其中的在Config目录下的AndroidBuildInfo.config和IOSBuildInfo.config这2个文件请复制一份到桌面或者其他位置,然后使用Jenkins的时候修改这个文件并上传即可实现无需更新远程打包设置也能修改打包设置和开发时个个不同设置来回设置的问题,如何扩展可修改内容,会在后面说明.

命令行为:
   -quit -batchmode -executeMethod Jenkins.JenkinsAdapter.CommandLineXmlBuildAndroid -xml "${WORKSPACE}\config"
   说明:
      命令行中的"config"为File Parameter参数的File location值,注意一点的就是 -xml后的参数需要用 "" 包起来
      
 测试项目:https://github.com/yika-aixi/JenkinsBuildTest
    库中的JenkinsProjectConfig目录下的Config.xml是Jenkins测试项目,复制到"xxx\Jenkins\jobs\项目名"目录中然后在Jenkins设置中点击 "	
读取设置" 即可看到项目

使用约定文件(xsd)：
  用VS来编辑xml，在菜单栏的“XML”里面的“架构”，点击添加找到BuildInfo.xsd就可以使用,其他编辑器应该也是类似

修改扩展:
  首先xxxxBuildInfo.config配置文件有1个约定格式的xsd文件名为"BuildInfo.xsd",其中还有一个是"UserData.xsd"
   他们的关系:
      xxxBuildInfo.config依赖->BuildInfo.xsd
      BuildInfo.xsd依赖-> UserData.xsd
  2个xsd负责的事情:
    BuildInfo.xsd 负责的就是约定xxx.config文件中的规范,要增删改内容,首先需要修改BuildInfo.xsd文件,然后在修改xxx.config,这样能避免大部分的错误,如一些自定义类型的复杂数据或参数约定,如枚举就可以放入到UserData.xsd中
    注意点:每个元素应该都有2个属性:explain和default,除了父元素外
    
    在代码中我是通过常量来获取标签,然后取配置进行修改
        脚本分别为:ConfigNodeConst.cs,XmlAttributeConst.cs,JenkinsAdapter[.xxx].cs
    UserData.xsd 负责的就是约定打包设置中必要约定的枚举类型的值,如果不约定手写太难,所以事先约定好,这样就极大的避免了枚举转换失败的问题,需要增加选择类型的打包选项可以在这里增加,语法复制我写好的一份修改就行~
    
    最后修改JenkinsAdapter[.*].cs脚本
