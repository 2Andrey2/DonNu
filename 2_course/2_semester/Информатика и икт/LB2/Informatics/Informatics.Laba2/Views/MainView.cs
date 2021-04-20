/// © Сreated in support of students.
/// Author TheWayToJunior.
/// Link to my profile: https://github.com/TheWayToJunior

using Informatics.Laba2.Providers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Informatics.Laba2
{
    public partial class MainView : Form
    {
        private readonly ITreeFactory _treeFactory;
        private readonly ISaveInformationService _saveService;
        private readonly FileViewProvider _provider;

        public MainView(ITreeFactory treeFactory, ISaveInformationService saveService, FileViewProvider provider)
        {
            InitializeComponent();

            _treeFactory = treeFactory ?? throw new ArgumentNullException(nameof(treeFactory));
            _saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            _provider    = provider    ?? throw new ArgumentNullException(nameof(provider));

            this.tsmOpen.Click += TsmOpenClick;
            this.tsmSave.Click += TsmSaveClick;
            this.treeView1.BeforeSelect += TreeViewBeforeSelect;

            this.label1.Text = "Total size: 0";
            this.label2.Text = "Selected files: 0";
        }

        private void ListViewItemCheck(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private async void TreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.listView1.ItemChecked -= ListViewItemCheck;

            listView1.Items.Clear();

            var result = await _provider.CreateListViewItems(e.Node.Text);

            listView1.Items.AddRange(result.ListViewItems
                .ToArray());

            label1.Text = $"Total bytes: {result.TotalSize}";

            if(result.TotalSize.Equals(0))
                this.label2.Text = "Selected files: 0";

            this.listView1.ItemChecked += ListViewItemCheck;
            RefreshInfo();
        }

        private async void TsmOpenClick(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddNode(await _treeFactory.CreateAsync(ofd.SelectedPath)
                        .ConfigureAwait(true));
                }
            }
        }

        private async void TsmSaveClick(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    await _saveService.SaveAsync(ofd.SelectedPath, treeView1.Nodes[0]);
                }
            }
        }

        private void RefreshInfo()
        {
            int? count = listView1.Items?
                .Cast<ListViewItem>()
                .Count((i) => i?.Checked ?? false);

            label2.Text = $"Selected files: {count ?? 0}";

            PringChart();
        }

        private void AddNode(TreeNode node)
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(node);
        }

        private void PringChart()
        {
            this.chart1.Series["Extensions"].Points.Clear();

            var list = listView1.Items
                .Cast<ListViewItem>()
                .Where(i => i?.Checked ?? false)
                .ToList();

            var group = list
                .GroupBy(i => i.SubItems[2].Text)
                .ToDictionary(t => t.Key, t => t.ToList());

            foreach (var item in group)
            {
                this.chart1.Series["Extensions"].Points.AddXY(item.Key, item.Value.Count);
            }
        }
    }
}
