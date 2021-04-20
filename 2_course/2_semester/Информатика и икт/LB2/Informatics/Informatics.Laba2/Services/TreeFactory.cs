using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2.Services
{
    public class TreeFactory<T> : ITreeFactory
        where T : class, INode
    {
        private readonly INodeInfoService<T> _infoService;

        public TreeFactory(INodeInfoService<T> infoService)
        {
            _infoService = infoService ?? throw new ArgumentNullException(nameof(infoService));
        }

        public async Task<TreeNode> CreateAsync(string selectedPath) =>
            await Task.Run(() => this.Create(selectedPath));

        public TreeNode Create(string selectedPath)
        {
            var root = new TreeNode(selectedPath);
            GenerateTree(ref root);

            return root;
        }

        private void GenerateTree(ref TreeNode node)
        {
            var info = _infoService.GetNodeInfo(node.Text);

            foreach (var item in info.Nodes)
            {
                var newNode = new TreeNode(item.Name);
                GenerateTree(ref newNode);

                node.Nodes.Add(newNode);
            }

            foreach (var item in info.Leafs)
            {
                node.Nodes.Add(item.Name);
            }
        }
    }
}
