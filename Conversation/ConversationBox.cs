using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GXPEngine;


class ConversationBox : GameObject
{
	StreamReader reader;
	List<string> _textLines;

	bool _started;
	int index;
	int _endTut;
	Text _text;

	bool _buttonIsPressed;
	bool _endTutorial;

	MainHub _mainHub;

	public ConversationBox(string file, MainHub _tempHub)
	{
		index = 0;
		_endTut = 0;

		reader = File.OpenText(file);
		_textLines = new List<string>();
		string line;

		_started = false;
		_endTutorial = false;

		_buttonIsPressed = false;

		_mainHub = _tempHub;

		while ((line = reader.ReadLine()) != null)
		{
			string[] items = line.Split('\n');

			foreach(string item in items)
			{
				if (item.StartsWith("T:"))
				{
					string newString = item.Substring(3);

					_textLines.Add(newString);
				}
			}
		}

		TextBoxImg _box = new TextBoxImg(game.width / 2, game.height - 100);
		LateAddChild(_box);

		_text = new Text(game.width / 2, game.height - 130, _box.width, _box.height);
		LateAddChild(_text);
	}

	void Update()
	{
		ReadTextLines();
		_text.UpdateText(_textLines[index]);
	}

	public void ReadTextLines()
	{
		int _numberOfLines = _textLines.Count;

		if (index >= 0 && index <= _numberOfLines - 1)
		{
			if (Input.GetKey(Key.E))
			{
				if (index < _numberOfLines - 1)
				{
					if (!_buttonIsPressed && !_endTutorial)
					{
						index++;
						_buttonIsPressed = true;
					}

				}

				if (_endTutorial)
				{
					_mainHub.DeleteTut();
				}
			}

			if (Input.GetKey(Key.Q))
			{
				if (index > 0)
				{
					if (!_buttonIsPressed)
					{
						index--;
						_buttonIsPressed = true;
					}
				}
			}

			if (!Input.GetKey(Key.E) && !Input.GetKey(Key.Q))
			{
				_buttonIsPressed = false;
			}

			if (index == _numberOfLines - 1)
			{
				_endTutorial = true;
				Console.WriteLine("End");
			}
			else
			{
				_endTutorial = false;
			}
		}
	}
}
