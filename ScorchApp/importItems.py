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
def create_weapon(raw):
    weapon                      = {}
    weapon['Name']              = raw['name']
    weapon['Description']       = raw['category_range']
    weapon['ItemClass']         = 
    
    print('Adding weapon: {0}'.format(weapon['Name']))

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