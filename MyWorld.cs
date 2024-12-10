using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyStart
{
    internal class MyWorld : World
    {
        public MyWorld() : base(1920, 1080)
        {
            // Tile background with the file "bluerock" in the Content folder.
            BackgroundTileName = "bluerock";
            Add(new Player(), "mario", 250, 500);
            for (int x = 20; x < 1920; x += 40)
            {
                Add(new Ground(), "Brick", x, 1012);
                Add(new Ground(), "Brick", x, 972);
                Add(new Ground(), "Brick", x, 932);
            }
            Add(new Ground(), "Brick", 400, 812);
        }  
    }
}
