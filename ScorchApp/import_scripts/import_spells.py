from bs4 import BeautifulSoup
import requests
import json
import re

def stripHtml(text):
    return re.sub(r"<[^>]*>", '', text)

def getSpellUrls():
    with open('spellsUrls.txt') as f:
        spellUrls = f.readlines()
        spellUrls = [x.strip() for x in spellUrls]

        return spellUrls

def doParse(spellUrls):
    spellAttributes = {}
    for url in spellUrls:
        print('Doing {0}'.format(url))
        r = requests.get(url)
        data = r.text
        soup = BeautifulSoup(data, 'html.parser')

        spellName = soup.find(class_='page-title').text
        print('Parsing {0}'.format(spellName))
        
        spellDescription = soup.find('script', { 'id': 'origpagecontent'}).text
        spellDescription = stripHtml(spellDescription)

        print(spellDescription)
        for attrItem in soup.find_all(class_='attrListItem'):
            attrName = attrItem.find_next(class_='attrName').text.replace(' ', '')
            attrValue = attrItem.find_next(class_='value').text.strip()
            if attrName in spellAttributes:
                continue
            spellAttributes[attrName] = attrValue

    return spellAttributes

if __name__ == '__main__':
    # spellUrls = getSpellUrls()
    # spellAttributes = doParse(spellUrls)
    # print json.dumps(spellAttributes)

    s = 'A beam of crackling energy streaks toward a creature within range. Make a ranged spell <a class="autolink" href="/compendium/dnd5e/Combat#h-Attack">Attack</a> against the target. On a hit, the target takes 1d10 force damage.<br><br>The spell creates more than one beam when you reach higher levels: two beams at 5th level, three beams at 11th level, and four beams at 17th level. You can direct the beams at the same target or at different ones. Make a separate <a class="autolink" href="/compendium/dnd5e/Combat#h-Attack">Attack</a> roll for each beam.<br>'


