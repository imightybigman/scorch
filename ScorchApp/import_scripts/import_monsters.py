from bs4 import BeautifulSoup
import requests
import json
import re
import pprint 

pp = pprint.PrettyPrinter(indent=4)


def getMonstersUrlGenerator():
    r = requests.get('https://roll20.net/compendium/dnd5e/Rules:Monsters%20by%20Name#content')
    data = r.text
    soup = BeautifulSoup(data, 'html.parser')
    urls = []
    monsterUrls = soup.find_all('a', { 'href': True })
    for url in monsterUrls:
        monsterUrl = url['href']
        pp.pprint(monsterUrl)
        if 'compendium/dnd5e/Monsters' in monsterUrl:
            yield 'https://roll20.net' + monsterUrl


def discoverAttributes():
    attributes = {}
    for url in getMonstersUrlGenerator(): 
        pp.pprint('Doing {0}'.format(url))
        r = requests.get(url)
        data = r.text
        soup = BeautifulSoup(data, 'html.parser')
        for attrItem in soup.find_all(class_='attrListItem'):
            # Save and SavingThrows are the same
            attrName = attrItem.find_next(class_='attrName').text.replace(' ', '')
            attrValue = attrItem.find_next(class_='value').text.strip()
            if not attrName in attributes:
                attributes[attrName] = attrValue
    
    return attributes


if __name__ == '__main__':
    attr = discoverAttributes()
    pp.pprint(attr)