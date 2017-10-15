using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HistoryMap.WorldMapUsers;

namespace HistoryMap.Shared_Classes
{
    class ButtonCreationClass
    {
        //so as a note, i hate all of this. This seems like a terrible way to generate the interactables and thus 
        //i'm going to completely redo it.
        //Note for self
        //Generate a list to the left of the screen of all the items, small arrow to maxmise or minimise it
        //think google maps
        //THen use labels rather than buttons and generate those only at max zoom level and min zoom level based 
        //on an int stored which lists priority
        //This should allow us to size them correctly and make it simple to do
        //Store as an int for easier modification later














        //TODO optomize? this seems horribly inefficent to have this much stored in mem
        /// <summary>
        /// This contains a list of all the buttons in the system
        /// </summary>
        List<ButtonStorage> _allButtons = new List<ButtonStorage>();
        /// <summary>
        /// This contains a list of all the buttons currently displayed 
        /// </summary>
        List<Button> _buttonControlList = new List<Button>();

        /// <summary>
        /// this creates and displays all the buttons that should be shown on the ui at this point in time
        /// </summary>
        public void CreateButtons(Form localForm, DrawClass localClass)
        {
            //get rid of all the old buttons
            foreach (var tempButton in _buttonControlList)
            {
                tempButton.Dispose();
            }
            //empty the list
            _buttonControlList.Clear();
            
            //go through all the buttons and modify their size to suit the zoom level 
            //TODO work out if they should be resized or if they should retain size in general through zoom levels?
            foreach (var localButtonStorage in _allButtons)
            {
                //get the size we should create them from 
                Tuple<int, int> sizeTuple = ButtonCreationSizeTuple(localForm, localClass);
                //if the button is in the right timeframe continue
                if (PlaceButton(localForm,localClass))
                {
                    //create a new button and assign the correct image to it
                    Button tempButton = new Button();
                    switch (localButtonStorage.Type)
                    {
                        case "Army":
                            break;
                        case "Battle":
                            break;
                        case "City":
                            break;
                        case "Fortified City":
                            break;
                        case "Country":
                            break;
                        case "Interesting events":
                            break;    
                    }
                    //assign it the correct size and set it to appear in the correct area
                    tempButton.Width = sizeTuple.Item1;
                    tempButton.Height = sizeTuple.Item2;
                    tempButton.Top = ;
                    tempButton.Left = ;
                }
            }
            //add it to the control list for later removal
            foreach (var tempButton in _buttonControlList)
            {
                localForm.Controls.Add(tempButton);
            }
        }
        //TODO
        /// <summary>
        /// Returns the correct pixel size for the button based on current zoom level
        /// </summary>
        private Tuple<int, int> ButtonCreationSizeTuple(Form localForm, DrawClass localDrawClass)
        {
            return new Tuple<int, int>(30,30);
        }
        //TODO
        /// <summary>
        /// places the instance of the button into the correct location
        /// </summary>
        private Boolean PlaceButton(Form localForm, DrawClass localDrawClass)
        {
            return false;
        }
        //TODO
        //left + size left
        /// <summary>
        /// this should calculate its location based on current zoom level
        /// </summary>
        private Point ButtonLocation(Form localForm, DrawClass localDrawClass, ButtonStorage localStorage)
        {
            return new Point();
        } 
    }
}
