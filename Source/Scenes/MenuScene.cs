using System;
using BulwarkOfTerra.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulwarkOfTerra.Scenes;

public class MenuScene : AbstractScene
{
    private SpriteBatch _spriteBatch;

    public override void Initialize()
    {
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        AddEntity(
            new Button(
                new Vector2(100, 100),
                "Play",
                () => Engine.SetScene(new GameScene("map-1"))
            )
        );

        AddEntity(
            new Button(
                new Vector2(100, 150),
                "Quit",
                () => Console.WriteLine("Quit")
            )
        );
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }
}