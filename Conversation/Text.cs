using System;
using GXPEngine;
using System.Drawing;
using System.Drawing.Text;

class Text : Canvas
{
	private StringFormat _stringFormatCenter;
	private Font _font;
	private string _text;
	private bool _isConversation;

	public int FontSize { get; set; }

	PrivateFontCollection pfc = new PrivateFontCollection();

	public Text(int _xPos, int _yPos, int tempWidth, int tempHeight, bool isConv) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);
		SetXY(_xPos, _yPos);

		pfc.AddFontFile("Fonts/ARCADE_N.TTF");

		FontSize = 10;

		_font = new Font(pfc.Families[0], FontSize, FontStyle.Regular);

		_text = "Null";

		_stringFormatCenter = new StringFormat();
		_stringFormatCenter.Alignment = StringAlignment.Center;
		_stringFormatCenter.LineAlignment = StringAlignment.Center;

		_isConversation = isConv;
	}

	public Text(int _xPos, int _yPos, int tempWidth, int tempHeight, bool isConv, int fontSize) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);
		SetXY(_xPos, _yPos);

		pfc.AddFontFile("Fonts/ARCADE_N.TTF");

		FontSize = fontSize;

		_font = new Font(pfc.Families[0], FontSize, FontStyle.Regular);

		_text = "Null";

		_stringFormatCenter = new StringFormat();
		_stringFormatCenter.Alignment = StringAlignment.Center;
		_stringFormatCenter.LineAlignment = StringAlignment.Center;

		_isConversation = isConv;
	}

	void Update()
	{
		graphics.Clear(Color.Empty);

		string[] stringArray = _text.Split('8');

		//Console.WriteLine(stringArray.Length);

		if (_isConversation)
		{
			if (stringArray.Length == 2)
				graphics.DrawString(stringArray[0] + "\n" + stringArray[1].TrimStart('8'), _font, Brushes.White, width / 2, 90, _stringFormatCenter);
			else if (stringArray.Length == 3)
				graphics.DrawString(stringArray[0] + "\n" + stringArray[1].TrimStart('8') + "\n" + stringArray[2].TrimStart('8'), _font, Brushes.White, width / 2, 90, _stringFormatCenter);
			else if (stringArray.Length == 4)
				graphics.DrawString(stringArray[0] + "\n" + stringArray[1].TrimStart('8') + "\n" + stringArray[2].TrimStart('8') + "\n" + stringArray[3].TrimStart('8'), _font, Brushes.White, width / 2, 90, _stringFormatCenter);
			graphics.DrawString("Press E to continue, \nPress Q to go back", _font, Brushes.White, width / 2, 165, _stringFormatCenter);
		}
		else
		{
			if (stringArray.Length == 2)
				graphics.DrawString(stringArray[0] + "\n" + stringArray[1].TrimStart('8'), _font, Brushes.White, width / 2, height / 2 + 30, _stringFormatCenter);
			else if (stringArray.Length == 3)
				graphics.DrawString(stringArray[0] + "\n" + stringArray[1].TrimStart('8') + "\n" + stringArray[2].TrimStart('8'), _font, Brushes.White, width / 2, height / 2 + 30, _stringFormatCenter);
		}
	}

	public void UpdateText(string tempText)
	{
		_text = tempText;
	}
}
