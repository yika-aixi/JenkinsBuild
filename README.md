# JenkinsBuild
Jenkins打包
目前想法是支持:json,xml配置打包
  json设置打包已经实现过,但是因为命令行拼接,然后正则获取的,对格式有严格要求,使用起来不是很方便
 
 现在是想吧这些配置抽成文件配置法(xml,json),然后上传文件,shell调用py解析,然后将解析结果存放在shell变量中,Unity编译命令行中,使用这个变量
  目前测试:前面都测试ok,使用变量还未测试,等后面安装了Jenkins在做测试
 
 配置优先级:xml->json
 
  xml -- 进行中
  
  json -- 编写了py
 

