import os


import os
import json
import fileinput

config_file_path = '../HiddenSolutionsAPI/appsettings.Development.json'
def changeDbConfig(connectionstring, database):
    with open(config_file_path, 'r') as config_file:
        data = json.load(config_file)
        data['Mongo']['ConnectionString'] = connectionstring
        data['Mongo']['Database'] = database

    os.remove(config_file_path)
    with open(config_file_path, 'w') as f:
        json.dump(data, f, indent=4)


changeDbConfig('mongodb://heroku_mjb835f5:i80k5asllgug6g3pjddmtbv3fn@ds031812.mlab.com:31812/heroku_mjb835f5', 'heroku_mjb835f5')

os.system('cd .. && cd HiddenSolutionsAPI && sudo docker build -t hiddensolutionsapi .')
os.system('cd .. && cd HiddenSolutionsAPI && sudo heroku container:push web -a hiddensolutionsapi')
os.system('cd .. && cd HiddenSolutionsAPI && sudo heroku container:release web -a hiddensolutionsapi')

changeDbConfig('mongodb://root:example@localhost:27017/', 'hiddensolutions')
