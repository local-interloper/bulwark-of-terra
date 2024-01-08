using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulwarkOfTerra.Types;

public class Map
{
    public MapInfo MapInfo;
    public TileMapInfo TileMapInfo;
    public TileSetInfo TileSetInfo;
    public Texture2D Atlas;
    public Vector2 Position;

    public delegate void OnTileClickedDelegate(Point position, TileInfo tileInfo);

    public event OnTileClickedDelegate OnTileClicked;

    public const int Scale = 4;

    public Map(string mapName, Vector2 position = new())
    {
        if (!Directory.Exists($"Streaming/maps/{mapName}"))
        {
            throw new Exception("Map does not exist");
        }

        Position = position;

        MapInfo = MapUtils.GetMapInfo(mapName);
        TileMapInfo = MapUtils.GetTileMapInfo(mapName);
        TileSetInfo = MapUtils.GetTileSetInfo(mapName);

        Atlas = Texture2D.FromFile(Engine.GraphicsDevice, $"Streaming/maps/{mapName}/atlas.png");

        InputSystem.OnClick += ClickHandler;
    }

    private void ClickHandler(Point point)
    {
        if (!new Rectangle(Position.ToPoint(),
                Position.ToPoint() + new Point(
                    TileMapInfo.Width * TileMapInfo.TileWidth * Scale,
                    TileMapInfo.Height * TileMapInfo.TileHeight * Scale
                )
            ).Contains(point))
        {
            return;
        }

        var tileCoords = point - Position.ToPoint();
        tileCoords.X /= TileSetInfo.TileWidth * Scale;
        tileCoords.Y /= TileSetInfo.TileHeight * Scale;

        var tileInfo = GetTileInfo(tileCoords);
        OnTileClicked?.Invoke(tileCoords, tileInfo);
    }

    public void DrawAtlas(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(Atlas, position, Color.White);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var tiles = TileMapInfo.Layers[0].Data;

        for (var i = 0; i < tiles.Count; i++)
        {
            var tileId = tiles[i] - 1;

            var destRect = new Rectangle
            {
                X = (int)Position.X + i % TileMapInfo.Width * TileMapInfo.TileWidth * Scale,
                Y = (int)Position.Y + i / TileMapInfo.Width * TileMapInfo.TileHeight * Scale,
                Width = TileMapInfo.TileWidth * Scale,
                Height = TileMapInfo.TileHeight * Scale
            };

            var sourceRect = new Rectangle
            {
                X = tileId * TileSetInfo.TileWidth % TileSetInfo.ImageWidth,
                Y = tileId / TileSetInfo.Columns * TileMapInfo.TileHeight,
                Width = TileSetInfo.TileWidth,
                Height = TileSetInfo.TileHeight
            };

            spriteBatch.Draw(Atlas, destRect, sourceRect, Color.White);
        }
    }

    public TileInfo GetTileInfo(Point pos)
    {
        var index = pos.X + pos.Y * TileMapInfo.Width;
        var tileId = TileMapInfo.Layers[0].Data[index] - 1;
        return TileSetInfo.Tiles.Find(tile => tile.Id == tileId);
    }
}