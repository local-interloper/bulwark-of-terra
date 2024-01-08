using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BulwarkOfTerra;

public abstract class AbstractScene
{
    protected readonly Dictionary<Guid, AbstractEntity> Entities = new();

    public virtual void Initialize()
    {
    }

    public virtual void Draw(GameTime gameTime)
    {
        foreach (var entity in Entities.Values)
        {
            entity.Draw(gameTime);
        }
    }

    public virtual void Update(GameTime gameTime)
    {
        foreach (var entitiy in Entities.Values)
        {
            entitiy.Update(gameTime);
        }
    }

    public void AddEntity(AbstractEntity entity)
    {
        entity.Initialize();
        Entities.Add(entity.Guid, entity);
    }
}