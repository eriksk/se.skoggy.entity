using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se.skoggy.entity.Core
{
    public class EntityEngine
    {
        protected List<Entity> entities;
        protected List<Entity> removalQueue;
        protected int indices;

        public EntityEngine()
        {
            entities = new List<Entity>();
            removalQueue = new List<Entity>();
        }

        public int EntityCount { get { return entities.Count; } }

        public virtual Entity CreateEntity() 
        {
            Entity e = new Entity();
            e.Engine = this;
            e.Id = indices++;
            entities.Add(e);
            return e;
        }
        
        /// <summary>
        /// Flags an entity for removal next update tick
        /// </summary>
        /// <param name="entity"></param>
        public virtual void RemoveEntity(Entity entity) 
        {
            removalQueue.Add(entity);
        }

        /// <summary>
        /// Starts the engine, initializing all entities
        /// </summary>
        public void Start() 
        {
            foreach (var entity in entities)
            {
                entity.Initialize();
            }
        }

        public Entity GetById(int id) 
        {
            foreach (var entity in entities)
            {
                if (entity.Id == id)
                    return entity;
            }
            return null;
        }

        public virtual void Update(float dt)
        {
            foreach (Entity e in entities)
            {
                e.Update(dt);
            }
            // clear queued for removal
            if (removalQueue.Count > 0)
            {
                foreach (Entity e in removalQueue)
                {
                    entities.Remove(e);
                }
                removalQueue.Clear();
            }
        }
    }
}
