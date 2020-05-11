using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class Logo : Sprite
{
    public Logo(int _xPos, int _yPos) : base("ArkanoidSprites/logo.png")
    {
        SetOrigin(width / 2, height / 2);
        SetXY(_xPos, _yPos);
        scale = 0.95f;
    }
}

