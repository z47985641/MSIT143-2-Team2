using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Utility
{
    public class ImageToBinary
    {
        public Image ConvertToImage(byte[] picBinary)
        {

            Image image = null;

            if (picBinary == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream(picBinary))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public byte[] ConvertToByte(Image image)
        {
            if (image == null) { return null; }
            try
            {
                using (Bitmap bitmap = new Bitmap(image))
                {
                    using (var ms = new MemoryStream())
                    {
                        bitmap.Save(ms, image.RawFormat);
                        return ms.GetBuffer();
                    }
                }
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }
        }


    }
}
