using System;
using GXPEngine;

class Obstacles : GameObject
{
	TicketsRoadRacer _obOne;
	OpponentCars _opCar;

	Random rnd = new Random();

	public Obstacles()
	{
		TimerForTickets();
		TimerForOtherCars();
	}

	private void TimerForTickets()
	{
		int timeTickets = rnd.Next(1, 10);
		AddChild(new Timer(timeTickets * 1000, SpawnTickets));
	}

	private void TimerForOtherCars()
	{
		int timeCar = rnd.Next(1, 5);
		AddChild(new Timer(timeCar * 1000, SpawnCar));
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
		_obOne = new TicketsRoadRacer();

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
	}
}
