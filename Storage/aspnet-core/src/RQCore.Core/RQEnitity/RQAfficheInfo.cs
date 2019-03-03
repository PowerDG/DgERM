﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace RQCore.RQEnitity
{
    public class RQAfficheInfo : Entity<int>, IFullAudited
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int? Id { get; set; }

        public int UserID { get; set; }
        public string Claime_Type { get; set; }
        public string Super_Type { get; set; }
        public string Claim_Name { get; set; }


        public string AfficheTitle { get; set; }
        public string AfficheContent { get; set; }
        public string AfficheData { get; set; }
        public int BranchID { get; set; }
        public string TypeName { get; set; }
        public int Status { get; set; }
        public int Sorting { get; set; }



        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
