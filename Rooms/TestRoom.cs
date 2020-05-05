using System;
using GXPEngine;
using GXPEngine.Core;

class TestRoom : GameObject
{

	Player _player;

	public TestRoom()
	{
		_player = new Player();
		LateAddChild(_player);
	}
}
