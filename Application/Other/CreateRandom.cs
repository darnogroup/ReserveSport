using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Other
{
    public static class CreateRandom
    {
        public static int Number()
        {
            
            Random random = new Random();
            int randomId = random.Next(1000, 9999);
            return randomId;
        }
    }
}
