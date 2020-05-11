using System;
using GXPEngine;

class MainMenu : GameObject
{

	Logo _logoThing;
	ImageButton _start;
	ImageButton _quit;
	MainGame _game;

	public MainMenu(MainGame gameTemp)
	{
		_logoThing = new Logo(game.width / 2, game.height / 2, "MainMenu.png");
		AddChild(_logoThing);

		_start = new ImageButton("Buttons/Start.png", 2, 1);
		_start.SetXY(game.width / 2, game.height / 2);
		_start.scale = 0.60f;
		AddChild(_start);

		_quit = new ImageButton("Buttons/Exit.png", 2, 1);
		_quit.SetXY(game.width / 2, game.height / 2 + 100);
		_quit.scale = 0.60f;
		AddChild(_quit);

		_game = gameTemp;
	}

	void Update()
	{
		if (_start.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
		{
			_game.SwitchRoom("Main");
			this.LateDestroy();
		}

		_quit.ExitMode();
	}
}