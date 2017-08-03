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
        List<ButtonStorage> _allButtons = new List<ButtonStorage>();
        List<Button> _buttonControlList = new List<Button>();
        public void CreateButtons(Form localForm, DrawClass localClass)
        {
            foreach (var tempButton in _buttonControlList)
            {
                tempButton.Dispose();
            }
            _buttonControlList.Clear();
            foreach (var localButtonStorage in _allButtons)
            {
                Tuple<int, int> sizeTuple = ButtonCreationSizeTuple(localForm, localClass);
                if (PlaceButton(localForm,localClass))
                {
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
                    tempButton.Width = sizeTuple.Item1;
                    tempButton.Height = sizeTuple.Item2;
                    tempButton.AutoSizeMode 
                    tempButton.Top = ;
                    tempButton.Left = ;
                }
            }
            foreach (var tempButton in _buttonControlList)
            {
                localForm.Controls.Add(tempButton);
            }
        }
        //TODO
        private Tuple<int, int> ButtonCreationSizeTuple(Form localForm, DrawClass localDrawClass)
        {
            return new Tuple<int, int>(30,30);
        }
        //TODO
        private Boolean PlaceButton(Form localForm, DrawClass localDrawClass)
        {
            return false;
        }
        //TODO
        private Point ButtonLocation(Form localForm, DrawClass localDrawClass, ButtonStorage localStorage)
        {
            return new Point();
        } 
    }
}
