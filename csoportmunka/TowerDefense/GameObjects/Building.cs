using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.GameObjects
{
    public abstract class Building: GameObject
    {
        protected bool _destroyable;

        public bool Destroyable
        {
            get => _destroyable;
            set => _destroyable = value;
        }
    }
}
