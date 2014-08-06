using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se.skoggy.entity.Core
{
    public class EntitySystem
    {
        protected internal Entity Entity;

        public T GetComponent<T>() where T : EntityComponent
        {
            return Entity.GetComponent<T>();
        }

        public virtual void Initialize() 
        {
        }

        public virtual void Update(float dt)
        {
        }
    }
}
