using System;

namespace InscrypShit
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Onscription())
                game.Run();
        }
    }
}
