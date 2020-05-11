using System;
using GXPEngine;

class PlayerRoadRacer : AnimationSprite
{

	private bool _keyIsPressed;

	public PlayerRoadRacer() : base("RoadRacerSprites/Car.png", 4, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2, game.height / 2 + 250);
		_keyIsPressed = false;
	}

	void Update()
	{
		if (Input.GetKey(Key.A))
		{
			if (!_keyIsPressed)
			{
				x -= 130;
				_keyIsPressed = true;
			}
		}

		if (Input.GetKey(Key.D))
		{
			if (!_keyIsPressed)
			{
				x += 130;
				_keyIsPressed = true;
			}
		}

		if (!Input.GetKey(Key.A) && !Input.GetKey(Key.D))
		{
			_keyIsPressed = false;
		}
	}
}
