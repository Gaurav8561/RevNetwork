using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class ProgrammeEntity : BaseEntity
    {
        public string StrProgrammeID { get; set; }
        public string StrProgrammeCode { get; set; }
        public string StrProgrammeTitle { get; set; }
        public decimal? DecProgrammeCommission { get; set; }
        public StatusEnumerator StatusProgrammeStatus { get; set; }
        public string StrProgrammeCreatedBy { get; set; }
        public DateTime? DteProgrammeCreatedDate { get; set; }
        public string StrProgrammeModifiedBy { get; set; }
        public DateTime? DteProgrammeModifiedDate { get; set; }
    }
}
