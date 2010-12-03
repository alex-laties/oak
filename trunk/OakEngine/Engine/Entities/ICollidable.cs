using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    public enum CollisionType
    {
        PlayerHit,
        EnemyHit,
        ObjectHit
    }

    public delegate void OnCollisionDelegate(GameTime time, ICollidable with);

    interface ICollidable
    {
        void OnCollision(CollisionType type, ICollidable with);
        Rectangle HitBox();
        void HitBox(Rectangle hitbox);
    }
}
