using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Game.Characters;

namespace Oak.Engine.Entities
{
    

    class CollidableEvent : IEvent, ICollidable
    {
        protected Rectangle bigHitBox;
        protected List<Rectangle> hitBoxes;

        protected bool active;

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

        public CollidableEvent()
        {
            bigHitBox = new Rectangle(0, 0, 10, 10);
            hitBoxes = new List<Rectangle>();
        }

        #region ICollidable Members

        public virtual void OnCollision(CollisionType type, ICollidable with, Rectangle collided)
        {
            switch (type)
            {
                case CollisionType.PlayerHit:
                    Player p = (Player)with;
                    HandleCollision(p);
                    break;
                case CollisionType.ObjectHit:
                    break;
                case CollisionType.EnemyHit:
                    break;
            }
        }

        public virtual Rectangle HitBox()
        {
            return bigHitBox;
        }

        public virtual void HitBox(Rectangle hitbox)
        {
            this.bigHitBox = hitbox;
        }

        public virtual List<Rectangle> HitBoxes()
        {
            return hitBoxes;
        }

        public virtual void HitBoxes(List<Rectangle> boxes)
        {
            hitBoxes = boxes;
        }

        public virtual void AddHitBox(Rectangle box)
        {
            hitBoxes.Add(box);
        }

        public virtual void RemoveHitBox(Rectangle box)
        {
            hitBoxes.Remove(box);
        }

        #endregion

        #region IEvent Members

        /// <summary>
        /// Checks whether this event is currently active.
        /// </summary>
        /// <returns>Whether the event is active or not</returns>
        public virtual bool Active()
        {
            return active;
        }

        /// <summary>
        /// Activates the event. The event will remain active until either it is finished or Deactivate is called.
        /// </summary>
        public virtual void Activate()
        {
            active = true;
        }

        public virtual void Deactivate()
        {
            active = false;
        }

        public virtual void Update(GameTime time)
        {
            if (active)
            {
                //do something
            }
            else
            {
                //do something else
            }
        }

        #endregion


        protected virtual void HandleCollision(Player p)
        {
            
        }
    }
}
