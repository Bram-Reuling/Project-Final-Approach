using System;
using System.Collections.Generic;
using System.IO;
using GXPEngine;

public class ShopItem : Sprite
{
	private StreamReader _reader;
	private List<string> _textLines;

	private Text _text;

	public ShopItem(string file, string textFile) : base(file)
	{
		SetOrigin(width / 2, height / 2);
		scale = 0.45f;
		SetXY(655, 320);

		TextInit(textFile);
	}

	private void TextInit(string file)
	{
		_reader = File.OpenText(file);
		_textLines = new List<string>();
		string line;

		while ((line = _reader.ReadLine()) != null)
		{
			string[] items = line.Split('\n');

			foreach (string item in items)
			{
				if (item.StartsWith("T:"))
				{
					string newString = item.Substring(3);
					Console.WriteLine(newString);
					_textLines.Add(newString);
				}
			}
		}

		_text = new Text(game.width / 2 - 525, game.height / 2 + 30, 1000, 350, false, 20);
		LateAddChild(_text);
	}

	void Update()
	{
		_text.UpdateText(_textLines[0]);
	}
}
