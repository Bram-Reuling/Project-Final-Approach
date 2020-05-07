using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

namespace GXPEngine
{
    class CollisionPoint : Sprite
    {
        public bool isColliding = false;

        public CollisionPoint(string filename, float x, float y) : base(filename)
        {
            this.x = x - width / 2;
            this.y = y - height / 2;
            this.visible = true;
        }


        private void OnCollision(GameObject other)
        {
            if (other is CollisionTile)
            {
                isColliding = true;
            }
        }
    }
}