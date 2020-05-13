using System;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

public class TicketText : Canvas
{
	private StringFormat _stringFormatCenter;
	private Font _font;
	private string _text;

	PrivateFontCollection pfc = new PrivateFontCollection();

	MainGame _game;

	public TicketText(int tempWidth, int tempHeight, MainGame tempGame) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);

		pfc.AddFontFile("Fonts/ARCADE_I.TTF");

		_font = new Font(pfc.Families[0], 10, FontStyle.Regular);

		_text = "Null";

		_stringFormatCenter = new StringFormat();
		_stringFormatCenter.Alignment = StringAlignment.Center;
		_stringFormatCenter.LineAlignment = StringAlignment.Center;

		_game = tempGame;
	}

	void Update()
	{
		graphics.Clear(Color.Empty);

		graphics.DrawString(_game.tickets.ToString(), _font, Brushes.Black, width / 2, height / 2, _stringFormatCenter);
	}
}
