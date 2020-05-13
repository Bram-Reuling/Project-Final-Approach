using System;
using GXPEngine;
using System.Drawing;

class Text : Canvas
{
	private StringFormat _stringFormatCenter;
	private Font _font;
	private string _text;
	private bool _isConversation;

	public Text(int _xPos, int _yPos, int tempWidth, int tempHeight, bool isConv) : base(tempWidth, tempHeight)
	{
		SetOrigin(this.width / 2, this.height / 2);
		SetXY(_xPos, _yPos);

		_font = new Font("Arial", 15, FontStyle.Regular);

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
			graphics.DrawString("Press E to continue, Press Q to go back", _font, Brushes.White, width / 2, 165, _stringFormatCenter);
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
