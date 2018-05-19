﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model class used for tracking bug
    /// </summary>
    public class Bug
    {
        public int BugId { get; set; }
        public string ProjectName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int ProgrammerId { get; set; }
        public string Status { get; set; }
        public Image Images { get; set; }
        public Code Codes { get; set; }
        public SourceControl SourceControl { get; set; }
    }
}
