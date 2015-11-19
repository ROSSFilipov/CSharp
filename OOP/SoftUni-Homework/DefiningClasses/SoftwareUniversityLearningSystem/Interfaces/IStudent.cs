using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Interfaces
{
    public interface IStudent
    {
        long StudentNumber { get; set; }

        decimal AverageGrade { get; set; }
    }
}
