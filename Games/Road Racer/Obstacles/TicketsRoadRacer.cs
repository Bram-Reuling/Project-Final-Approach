using System;
using GXPEngine;

class TicketsRoadRacer : Sprite
{


	public TicketsRoadRacer() : base("circle.png")
	{
		SetOrigin(width / 2, height / 2);
		scale = 0.5f;
	}

	void Update()
	{
		y += 8;
	}

	void OnCollision(GameObject other)
	{
		if (other is PlayerRoadRacer)
		{
			LateDestroy();
		}
	}
}
