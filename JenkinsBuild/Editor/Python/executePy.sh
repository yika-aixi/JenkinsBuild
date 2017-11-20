echo "调用py的shell被调用~"
echo "进入当前shell目录~ $(cd "$(dirname "$0")";pwd)"

loadxml(){
	echo "xml路径: $1"
	config=$(python -c "import LoadConfig; LoadConfig.loadxml('$1')") 
}

export -f loadxml






