using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Timers;

// Informacion de ConfigurationManager en https://goo.gl/M6THsb

namespace MainService
{
    public class Keeper
    {
        private readonly Timer _timer;
        private readonly string downloadsPath = KnownFolders.GetPath(KnownFolder.Downloads);
        private int daysOld;
        private readonly string tempPath = Path.GetTempPath();

        private string ReadRunPeriod()
        {
            var appSetting = ConfigurationManager.AppSettings;
            daysOld = int.Parse(appSetting["MaxFileDays"]);
            return appSetting["RunPeriod"];
        }

        public Keeper()
        {
            _timer = new Timer(double.Parse(ReadRunPeriod()));
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(downloadsPath);
            var Files = dir.GetFiles("*.*").Where(f => DateTime.Now.Subtract(f.CreationTime).Days >= daysOld).OrderBy(f => f.CreationTime);
            
            if (Files.Count() >= 1)
            {
                foreach (FileInfo file in Files)
                {
                    LogDelete(file.Name);
                    file.Delete();
                }
            }
        }

        public void LogDelete(string DeletedFileName){ 
            string[] lines = null;
            lines = new string[] {$"Deleted {DeletedFileName} on " + DateTime.Now.ToString()};
            File.AppendAllLines($@"{tempPath}\DownloadsKeeper\FilesDeleted.log", lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}