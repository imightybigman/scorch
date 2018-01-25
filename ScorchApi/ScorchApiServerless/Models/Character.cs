using System;
using System.Collections.Generic;
using System.Linq;
using ScorchApiServerless.Abstract;
using ScorchApiServerless.Models.Items;

namespace ScorchApiServerless.Models
{
    public class Character
    {
        public Guid CharacterId                                 { get; set; }
        public string Firstname                                 { get; set; }
        public string Lastname                                  { get; set; }
        public string Race                                      { get; set; }
        public string Class                                     { get; set; }
        public string Sex                                       { get; set; }
        public string Align                                     { get; set; }
        public int Age                                          { get; set; }
        public int Hp                                           { get; set; }
        public int MaxHp                                        { get; set; }
        public int Gold                                         { get; set; }
        public int Exp                                          { get; set; }
        public int Level                                        { get; set; }
        public int Proficiency                                  { get; set; }
        public int Initiation                                   { get; set; }
        public Stats Stats                                      { get; set; }
        public Equipment Equipment                              { get; set; } = new Equipment();
        public List<Trait> Traits                               { get; set; } = new List<Trait>();
        public List<Skill> Skills                               { get; set; } = new List<Skill>();
        public List<Spell> Spells                               { get; set; } = new List<Spell>();
        public List<Item> Inventory                             { get; set; } = new List<Item>();
        public List<string> Notes                               { get; set; } = new List<string>();
        public List<SpellSlot> SpellSlots                       { get; set; } = new List<SpellSlot>();


        public Character() { }

        public void OrganizeAbilities()
        {
            Traits = Traits.OrderBy(t => t.Name).ToList();
            Skills = Skills.OrderBy(s => s.Name).ToList();
            Spells = Spells.OrderBy(s => s.Name).ToList();
        }

        public void UpdateEquipment(Item equipment)
        {
            if (Equipment.Quiver != null && Equipment.Quiver.ItemId == equipment.ItemId)
            {
                Equipment.Quiver = (Quiver)equipment;
            }
            else if (Equipment.Boots != null && Equipment.Boots.ItemId == equipment.ItemId)
            {
                Equipment.Boots = (Armor)equipment;
            }
            else if (Equipment.Chest != null && Equipment.Chest.ItemId == equipment.ItemId)
            {
                Equipment.Chest = (Armor)equipment;
            }
            else if (Equipment.Gauntlets != null && Equipment.Gauntlets.ItemId == equipment.ItemId)
            {
                Equipment.Gauntlets = (Armor)equipment;
            }
            else if (Equipment.Helm != null && Equipment.Helm.ItemId == equipment.ItemId)
            {
                Equipment.Helm = (Armor)equipment;
            }
            else if (Equipment.LeftRing != null && Equipment.LeftRing.ItemId == equipment.ItemId)
            {
                Equipment.LeftRing = (Accessory)equipment;
            }
            else if (Equipment.RightRing != null && Equipment.RightRing.ItemId == equipment.ItemId)
            {
                Equipment.RightRing = (Accessory)equipment;
            }
            else if (Equipment.Legs != null && Equipment.Legs.ItemId == equipment.ItemId)
            {
                Equipment.Legs = (Armor)equipment;
            }
            else if (Equipment.MainHand != null && Equipment.MainHand.ItemId == equipment.ItemId)
            {
                Equipment.MainHand = (Weapon)equipment;
            }
            else if (Equipment.OffHand != null && Equipment.OffHand.ItemId == equipment.ItemId)
            {
                Equipment.OffHand = (Weapon)equipment;
            }
            else if (Equipment.Necklace != null && Equipment.Necklace.ItemId == equipment.ItemId)
            {
                Equipment.Necklace = (Accessory)equipment;
            }
        }

        public void Equip(Item equipment)
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
            if (slot == "MainHand" || slot =="One-Handed" || slot =="Two-Handed")
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
            if(weapon.Slot == "One-Handed" || weapon.Slot == "Two-Handed")
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
            else if (armor.Slot == "Shield")
            {
                Equipment.Shield = armor;
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
                if (Equipment.LeftRing != null && Equipment.LeftRing.ItemId == accessory.ItemId)
                {
                    throw new InvalidOperationException("Can't equip the same ring twice.");
                }
                Equipment.RightRing = accessory;
            }
            else if (accessory.Slot == "LeftRing")
            {
                if (Equipment.RightRing != null && Equipment.RightRing.ItemId == accessory.ItemId)
                {
                    throw new InvalidOperationException("Can't equip the same ring twice.");

                }
                Equipment.LeftRing = accessory;
            }
        }

        private void EquipQuiver(Quiver quiver)
        {
            Equipment.Quiver = quiver;
        }

        
    }
}
    