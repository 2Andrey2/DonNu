using System.Collections;
using System.Collections.Generic;

namespace Informatics.Laba2.Services
{
    public interface INode
    {
        string Name { get; set; }

        IEnumerable<INode> Nodes { get; set; }

        IEnumerable<ILeaf> Leafs { get; set; }
    }
}