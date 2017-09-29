using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.S3.Model;

namespace ScorchApi.Models
{
    public class Inventory
    {
        public Item Helm        { get; set; }
        public Item Necklace    { get; set; }  
        public Item Chest       { get; set; } 
        public Item Legs        { get; set; }
        public Item Gauntlets   { get; set; }
        public Item Boots       { get; set; }
        public Item LeftRing    { get; set; }
        public Item RightRing   { get; set; }
        public Item MainHand    { get; set; }
        public Item OffHand     { get; set; }
        public Item Quiver      { get; set; }

        public Inventory() { }

        public Inventory(DynamoDBEntry entry)
        {
            var doc     = entry.AsDocument();
            Helm        = new Item(doc["Helm"]);
            Necklace    = new Item(doc["Necklace"]);
            Chest       = new Item(doc["Chest"]); 
            Legs        = new Item(doc["Legs"]);
            Gauntlets   = new Item(doc["Gauntlets"]);
            Boots       = new Item(doc["Boots"]);
            LeftRing    = new Item(doc["LeftRing"]);
            RightRing   = new Item(doc["RightRing"]);
            MainHand    = new Item(doc["MainHand"]);
            OffHand     = new Item(doc["OffHand"]);
            Quiver      = new Item(doc["Quiver"]);
    }
    }
}
