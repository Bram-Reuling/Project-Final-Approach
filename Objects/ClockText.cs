using System;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

public class ClockText : Canvas
{
	private StringFormat _stringFormatCenter;
	private Font _font;
	private string _text;

	PrivateFontCollection pfc = new PrivateFontCollection();

	public ClockText(int tempWidth, int tempHeight) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);

		pfc.AddFontFile("Fonts/alarm clock.ttf");

		_font = new Font(pfc.Families[0], 25, FontStyle.Regular);

		_text = "Null";

		_stringFormatCenter = new StringFormat();
		_stringFormatCenter.Alignment = StringAlignment.Center;
		_stringFormatCenter.LineAlignment = StringAlignment.Center;
	}

	void Update()
	{
		graphics.Clear(Color.Empty);

		graphics.DrawString(DateTime.Now.ToString("t"), _font, Brushes.White, width / 2 - 5, height / 2 + 4, _stringFormatCenter);
	}
}
