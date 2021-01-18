using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Dungeon
{
    
    class Combat
    {
        #region Variables
        public int turn { get; private set; }

        #endregion


        #region Methods
        
        public void Turn()
        {

            this.turn = this.turn + 1;
        }

       

        #endregion
    }
}
