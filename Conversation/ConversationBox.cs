using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GXPEngine;


class ConversationBox : GameObject
{
	private StreamReader reader;
	private List<string> _textLines;

	private int index;
	private Text _text;

	private bool _buttonIsPressed;
	private bool _endTutorial;

	private readonly MainHub _mainHub;

	public ConversationBox(string file, MainHub _tempHub)
	{
		_mainHub = _tempHub;

		InitializeBox(file);
	}

	private void InitializeBox(string file)
	{
		index = 0;

		reader = File.OpenText(file);
		_textLines = new List<string>();
		string line;

		_endTutorial = false;

		_buttonIsPressed = false;

		while ((line = reader.ReadLine()) != null)
		{
			string[] items = line.Split('\n');

			foreach (string item in items)
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

		_text = new Text(game.width / 2, game.height - 130, _box.width, _box.height, true);
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

				if (_endTutorial && _mainHub != null)
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

			if (index == _numberOfLines - 1 && _mainHub != null)
			{
				_endTutorial = true;
				LineChanger("DisplayTutorial = false", "Text/Settings.txt", 1);
			}
			else
			{
				_endTutorial = false;
			}
		}
	}
	
	static void LineChanger(string newText, string fileName, int line_to_edit)
	{
		string[] arrLine = File.ReadAllLines(fileName);
		arrLine[line_to_edit - 1] = newText;
		File.WriteAllLines(fileName, arrLine);
	}

}
