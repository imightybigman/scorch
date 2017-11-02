import json
import requests

#apiUrl = "http://localhost:5000/api/character"
apiUrl = "http://scorchapiv2-dev.us-east-1.elasticbeanstalk.com/api/character"
#apiUrl = "https://dnd-api.imightybigman.com/api/character"

def createSkill(skill):
    skill = list(skill)[0]
    mySkill = {}
    if(skill == "Athletics (Strength)"):
        mySkill['Name'] = 'Athletics'
        mySkill['Stat'] = 'Strength'
        mySkill['Description'] = 'Your Strength (Athletics) check covers difficult situations you encounter while climbing, Jumping, or swimming. For example you try to jump an unusually long distance or pull off a stunt midjump.'
    if(skill == "Acrobatics (Dexterity)"):
        mySkill['Name'] = 'Acrobatics'
        mySkill['Stat'] = 'Dexterity'
        mySkill['Description'] = "Your Dexterity (Acrobatics) check covers your attempt to stay on your feet in a tricky situation, such as when you're trying to run across a sheet of ice, balance on a tightrope, or stay upright on a rocking ship's deck."
    if(skill == "Sleight of Hand (Dexterity)"):
        mySkill['Name'] = 'Sleight of Hand'
        mySkill['Stat'] = 'Dexterity'
        mySkill['Description'] = 'Whenever you attempt an act of legerdemain or manual trickery, such as planting something on someone else or concealing an object on your person, make a Dexterity (Sleight of Hand) check.'
    if(skill == "Stealth (Dexterity)"):
        mySkill['Name'] = 'Stealth'
        mySkill['Stat'] = 'Dexterity'
        mySkill['Description'] = 'Make a Dexterity (Stealth) check when you attempt to conceal yourself from enemies, slink past guards, slip away without being noticed, or sneak up on someone without being seen or heard.'
    if(skill == "Arcana (Intelligence)"):
        mySkill['Name'] = 'Arcana'
        mySkill['Stat'] = 'Intelligence'
        mySkill['Description'] = 'Your Intelligence (Arcana) check measures your ability to recall lore about Spells, Magic Items, eldritch symbols, magical traditions, The Planes of Existence, and the inhabitants of those planes.'
    if(skill == "History (Intelligence)"):
        mySkill['Name'] = 'History'
        mySkill['Stat'] = 'Intelligence'
        mySkill['Description'] = 'Your Intelligence (History) check measures your ability to recall lore about historical events, legendary people, ancient kingdoms, past disputes, recent wars, and lost civilizations.'
    if(skill == "Investigation (Intelligence)"):
        mySkill['Name'] = 'Investigation'
        mySkill['Stat'] = 'Intelligence'
        mySkill['Description'] = 'When you look around for clues and make deductions based on those clues, you make an Intelligence (Investigation) check. You might deduce the location of a hidden object, discern from the appearance of a wound what kind of weapon dealt it, or determine the weakest point in a tunnel that could cause it to collapse. Poring through ancient scrolls in Search of a hidden fragment of knowledge might also call for an Intelligence (Investigation) check.'
    if(skill == "Nature (Intelligence)"):
        mySkill['Name'] = 'Nature'
        mySkill['Stat'] = 'Intelligence'
        mySkill['Description'] = 'Your Intelligence (Nature) check measures your ability to recall lore about terrain, Plants and animals, the weather, and natural cycles.'
    if(skill == "Religion (Intelligence)"):
        mySkill['Name'] = 'Religion'
        mySkill['Stat'] = 'Intelligence'
        mySkill['Description'] = 'Your Intelligence (Religion) check measures your ability to recall lore about deities, rites and prayers, religious hierarchies, holy symbols, and the practices of secret cults.'
    if(skill == "Animal Handling (Wisdom)"):
        mySkill['Name'] = 'Animal'
        mySkill['Stat'] = 'Wisdom'
        mySkill['Description'] = "When there is any question whether you can calm down a domesticated animal, keep a mount from getting spooked, or intuit an animal's intentions, the GM might call for a Wisdom (Animal Handling) check. You also make a Wisdom (Animal Handling) check to control your mount when you attempt a risky maneuver."
    if(skill == "Insight (Wisdom)"):
        mySkill['Name'] = 'Insight'
        mySkill['Stat'] = 'Wisdom'
        mySkill['Description'] = "Your Wisdom (Insight) check decides whether you can determine the true intentions of a creature, such as when searching out a lie or predicting someone's next move. Doing so involves gleaning clues from body Language, Speech habits, and changes in mannerisms."
    if(skill == "Medicine (Wisdom)"):
        mySkill['Name'] = 'Medicine'
        mySkill['Stat'] = 'Wisdom'
        mySkill['Description'] = 'A Wisdom (Medicine) check lets you try to stabilize a dying companion or diagnose an illness.'
    if(skill == "Perception (Wisdom)"):
        mySkill['Name'] = 'Perception'
        mySkill['Stat'] = 'Wisdom'
        mySkill['Description'] = 'Your Wisdom (Perception) check lets you spot, hear, or otherwise detect the presence of something. It measures your general awareness of your surroundings and the keenness of your senses. For example, you might try to hear a conversation through a closed door, eavesdrop under an open window, or hear Monsters moving stealthily in the forest. Or you might try to spot things that are obscured or easy to miss, whether they are orcs lying in ambush on a road, thugs hiding in the shadows of an alley, or candlelight under a closed secret door.'
    if(skill == "Survival (Wisdom)"):
        mySkill['Name'] = 'Survival'
        mySkill['Stat'] = 'Wisdom'
        mySkill['Description'] = 'The GM might ask you to make a Wisdom (Survival) check to follow tracks, hunt wild game, guide your group through frozen wastelands, Identify signs that owlbears live nearby, predict the weather, or avoid quicksand and other natural hazards.'
    if(skill == "Deception (Charisma)"):
        mySkill['Name'] = 'Deception'
        mySkill['Stat'] = 'Charisma'
        mySkill['Description'] = "Your Charisma (Deception) check determines whether you can convincingly hide the truth, either verbally or through your actions. This deception can encompass everything from misleading others through ambiguity to telling outright lies. Typical situations include trying to fast- talk a guard, con a merchant, earn money through gambling, pass yourself off in a disguise, dull someone's suspicions with false assurances, or maintain a straight face while telling a blatant lie."
    if(skill == "Intimidation (Charisma)"):
        mySkill['Name'] = 'Intimidation'
        mySkill['Stat'] = 'Charisma'
        mySkill['Description'] = 'When you attempt to influence someone through overt threats, hostile actions, and physical violence, the GM might ask you to make a Charisma (Intimidation) check. Examples include trying to pry information out of a prisoner, convincing street thugs to back down from a confrontation, or using the edge of a broken bottle to convince a sneering vizier to reconsider a decision.'
    if(skill == "Performance (Charisma)"):
        mySkill['Name'] = 'Performance'
        mySkill['Stat'] = 'Charisma'
        mySkill['Description'] = 'Your Charisma (Performance) check determines how well you can delight an audience with music, dance, acting, storytelling, or some other form of entertainment.'
    if(skill == "Persuasion (Charisma)"):
        mySkill['Name'] = 'Persuasion'
        mySkill['Stat'] = 'Charism'
        mySkill['Description'] = 'When you attempt to influence someone or a group of people with tact, social graces, or good nature, the GM might ask you to make a Charisma (Persuasion) check. Typically, you use persuasion when acting in good faith, to foster friendships, make cordial requests, or exhibit proper etiquette. Examples of persuading others include convincing a chamberlain to let your party see the king, negotiating peace between warring tribes, or inspiring a crowd of townsfolk.'
    
    return mySkill

