using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class DoorTile : AnimationSprite
    {
        public string _goto { get; set; }

        public DoorTile(string filename, int cols, int rows, TiledObject obj) : base(filename, cols, rows)
        {
            width = (int)obj.Width;
            height = (int)obj.Height;

            visible = false;

            SetOrigin(width / 2, height / 8);
            _goto = obj.GetStringProperty("GoTo");
        }
    }
}
