echo "调用py的shell被调用~"
loadxml(){
	echo "xml路径: $1"
	config=$(python -c "import LoadConfig; LoadConfig.loadxml('I:\GitHubProject\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config')") 
}

export -f loadxml






