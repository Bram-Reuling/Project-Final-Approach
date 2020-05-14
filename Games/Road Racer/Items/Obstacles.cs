using System;
using GXPEngine;

public class Obstacles : GameObject
{
	private TicketsRoadRacer _obOne;
	private OpponentCars _opCar;

	private readonly Random rnd = new Random();

	private readonly MainGame _game;

	public Obstacles(MainGame tempGame)
	{
		_game = tempGame;
		TimerForTickets();
		TimerForOtherCars();
	}

	private void TimerForTickets()
	{
		if (_game.ticketsReceived < 50)
		{
			int timeTickets = rnd.Next(1, 10);
			AddChild(new Timer(timeTickets * 1000, SpawnTickets));
		}

		if (_game.ticketsReceived >= 50 && _game.ticketsReceived < 75)
		{
			int timeTickets = rnd.Next(1, 12);
			AddChild(new Timer(timeTickets * 1000, SpawnTickets));
		}

		if (_game.ticketsReceived > 75)
		{
			int timeTickets = rnd.Next(1, 14);
			AddChild(new Timer(timeTickets * 1000, SpawnTickets));
		}
	}

	private void TimerForOtherCars()
	{
		if (_game.ticketsReceived < 50)
		{
			int timeCar = rnd.Next(1, 5);
			AddChild(new Timer(timeCar * 1000, SpawnCar));
		}

		if (_game.ticketsReceived >= 50 && _game.ticketsReceived < 75)
		{
			int timeCar = rnd.Next(1, 4);
			AddChild(new Timer(timeCar * 1000, SpawnCar));
		}

		if (_game.ticketsReceived >= 75)
		{
			int timeCar = rnd.Next(1, 3);
			AddChild(new Timer(timeCar * 1000, SpawnCar));
		}
	}

	private void SpawnCar()
	{
		int lane = rnd.Next(4);
		_opCar = new OpponentCars();

		if (lane == 1)
		{
			_opCar.x = -130;
		}

		if (lane == 2)
		{
			_opCar.x = 0;
		}

		if (lane == 3)
		{
			_opCar.x = 130;
		}
		LateAddChild(_opCar);
		TimerForOtherCars();
	}

	private void SpawnTickets()
	{
		int lane = rnd.Next(4);
		Console.WriteLine(lane);
		_obOne = new TicketsRoadRacer(_game);

		if (lane == 1)
		{
			_obOne.x = -130;
		}

		if (lane == 2)
		{
			_obOne.x = 0;
		}

		if (lane == 3)
		{
			_obOne.x = 130;
		}
		LateAddChild(_obOne);

		TimerForTickets();
	}

	void Update()
	{
		if(_obOne != null)
		{
			if (_obOne.y >= game.height)
			{
				_obOne.LateDestroy();
				_obOne = null;
			}
		}

		if (_opCar != null)
		{
			if (_opCar.y >= game.height)
			{
				_opCar.LateDestroy();
				_opCar = null;
			}
		}
	}
}
