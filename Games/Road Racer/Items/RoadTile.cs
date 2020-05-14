using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;

class RoadTile : AnimationSprite
{
	private int _moveSpeed;
	MainGame _game;

	public RoadTile(MainGame tempGame) : base("RoadRacerSprites/RacingGameSpriteSheet.png", 32, 24)
	{
		_game = tempGame;
		SetOrigin(width / 2, height / 2);
		_moveSpeed = 16;
	}

	void Update()
	{
		y += _moveSpeed;

		if (y > game.height)
		{
			y = 0;
		}
	}
}
