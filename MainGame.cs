using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : Game
{

	MainHub _mainHub;

	// TODO:
	// - Add a settings mechanic so everyone can change certain settings quickly
	//   without starting Visual Studio and load the project.

	public MainGame () : base(1024, 768, false, false)
	{
		_mainHub = new MainHub();
		AddChild(_mainHub);
	}

	static void Main() {
		new MainGame().Start();
	}
}