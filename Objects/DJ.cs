using System;
using GXPEngine;

class DJ : AnimationSprite
{

	int animationDrawsBetweenFrames;
	int step;

	public DJ() : base("Sprites/Employee.png", 6, 2)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2 - 320, game.height / 2 - 200);
		scale = 0.25f;

		animationDrawsBetweenFrames = 6;
		step = 0;
	}

	public void Update()
	{
		step = step + 1;
		if (step > animationDrawsBetweenFrames)
		{
			if (currentFrame < 5)
			{
				NextFrame();
				step = 0;
			}
			else
			{
				SetFrame(0);
			}
		}
	}
}