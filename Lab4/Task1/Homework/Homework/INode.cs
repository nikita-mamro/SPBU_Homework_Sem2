using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTree
{
    /// <summary>
    /// Интерфейс узла дерева
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Значение в текущем узле дерева
        /// </summary>
        int Calculate();
    }
}
