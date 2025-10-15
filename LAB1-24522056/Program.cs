
using System;
using System.Windows.Forms;

namespace LAB1_24522056
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Lab1_bai9());

        }
    }
}
