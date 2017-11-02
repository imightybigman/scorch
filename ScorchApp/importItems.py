import json
import requests
import pprint 

#dndApi = "https://dnd-api.imightybigman.com/api/item"
dndApi = "http://scorchapiv2-dev.us-east-1.elasticbeanstalk.com/api/item"
#dndApi = "http://localhost:5000/api/item"
pp = pprint.PrettyPrinter(indent=4)

def handle_response(r):
    if r.status_code != 200:
        pp.pprint('{0} : {1}'.format(r.status_code, r.text))
    else:
        pp.pprint(r.status_code)

def get_weapon_slot(raw): 
    hand = any(x['name'] == 'Two-Handed' if isinstance(x,dict) else False for x in raw['properties'])
    if hand:
        return 'Two-Handed'
    return 'One-Handed'

def get_weapon_short_range(raw):
    if raw['name'] == 'Crossbow, light':
        return 80
    if raw['name'] == 'Shortbow':
        return 80
    if raw['name'] == 'Crossbow, hand':
        return 30
    if raw['name'] == 'Crossbow, heavy':
        return 100
    if raw['name'] == 'Longbow':
        return 150
    return raw['range']['normal'] if raw['range']['normal'] != None else 0

def get_weapon_long_range(raw): 
    if raw['name'] == 'Crossbow, light':
        return 320
    if raw['name'] == 'Shortbow':
        return 320
    if raw['name'] == 'Crossbow, hand':
        return 120
    if raw['name'] == 'Crossbow, heavy':
        return 400
    if raw['name'] == 'Longbow':
        return 600
    return raw['range']['long'] if raw['range']['long'] != None else 0

def create_weapon(raw):
    pp.pprint('Porting weapon {0}, id: {1}'.format(raw['name'], raw['index']))

    weapon                      = {}
    weapon['Name']              = raw['name']
    weapon['Description']       = raw['category_range']
    weapon['ItemClass']         = 'Weapon'
    weapon['ItemType']          = raw['weapon_range']
    weapon['Cost']              = raw['cost']['quantity']
    weapon['Weight']            = raw['weight']
    weapon['Damage']            = '{0}d{1}'.format(raw['damage']['dice_count'], raw['damage']['dice_value'])
    weapon['Versatile']         = any(x['name'] == 'Versatile' if isinstance(x,dict) else False for x in raw['properties'])
    weapon['Slot']              = get_weapon_slot(raw)
    weapon['ShortRange']        = get_weapon_short_range(raw)
    weapon['LongRange']         = get_weapon_long_range(raw)

    if 'damage_type' in raw['damage']:
        weapon['DamageType'] = raw['damage']['damage_type']['name']
    elif 'type' in raw['damage']:
        weapon['DamageType'] = raw['damage']['type']['name']    
        
    if '2h_damage' in raw:
        weapon['VersatileDamage'] = '{0}d{1}'.format(raw['2h_damage']['dice_count'], raw['2h_damage']['dice_value'])

    pp.pprint('Adding weapon: {0}'.format(weapon['Name']))
    pp.pprint(json.dumps(weapon))
    r = requests.post(dndApi, json=weapon)
    handle_response(r)

def create_armor(raw):
    pp.pprint('Porting armor {0}, id: {1}'.format(raw['name'], raw['index']))

    armor = {}
    armor['Name']              = raw['name']
    armor['ItemClass']         = 'Armor'
    armor['Cost']              = raw['cost']['quantity']
    armor['Weight']            = raw['weight']
    armor['StealthAdvantage']  = raw['stealth_disadvantage']
    armor['AC']                = raw['armor_class']['base']
    armor['DexterityBonus']    = raw['armor_class']['dex_bonus']
    armor['Slot']              = 'Chest'


    if isinstance(raw['armor_category:'], dict):
        armor['ItemType'] = raw['armor_category:']['name']
    else:
        armor['ItemType'] = raw['armor_category:']

    if armor['ItemType'] == 'Shield':
        armor['Slot'] = 'OffHand'

    pp.pprint('Adding armor: {0}'.format(armor['Name']))
    pp.pprint(json.dumps(armor))
    r = requests.post(dndApi, json=armor)
    handle_response(r)


def create_adventuring_gear(raw):
    pp.pprint('Porting adv gear id: {0}'.format(raw['index']))
    if(raw['gear_category'] == 'Equipment Pack'):
        return

    advGear = {}
    advGear['Name']         = raw['name']
    advGear['ItemClass']    = 'AdventurerGear'
    advGear['ItemType']     = raw['gear_category']
    advGear['Cost']         = raw['cost']['quantity']
    advGear['Weight']       = raw['weight']

    if 'desc' in raw:
        advGear['Description'] = raw['desc'][0]

    pp.pprint(json.dumps(advGear))
    r = requests.post(dndApi, json=advGear)
    handle_response(r)

# quivers are so unique... make them ourselves
def create_quiver():
    pp.pprint('Create quiver')
    quiver = {}
    arrowCount = {}
    arrowCount['Arrows'] = {}
    arrowCount['Arrows']['CurrentAmount'] = 0
    arrowCount['Arrows']['MaxAmount'] = 20
    
    quiver['Name'] = 'Quiver'
    quiver['Description'] = 'A quiver that holds 20 arrows'
    quiver['ItemClass'] = 'Quiver'
    quiver['ItemType'] = 'Quiver'
    quiver['Slot'] = 'Quiver'    
    quiver['Cost'] = 1
    quiver['Weight'] = 1
    quiver['Projectiles'] = arrowCount
    
    pp.pprint(json.dumps(quiver))
    r = requests.post(dndApi, json=quiver)
    handle_response(r)

def import_equipment():
    er = requests.get('http://www.dnd5eapi.co/api/equipment')
    ebody = er.json()

    for res in ebody['results']:
        url = res['url']
        r = requests.get(url).json()
        if r['name'] == 'Quiver':
            create_quiver()
        elif r['equipment_category'] == 'Weapon':
            create_weapon(r)
        elif r['equipment_category'] == 'Armor':
            create_armor(r)
        elif r['equipment_category'] == 'Adventuring Gear':
            create_adventuring_gear(r)
        else:
            pp.pprint(r['equipment_category'])

if __name__ == '__main__':
    pp.pprint('Importing stuff')
    import_equipment()