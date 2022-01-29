using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentOffice.WinUI.Helper
{

    public static class ImageHelper
    {
        public static Image ByteArrayToImage(byte[] bmpBytes)
        {
            Image image = null;
            using (MemoryStream stream = new MemoryStream(bmpBytes))
            {
                image = Image.FromStream(stream);
            }

            return image;
        }

    }
}