def buildSkills(skills):
    mySkills = []
    for skill in skills:
        mySkills.append(createSkill(skill))

    return mySkills

def buildSpells(spells):
    mySpells = []
    for spell in spells:
        mySpells.append({
            "Name" : spell['name'],
            "Level" : spell['lvl'],
            "Description" : spell['desc']
        })

    return mySpells

def getEquipment():
    return {
    "Boots": None,
    "Chest": None,
    "Gauntlets": None,
    "Helm": None,
    "LeftRing": None,
    "Legs": None,
    "MainHand": None,
    "Necklace": None,
    "OffHand": None,
    "Quiver": None,
    "RightRing": None
    }

def loadCharacters(url):
    character = requests.get(url)
    c = json.loads(character.text)
    n = {}
    stats = {}
    n['Firstname']      = c['firstname']
    n['Lastname']       = c['lastname']
    n['Race']           = c['race']
    n['Class']          = c['class']
    n['Sex']            = c['sex']
    n['Age']            = c['age']
    n['Align']          = c['align']
    n['Hp']             = c['hp']
    n['MaxHp']          = c['maxHp']
    n['Stats']          = c['stats']
    n['Gold']           = c['gold']
    n['Exp']            = c['exp']
    n['Level']          = 3
    n['Proficiency']    = 2
    n['Skills']         = buildSkills(c['skills'])
    #n['Equipment']      = getEquipment()

    r = requests.post(apiUrl, json=n)
    if(r.status_code == 200):
        print("Loaded: " + url)
    else:
        print("Error: " + r.text)

if __name__ == '__main__':
    loadCharacters("http://tjedens.com/chars/Kiliso.json")
    loadCharacters("http://tjedens.com/chars/iMightyJun.json")
    loadCharacters("http://tjedens.com/chars/Nightwing.json")
    loadCharacters("http://tjedens.com/chars/Scooty.json")
    loadCharacters("http://tjedens.com/chars/Redtail.json")
    loadCharacters("http://tjedens.com/chars/Fyreblood.json")