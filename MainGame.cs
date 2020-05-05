using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : Game
{

	TestRoom _testRoom;

	// TODO:
	// - Add a settings mechanic so everyone can change certain settings quickly
	//   without starting Visual Studio and load the project.

	public MainGame () : base(800, 600, false, false)
	{
		_testRoom = new TestRoom();
		AddChild(_testRoom);
	}

	static void Main() {
		new MainGame().Start();
	}
}