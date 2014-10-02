using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAcademyChecker
{
    class HtmlAcademyCourseScore
    {
        private readonly string name;
        private readonly int completeSteps, totalSteps;

        internal HtmlAcademyCourseScore(String Name, int CompletedSteps, int TotalSteps)
        {
            name = Name;
            completeSteps = CompletedSteps;
            totalSteps = TotalSteps;
        }

        public int CompleteSteps { get { return completeSteps; } }
        public int TotalSteps { get { return totalSteps; } }
        public String Name { get { return name; } }
    }
}
