using System;
using GXPEngine;

public class TextBoxImg : Sprite
{
	public TextBoxImg(float xPos, float yPos) : base("Sprites/TextBox.png")
	{
		SetOrigin(width / 2, height / 2);
		SetXY(xPos, yPos);
		scaleX = 0.35f;
		scaleY = 0.4f;
	}
}
