using System.Collections.Generic;
using System.Windows.Forms;

namespace Informatics.Laba2.Models
{
    public class FolderResultObject
    {
        public IEnumerable<ListViewItem> ListViewItems { get; set; }

        public long TotalSize { get; set; }
    }
}
