using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MainGame : Game
{

    MainHub _mainHub;
    BarHub _barHub;
    MainMenuScreenArkanoid _arkanoid;
    MainMenuRoadRacer _roadRacer;

    private SoundChannel _backgroundMusicChannel;

    public bool _displayTutorial { get; set; }

    MainMenu _mainMenu;

    // TODO:
    // - Add a settings mechanic so everyone can change certain settings quickly
    //   without starting Visual Studio and load the project.

    public MainGame() : base(1024, 768, false, true)
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade");
        // Start of the game
        _displayTutorial = true;
        SwitchRoom("");
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														Main()
    //------------------------------------------------------------------------------------------------------------------------
    static void Main()
    {
        new MainGame().Start();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														SwitchRoom()
    //------------------------------------------------------------------------------------------------------------------------
    public void SwitchRoom(string _roomToSwitchTo)
    {
        switch (_roomToSwitchTo)
        {
            case "Main":
                LoadMain();
                break;
            case "Bar":
                LoadBar();
                break;
            case "Arkanoid":
                LoadArkanoid();
                break;
            case "Race":
                LoadRace();
                break;
            default:
                LoadMenu();
                break;
        }
    }

    private void LoadMenu()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade");
        _mainMenu = new MainMenu(this);
        LateAddChild(_mainMenu);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														LoadRace()
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadRace()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Road Racer");
        Console.WriteLine("Loading Race");
        if (_mainHub != null)
        {
            _mainHub.LateRemove();
            _mainHub = null;
            _backgroundMusicChannel.Stop();
        }

        _roadRacer = new MainMenuRoadRacer(this);
        LateAddChild(_roadRacer);
        Console.WriteLine("Race Loaded!");
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														LoadArkanoid()
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadArkanoid()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Arkanoid");
        Console.WriteLine("Loading Arkanoid");
        if (_mainHub != null)
        {
            _mainHub.LateRemove();
            _mainHub = null;
            _backgroundMusicChannel.Stop();
        }

        _arkanoid = new MainMenuScreenArkanoid(this);
        LateAddChild(_arkanoid);
        Console.WriteLine("Arkanoid Loaded!");
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														LoadBar()
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadBar()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Multiplayer Hub");
        Console.WriteLine("Loading Bar");
        if (_mainHub != null)
        {
            _mainHub.LateRemove();
            _mainHub = null;
            _backgroundMusicChannel.Stop();
        }

        _barHub = new BarHub(this);
        LateAddChild(_barHub);

        Sound backgroundMusic = new Sound("Sounds/MultiplayerHub.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;

        Console.WriteLine("Bar Loaded!");
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														LoadMain()
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadMain()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Main Hub");
        Console.WriteLine("Loading Main Hub");
        if (_barHub != null)
        {
            _barHub.LateRemove();
            _barHub = null;
            _backgroundMusicChannel.Stop();
        }

        if (_arkanoid != null)
        {
            _arkanoid.LateRemove();
            _arkanoid = null;
        }

        if (_roadRacer != null)
        {
            _roadRacer.LateRemove();
            _roadRacer = null;
        }

        _mainMenu = null;

        _mainHub = new MainHub(this);
        LateAddChild(_mainHub);

        Sound backgroundMusic = new Sound("Sounds/MainHub.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;

        Console.WriteLine("Main Hub Loaded!");
    }
}