using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    interface IBank
    {
        string Name { get; }
        string Adress { get; }
        int costumerAcount { get; }
    }
}
