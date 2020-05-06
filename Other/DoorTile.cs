using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class DoorTile : AnimationSprite
    {
        public DoorTile(string filename, int cols, int rows) : base(filename, cols, rows)
        {
            SetOrigin(width / 2, height / 2);
        }
    }
}
