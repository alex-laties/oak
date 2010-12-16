using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    public static class CollisionManager
    {
        static List<ICollidable> objects;
        static List<ICollidable> enemies;
        static List<ICollidable> players;

        static CollisionManager()
        {
            objects = new List<ICollidable>();
            enemies = new List<ICollidable>();
            players = new List<ICollidable>();
        }

        public static void AddObject(ICollidable toAdd)
        {
            objects.Add(toAdd);
        }

        public static void AddEnemy(ICollidable toAdd)
        {
            enemies.Add(toAdd);
        }

        public static void AddPlayer(ICollidable toAdd)
        {
            players.Add(toAdd);
        }

        //TODO make this all much more efficient
        public static void Update(GameTime time)
        {
            //check for player collisions first
            foreach (ICollidable p in players)
            {
                foreach (ICollidable o in objects)
                {
                    if (p.HitBox().Intersects(o.HitBox()))
                    {
                        p.OnCollision(CollisionType.ObjectHit, o);
                        o.OnCollision(CollisionType.PlayerHit, p);
                    }
                }

                foreach (ICollidable e in enemies)
                {
                    if (p.HitBox().Intersects(p.HitBox()))
                    {
                        p.OnCollision(CollisionType.EnemyHit, e);
                        e.OnCollision(CollisionType.PlayerHit, p);
                    }
                }
            }

            //object and enemy collision checks
            foreach (ICollidable o in objects)
            {
                foreach (ICollidable e in enemies)
                {
                    if (o.HitBox().Intersects(e.HitBox()))
                    {
                        o.OnCollision(CollisionType.EnemyHit, e);
                        e.OnCollision(CollisionType.ObjectHit, o);
                    }
                }
            }
        }
    }
}
