using System;
using System.Collections.Generic;
using System.Drawing;
using HistoryMap.WorldMapUsers;

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
            this._formUser = formUser;
        }
        /// <summary>
        /// local pointer to our original form
        /// </summary>
        private WorldMapUser _formUser;

        /// <summary>
        /// This should maximise the list and populate it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaximisedScreen(object sender, EventArgs e)
        {
            //Sets the panel and all subsidiaries to be transparent
            _formUser.ListPanel.Enabled = true;
            _formUser.ListPanel.Visible = true;
            _formUser.ListPanel.Parent = _formUser.WorldMap;
            _formUser.ListPanel.BackColor = Color.Transparent;
            _formUser.MaximiseButton.Visible = false;
        }

        public void MinimisedScreen(object sender, EventArgs e)
        {
            _formUser.ListPanel.Enabled = false;
            _formUser.ListPanel.Visible = false;
            _formUser.MaximiseButton.Visible = true;
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


    }
}
