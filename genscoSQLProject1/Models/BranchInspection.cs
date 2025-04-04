﻿using genscoSQLProject1.Enums;

namespace genscoSQLProject1.Models
{
    public class BranchInspection
    {
        public int BranchInspectionId { get; set; }
        public  string? CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? BranchNumber { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime? RevisedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateLastMaintained { get; set; }
        public  bool DeleteFlag { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool NeedsApproval { get; set; } = true;



        public BranchInspectionStatus Status { get; set; } = BranchInspectionStatus.Submitted;



        //---------NAVIGATION PROPERTIES-----------///
        public Branch Branch { get; set; }
        public User CreatedByUser { get; set; }  
        public User ApprovedByUser { get; set; }
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
        public ICollection<FormChecklistItems> FormChecklistItems { get; set; } = new List<FormChecklistItems>();
        public ICollection<FormNote> FormNotes { get; set; } = new List<FormNote>();
        public ICollection<FormComment> FormComments { get; set; } = new List<FormComment>();

    }
}

