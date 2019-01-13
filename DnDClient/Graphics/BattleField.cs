using System;
using System.Drawing;
using System.Windows.Forms;

namespace DnDClient.Graphics
{
    class BattleField
    {
        private static int rows = 15;
        private static int columns = 10;
        public static void CreateBattleField(Panel panelBattlefield)
        {
            int stepX = panelBattlefield.Size.Width / columns;
            int stepY = panelBattlefield.Size.Height / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Panel p = new FieldSquare(i, j)
                    {
                        Width = stepX,
                        Height = stepY,
                        Location = new Point(stepX * j, stepY * i),
                        BackColor = Color.FromArgb(255, 255, 255, 255),
                        BorderStyle = BorderStyle.FixedSingle,
                        Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom)
                    };

                    panelBattlefield.Controls.Add(p);
                }
            }
        }
    }
}