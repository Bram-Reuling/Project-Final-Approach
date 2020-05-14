using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GXPEngine;

public class ActivityBox : GameObject
{
    private StreamReader reader;
    private List<string> _textLines;

    private Text _text;

    public ActivityBox(string file)
    {

        InitializeBox(file);
    }

    private void InitializeBox(string file)
    {
		reader = File.OpenText(file);
		_textLines = new List<string>();
		string line;

		while ((line = reader.ReadLine()) != null)
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

		TextBoxImg _box = new TextBoxImg(game.width / 2, game.height - 100);
		LateAddChild(_box);

		_text = new Text(game.width / 2, game.height - 130, _box.width, _box.height, false);
		LateAddChild(_text);
	}

	void Update()
	{
		_text.UpdateText(_textLines[0]);
	}
}