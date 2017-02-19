using System;
using System.Drawing;
using System.Windows.Forms;
using HB_Nieuwsbrief.Logic;

namespace HB_Nieuwsbrief
{
    public partial class FrmConfiguration : Form
    {
        #region Constants
        private const string FILTER_SUPPORTED_FILE_TYPES = "Afbeelding (JPG, JPEG, GIF, BMP, PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
        private const string ERROR_ALL_FIELDS_REQUIRED = "Kan niet opslaan tot alle velden correct zijn ingevuld.";
        private const string EMPTY = "";

        private const float DEFAULT_FONT_HEIGHT = 8;
        #endregion
        #region Fields
        private ErrorDelegation errorDelegation;
        private bool fontWasSet = false;
        private bool mayNotBeClosed = true;
        private Configuration configuration;
        #endregion
        #region Methods

        private void FillFormFields()
        {
            tbDatabase.Text = configuration.Database;
            tbBackground.Text = configuration.Background;
            tbLogo.Text = configuration.Logo;
            tbPassword.Text = configuration.Password;
            tbRow.Text = configuration.Row;
            tbServer.Text = configuration.Server;
            tbTable.Text = configuration.Table;
            tbUser.Text = configuration.User;
        }

        private void ErrorHandling()
        {
            //Make sure errors get displayed
            errorDelegation = new ErrorDelegation(ShowError);
        }

        private void ShowError(string s)
        {
            lblError.Text = s;
        }
        #endregion
        #region Events
        private void FrmConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mayNotBeClosed) e.Cancel = true;
        }
        private void btnBrowseBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = FILTER_SUPPORTED_FILE_TYPES;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                configuration.Background = ofd.FileName;
                tbBackground.Text = ofd.FileName;
            }
        }
        private void btnBrowseLogo_Click(object sender, EventArgs e)
{
    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Multiselect = false;
    ofd.Filter = FILTER_SUPPORTED_FILE_TYPES;

    if (ofd.ShowDialog() == DialogResult.OK)
    {
        configuration.Logo = ofd.FileName;
        tbLogo.Text = ofd.FileName;
    }
}
        private void btnCancel_Click(object sender, EventArgs e)
        {
            mayNotBeClosed = false;
        }
        private void btnFont_Click(object sender, EventArgs e)
{
    FontDialog fd = new FontDialog();

    fd.ShowColor = true;
    fd.FontMustExist = true; 

    if (configuration.Color != null)
    {
        fd.Color = (Color)new ColorConverter().ConvertFromString(configuration.Color);
    }

    if (configuration.Font != null)
    {
        fd.Font = (Font)new FontConverter().ConvertFromString(configuration.Font);
    }
    
    if (fd.ShowDialog() == DialogResult.OK)
    {
        configuration.Font = new FontConverter().ConvertToString(fd.Font);
        configuration.Color = new ColorConverter().ConvertToString(fd.Color);
    }
}
        private void btnOK_Click(object sender, EventArgs e)
        {
            //NOTE: Font already set when respective buttons were clicked
            if (tbBackground.Text != EMPTY && tbDatabase.Text != EMPTY && tbLogo.Text != EMPTY && tbPassword.Text != EMPTY &&
                tbRow.Text != EMPTY && tbServer.Text != EMPTY && tbTable.Text != EMPTY && tbUser.Text != EMPTY)
            {
                if (!fontWasSet && configuration.Font == null) configuration.Font = new FontConverter().ConvertToString(new Font(FontFamily.GenericSansSerif, DEFAULT_FONT_HEIGHT));
                configuration.Background = tbBackground.Text;
                configuration.Database = tbDatabase.Text;
                configuration.Logo = tbLogo.Text;
                configuration.Password = tbPassword.Text;
                configuration.Row = tbRow.Text;
                configuration.Server = tbServer.Text;
                configuration.Table = tbTable.Text;
                configuration.User = tbUser.Text;

                configuration.EraseOld();
                configuration.Save();
                
                //prevent from saving incomplete information
                mayNotBeClosed = false;
            }
            else
            {
                errorDelegation(ERROR_ALL_FIELDS_REQUIRED);
            }
        }
        #endregion
        #region Constructors
        public FrmConfiguration(Configuration configuration)
        {
            this.configuration = configuration;
            InitializeComponent();
            ErrorHandling();
            FillFormFields();
        }
        #endregion
    }
}