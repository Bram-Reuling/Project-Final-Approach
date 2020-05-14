using System;
using GXPEngine;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

public class MainGame : Game
{

    public bool DisplayTutorial { get; set; }
    public int tickets;
    public int ticketsReceived;
    public bool sufficientTickets;

    private MainHub _mainHub;
    private BarHub _barHub;

    private MainMenuScreenArkanoid _arkanoid;
    private ArkanoidLevelScreen _aLevelOne;
    private ArkanoidDeathScreen _aDeathScreen;
    private ArkanoidWinScreen _aWinScreen;

    private MainMenuRoadRacer _roadRacer;
    private LevelRoadRacer _rLevel;
    private DeathScreenRoad _rDeathScreen;

    private SoundChannel _backgroundMusicChannel;

    private MainMenu _mainMenu;

    private StreamReader _reader;

    public MainGame() : base(1024, 768, false, true)
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade");

        ReadVariableFile();
        TicketCheck(tickets);
        ticketsReceived = 0;
        // Start of the game
        SwitchRoom("");
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														AddTickets()
    //------------------------------------------------------------------------------------------------------------------------
    public void AddTickets(int numberOfTickets)
    {
        int newTickets = tickets + numberOfTickets;

        TicketCheck(newTickets);

        LineChanger("Tickets = " + newTickets.ToString(), "Text/Settings.txt", 2);

        ReadVariableFile();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														SubtracktTickets()
    //------------------------------------------------------------------------------------------------------------------------
    public void SubtracktTickets(int numberOfTickets)
    {
        int newTickets = tickets - numberOfTickets;

        TicketCheck(newTickets);

        LineChanger("Tickets = " + newTickets.ToString(), "Text/Settings.txt", 2);

        ReadVariableFile();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														TicketCheck()
    //------------------------------------------------------------------------------------------------------------------------
    private void TicketCheck(int tempTickets)
    {
        if (tempTickets > 0)
        {
            sufficientTickets = true;
        }
        else
        {
            sufficientTickets = false;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														LineChanger()
    //------------------------------------------------------------------------------------------------------------------------
    static void LineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														ReadVariableFile()
    //------------------------------------------------------------------------------------------------------------------------
    private void ReadVariableFile()
    {
        _reader = File.OpenText("Text/Settings.txt");
        string line;

        while ((line = _reader.ReadLine()) != null)
        {
            string[] items = line.Split('\n');

            foreach (string item in items)
            {
                if (item.StartsWith("DisplayTutorial = "))
                {
                    string newString = item.Substring(18);
                    Console.WriteLine(newString);
                    DisplayTutorial = Convert.ToBoolean(newString);
                }

                if (item.StartsWith("Tickets = "))
                {
                    string newString = item.Substring(10);
                    Console.WriteLine(newString);

                    tickets = Int32.Parse(newString);
                }
            }
        }

        _reader.Close();
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

    //------------------------------------------------------------------------------------------------------------------------
    //														LoadMenu()
    //------------------------------------------------------------------------------------------------------------------------
    private void LoadMenu()
    {
        GXPEngine.OpenGL.GL.glfwSetWindowTitle("The Homebox Arcade");
        _mainMenu = new MainMenu(this);
        LateAddChild(_mainMenu);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //														BAR MENU
    //------------------------------------------------------------------------------------------------------------------------
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

    //------------------------------------------------------------------------------------------------------------------------
    //														SHOP MENU
    //------------------------------------------------------------------------------------------------------------------------
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

        SubtracktTickets(10);
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

        SubtracktTickets(10);

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