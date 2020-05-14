using System;
using GXPEngine;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

public class MainGame : Game
{

    MainHub _mainHub;
    BarHub _barHub;

    MainMenuScreenArkanoid _arkanoid;
    ArkanoidLevelScreen _aLevelOne;
    ArkanoidDeathScreen _aDeathScreen;
    ArkanoidWinScreen _aWinScreen;

    MainMenuRoadRacer _roadRacer;
    LevelRoadRacer _rLevel;
    DeathScreenRoad _rDeathScreen;

    private SoundChannel _backgroundMusicChannel;

    public bool _displayTutorial { get; set; }

    MainMenu _mainMenu;

    StreamReader reader;
    List<string> _textLines;

    public int tickets;
    public int ticketsReceived;
    public bool _sufficientTickets;

    public MainGame() : base(1024, 768, false, true)
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade");

        ReadSettingsFile();
        ticketCheck(tickets);
        ticketsReceived = 0;
        // Start of the game
        SwitchRoom("");
    }

    public void AddTickets(int numberOfTickets)
    {
        int newTickets = tickets + numberOfTickets;

        ticketCheck(newTickets);

        lineChanger("Tickets = " + newTickets.ToString(), "Text/Settings.txt", 2);

        ReadSettingsFile();
    }

    public void SubtrackTickets(int numberOfTickets)
    {
        int newTickets = tickets - numberOfTickets;

        ticketCheck(newTickets);

        lineChanger("Tickets = " + newTickets.ToString(), "Text/Settings.txt", 2);

        ReadSettingsFile();
    }

    private void ticketCheck(int tempTickets)
    {
        if (tempTickets > 0)
        {
            _sufficientTickets = true;
        }
        else
        {
            _sufficientTickets = false;
        }
    }

    static void lineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    private void ReadSettingsFile()
    {
        reader = File.OpenText("Text/Settings.txt");
        _textLines = new List<string>();
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] items = line.Split('\n');

            foreach (string item in items)
            {
                if (item.StartsWith("DisplayTutorial = "))
                {
                    string newString = item.Substring(18);
                    Console.WriteLine(newString);
                    _displayTutorial = Convert.ToBoolean(newString);
                }

                if (item.StartsWith("Tickets = "))
                {
                    string newString = item.Substring(10);
                    Console.WriteLine(newString);

                    tickets = Int32.Parse(newString);
                }
            }
        }

        reader.Close();
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
                LoadArkanoidMenu();
                break;
            case "ALevelOne":
                LoadArkanoidLevelOne();
                break;
            case "ADeath":
                LoadArkanoidDeathScreen();
                break;
            case "AWin":
                LoadArkanoidWinScreen();
                break;
            case "Race":
                LoadRoadRaceMenu();
                break;
            case "RLevel":
                LoadRoadRacerLevel();
                break;
            case "RDeath":
                LoadRoadRacerDeathScreen();
                break;
            case "Dance":
                break;
            case "OpenShop":
                OpenShop();
                break;
            case "CloseShop":
                CloseShop();
                break;
            case "OpenBar":
                OpenBar();
                break;
            case "CloseBar":
                CloseBar();
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

    private void OpenBar()
    {
        if (_barHub != null)
        {
            _barHub.OpenBar();
        }
    }

    private void CloseBar()
    {
        if (_barHub != null)
        {
            _barHub.CloseShop();
        }
    }

    private void OpenShop()
    {
        if (_mainHub != null)
        {
            _mainHub.OpenShop();
        }
    }

    private void CloseShop()
    {
        if (_mainHub != null)
        {
            _mainHub.CloseShop();
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														ROAD RACER
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadRoadRaceMenu()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Road Racer");
        Console.WriteLine("Loading Race");
        if (_mainHub != null)
        {
            _mainHub.LateDestroy();
            _mainHub = null;
            _backgroundMusicChannel.Stop();
        }

        if (_rDeathScreen != null)
        {
            _rDeathScreen.LateDestroy();
            _rDeathScreen = null;
        }

        _roadRacer = new MainMenuRoadRacer(this);
        LateAddChild(_roadRacer);
        Console.WriteLine("Race Loaded!");
    }

    private void LoadRoadRacerLevel()
    {
        if(_roadRacer != null)
        {
            _roadRacer.LateRemove();
            _roadRacer = null;
        }

        SubtrackTickets(10);
        _rLevel = new LevelRoadRacer(this);
        LateAddChild(_rLevel);
    }

    private void LoadRoadRacerDeathScreen()
    {
        if(_rLevel != null)
        {
            _rLevel.LateRemove();
            _rLevel = null;
        }

        _rDeathScreen = new DeathScreenRoad(this);
        LateAddChild(_rDeathScreen);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														ARKANOID
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadArkanoidMenu()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Arkanoid");
        Console.WriteLine("Loading Arkanoid");
        if (_mainHub != null)
        {
            _mainHub.LateDestroy();
            _mainHub = null;
            _backgroundMusicChannel.Stop();
        }

        if (_aDeathScreen != null)
        {
            _aDeathScreen.LateDestroy();
            _aDeathScreen = null;
        }

        if (_aLevelOne != null)
        {
            _aLevelOne.LateDestroy();
            _aLevelOne = null;
        }

        if (_aWinScreen != null)
        {
            _aWinScreen.LateDestroy();
            _aWinScreen = null;
        }

        _arkanoid = new MainMenuScreenArkanoid(this);
        LateAddChild(_arkanoid);
        Console.WriteLine("Arkanoid Loaded!");
    }

    private void LoadArkanoidLevelOne()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Arkanoid - Level 1");

        if (_arkanoid != null)
        {
            _arkanoid.LateDestroy();
            _arkanoid = null;
        }

        SubtrackTickets(10);

        _aLevelOne = new ArkanoidLevelScreen("ArkanoidLevels/level1.tmx", this);
        LateAddChild(_aLevelOne);
    }

    private void LoadArkanoidDeathScreen()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Arkanoid - Game Over");
        if (_aLevelOne != null)
        {
            _aLevelOne.LateDestroy();
            _aLevelOne = null;
        }

        if (_aWinScreen != null)
        {
            _aWinScreen.LateDestroy();
            _aWinScreen = null;
        }

        _aDeathScreen = new ArkanoidDeathScreen(this);
        LateAddChild(_aDeathScreen);
    }

    private void LoadArkanoidWinScreen()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade - Arkanoid - Win!");
        if (_aLevelOne != null)
        {
            _aLevelOne.LateDestroy();
            _aLevelOne = null;
        }

        _aWinScreen = new ArkanoidWinScreen(this);
        LateAddChild(_aWinScreen);
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
            _mainHub.LateDestroy();
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

        RemoveInstancesForMain();

        _mainMenu = null;

        _mainHub = new MainHub(this);
        LateAddChild(_mainHub);

        Sound backgroundMusic = new Sound("Sounds/MainHub.mp3", true, true);
        _backgroundMusicChannel = backgroundMusic.Play();
        _backgroundMusicChannel.Volume = 1f;

        Console.WriteLine("Main Hub Loaded!");
    }

    private void RemoveInstancesForMain()
    {
        if (_barHub != null)
        {
            _barHub.LateDestroy();
            _barHub = null;
            _backgroundMusicChannel.Stop();
        }

        if (_arkanoid != null)
        {
            _arkanoid.LateDestroy();
            _arkanoid = null;
        }

        if (_roadRacer != null)
        {
            _roadRacer.LateDestroy();
            _roadRacer = null;
        }
    }
}