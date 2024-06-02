using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class Submission : BaseModel
    {
        public string? TransactionNo {  get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
        public int TrainingSubjectId { get; set; }
        public virtual TrainingSubjects TrainingSubjects { get; set; }
        public string? Message { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


    }
}
