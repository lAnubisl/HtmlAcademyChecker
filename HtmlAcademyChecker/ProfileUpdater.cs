using System.Linq;
using System.Threading.Tasks;

namespace HtmlAcademyChecker
{
    class ProfileUpdater : IProfileUpdater
    {
        private readonly IHtmlAcademyDAO dao;
        private readonly IProfileReader reader;
        private readonly IProfileDownloader downloader;

        public ProfileUpdater(IHtmlAcademyDAO dao, IProfileReader reader, IProfileDownloader downloader)
        {
            this.dao = dao;
            this.reader = reader;
            this.downloader = downloader;
        }

        public void UpdateAllProfiles()
        {
            var profiles = dao.Load();
            if (profiles == null)
            {
                // log
                return;
            }

            if (!profiles.Any())
            {
                // log
                return;
            }

            Parallel.ForEach(profiles, UpdateProfile);
        }

        private void UpdateProfile(HtmlAcademyProfile profile)
        {
            var htmlAcademyPage = downloader.Download(profile.ProfileId);
            if (string.IsNullOrWhiteSpace(htmlAcademyPage))
            {
                // log
                return;
            }

            var updatedProfile = reader.Read(profile.ProfileId, htmlAcademyPage);
            if (updatedProfile == null)
            {
                // log
                return;
            }

            dao.Save(updatedProfile);
        }
    }
}
