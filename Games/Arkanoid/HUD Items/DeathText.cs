using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

public class DeathText : Canvas
{
    private readonly StringFormat _stringFormatCenter;
    private readonly Font _font;
    private readonly int _tickets;

    public DeathText(int _xPos, int _yPos, int tickets) : base(500, 500)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_xPos, _yPos);

        _font = new Font("Arial", 30, FontStyle.Bold);

        _stringFormatCenter = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        _tickets = tickets;
    }

    void Update()
    {

        graphics.Clear(Color.Empty);

        graphics.DrawString("GAME  OVER \nTickets Received: " + _tickets, _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
    }
}
