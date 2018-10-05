using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderCardGame.Gui
{
    public class GuiCard
    {
        public List<int> position;
        public PictureBox picture;

        public GuiCard(List<int> position, PictureBox picture)
        {
            this.position = position;
            this.picture = picture;
        }
    }
}
