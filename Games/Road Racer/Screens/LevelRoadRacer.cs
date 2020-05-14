using System;
using System.CodeDom;
using GXPEngine;
using TiledMapParser;

class LevelRoadRacer : GameObject
{
    RoadTile _rTile;
	Overlay _overlay;

	PlayerRoadRacer _player;

	Obstacles _obst;

	private SoundChannel _backgroundMusicChannel;

	MainGame _game;

	private string _fileName { get; set; }

	public LevelRoadRacer(MainGame tempGame)
	{
		_fileName = @"RoadRacerLevel/RoadRacer.tmx";
		Map _levelData = MapParser.ReadMap(_fileName);
		spawnRoad(_levelData);

		_obst = new Obstacles(tempGame);
		_obst.SetXY(game.width / 2, 0);
		AddChild(_obst);

		_overlay = new Overlay();
		AddChild(_overlay);
		_player = new PlayerRoadRacer(this);
		AddChild(_player);

		_game = tempGame;

		Sound backgroundMusic = new Sound("Sounds/RoadRacerSong.mp3", true, true);
		_backgroundMusicChannel = backgroundMusic.Play();
		_backgroundMusicChannel.Volume = 1f;
	}

	void Update()
	{
	}

	private void spawnRoad(Map levelData)
	{
		// Check if there are layers
		if (levelData.Layers == null || levelData.Layers.Length == 0)
			return;

		// Setting the mainlayer to the first layer
		Layer mainLayer = levelData.Layers[0];

		short[,] tileNumbers = mainLayer.GetTileArray();

		for (int row = 0; row < mainLayer.Height; row++)
		{
			for (int col = 0; col < mainLayer.Width; col++)
			{
				int tileNumber = tileNumbers[col, row];
				if (tileNumber > 0)
				{
					_rTile = new RoadTile();
					_rTile.SetFrame(tileNumber - 1);
					_rTile.x = col * _rTile.width + _rTile.width / 2;
					_rTile.y = row * _rTile.height + _rTile.height / 2;
					AddChild(_rTile);
				}
			}
		}
	}

	public void LoadDeathScreen()
	{
		_backgroundMusicChannel.Stop();
		_game.SwitchRoom("RDeath");
	}
}
