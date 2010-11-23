using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    class Event
    {
        public enum EventCollisionType
        {
            PlayerHit,
            EnemyHit,
            ObjectHit
        }

        Rectangle hitbox;
        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
            set
            {
                hitbox = value;
            }
        }

        public delegate void OnCollisionDelegate(GameTime time);

        public OnCollisionDelegate PlayerHit
        {
            get;
            set;
        }

        public OnCollisionDelegate EnemyHit
        {
            get;
            set;
        }

        public OnCollisionDelegate ObjectHit
        {
            get;
            set;
        }

        public virtual void OnCollision(EventCollisionType type)
        {
            switch (type)
            {
                case EventCollisionType.PlayerHit:
                    break;
                case EventCollisionType.ObjectHit:
                    break;
                case EventCollisionType.EnemyHit:
                    break;
            }
        }
    }
}
