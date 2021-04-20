using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2.Services
{
    public class ListViewItemFactory : IListViewItemFactory
    {
        public async Task<ListViewItem> CreateAsync(DocumentInfo info) =>
            await Task.Run(() => Create(info));

        public ListViewItem Create(DocumentInfo info)
        {
            var item = new ListViewItem(info.Name)
            {
                Checked = true,
                BackColor = GetColor(info.Type)
            };

            item.SubItems.Add(info.Size.ToString());
            item.SubItems.Add(info.Type);

            return item;
        }

        private Color GetColor(string key)
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;

            if (!keys.Any((k) => k.Equals(key)))
            {
                return Color.White;
            }

            var value = ConfigurationManager.AppSettings[key];
            return Color.FromName(value);
        }
    }
}
