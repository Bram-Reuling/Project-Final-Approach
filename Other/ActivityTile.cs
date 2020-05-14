using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;

namespace GXPEngine
{
    class ActivityTile : AnimationSprite
    {

        public string Activity { get; set; }

        public ActivityTile(string filename, int cols, int rows, TiledObject obj) : base(filename, cols, rows)
        {
            width = (int)obj.Width;
            height = (int)obj.Height;

            visible = false;

            SetOrigin(width / 2, height / 2);

            Activity = obj.GetStringProperty("Activity");

        }
    }
}
