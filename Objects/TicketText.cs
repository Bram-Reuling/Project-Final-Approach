using System;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

public class TicketText : Canvas
{
	readonly private StringFormat _stringFormatCenter;
	readonly private Font _font;

	readonly private PrivateFontCollection pfc = new PrivateFontCollection();

	readonly private MainGame _game;

	public TicketText(int tempWidth, int tempHeight, MainGame tempGame) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);

		pfc.AddFontFile("Fonts/ARCADE_I.TTF");

		_font = new Font(pfc.Families[0], 10, FontStyle.Regular);

		_stringFormatCenter = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};

		_game = tempGame;
	}

	void Update()
	{
		graphics.Clear(Color.Empty);

		graphics.DrawString(_game.tickets.ToString(), _font, Brushes.Black, width / 2, height / 2, _stringFormatCenter);
	}
}
