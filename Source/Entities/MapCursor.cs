using System;
using System.Drawing;
using BulwarkOfTerra.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace BulwarkOfTerra.Entities;

public class MapCursor : AbstractEntity
{
    private Map _map;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;

    private bool _valid = true;

    public override void Initialize()
    {
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        _texture = Engine.ContentManager.Load<Texture2D>("textures/ui/map-ui");
    }

    public MapCursor(Map map)
    {
        _map = map;

        _map.OnTileClicked += ClickHandler;
    }

    private void ClickHandler(Point point, TileInfo tileInfo)
    {
        Position = _map.Position + point.ToVector2() * _map.TileSetInfo.TileWidth * Map.Scale;
        _valid = tileInfo.Type.Contains("grass");
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(
            _texture,
            new Rectangle(
                Position.ToPoint(),
                new Point(16 * Map.Scale, 16 * Map.Scale)
            ),
            new Rectangle(
                new Point(_valid ? 0 : 16, 0),
                new Point(16, 16)
            ),
            Color.White
        );
        _spriteBatch.End();
    }
}