using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2.Services
{
    public interface IListViewItemFactory
    {
        Task<ListViewItem> CreateAsync(DocumentInfo info);

        ListViewItem Create(DocumentInfo info);
    }
}