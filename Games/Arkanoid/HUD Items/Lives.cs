using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;
using TiledMapParser;

class Lives : Canvas
{
    private readonly StringFormat _stringFormatCenter;
    private readonly Font _font;

    private readonly PlayerArkanoid _player;

    public Lives(PlayerArkanoid _playerInst, TiledObject _obj) : base(200, 50)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_obj.X, _obj.Y);

        _font = new Font("Arial", 20, FontStyle.Regular);

        _stringFormatCenter = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        _player = _playerInst;
    }

    void Update()
    {

        graphics.Clear(Color.Empty);

        graphics.DrawString("LIVES: " + _player.Lives() , _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
    }
}

