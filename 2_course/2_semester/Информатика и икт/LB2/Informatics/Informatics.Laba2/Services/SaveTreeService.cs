using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2.Services
{
    public class SaveTreeService : ISaveInformationService
    {
        public async Task SaveAsync<T>(string selectedPath, T treeNode)
        {
            var root = treeNode as TreeNode;

            var tree = SelectFileName(root);

            using (var stream = new FileStream($"{selectedPath}\\save.json", FileMode.Create, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(stream, tree);
            }
        }

        private Filter SelectFileName(TreeNode node)
        {
            var filter = new Filter() { Text = node.Text.Split('\\').Last() };

            foreach (TreeNode item in node.Nodes)
            {
                filter.Filters.Add(SelectFileName(item));
            }

            return filter;
        }

        private class Filter 
        {
            public string Text { get; set; }

            public List<Filter> Filters { get; set; } = new List<Filter>();
        }
    }
}
