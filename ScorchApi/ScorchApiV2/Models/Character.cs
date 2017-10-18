using System;
using System.Collections.Generic;
using System.Linq;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Character
    {
        public Guid CharacterId         { get; set; }
        public string Firstname         { get; set; }
        public string Lastname          { get; set; }
        public string Race              { get; set; }
        public string Class             { get; set; }
        public string Sex               { get; set; }
        public int Age                  { get; set; }
        public string Align             { get; set; }
        public int Hp                   { get; set; }
        public int MaxHp                { get; set; }
        public int Gold                 { get; set; }
        public int Exp                  { get; set; }
        public int Level                { get; set; }
        public int Proficiency          { get; set; }
        public Stats Stats              { get; set; }
        public Equipment Equipment      { get; set; } = new Equipment();
        public List<Trait> Traits       { get; set; } = new List<Trait>();
        public List<Skill> Skills       { get; set; } = new List<Skill>();
        public List<Spell> Spells       { get; set; } = new List<Spell>();
        public List<IItem> Inventory    { get; set; } = new List<IItem>();
        public List<string> Notes       { get; set; } = new List<string>();
        
        public Character() { }

        public void OrganizeAbilities()
        {
            Equipment = new Equipment();
            Traits = Traits.OrderBy(t => t.Name).ToList();
            Skills = Skills.OrderBy(s => s.Name).ToList();
            Spells = Spells.OrderBy(s => s.Name).ToList();
        }

        public void Equip(IItem equipment)
        {
            var itemClass = equipment.ItemClass;
            switch (itemClass)
            {
                case "Weapon":
                    EquipWeapon((Weapon)equipment);
                    break;
                case "Armor":
                    EquipArmor((Armor)equipment);
                    break;
                case "Quiver":
                    EquipQuiver((Quiver)equipment);
                    break;
                case "Accessory":
                    EquipAccessory((Accessory) equipment);
                    break;
            }
        }

        public void Unequip(string slot)
        {
            if (slot == "Helm")
            {
                Equipment.Helm = null;
            }
            if (slot == "Necklace")
            {
                Equipment.Necklace = null;
            }
            if (slot == "Chest")
            {
                Equipment.Chest = null;
            }
            if (slot == "Legs")
            {
                Equipment.Legs = null;
            }
            if (slot == "Gauntlets")
            {
                Equipment.Gauntlets = null;
            }
            if (slot == "Boots")
            {
                Equipment.Boots = null;
            }
            if (slot == "LeftRing")
            {
                Equipment.LeftRing = null;
            }
            if (slot == "RightRing")
            {
                Equipment.RightRing = null;
            }
            if (slot == "MainHand")
            {
                Equipment.MainHand = null;
            }
            if (slot == "OffHand")
            {
                Equipment.OffHand = null;
            }
            if (slot == "Quiver")
            {
                Equipment.Quiver = null;
            }
        }

        private void EquipWeapon(Weapon weapon)
        {
            if(weapon.Slot == "MainHand")
            {
                Equipment.MainHand = weapon;
            }
            else if(weapon.Slot == "OffHand") {
                Equipment.OffHand = weapon;
            }
        }

        private void EquipArmor(Armor armor)
        {
            if (armor.Slot == "Chest")
            {
                Equipment.Chest = armor;
            }
            else if (armor.Slot == "Helm")
            {
                Equipment.Helm = armor;
            }
            else if (armor.Slot == "Legs")
            {
                Equipment.Legs = armor;
            }
            else if (armor.Slot == "Gauntlets")
            {
                Equipment.Gauntlets = armor;
            }
            else if (armor.Slot == "Boots")
            {
                Equipment.Boots = armor;
            }
        }

        private void EquipAccessory(Accessory accessory)
        {
            if (accessory.Slot == "Necklace")
            {
                Equipment.Necklace = accessory;
            }
            else if (accessory.Slot == "RightRing")
            {
                Equipment.RightRing = accessory;
            }
            else if (accessory.Slot == "LeftRing")
            {
                Equipment.LeftRing = accessory;
            }
        }

        private void EquipQuiver(Quiver quiver)
        {
            Equipment.Quiver = quiver;
        }

        
    }
}
    