using System;
using GXPEngine;
using TiledMapParser;

public class Hub : GameObject
{

	// Tileset files
	private string _bgSpriteSheet { get; set; }
	private string _colSpriteSheet { get; set; }
	private string _objSpriteSheet { get; set; }

	// Tileset rows and cols
	private int _bgCols { get; set; }
	private int _bgRows { get; set; }
	
	private int _colCols { get; set; }
	private int _colRows { get; set; }

	private int _objCols { get; set; }
	private int _objRows { get; set; }

	MainGame _game { get; set; }

	BackgroundTile bgTile;
	CollisionTile cTile;
	DoorTile _door;
	ActivityTile _activity;

	public ActivityBox _aArkanoid;
	public ActivityBox _aRoadRacer;
	public ActivityBox _dance;
	public ActivityBox _shopBox;

	Player _player;


	public Hub(string bgSpriteSheet, int bgCols, int bgRows, string colSpriteSheet, int colCols, int colRows, string objSpriteSheet, int objCols, int objRows, MainGame tempGame)
	{
		_bgSpriteSheet = bgSpriteSheet;
		_colSpriteSheet = colSpriteSheet;
		_objSpriteSheet = objSpriteSheet;

		_bgCols = bgCols;
		_bgRows = bgRows;

		_colCols = colCols;
		_colRows = colRows;

		_objCols = objCols;
		_objRows = objRows;

		_game = tempGame;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnBackgroundTiles()
	//------------------------------------------------------------------------------------------------------------------------
	public void SpawnBackgroundTiles(Map levelData, bool mainHub)
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
					bgTile = new BackgroundTile(_bgSpriteSheet, _bgCols, _bgRows);
					if (mainHub)
					{
						bgTile.SetFrame(tileNumber - 4);
					} else
					{
						bgTile.SetFrame(tileNumber - 2);
					}
					bgTile.x = col * bgTile.width + bgTile.width / 2;
					bgTile.y = row * bgTile.height + bgTile.height / 2;
					AddChild(bgTile);
				}
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnCollisionTiles()
	//------------------------------------------------------------------------------------------------------------------------
	public void SpawnCollisionTiles(Map levelData)
	{
		// Check if there are layers
		if (levelData.Layers == null || levelData.Layers.Length == 0)
			return;

		// Setting the mainlayer to the first layer
		Layer mainLayer = levelData.Layers[1];

		short[,] tileNumbers = mainLayer.GetTileArray();

		for (int row = 0; row < mainLayer.Height; row++)
		{
			for (int col = 0; col < mainLayer.Width; col++)
			{
				int tileNumber = tileNumbers[col, row];
				if (tileNumber > 0)
				{
					cTile = new CollisionTile(_colSpriteSheet, _colCols, _colRows);
					cTile.SetFrame(tileNumber - 1);
					cTile.x = col * cTile.width + cTile.width / 2;
					cTile.y = row * cTile.height + cTile.height / 2;
					AddChild(cTile);
				}
			}
		}
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnBackgroundTiles()
	//------------------------------------------------------------------------------------------------------------------------
	public void SpawnOverlapTiles(Map levelData)
	{
		// Check if there are layers
		if (levelData.Layers == null || levelData.Layers.Length == 0)
			return;

		// Setting the mainlayer to the first layer
		Layer mainLayer = levelData.Layers[2];

		short[,] tileNumbers = mainLayer.GetTileArray();

		for (int row = 0; row < mainLayer.Height; row++)
		{
			for (int col = 0; col < mainLayer.Width; col++)
			{
				int tileNumber = tileNumbers[col, row];
				if (tileNumber > 0)
				{
					bgTile = new BackgroundTile(_bgSpriteSheet, _bgCols, _bgRows);
					bgTile.SetFrame(tileNumber - 4);
					bgTile.x = col * bgTile.width + bgTile.width / 2;
					bgTile.y = row * bgTile.height + bgTile.height / 2;
					AddChild(bgTile);
				}
			}
		}

		_aArkanoid = new ActivityBox("Text/Arkanoid.txt");
		AddChild(_aArkanoid);
		_aArkanoid.visible = false;

		_aRoadRacer = new ActivityBox("Text/RoadRacer.txt");
		AddChild(_aRoadRacer);
		_aRoadRacer.visible = false;

		_dance = new ActivityBox("Text/Dance.txt");
		AddChild(_dance);
		_dance.visible = false;

		_shopBox = new ActivityBox("Text/Shop.txt");
		AddChild(_shopBox);
		_shopBox.visible = false;
	}

	//------------------------------------------------------------------------------------------------------------------------
	//														spawnObjects()
	//------------------------------------------------------------------------------------------------------------------------
	public void SpawnObjects(Map levelData)
	{
		if (levelData.ObjectGroups == null || levelData.ObjectGroups.Length == 0)
			return;

		ObjectGroup objectGroup = levelData.ObjectGroups[0];
		if (objectGroup.Objects == null || objectGroup.Objects.Length == 0)
			return;

		foreach (TiledObject obj in objectGroup.Objects)
		{
			switch (obj.Name)
			{
				case "Door":
					_door = new DoorTile(_objSpriteSheet, _objCols, _objRows, obj);
					_door.SetFrame(obj.GetIntProperty("Type") - 1);
					_door.x = obj.X + _door.width / 2;
					_door.y = obj.Y - _door.height / 2;
					AddChild(_door);
					break;
				case "Player":
					_player = new Player(obj.X, obj.Y, _game, this);
					AddChild(_player);
					break;
				case "Activity":
					_activity = new ActivityTile(_objSpriteSheet, _objCols, _objRows, obj, _game);
					_activity.SetFrame(obj.GetIntProperty("Type") - 1);
					_activity.x = obj.X + _activity.width;
					_activity.y = obj.Y + _activity.height;
					AddChild(_activity);
					break;
			}
		}
	}
}
