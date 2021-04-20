using System.Collections.Generic;

namespace Informatics.Laba2.Services
{
    public interface INodeInfoService<T>
    {
        T GetNodeInfo(string selectedPath);
    }

    public interface ILeafInfoService<T>
    {
        IEnumerable<T> GetLeafInfo(string selectedPath);
    }
}