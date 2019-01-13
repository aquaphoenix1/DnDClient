using System;
using System.Windows.Forms;

namespace DnDClient.Graphics
{
    class FieldSquare : Panel
    {
        public int I { get; set; }
        public int J { get; set; }

        private ContextMenu contextMenu;

        public FieldSquare(int i, int j)
        {
            I = i;
            J = j;

            contextMenu = new ContextMenu();
            ContextMenu = contextMenu;


            if (GraphicsController.IsMaster)
            {
            }
            else
            {
                contextMenu.MenuItems.Add(new MenuItem("Переместить персонажа", MoveCharacter));
            }
        }

        private void MoveCharacter(object sender, EventArgs e)
        {
        }
    }
}