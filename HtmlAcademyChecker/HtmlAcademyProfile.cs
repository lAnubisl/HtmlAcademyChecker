using System;
using System.Collections.Generic;

namespace HtmlAcademyChecker
{
    class HtmlAcademyProfile
    {
        private readonly int profileId, completeCoursesCount, score;
        private readonly DateTime updateDate;

        private readonly ICollection<HtmlAcademyCourseScore> courseScores;

        internal HtmlAcademyProfile(int profileId)
        {
            this.updateDate = DateTime.Now;
            this.profileId = profileId;
        }

        internal HtmlAcademyProfile(int profileId, int completeCoursesCount, int score)
            : this(profileId)
        {
            this.completeCoursesCount = completeCoursesCount;
            this.score = score;
        }

        public int ProfileId
        {
            get { return this.profileId; }
        }

        public DateTime UpdateDate
        {
            get { return this.updateDate; }
        }
    }
}