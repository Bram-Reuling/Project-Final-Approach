using System;
using GXPEngine;
using GXPEngine.Core;

class MainHub : GameObject
{

	Player _player;

	public MainHub()
	{
		_player = new Player();
		LateAddChild(_player);
	}
}
