using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Informatics.Laba2.Services
{
    public class DirectoryService : INodeInfoService<FolderInfo>, ILeafInfoService<DocumentInfo>
    {
        public IEnumerable<DocumentInfo> GetLeafInfo(string selectedPath)
        {
            if (!Directory.Exists(selectedPath))
                yield break;

            foreach (var item in Directory.GetFiles(selectedPath))
            {
                var info = new FileInfo(item);

                yield return new DocumentInfo
                {
                    Name = info.Name,
                    Type = info.Extension,
                    Size = info.Length,
                    Parent = info.DirectoryName
                };
            }
        }

        public FolderInfo GetNodeInfo(string selectedPath)
        {
            if (!Directory.Exists(selectedPath))
                return null;

            var info = new DirectoryInfo(selectedPath);

            return new FolderInfo
            {
                Name = selectedPath,

                Nodes = info
                    .GetDirectories()
                    .Select((i) => new FolderInfo() { Name = i.FullName })
                    .ToList(),

                Leafs = info
                    .GetFiles()
                    .Select((i) => new DocumentInfo() { Name = i.FullName, Parent = selectedPath })
                    .ToList()
            };
        }
    }
}
