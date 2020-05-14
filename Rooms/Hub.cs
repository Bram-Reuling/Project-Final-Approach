using System;
using GXPEngine;
using TiledMapParser;

public class Hub : GameObject
{

	// Tileset files
	private string BgSpriteSheet { get; set; }
	private string ColSpriteSheet { get; set; }
	private string ObjSpriteSheet { get; set; }

	// Tileset rows and cols
	private int BgCols { get; set; }
	private int BgRows { get; set; }
	
	private int ColCols { get; set; }
	private int ColRows { get; set; }

	private int ObjCols { get; set; }
	private int ObjRows { get; set; }

	MainGame Game { get; set; }

	BackgroundTile bgTile;
	CollisionTile cTile;
	DoorTile _door;
	ActivityTile _activity;

	public ActivityBox _aArkanoid;
	public ActivityBox _aRoadRacer;
	public ActivityBox _dance;
	public ActivityBox _shopBox;
	public ActivityBox _barBox;
	public ActivityBox _noTickets;

	Player _player;


	public Hub(string bgSpriteSheet, int bgCols, int bgRows, string colSpriteSheet, int colCols, int colRows, string objSpriteSheet, int objCols, int objRows, MainGame tempGame)
	{
		BgSpriteSheet = bgSpriteSheet;
		ColSpriteSheet = colSpriteSheet;
		ObjSpriteSheet = objSpriteSheet;

		BgCols = bgCols;
		BgRows = bgRows;

		ColCols = colCols;
		ColRows = colRows;

		ObjCols = objCols;
		ObjRows = objRows;

		Game = tempGame;
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
					bgTile = new BackgroundTile(BgSpriteSheet, BgCols, BgRows);
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
					cTile = new CollisionTile(ColSpriteSheet, ColCols, ColRows);
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
					bgTile = new BackgroundTile(BgSpriteSheet, BgCols, BgRows);
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

		_barBox = new ActivityBox("Text/Bar.txt");
		AddChild(_barBox);
		_barBox.visible = false;

		_noTickets = new ActivityBox("Text/NoTickets.txt");
		AddChild(_noTickets);
		_noTickets.visible = false;
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
					_door = new DoorTile(ObjSpriteSheet, ObjCols, ObjRows, obj);
					_door.SetFrame(obj.GetIntProperty("Type") - 1);
					_door.x = obj.X + _door.width / 2;
					_door.y = obj.Y - _door.height / 2;
					AddChild(_door);
					break;
				case "Player":
					_player = new Player(obj.X, obj.Y, Game, this);
					AddChild(_player);
					break;
				case "Activity":
					_activity = new ActivityTile(ObjSpriteSheet, ObjCols, ObjRows, obj);
					_activity.SetFrame(obj.GetIntProperty("Type") - 1);
					_activity.x = obj.X + _activity.width;
					_activity.y = obj.Y + _activity.height;
					AddChild(_activity);
					break;
			}
		}
	}
}
