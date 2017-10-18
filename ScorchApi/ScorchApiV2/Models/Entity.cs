using System;
using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class Entity
    {
        public Guid EntityId                { get; set; }
        public Guid CampaignId              { get; set; }
        public string Title                 { get; set; }
        public string Description           { get; set; }
        public List<string> Tags            { get; set; }
        public Entity() { }


    }
}
    