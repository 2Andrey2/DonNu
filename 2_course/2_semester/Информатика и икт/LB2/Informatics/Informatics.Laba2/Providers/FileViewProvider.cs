using Informatics.Laba2.Models;
using Informatics.Laba2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2.Providers
{
    public class FileViewProvider
    {
        private readonly ILeafInfoService<DocumentInfo> _infoService;
        private readonly IListViewItemFactory _factory;

        public FileViewProvider(ILeafInfoService<DocumentInfo> infoService, IListViewItemFactory factory)
        {
            _infoService = infoService ?? throw new ArgumentNullException(nameof(infoService));
            _factory     = factory     ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<FolderResultObject> CreateListViewItems(string selectedPath)
        {
            var result = new FolderResultObject()
            {
                ListViewItems = new List<ListViewItem>()
            };

            IEnumerable<DocumentInfo> info = _infoService.GetLeafInfo(selectedPath);

            if (!info.Any())
                return result;

            foreach (var item in info)
            {
                (result.ListViewItems as IList<ListViewItem>).Add(
                    await _factory.CreateAsync(item));
            }

            result.TotalSize = info
                .Sum((i) => i.Size);

            return result;
        }
    }
}
