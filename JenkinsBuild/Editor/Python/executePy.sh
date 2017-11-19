echo "调用py的shell被调用~"
loadxml(){
	echo "xml路径: $1"
	config=$(python -c "import LoadConfig; LoadConfig.loadxml('$1')") 
}

export -f loadxml






