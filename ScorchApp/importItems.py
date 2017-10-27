import json
import requests

# string Name          
# string Description   
# string ItemClass     
# string ItemType      
# double Cost          
# int Weight           

# string Damage                    
# string DamageType                
# string Slot                      
# List<string> Properties          
# List<Modifiers> StatModifiers    
# int ShortRange                   
# int LongRange     
#   
# 
# {
# 	"_id": "58f40bc5c9e7ce9f721536e2",
# 	"index": 22,
# 	"name": "Longsword",
# 	"equipment_category": "Weapon",
# 	"weapon_category:": "Martial",
# 	"weapon_range": "Melee",
# 	"category_range": "Martial Melee",
# 	"cost": {
# 		"quantity": 15,
# 		"unit": "gp"
# 	},
# 	"damage": {
# 		"dice_count": 1,
# 		"dice_value": 8,
# 		"type": {
# 			"url": "http://www.dnd5eapi.co/api/damage-types/12",
# 			"name": "Slashing"
# 		}
# 	},
# 	"range": {
# 		"normal": 5,
# 		"long": null
# 	},
# 	"weight": 3,
# 	"properties": [
# 		{
# 			"name": "Versatile",
# 			"url": "http://www.dnd5eapi.co/api/weapon-properties/10"
# 		}
# 	],
# 	"2h_damage": {
# 		"dice_count": 1,
# 		"dice_value": 10,
# 		"type": {
# 			"url": "http://www.dnd5eapi.co/api/damage-types/12",
# 			"name": "Slashing"
# 		}
# 	},
# 	"url": "http://www.dnd5eapi.co/api/equipment/22"
# }            
def create_weapon(raw):
    weapon                      = {}
    weapon['Name']              = raw['name']
    weapon['Description']       = raw['category_range']
    weapon['ItemClass']         = 'Weapon'
    weapon['ItemType']          = raw['weapon_range']
    weapon['Cost']              = raw['cost']['quantity']
    weapon['Weight']            = raw['weight']
    weapon['Damage']            = '{0}d{1}'.format(raw['damage']['dice_count'], raw['damage']['dice_value'])
    weapon['Versatile']         = any(x['name'] == 'Versatile' if isinstance(x,dict) else False for x in raw['properties'])
    weapon['VersatileDamage']   = '{0}d{1}'.format(raw['2h_damage']['dice_count'], raw['2h_damage']['dice_value']) if weapon['Versatile'] else None
    weapon['Slot']              = 'MainHand'
    weapon['ShortRange']        = raw['range']['normal']
    weapon['LongRange']         = raw['rnage']['long']

    print('Adding weapon: {0}'.format(weapon['Name']))
    r = requests.post('')
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