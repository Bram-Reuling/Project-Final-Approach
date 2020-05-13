using System;
using GXPEngine;

class ShopKeeper : AnimationSprite
{

	int animationDrawsBetweenFrames;
	int step;

	public ShopKeeper() : base("Sprites/Quebert.png", 6, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2 - 300, game.height / 2 + 250);

		scaleY = 0.35f;
		scaleX = -0.35f;

		animationDrawsBetweenFrames = 6;
		step = 0;
	}

	public void Update()
	{
		step++;
		if (step > animationDrawsBetweenFrames)
		{
			if (currentFrame < 6)
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
