using System.Threading.Tasks;

namespace Informatics.Laba2
{
    public interface ISaveInformationService
    {
        Task SaveAsync<T>(string selectedPath, T treeNode);
    }
}