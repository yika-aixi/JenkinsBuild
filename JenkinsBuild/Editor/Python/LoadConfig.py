import json
import xml.etree.ElementTree as ET

# 读取json文件
def loadjson(path):
    # 打开文件
    file = open(path)
    # 从文件加载json
    json_str = json.load(file)
    return json_str

# 读取xml配置文件
def loadxml(path):
    # 解析文件
    xml_str = ET.parse(path)
    # 将解析内容输出为字符串
    return ET.tostring(xml_str.getroot(),encoding="utf-8").decode("utf-8")