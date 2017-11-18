echo "tt"
export loadxml
loadxml(){
	echo $0
	config=$(python -c "import LoadConfig; LoadConfig.loadxml('I:\GitHubProject\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config')") 
}


