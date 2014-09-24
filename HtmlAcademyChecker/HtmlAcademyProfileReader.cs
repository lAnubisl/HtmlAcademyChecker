using System.Text.RegularExpressions;

namespace HtmlAcademyChecker
{
    class HtmlAcademyProfileReader : IProfileReader
    {
        private const string coursesCompleteCountRegex = @"Курсов пройдено: (?<Count>[\d]+)";
        private const string totalScoreRegex = @"Очков заработано: (?<Count>[\d]+)";
        private const string courseProgressRegex = @"<tr>\n[ ]+<td>\n[ ]+<a href=""/courses/[\d]+"">[^<]+</a>\n[ ]+\n[ ]+</td>\n[ ]+<td>\n[ ]+<div class=""progress"" style=""margin-bottom:0;"">\n[ ]+<div class=""bar"" style=""width:[^%]+%;""></div>\n[ ]+</div>\n[ ]+</td>\n[ ]+<td>\n[ ]+[\d]+ / [\d]+";

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
            var score = int.Parse(totalScoreMatch.Groups["Count"].Value);
            return new HtmlAcademyProfile(profileId, coursesConmpleteCount, score);
        }
    }
}
