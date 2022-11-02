using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_Manager.Enums;

namespace Mod_Manager.Classes
{
    public abstract class Mod
    {
        private Game game;
        private Attribute attribute;
        private double fileSize;
        private static int modCount = 0;
        private int endoresment = 0;
        private int download = 0;

        public Mod() => Interlocked.Increment(ref modCount);
        ~Mod() => Interlocked.Decrement(ref modCount);

        public Game Game => game;
        public Attribute Attribute => attribute;
        public float FileSize { get; }
        
        public static double GetFileSize(string path)
        {
            double size = new FileInfo(path).Length;

            return size;
        }
        public void SetEndoresment() => Interlocked.Increment(ref endoresment);
        public void SetDownload() => Interlocked.Increment(ref download);
    }
}
