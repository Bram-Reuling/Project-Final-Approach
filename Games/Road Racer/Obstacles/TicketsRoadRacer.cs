using System;
using GXPEngine;

class TicketsRoadRacer : Sprite
{

	MainGame _game;

	public TicketsRoadRacer(MainGame tempGame) : base("Sprites/Ticket.png")
	{
		SetOrigin(width / 2, height / 2);
		scale = 0.5f;
		_game = tempGame;
	}

	void Update()
	{
		y += 8;
	}

	void OnCollision(GameObject other)
	{
		if (other is PlayerRoadRacer)
		{
			_game.AddTickets(5);
			_game.ticketsReceived += 5;
			LateDestroy();
		}
	}
}
