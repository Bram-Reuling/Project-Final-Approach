using System;
using System.Drawing.Text;
using GXPEngine;

public class PlayerRoadRacer : AnimationSprite
{

	private bool _keyIsPressed;
    private int _leftrightcount=0;

	private readonly LevelRoadRacer _level;

	private readonly MainGame _game;

	public PlayerRoadRacer(LevelRoadRacer _levelInst, MainGame tempGame) : base("RoadRacerSprites/Car.png", 4, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2, game.height / 2 + 250);
		_keyIsPressed = false;

		_level = _levelInst;
		_game = tempGame;
		_game.ticketsReceived = 0;
	}

	void Update()
	{
		if (Input.GetKey(Key.A))
		{
			if (!_keyIsPressed && (_leftrightcount >= 0))
            {
				x -= 130;
				_keyIsPressed = true;
                _leftrightcount--;
			}
		}

		if (Input.GetKey(Key.D))
		{
			if (!_keyIsPressed && (_leftrightcount <= 0))
            {
				x += 130;
				_keyIsPressed = true;
                _leftrightcount++;
			}
		}

		if (!Input.GetKey(Key.A) && !Input.GetKey(Key.D))
		{
			_keyIsPressed = false;
		}
	}

	public void Death()
	{
		_level.LoadDeathScreen();
	}
}
