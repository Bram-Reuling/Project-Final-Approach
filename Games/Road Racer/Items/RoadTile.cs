using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledMapParser;
using GXPEngine;

class RoadTile : AnimationSprite
{
	private int _moveSpeed;
	private bool _aahYes;

	public RoadTile() : base("RoadRacerSprites/RacingGameSpriteSheet.png", 32, 24)
	{
		SetOrigin(width / 2, height / 2);
		_moveSpeed = 8;
		_aahYes = false;
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
