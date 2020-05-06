using System;
using GXPEngine;

public class Player : AnimationSprite
{

	private int _moveSpeed { get; set; }

	Vec2 _position { get; set; }
	Vec2 _velocity;

	public Player() : base("barry.png", 7 , 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(game.width / 2, game.height / 2);
		_position = new Vec2(game.width / 2, game.height / 2);
		_moveSpeed = 5;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														Update()
	//------------------------------------------------------------------------------------------------------------------------
	void Update()
	{
		movement();
		updatePos();
		updateScreenPos();
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														updatePos()
	//------------------------------------------------------------------------------------------------------------------------
	private void updatePos()
	{
		x = _position.x;
		y = _position.y;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														updateScreenPos()
	//------------------------------------------------------------------------------------------------------------------------
	private void updateScreenPos()
	{
		// Euler integration
		_position += _velocity;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														movement()
	//------------------------------------------------------------------------------------------------------------------------
	private void movement()
	{
		// UP
		if (Input.GetKey(Key.W))
		{
			_velocity.y = -_moveSpeed;
		}

		// DOWN
		if (Input.GetKey(Key.S))
		{
			_velocity.y = _moveSpeed;
		}

		// RIGHT
		if (Input.GetKey(Key.D))
		{
			_velocity.x = _moveSpeed;
		}

		// LEFT
		if (Input.GetKey(Key.A))
		{
			_velocity.x = -_moveSpeed;
		}

		noInputCheck();

		normalizeVelocity();
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														normalizeVelocity()
	//------------------------------------------------------------------------------------------------------------------------
	private void normalizeVelocity()
	{
		// Normalize the velocity to have the same movement on diagonal as non-diagonal
		_velocity.Normalize();
		_velocity *= _moveSpeed;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														noInputCheck()
	//------------------------------------------------------------------------------------------------------------------------
	private void noInputCheck()
	{
		// If the input is nothing than don't move
		if (!Input.GetKey(Key.W) && !Input.GetKey(Key.S) && !Input.GetKey(Key.D) && !Input.GetKey(Key.A))
		{
			_velocity.x = 0;
			_velocity.y = 0;
		}
	}
}
