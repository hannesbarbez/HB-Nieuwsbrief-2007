using System.Drawing;
using System.Windows.Forms;
using stdole;

namespace HB_Nieuwsbrief.Logic
{
    public class PictureHost : AxHost
    {
        public PictureHost() : base("59EE46BA-677D-4d20-BF10-8D8067CB8B33") { }

        internal new static IPictureDisp GetIPictureDispFromPicture(Image image)
        {
            return (IPictureDisp)AxHost.GetIPictureDispFromPicture(image);
        }
    }
}