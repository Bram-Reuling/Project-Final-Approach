using System;
using GXPEngine;

public class Player : AnimationSprite
{

	private int _moveSpeed { get; set; }

	public Player() : base("barry.png", 7 , 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2, game.height / 2);
		_moveSpeed = 5;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														Update()
	//------------------------------------------------------------------------------------------------------------------------
	void Update()
	{
		movement();
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														movement()
	//------------------------------------------------------------------------------------------------------------------------
	private void movement()
	{
		// UP
		if (Input.GetKey(Key.W))
		{
			y -= _moveSpeed;
		}

		// DOWN
		if (Input.GetKey(Key.S))
		{
			y += _moveSpeed;
		}

		// RIGHT
		if (Input.GetKey(Key.D))
		{
			x += _moveSpeed;
		}

		// LEFT
		if (Input.GetKey(Key.A))
		{
			x -= _moveSpeed;
		}
	}
}
