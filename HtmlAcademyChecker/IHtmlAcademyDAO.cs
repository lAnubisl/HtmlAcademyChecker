using System.Collections.Generic;

namespace HtmlAcademyChecker
{
    interface IHtmlAcademyDAO
    {
        ICollection<HtmlAcademyProfile> Load();

        void Save(HtmlAcademyProfile profile);
    }
}
