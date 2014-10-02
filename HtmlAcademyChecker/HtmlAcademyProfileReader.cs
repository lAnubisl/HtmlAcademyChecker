using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace HtmlAcademyChecker
{
    class HtmlAcademyProfileReader : IProfileReader
    {
        private const string coursesCompleteCountRegex = @"Курсов пройдено</td>\n[ ]+<td style=""border:none;vertical-align:middle;""><b>(?<Count>[\d]+)</b></td>";
        private const string totalScoreRegex = @"Очков заработано</td>\n[ ]+<td style=""border:none;vertical-align:middle;""><b>(?<Count>[\d ]+)";
        private const string courseProgressRegex = @"<tr>\n[ ]+<td>\n[ ]+<a href=""/courses/[\d]+"">(?<Name>[^<]+)</a>\n[ ]+\n[ ]+</td>\n[ ]+<td>\n[ ]+<div class=""progress"" style=""margin-bottom:0"">\n[ ]+<div class=""bar"" style=""width:[^%]+%""></div>\n[ ]+</div>\n[ ]+</td>\n[ ]+<td>\n[ ]+(?<Done>[\d]+) / (?<Total>[\d]+)";

        HtmlAcademyProfile IProfileReader.Read(int profileId, string profileHtml)
        {
            var coursesConmpleteCountMatch = Regex.Match(profileHtml, coursesCompleteCountRegex);
            if (coursesConmpleteCountMatch == null)
            {
                //log
                return null;
            }

            var totalScoreMatch = Regex.Match(profileHtml, totalScoreRegex);
            if (totalScoreMatch == null)
            {
                //log
                return null;
            }

            var courseProgressMatches = Regex.Matches(profileHtml, courseProgressRegex);
            if (courseProgressMatches == null || courseProgressMatches.Count == 0)
            {
                //log
                return null;
            }
            var coursesConmpleteCount = int.Parse(coursesConmpleteCountMatch.Groups["Count"].Value);
            var score = int.Parse(totalScoreMatch.Groups["Count"].Value.Replace(" ", ""));
            var courseScores = new Collection<HtmlAcademyCourseScore>();
            foreach (Match match in courseProgressMatches)
            {
                courseScores.Add(new HtmlAcademyCourseScore(match.Groups["Name"].Value, int.Parse(match.Groups["Done"].Value), int.Parse(match.Groups["Total"].Value)));
            }

            return new HtmlAcademyProfile(profileId, coursesConmpleteCount, score, courseScores);
        }
    }
}
