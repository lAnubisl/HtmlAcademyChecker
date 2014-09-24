using System;

namespace HtmlAcademyChecker
{
    interface IProfileReader
    {
        HtmlAcademyProfile Read(int profileId, String profileHtml);
    }
}
