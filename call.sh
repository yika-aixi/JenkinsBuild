# call函数
call(){
	echo "executePy路径: $1"
	source $0 #加载executePy.sh
	#$configPath="I:\GitHubProject\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config" #声明配置文件路径,也将是Jenkins使用唯一需要修改的~ **********
	cd $1 #进入executePy.sh所在路径,不然在执行py时会报 No module named
	loadxml $CONFIGPATH #调用 executePy.sh 中的 loadxml 函数并传入配置文件的路径
	echo "解析完成:
	$config"
}
export CONFIGPATH #声明全局变量
main(){
	findPath=$1 # 得到查找路径
	declare -x CONFIGPATH=$2 #修改全局变量为参数
	echo "在${findPath}路径中寻找"
	echo "findPath: $findPath"
	echo "配置文件所在路径: $CONFIGPATH"
	# 找到 executePy.sh 调用 call 传入 executePy.sh 及 所在路径 ("dirname" 获取路径)
	find $findPath -name executePy.sh -print -exec sh -c 'call $(dirname $0)' {} \;
}

export -f call # 声明函数,需要在函数之后
export -f main # 声明函数,需要在函数之后

