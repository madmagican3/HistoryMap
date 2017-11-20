using System;
using System.Collections.Generic;
using System.Drawing;
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
            //Sets the panel and all subsidiaries to be transparent
            formUser.ListPanel.Enabled = true;
            formUser.ListPanel.Visible = true;
            formUser.ListPanel.Parent = formUser.WorldMap;
            formUser.ListPanel.BackColor = Color.Transparent;
            formUser.MaximiseButton.Visible = false;
            //popList();
            //TODO
        }

        public void MinimisedScreen(object sender, EventArgs e)
        {
            formUser.ListPanel.Enabled = false;
            formUser.ListPanel.Visible = false;
            formUser.MaximiseButton.Visible = true;
            //TODO
        }
        /// <summary>
        /// This handles either pressing the button or the key press, gotta do a check on 
        /// both when this is implemented
        /// </summary>
        public void Search(object sender, EventArgs e)
        {
            //TODO
        }
        /// <summary>
        /// This should display the item, focus the world map on that item and then
        /// create the popup
        /// </summary>
        public void ChoseItem(object sender, EventArgs e)
        {
            //TODO
        }

        /// <summary>
        /// This should populate the list contained in the panel
        /// </summary>
        public void PopList()
        {
            //TODO
            List<ButtonCreationClass> interestingStuffList = LocalSqlGetter.GetListFromDateSelection(new DateTime(), new DateTime());

        }
    }
}
