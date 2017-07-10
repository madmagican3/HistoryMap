using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoryMap.WorldMapUsers
{
    public partial class InformationPanel : Form
    {
        private readonly Dictionary<string,string> _textList;
        public InformationPanel(Dictionary<string,string> text)
        {
            _textList = text;
            InitializeComponent();
            this.Focus();
        }

        private void InformationPanel_Load(object sender, EventArgs e)
        {
            foreach (var text in _textList)
            {
                RichText.SelectionFont = new Font(Font.Name,Font.Size,FontStyle.Bold);
                RichText.AppendText(text.Key + " :" );
                RichText.SelectionFont = new Font(Font.Name, Font.Size, FontStyle.Regular);
                RichText.AppendText(" "+text.Value + System.Environment.NewLine + System.Environment.NewLine);
            }
        }
    }
}
