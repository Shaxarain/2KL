using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
