using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI.Helper
{
    public static class ValidationHelper
    {
        public static bool ValidirajKontrolu(this ErrorProvider err, object kontrolaGen, CancelEventArgs e, string poruka)
        {
            if (!(kontrolaGen is Control kontrola))
                return false;

            bool valid = true;
            if (kontrola is TextBox && string.IsNullOrWhiteSpace(kontrola.Text))
                valid = false;
            else if (kontrola is ComboBox && (kontrola as ComboBox).SelectedIndex < 0)
                valid = false;
            else if (kontrola is PictureBox && (kontrola as PictureBox).Image == null)
                valid = false;

            if (valid == false)
            {
                err.SetError(kontrola, poruka);
                e.Cancel = true;
                return false;
            }
            err.SetError(kontrola, null);
            return true;
        }
    }
}
