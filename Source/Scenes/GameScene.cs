using System;
using BulwarkOfTerra.Entities;
using BulwarkOfTerra.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulwarkOfTerra.Scenes;

public class GameScene : AbstractScene
{
    private string _mapName;
    private Map _map;
    private Texture2D _texture;
    private SpriteBatch _spriteBatch;

    public GameScene(string mapName)
    {
        _mapName = mapName;
    }

    public override void Initialize()
    {
        _map = new Map(_mapName);
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        AddEntity(new MapCursor(_map));
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _map.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}