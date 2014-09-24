using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAcademyChecker
{
    public interface IProfileDownloader
    {
        string Download(int profileId);
    }
}
