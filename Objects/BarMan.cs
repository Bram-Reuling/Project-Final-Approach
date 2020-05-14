using System;
using GXPEngine;

class BarMan : AnimationSprite
{

	private readonly int animationDrawsBetweenFrames;
	int step;

	public BarMan() : base("Sprites/Employee.png", 6, 2)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2 + 415, game.height / 2 - 50);
		scale = 0.15f;

		animationDrawsBetweenFrames = 6;
		step = 0;
	}

	public void Update()
	{
		step += 1;
		if (step > animationDrawsBetweenFrames)
		{
			if (currentFrame > 5 && currentFrame < 9)
			{
				NextFrame();
				step = 0;
			}
			else
			{
				SetFrame(6);
			}
		}
	}
}
