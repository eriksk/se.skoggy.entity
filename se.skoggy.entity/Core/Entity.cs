using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se.skoggy.entity.Core
{
    public class Entity
    {
        internal EntityEngine Engine;
        protected List<EntityComponent> components;
        protected List<EntitySystem> systems;
        public int Id;

        public Entity()
        {
            components = new List<EntityComponent>();
            systems = new List<EntitySystem>();
        }

        public virtual void AddComponent(EntityComponent component) 
        {
            component.Entity = this;
            components.Add(component);
        }

        public virtual void AddSystem(EntitySystem system)
        {
            system.Entity = this;
            systems.Add(system);
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            foreach (var component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    return (T)component;
                }
            }
            throw new ArgumentException(String.Format("Component of type '{0}' does not exist", typeof(T)));
        }

        public T GetSystem<T>() where T : EntitySystem
        {
            foreach (var system in systems)
            {
                if (system.GetType() == typeof(T))
                {
                    return (T)system;
                }
            }
            throw new ArgumentException(String.Format("System of type '{0}' does not exist", typeof(T)));
        }

        public void Destroy() 
        {
            Engine.RemoveEntity(this);
        }

        public virtual void Initialize() 
        {
            foreach (var system in systems)
            {
                system.Initialize();
            }
        }

        public virtual void Update(float dt) 
        {
            foreach (EntitySystem system in systems)
            {
                system.Update(dt);
            }
        }
    }
}
