pa="23123124"
export call
find ./JenkinsBuild -name executePy.sh -print -exec sh -c 'loadxml "$0"' {} \;
echo $shell
#sh $shell loadxml $pa
#sh $shell loadxml $pa $(sh readlink -f "$0" loadxml $pa) {} \;
echo $config

call(){
echo $0
sh $0 loadxml $pa
}