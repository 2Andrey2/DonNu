using Informatics.Laba2.Providers;
using Informatics.Laba2.Services;
using System;
using System.Windows.Forms;

namespace Informatics.Laba2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var infoService = new DirectoryService();

            Application.Run(new MainView(
                new TreeFactory<FolderInfo>(infoService),
                new SaveTreeService(),
                new FileViewProvider(infoService, new ListViewItemFactory())));
        }
    }
}
