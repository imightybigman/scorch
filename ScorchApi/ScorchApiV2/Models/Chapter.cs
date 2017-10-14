using System;
using System.Collections.Generic;

namespace ScorchApiV2.Models
{
    public class Chapter
    {
        public Guid ChapterId               { get; set; }
        public Guid CampaignId              { get; set; }
        public string Summary               { get; set; }
        public string Detail                { get; set; }
        public string Title                 { get; set; }
        public int ChapterNumber            { get; set; }
        public bool IsPlayerVisible         { get; set; }
        List<Entity> Entities               { get; set; }
        public Chapter() { }

    }
}
