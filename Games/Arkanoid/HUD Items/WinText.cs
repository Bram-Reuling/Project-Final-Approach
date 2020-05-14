using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class WinText : Canvas
{
    private StringFormat _stringFormatCenter;
    private Font _font;
    int _tickets;

    public WinText(int _xPos, int _yPos, int tickets) : base(700, 500)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_xPos, _yPos);

        _font = new Font("Arial", 30, FontStyle.Bold);

        _stringFormatCenter = new StringFormat();
        _stringFormatCenter.Alignment = StringAlignment.Center;
        _stringFormatCenter.LineAlignment = StringAlignment.Center;
        _tickets = tickets;
    }

    void Update()
    {

        graphics.Clear(Color.Empty);

        graphics.DrawString("YOU WIN! \nMORE LEVELS COMING SOON! \nTickets Received: " + _tickets, _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
    }
}
