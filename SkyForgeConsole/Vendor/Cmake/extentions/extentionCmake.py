import xml.etree.ElementTree as ET
import argparse

def AddConfiguration(path, configuration):
    # Загружаем .csproj файл
    tree = ET.parse(path)
    root = tree.getroot()

    # Находим секцию Configurations или создаем, если ее нет
    config_section = root.find('Configurations')
    if config_section is None:
        config_section = ET.SubElement(root[0], 'Configurations')

    # Устанавливаем значение
    config_section.text = configuration

    # Сохраняем изменения
    tree.write(path)


def WriteConfiguration(path):
    with open(path, 'r', encoding="utf-8") as file:
        lines = file.readlines()
        for line in lines:
            if "CMAKE_CONFIGURATION_TYPES" in line:
                return line.strip().split( sep='=')[1]
        return ""
    

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("path", type=str)
    parser.add_argument("pathToConfiguration", type=str)

    args = parser.parse_args()
    configuration = WriteConfiguration(args.pathToConfiguration)
    
    if(configuration == ""):
        print(f'could not found configuration in {args.pathToConfiguration}')
    else:
        AddConfiguration(args.path, configuration)
    
