using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

class TrailBall : Sprite
{
    private int _duration;

    public TrailBall(Sprite sprite) : base(sprite.name)
    {
        //SetOrigin(width * 0.5f, height * 0.5f);
        _duration = 30;

        x = sprite.x;
        y = sprite.y;
        rotation = sprite.rotation;
        scale = sprite.scale;
    }

    public void Update()
    {
        alpha = _duration / 30.0f;
        _duration -= 1;
        if (_duration < 0)
        {
            LateDestroy();
        }
    }
}
