using System;
using System.Drawing;
using System.Windows.Forms;

namespace DnDClient.Graphics
{
    class BattleField
    {
        private static int Rows = 15;
        private static int Columns = 10;
        public static void CreateBattleField(Panel panelBattlefield, int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            int stepX = panelBattlefield.Size.Width / columns;
            int stepY = panelBattlefield.Size.Height / rows;

            var pb = new PictureBox
            {
                Dock = DockStyle.Fill
            };
            panelBattlefield.Controls.Add(pb);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Draw(new Bitmap(panelBattlefield.Width, panelBattlefield.Height)) as Image;
        }

        private static int ConvertCoord(int j, int i, int width)
        {
            return (j + i * width) * 4;
        }


        private static Bitmap Draw(Bitmap bmp)
        {
            var width = bmp.Width / Columns;
            var height = bmp.Height / Rows;

            bmp = new Bitmap(bmp, width * Columns + 1, height * Rows + 1);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);



            for (int i = 0; i < bmp.Height; i += height)
            {
                for (int j = 0; j < width * Columns; j++)
                {
                    var s = ConvertCoord(j, i, bmp.Width);
                    rgbValues[s] = 0;
                    rgbValues[s + 1] = 0;
                    rgbValues[s + 2] = 255;
                    rgbValues[s + 3] = 255;
                }
            }

            for (int i = 0; i < height * Rows; i++)
            {
                for (int j = 0; j < bmp.Width; j += width)
                {
                    var s = ConvertCoord(j, i, bmp.Width);
                    rgbValues[s] = 0;
                    rgbValues[s + 1] = 0;
                    rgbValues[s + 2] = 255;
                    rgbValues[s + 3] = 255;
                }
            }


            //// Set every third value to 255. A 24bpp bitmap will look red.  
            //for (int counter = 2; counter < rgbValues.Length; counter += 3)
            //    rgbValues[counter] = 255;



            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            //// Draw the modified image.
            //e.Graphics.DrawImage(bmp, 0, 150);
            return bmp;
        }
    }
}