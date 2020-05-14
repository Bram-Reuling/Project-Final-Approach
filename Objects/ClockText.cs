using System;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

public class ClockText : Canvas
{
	readonly private StringFormat _stringFormatCenter;
	readonly private Font _font;

	readonly private PrivateFontCollection pfc = new PrivateFontCollection();

	public ClockText(int tempWidth, int tempHeight) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);

		pfc.AddFontFile("Fonts/alarm clock.ttf");

		_font = new Font(pfc.Families[0], 25, FontStyle.Regular);

		_stringFormatCenter = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
	}

	void Update()
	{
		graphics.Clear(Color.Empty);

		graphics.DrawString(DateTime.Now.ToString("t"), _font, Brushes.White, width / 2, height / 2 + 4, _stringFormatCenter);
	}
}
