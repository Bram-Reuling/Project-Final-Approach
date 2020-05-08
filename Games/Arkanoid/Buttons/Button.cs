using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class Button : Canvas
{
    private StringFormat _stringFormatCenter;
    private Font _font;
    private string _buttonText;

    public Button(int _width, int _height, int _fontSize, string _buttonName) : base(_width, _height)
    {
        SetOrigin(this.width / 2, this.height / 2);

        _font = new Font("Arial", _fontSize, FontStyle.Regular);

        _stringFormatCenter = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        _buttonText = _buttonName;
    }

    public void BrighterOnHover()
    {
        graphics.Clear(Color.Empty);

        if (HitTestPoint(Input.mouseX, Input.mouseY))
        {
            graphics.DrawString(_buttonText, _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
        }
        else
        {
            graphics.DrawString(_buttonText, _font, Brushes.DimGray, width / 2, height / 2, _stringFormatCenter);
        }
    }
}

