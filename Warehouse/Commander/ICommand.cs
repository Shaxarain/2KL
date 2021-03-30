using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
