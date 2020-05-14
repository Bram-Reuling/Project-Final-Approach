using GXPEngine;
using System.Drawing;
using TiledMapParser;

class Score : Canvas
{
    private readonly StringFormat _stringFormatCenter;
    private readonly Font _font;

    private int _playerScore;

    private readonly PlayerArkanoid _player;

    public Score(PlayerArkanoid _playerInst, TiledObject _obj) : base(200, 50)
    {
        SetOrigin(this.width / 2, this.height / 2);
        SetXY(_obj.X, _obj.Y);

        _font = new Font("Arial", 20, FontStyle.Regular);

        _stringFormatCenter = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        _player = _playerInst;
    }

    private void Update()
    {

        _playerScore = _player.score;

        graphics.Clear(Color.Empty);

        graphics.DrawString("SCORE: " + _playerScore, _font, Brushes.White, width / 2, height / 2, _stringFormatCenter);
    }
}

