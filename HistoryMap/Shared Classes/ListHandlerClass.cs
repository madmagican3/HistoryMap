using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    class ListHandlerClass
    {
        /// <summary>
        /// constructor to get the form we need to interact with
        /// </summary>
        /// <param name="formUser"></param>
        public ListHandlerClass(WorldMapUser formUser)
        {
            this.formUser = formUser;
        }
        /// <summary>
        /// local pointer to our original form
        /// </summary>
        private WorldMapUser formUser;

        /// <summary>
        /// This should maximise the list and populate it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaximisedScreen(object sender, EventArgs e)
        {
            formUser.ListPanel.Enabled = true;
            popList();
            //TODO
        }

        public void MinimisedScreen(object sender, EventArgs e)
        {
            formUser.ListPanel.Enabled = false;
            //TODO
        }
        /// <summary>
        /// This should populate the list contained in the panel
        /// </summary>
        public void popList()
        {
            //TODO
            throw new NotSupportedException();   
        }
    }
}
