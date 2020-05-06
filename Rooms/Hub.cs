using System;
using GXPEngine;
using TiledMapParser;

class Hub : GameObject
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
	public void SpawnBackgroundTiles(Map levelData)
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
					BackgroundTile tile = new BackgroundTile(_bgSpriteSheet, _bgCols, _bgRows);
					tile.SetFrame(tileNumber - 1);
					tile.x = col * tile.width + tile.width / 2;
					tile.y = row * tile.height + tile.height / 2;
					AddChild(tile);
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
					CollisionTile tile = new CollisionTile(_colSpriteSheet, _colCols, _colRows);
					tile.SetFrame(tileNumber - 1);
					tile.x = col * tile.width + tile.width / 2;
					tile.y = row * tile.height + tile.height / 2;
					AddChild(tile);
				}
			}
		}
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
				case "Player":
					Player _player = new Player(obj.X, obj.Y, _game);
					AddChild(_player);
					break;
				case "Door":
					DoorTile _door = new DoorTile(_objSpriteSheet, _objCols, _objRows);
					_door.SetFrame(obj.GetIntProperty("Type") - 1);
					_door.x = obj.X + _door.width / 2;
					_door.y = obj.Y - _door.height / 2;
					AddChild(_door);
					break;
			}
		}
	}
}
