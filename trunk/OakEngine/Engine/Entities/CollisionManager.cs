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
                    //preliminary cull check
                    if (p.HitBox().Intersects(o.HitBox()))
                    {
                        //jesus christ this might be O(n^4)...
                        List<Rectangle> ohbs = o.HitBoxes();
                        List<Rectangle> phbs = p.HitBoxes();

                        foreach (Rectangle ohb in ohbs)
                        {
                            foreach (Rectangle phb in phbs)
                            {
                                if (ohb.Intersects(phb))
                                {
                                    p.OnCollision(CollisionType.ObjectHit, o, phb);
                                    o.OnCollision(CollisionType.PlayerHit, p, ohb);
                                }
                            }
                        }
                    }
                }

                foreach (ICollidable e in enemies)
                {
                    if (p.HitBox().Intersects(e.HitBox()))
                    {
                        List<Rectangle> phbs = p.HitBoxes();
                        List<Rectangle> ehbs = e.HitBoxes();

                        foreach (Rectangle phb in phbs)
                        {
                            foreach (Rectangle ehb in ehbs)
                            {
                                if (phb.Intersects(ehb))
                                {
                                    p.OnCollision(CollisionType.EnemyHit, e, phb);
                                    e.OnCollision(CollisionType.PlayerHit, p, ehb);
                                }
                            }
                        }
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
                        List<Rectangle> ohbs = o.HitBoxes();
                        List<Rectangle> ehbs = e.HitBoxes();

                        foreach (Rectangle ohb in ohbs)
                        {
                            foreach (Rectangle ehb in ehbs)
                            {
                                if (ohb.Intersects(ehb))
                                {
                                    o.OnCollision(CollisionType.EnemyHit, e, ohb);
                                    e.OnCollision(CollisionType.ObjectHit, o, ehb);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
