using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : Game
{	

	public MainGame () : base(800, 600, false, false)
	{

	}

	static void Main() {
		new MainGame().Start();
	}
}