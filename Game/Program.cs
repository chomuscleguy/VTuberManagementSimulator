using System;
using System.Threading;
using VTuberManagementSimulator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VTuberManagementSimulator
{
    class Program
    {
        static void Main()
        {
            Managers managers = new Managers();
            managers.Scene.ChangeScene(new TitleScene(managers));

            while (true)
            {
                managers.Scene.Update();
            }
        }
    }
}
 