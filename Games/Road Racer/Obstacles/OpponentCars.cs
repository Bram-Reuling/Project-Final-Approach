using System;
using GXPEngine;

class OpponentCars : AnimationSprite
{
	public OpponentCars() : base("RoadRacerSprites/Car.png",4,1)
	{
		SetOrigin(width / 2, height / 2);
	}

	void Update()
	{
		y += 8;
	}

	void OnCollision(GameObject other)
	{
		if (other is PlayerRoadRacer)
		{
			PlayerRoadRacer _other = other as PlayerRoadRacer;
			_other.Death();

			LateDestroy();
		}
	}
}
