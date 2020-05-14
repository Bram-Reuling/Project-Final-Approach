using System;
using GXPEngine;

class CatManNPC : AnimationSprite
{

	private readonly int animationDrawsBetweenFrames;
	int step;

	public CatManNPC() : base("Sprites/SideChar.png", 6, 3)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2 + 350, game.height / 2 - 200);

		scaleY = 0.17f;
		scaleX = -0.17f;

		animationDrawsBetweenFrames = 6;
		step = 0;
	}

	public void Update()
	{
		step++;
		if (step > animationDrawsBetweenFrames)
		{
			if (currentFrame < 11 && currentFrame > 5)
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
