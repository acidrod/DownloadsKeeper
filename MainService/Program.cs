using System;
using System.IO;
using Topshelf;

namespace MainService
{
    class Program
    {
        static void Main(string[] args)
        {
            var ec = HostFactory.Run(x =>
            {
                x.Service<Keeper>(s =>
                {
                    s.ConstructUsing(keeper => new Keeper());
                    s.WhenStarted(keeper => keeper.Start());
                    s.WhenStopped(keeper => keeper.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("DownloadKeeper");
                x.SetDisplayName("DownloadKeeper Service");
                x.SetDescription("This service will delete the old downloaded files from your default windows download folder.");
            });

            int exitCodeValue = (int)Convert.ChangeType(ec, ec.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
