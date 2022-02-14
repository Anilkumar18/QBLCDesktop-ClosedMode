using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SetAccessRights
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessRightsProvider provider = new AccessRightsProvider();
            provider.SetRightsToAll();
        }
    }
}
