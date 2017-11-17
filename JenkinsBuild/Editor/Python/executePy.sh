config=$(python -c "import LoadConfig; LoadConfig.loadxml('I:\GitHubProject\JenkinsBuild\JenkinsBuild\Editor\Config\AndroidBuildInfo.config')") 

echo Xml解析内容:
# 我自己的电脑是乱码,但是使用cmd调用 python -c 是正常的
echo ${config}
