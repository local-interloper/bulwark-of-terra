using System;
using Microsoft.Xna.Framework;

namespace BulwarkOfTerra;

public abstract class AbstractEntity
{
    public Guid Guid = System.Guid.NewGuid();
    public Vector2 Position;

    public AbstractEntity()
    {
        Position = Vector2.Zero;
    }

    public AbstractEntity(Vector2 position)
    {
        Position = position;
    }

    public virtual void Initialize()
    {
    }

    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Draw(GameTime gameTime)
    {
    }
}