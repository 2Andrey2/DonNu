using Informatics.Laba2.Services;
using System.Collections.Generic;

namespace Informatics.Laba2
{
    public class FolderInfo : INode
    {
        public string Name { get; set; }

        public IEnumerable<INode> Nodes { get; set; }

        public IEnumerable<ILeaf> Leafs { get; set ; }
    }

    public class DocumentInfo : ILeaf
    {
        public string Name { get; set; }

        public string Type { get; set; }
        
        public long Size { get; set; }

        public string Parent { get; set; }
    }
}
