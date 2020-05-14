using System;
using GXPEngine;

public class Clock : Sprite
{

	private readonly ClockText _text;

	public Clock() : base("Sprites/Clock.png")
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width - width / 2, height / 2);

		_text = new ClockText(this.width, this.height);
		AddChild(_text);
	}
}
