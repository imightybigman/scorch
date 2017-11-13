from bs4 import BeautifulSoup
import requests
import json
import re
import pprint 

pp = pprint.PrettyPrinter(indent=4)

# dndApiUrl = "https://dnd-api.imightybigman.com/api/spells"
dndApiUrl = "http://scorchapiv2-dev.us-east-1.elasticbeanstalk.com/api/spells"
#dndApiUrl = "http://localhost:5000/api/spells"

def handle_response(r):
    if r.status_code != 200:
        pp.pprint('{0} : {1}'.format(r.status_code, r.text))
    else:
        pp.pprint(r.status_code)

def stripHtml(text):
    return re.sub(r"<[^>]*>", '', text)

def getSpellUrls():
    with open('spellsUrls.txt') as f:
        spellUrls = f.readlines()
        spellUrls = [x.strip() for x in spellUrls]

        return spellUrls

def toBool(modifier):
    if modifier == 'Yes':
        return True
    return False

def toInt(modifier):
    if modifier != None:
        return int(modifier)
    return None

def getClasses(classes):
    if classes == None:
        return None
    classes = classes.replace(' ', '')
    return classes.split(',')

def getHigherLevelSlotDice(raw):
    dice = raw.get('HigherSpellSlotDice')
    die = raw.get('HigherSpellSlotDie')
    if dice != None and die != None:
        return '{0}{1}'.format(dice, die)
    return None

def getSecondaryHigherLevelSlotDice(raw):
    dice = raw.get('SecondaryHigherSpellSlotDice')
    die = raw.get('SecondaryHigherSpellSlotDie')
    if dice != None and die != None:
        return '{0}{1}'.format(dice, die)
    return None

def createSpellBody(raw):
    retSpell = {}
    retSpell['Name'] = raw.get('Name')
    retSpell['Description'] = raw.get('Description')
    retSpell['AddCastingModifier'] = toBool(raw.get('AddCastingModifier'))
    retSpell['CastingTime'] = raw.get('CastingTime')
    retSpell['Classes'] = getClasses(raw.get('Classes'))
    retSpell['Concentration'] = toBool(raw.get('Concentration'))
    retSpell['Damage'] = raw.get('Damage')
    retSpell['DamageType'] = raw.get('DamageType')
    retSpell['Duration'] = raw.get('Duration')
    retSpell['Healing'] = raw.get('Healing')
    retSpell['HigherLevelHealing'] = toInt(raw.get('HigherLevelHealing'))
    retSpell['HigherSpellSlotBonus'] = toInt(raw.get('HigherSpellSlotBonus'))
    retSpell['HigherSpellSlotDice'] = getHigherLevelSlotDice(raw)
    retSpell['Level'] = toInt(raw.get('Level'))
    retSpell['Range'] = raw.get('Range')
    retSpell['Save'] = raw.get('Save')
    retSpell['SaveSuccess'] = raw.get('SaveSuccess')
    retSpell['School'] = raw.get('School')
    retSpell['SecondaryDamage'] = raw.get('SecondaryDamage')
    retSpell['SecondaryDamageType'] = raw.get('SecondaryDamageType')
    retSpell['SecondaryHigherSpellSlotDice'] = getSecondaryHigherLevelSlotDice(raw)
    retSpell['SpellType'] = raw.get('SpellType')
    retSpell['Target'] = raw.get('Target')
    
    return retSpell

def importSpells():
    rawSpells = rawSpellGenerator()
    for raw in rawSpells:
        spell = createSpellBody(raw)
        pp.pprint('Creating Spell {0}'.format(spell['Name']))
        r = requests.post(dndApiUrl, json=spell)
        handle_response(r)

def rawSpellGenerator():
    spellUrls = getSpellUrls()
    for url in spellUrls:
        spellAttributes = {}
        pp.pprint('Doing {0}'.format(url))
        
        r = requests.get(url)
        data = r.text
        soup = BeautifulSoup(data, 'html.parser')
        
        spellName = soup.find(class_='page-title').text        
        spellDescription = soup.find('script', { 'id': 'origpagecontent'}).text
        spellDescription = stripHtml(spellDescription)

        spellAttributes['Name'] = spellName
        spellAttributes['Description'] = spellDescription
        
        for attrItem in soup.find_all(class_='attrListItem'):
            # Save and SavingThrows are the same
            attrName = attrItem.find_next(class_='attrName').text.replace(' ', '')
            attrValue = attrItem.find_next(class_='value').text.strip()
            spellAttributes[attrName] = attrValue

        yield spellAttributes

if __name__ == '__main__':
    importSpells()