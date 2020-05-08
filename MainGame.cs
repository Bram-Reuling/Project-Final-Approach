using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : Game
{

    MainHub _mainHub;
    BarHub _barHub;

    // TODO:
    // - Add a settings mechanic so everyone can change certain settings quickly
    //   without starting Visual Studio and load the project.

    public MainGame() : base(1024, 768, false, true)
    {
        // Start of the game
        SwitchRoom("Main");
    }

    static void Main()
    {
        new MainGame().Start();
    }

    public void SwitchRoom(string _roomToSwitchTo)
    {
        switch (_roomToSwitchTo)
        {
            case "Main":
                if (_barHub != null)
                {
                    _barHub.LateRemove();
                    _barHub = null;
                }

                _mainHub = new MainHub(this);
                LateAddChild(_mainHub);
                break;
            case "Bar":
                if (_mainHub != null)
                {
                    _mainHub.LateRemove();
                    _mainHub = null;
                }

                _barHub = new BarHub(this);
                LateAddChild(_barHub);
                break;
            case "Arkanoid":
                Console.WriteLine("Loading Arkanoid");
                break;
            case "Race":
                Console.WriteLine("Loading Race");
                break;
        }
    }
}