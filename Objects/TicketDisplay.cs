using System;
using GXPEngine;

public class TicketDisplay : Sprite
{

	private readonly TicketText _ticketText;
	private readonly MainGame _game;

	public TicketDisplay(MainGame tempGame) : base("Sprites/Ticket.png")
	{
		SetOrigin(width / 2, height / 2);
		SetXY(width / 2, height / 2);
		_game = tempGame;

		_ticketText = new TicketText(this.width, this.height, _game);
		AddChild(_ticketText);
	}
}
