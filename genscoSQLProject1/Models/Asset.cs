﻿namespace genscoSQLProject1.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetNumber { get; set; }
        public string AssetType { get; set; }
        public int? BranchId { get; set; } 
        public int? BranchNumber { get; set; }
        public int? CategoryId { get; set; }

        //---------NAVIGATION PROPERTIES-----------//
        public Branch Branch { get; set; }
        
    }
}
