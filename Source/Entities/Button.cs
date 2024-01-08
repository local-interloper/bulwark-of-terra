using System;
using BulwarkOfTerra;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulwarkOfTerra.Entities;

public class Button : AbstractEntity
{
    private SpriteBatch _spriteBatch;
    public string Text;
    private Texture2D _texture;

    public delegate void ClickHandler();

    private ClickHandler _clickHandler;

    public Button(Vector2 position, string text, ClickHandler clickHandler) : base(position)
    {
        _spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        Text = text;
        _clickHandler = clickHandler;
    }

    public override void Initialize()
    {
        _texture = Engine.ContentManager.Load<Texture2D>("textures/ui/button");

        InputSystem.OnClick += position =>
        {
            if (
                new Rectangle(
                    Position.ToPoint(),
                    new Point(_texture.Width, _texture.Height)
                ).Contains(position)
            )
            {
                _clickHandler();
            }
        };
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();

        _spriteBatch.Draw(_texture, Position, Color.White);

        _spriteBatch.DrawString(
            Engine.DefaultFont,
            Text,
            Position + new Vector2(_texture.Width / 2f, _texture.Height / 2f) -
            Engine.DefaultFont.MeasureString(Text) / 2,
            Color.White
        );

        _spriteBatch.End();
    }
}