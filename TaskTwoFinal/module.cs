//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskTwoFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class module
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int Credits { get; set; }
        public int ClassHours { get; set; }
        public System.DateTime StudyDate { get; set; }
        public int SelfStudyHours { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SemesterID { get; set; }
    
        public virtual semester semester { get; set; }
        public virtual user user { get; set; }
    }
}
