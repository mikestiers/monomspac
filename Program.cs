using System;

namespace MsPacMan
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MsPacManGame())
                game.Run();
        }
    }
}
