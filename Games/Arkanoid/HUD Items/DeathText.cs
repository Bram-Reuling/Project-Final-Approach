using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

public class DeathText : Canvas
{
    private readonly StringFormat _stringFormatCenter;
    private readonly Font _font;
    private readonly int _tickets;

    private readonly PrivateFontCollection pfc = new PrivateFontCollection();

    public DeathText(int _xPos, int _yPos, int tickets) : base(700, 500)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_xPos, _yPos);

        pfc.AddFontFile("Fonts/ARCADE_N.TTF");

        _font = new Font(pfc.Families[0], 20, FontStyle.Bold);

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
