using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    class Action
    {
        #region Variables

        public string Name { get; set; }

        #endregion


        #region Construct

        public Action(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.Name;
        }
        #endregion

        #region Methods



        public virtual void effet()
        {

        }

        #endregion
    }
}
}
