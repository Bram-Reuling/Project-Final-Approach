using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class DeathText : Canvas
{
    private StringFormat _stringFormatCenter;
    private Font _font;

    public DeathText(int _xPos, int _yPos) : base(350, 100)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_xPos, _yPos);

        _font = new Font("Arial", 40, FontStyle.Bold);

        _stringFormatCenter = new StringFormat();
        _stringFormatCenter.Alignment = StringAlignment.Center;
        _stringFormatCenter.LineAlignment = StringAlignment.Center;
    }

    void Update()
    {

        graphics.Clear(Color.Empty);

        graphics.DrawString("GAME  OVER", _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
    }
}
