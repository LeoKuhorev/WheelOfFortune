using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    class Utils
    {
        public static string CaptureUserInput()
        {
            string playerInput = Console.ReadLine().ToUpper().Trim();
            if (playerInput == "QUIT")
                throw new ApplicationException();

            return playerInput;
        }
    }
}
