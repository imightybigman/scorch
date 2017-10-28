import json
import requests

dndApi = "https://dnd-api.imightybigman.com/api/item"

def create_weapon(raw):
    print('Porting weapon {0}, id: {1}'.format(raw['name'], raw['index']))
    twoHandDamage = None
    if '2h_damage' in raw:
        twoHandDamage = '{0}d{1}'.format(raw['2h_damage']['dice_count'], raw['2h_damage']['dice_value'])

    weapon                      = {}
    weapon['Name']              = raw['name']
    weapon['Description']       = raw['category_range']
    weapon['ItemClass']         = 'Weapon'
    weapon['ItemType']          = raw['weapon_range']
    weapon['Cost']              = raw['cost']['quantity']
    weapon['Weight']            = raw['weight']
    weapon['Damage']            = '{0}d{1}'.format(raw['damage']['dice_count'], raw['damage']['dice_value'])
    weapon['Versatile']         = any(x['name'] == 'Versatile' if isinstance(x,dict) else False for x in raw['properties'])
    weapon['VersatileDamage']   = twoHandDamage
    weapon['Slot']              = 'MainHand'
    weapon['ShortRange']        = raw['range']['normal'] if raw['range']['normal'] != None else 0
    weapon['LongRange']         = raw['range']['long'] if raw['range']['long'] != None else 0

    print('Adding weapon: {0}'.format(weapon['Name']))
    print(json.dumps(weapon))
    r = requests.post(dndApi, json=weapon)
    print(r.status_code)

def import_equipment():
    er = requests.get('http://www.dnd5eapi.co/api/equipment')
    ebody = er.json()

    for res in ebody['results']:
        url = res['url']
        r = requests.get(url).json()
        if r['equipment_category'] == 'Weapon':
            create_weapon(r)


if __name__ == '__main__':
    print('Importing stuff')
    import_equipment()