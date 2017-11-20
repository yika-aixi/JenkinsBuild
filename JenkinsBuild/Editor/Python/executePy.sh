loadxml(){
	echo "xml路径: $1"
	config=$(python3 -c "import LoadConfig; LoadConfig.loadxml("$1")") 
}

export -f loadxml






