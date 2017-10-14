using System;
using System.Collections.Generic;
using ScorchApiV2.Interfaces;

namespace ScorchApiV2.Models
{
    public class Entity
    {
        public Guid EntityId                { get; set; }
        public Guid CampaignId              { get; set; }
        public string Title                 { get; set; }
        public string Description           { get; set; }
        
        public Entity() { }


    }
}
    