using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatics.Laba2
{
    public interface ITreeFactory
    {
        TreeNode Create(string selectedPath);
     
        Task<TreeNode> CreateAsync(string selectedPath);
    }
}