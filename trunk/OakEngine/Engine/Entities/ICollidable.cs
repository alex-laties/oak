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

    public interface ICollidable
    {
        void OnCollision(CollisionType type, ICollidable with, Rectangle collided);
        /// <summary>
        /// Gets the overall hitbox (for preliminary hit detection)
        /// </summary>
        /// <returns></returns>
        Rectangle HitBox();

        /// <summary>
        /// Sets the overall hitbox (for preliminary hit detection)
        /// </summary>
        /// <param name="hitbox"></param>
        void HitBox(Rectangle hitbox);

        /// <summary>
        /// Gets all specific hitboxes (for advanced hit detection)
        /// </summary>
        /// <returns></returns>
        List<Rectangle> HitBoxes();
        
        /// <summary>
        /// Sets all specific hitboxes
        /// </summary>
        void HitBoxes(List<Rectangle> boxes);

        /// <summary>
        /// Addes a specific hitbox to the list of hitboxes
        /// </summary>
        /// <param name="box"></param>
        void AddHitBox(Rectangle box);

        /// <summary>
        /// Removes a specific hitbox from the list of hitboxes
        /// </summary>
        /// <param name="box"></param>
        void RemoveHitBox(Rectangle box);
    }
}
