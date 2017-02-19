using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using HB_Nieuwsbrief.Logic;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace HB_Nieuwsbrief
{
    public partial class HBN
    {
        #region Fields
        private Office.CommandBarButton btnStelNieuwsbriefOp, btnConfigureerNieuwsbrief;
        //, btnSynchroniseer;
        private Office.CommandBar cbNieuwsbrief;
        private ErrorDelegation errorDelegation;
        private SynchronizationDelegation synchronizationDelegation;
        private Configuration configuration;
        private FrmSynchronize frmSynchronize;

        private string MSG_SERVER_UNAVAILABLE = "Er is een probleem bij het verbinden met de databaseserver. De lijst met contactpersonen kon niet worden opgehaald. " + Environment.NewLine + Environment.NewLine +
                        "Dit kan te wijten zijn aan één van volgende oorzaken:" + Environment.NewLine + Environment.NewLine +
                        "1. De server vermeld in de instellingen is momenteel niet bereikbaar. Controleer uw nieuwsbriefinstellingen." + Environment.NewLine + Environment.NewLine +
                        "2. Er staat foutieve informatie (bv. tabel of rij) vermeld in de instellingen, uw instellingenbestand is corrupt of bestaat (nog) niet. Klik op 'instellingen' om dit na te gaan." + Environment.NewLine + Environment.NewLine +
                        "3. U heeft geen of beperkte internetverbinding. Kunt u surfen?";
        #endregion
        #region Constants
        //private const string TOOLTIP_BUTTON_SYNCHRONIZE = "Controleren op nieuwe of verwijderde inschrijvingen.";
        //private const string TEXT_BUTTON_SYNCHRONIZE = "Synchroniseren";
        //private const string DISTRIBUTION_LIST_TITLE = "HB Nieuwsbrief - Distributielijst";

        private const string TOOLTIP_BUTTON_SEND = "Schrijven en verzenden van een nieuwe nieuwsbrief.";
        private const string TOOLTIP_BUTTON_CONFIG = "Instellingen voor het schrijven en zenden van een nieuwsbrief.";
        private const string TEXT_BUTTON_SEND = "Nieuwe nieuwsbrief...";
        private const string TEXT_BUTTON_CONFIG = "Configuratie";
        private const string COMMANDBAR_TITLE = "HB Nieuwsbrief Toolbar";
        private const string MSGBOX_TITLE = "HB Nieuwsbrief - Fout";
        private const string MAIL_SUBJECT = "";
        private const string ERROR_IMAGES_NOT_FOUND = "Eén van de afbeeldingen (logo, achtergrond) voor de nieuwsbrief is niet gevonden. Controleer uw nieuwsbrief instellingen.";
        #endregion
        #region Start-up and Shut-down
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            FlowToolbar();
            LoadConfiguration();
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #endregion
        #region Loads
        private void LoadRecipientsFromDataSource()
        {
            this.configuration.LoadRecipientsFromDataSource(synchronizationDelegation);
        }
        private void LoadConfiguration()
        {
            //Should an error occur
            this.errorDelegation = new ErrorDelegation(ShowError);
            this.synchronizationDelegation = new SynchronizationDelegation(ShowProgress);
            this.frmSynchronize = new FrmSynchronize();

            //Load the previous configuration
            this.configuration = new Configuration(errorDelegation);
        }
        #endregion
        #region Flows
        private void FlowToolbar()
        {
            InitializeToolbar();
            FlowMakeToolBarHaveButtons();
            InitializeToolBarEventHandlers();
            ShowToolbar();
        }
        private void FlowMakeToolBarHaveButtons()
        {
            InitializeToolBarButtons();
            InitializeButtonStyles();
            InitializeButtonPictures();
            InitializeButtonCaptions();
            InitializeButtonTooltips();
        }
        #endregion
        #region Initializers
        private void InitializeToolBarEventHandlers()
        {
            // Adding the event handler for the button in the toolbar
            // btnSynchroniseer.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(btnSynchroniseer_Click);
            btnStelNieuwsbriefOp.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(btnStelNieuwsbriefOp_Click);
            btnConfigureerNieuwsbrief.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(btnConfigureerNieuwsbrief_Click);
        }
        private void InitializeToolBarButtons()
        {
            // Adding buttons to the custom tool bar
            //btnSynchroniseer = (Office.CommandBarButton)cbNieuwsbrief.Controls.Add(1, missing, missing, missing, missing);
            btnStelNieuwsbriefOp = (Office.CommandBarButton)cbNieuwsbrief.Controls.Add(1, missing, missing, missing, missing);
            btnConfigureerNieuwsbrief = (Office.CommandBarButton)cbNieuwsbrief.Controls.Add(1, missing, missing, missing, missing);
        }
        private void InitializeButtonCaptions()
        {
            // Set button caption
            //btnSynchroniseer.Caption = TEXT_BUTTON_SYNCHRONIZE;
            btnStelNieuwsbriefOp.Caption = TEXT_BUTTON_SEND;
            btnConfigureerNieuwsbrief.Caption = TEXT_BUTTON_CONFIG;
        }
        private void InitializeButtonTooltips()
        {
            // Set button tooltips
            //btnSynchroniseer.TooltipText = TOOLTIP_BUTTON_SYNCHRONIZE;
            btnStelNieuwsbriefOp.TooltipText = TOOLTIP_BUTTON_SEND;
            btnConfigureerNieuwsbrief.TooltipText = TOOLTIP_BUTTON_CONFIG;
        }
        private void InitializeButtonPictures()
        {
            Assembly AssemblyNieuwsbrief = Assembly.GetExecutingAssembly();

            //using (Stream s = AssemblyNieuwsbrief.GetManifestResourceStream("HB_Nieuwsbrief.References.a.bmp"))
            //{
            //    btnSynchroniseer.Picture = PictureHost.GetIPictureDispFromPicture(Image.FromStream(s));
            //}

            using (Stream s = AssemblyNieuwsbrief.GetManifestResourceStream("HB_Nieuwsbrief.References.b.bmp"))
            {
                btnStelNieuwsbriefOp.Picture = PictureHost.GetIPictureDispFromPicture(Image.FromStream(s));
            }

            using (Stream s = AssemblyNieuwsbrief.GetManifestResourceStream("HB_Nieuwsbrief.References.c.bmp"))
            {
                btnConfigureerNieuwsbrief.Picture = PictureHost.GetIPictureDispFromPicture(Image.FromStream(s));
            }
        }
        private void InitializeButtonStyles()
        {
            // Set the button style
            //btnSynchroniseer.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
            btnStelNieuwsbriefOp.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
            btnConfigureerNieuwsbrief.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
        }
        private void InitializeToolbar()
        {
            if (cbNieuwsbrief == null)
            {
                // Adding the commandbar to Active explorer
                Office.CommandBars commandBars = this.Application.ActiveExplorer().CommandBars;

                // Adding Nieuwsbrief Toolbar to the commandBars
                cbNieuwsbrief = commandBars.Add(COMMANDBAR_TITLE, Office.MsoBarPosition.msoBarTop, false, true);
            }
        }
        #endregion
        #region Event Handling
        private void btnConfigureerNieuwsbrief_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            FrmConfiguration configuratievenster = new FrmConfiguration(this.configuration);
            configuratievenster.ShowDialog();
        }
        private void btnStelNieuwsbriefOp_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Synchroniseer();
            SendMassMail();
        }
        //private void btnSynchroniseer_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        //{
        //    Synchroniseer();
        //}
        private void Synchroniseer()
        {
            this.frmSynchronize = new FrmSynchronize();
            frmSynchronize.Show();
            LoadRecipientsFromDataSource();
            //CreateDistributionList(true);
            frmSynchronize.Close();
        }
        #endregion
        #region Shows
        private void ShowToolbar()
        {
            // Show on startup
            cbNieuwsbrief.Visible = true;
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ShowProgress(int max)
        {
            //frmSynchronize.pbSynchronization.Maximum = max;
            frmSynchronize.pbSynchronization.PerformStep();
        }
        #endregion
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
        #region Sending Mass Mail
        private void SendMassMail()
        {
            string fileLogo = Configuration.DeriveFileNameFromPath(configuration.Logo);
            string fileBackground = Configuration.DeriveFileNameFromPath(configuration.Background);

            if (Configuration.DoesPathExist(configuration.Logo) && Configuration.DoesPathExist(configuration.Background))
            {
                //Make Font object in order to derive user-selected properties
                Font font = (Font)new FontConverter().ConvertFromString(configuration.Font);
                Outlook.MailItem mail = (Outlook.MailItem)this.Application.CreateItem(Outlook.OlItemType.olMailItem);

                AddRecipients(mail);
                mail.Subject = MAIL_SUBJECT;

                Outlook.Attachment logo = mail.Attachments.Add(configuration.Logo, Outlook.OlAttachmentType.olEmbeddeditem, 0, "<logo.jpg>");
                Outlook.Attachment background = mail.Attachments.Add(configuration.Background, Outlook.OlAttachmentType.olEmbeddeditem, 0, "<background.jpg>");

                string SchemaPR_ATTACH_CONTENT_ID = @"http://schemas.microsoft.com/mapi/proptag/0x3712001E";

                Outlook.PropertyAccessor logoProperties = mail.Attachments[1].PropertyAccessor;
                Outlook.PropertyAccessor backgroundProperties = mail.Attachments[2].PropertyAccessor;

                logoProperties.SetProperty(SchemaPR_ATTACH_CONTENT_ID, "<logo.jpg>");
                backgroundProperties.SetProperty(SchemaPR_ATTACH_CONTENT_ID, "<background.jpg>");

                mail.HTMLBody = "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.0 Transitional//EN\"><HTML><BODY background='cid:background.jpg' ><IMG alt=\"\" src='cid:logo.jpg' /><FONT color=" +
                    configuration.Color + " size=\"" + font.SizeInPoints + "\" face=\"" + font.OriginalFontName + "\"><P><STRONG>" + MAIL_SUBJECT + "</STRONG></P><P>" + HintOfTheDay.Generate() + "</P></FONT></BODY></HTML>";

                mail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mail.Display(false);
            }
            else ShowError(ERROR_IMAGES_NOT_FOUND);
        }

        /// <summary>
        /// Stacks up recipients in the BCC field. (Used to: Stacks the loaded recipients into a full blown distribution list.)
        /// </summary>
        /// <param name="errorsOn">True if any errors have to be displayed</param>
        private void AddRecipients(Outlook.MailItem mail)
        {
            //foreach (string rec in configuration.Recipients)
            //{
            //    mail.BCC += rec + "; ";
            //}
            if (configuration.Recipients != null && configuration.Recipients.Count > 1)
            {
                //// Using the Outlook object reading through the Distribution item
                //// Preparing to create a new Distribution item
                //Outlook.DistListItem distributionList =
                //    (Outlook.DistListItem)this.Application.CreateItem
                //    (Outlook.OlItemType.olDistributionListItem);

                //distributionList.DLName = DISTRIBUTION_LIST_TITLE;

                //// Set the recipient information
                //Outlook.MailItem recipientInformation =
                //    (Outlook.MailItem)this.Application.CreateItem(Outlook.OlItemType.olMailItem);

                // Adding mail items
                foreach (string recipient in configuration.Recipients)
                {
                    //recipientInformation.Recipients.Add(recipient);
                    //this.frmSynchronize.pbSynchronization.Increment(1);
                    //MessageBox.Show(recipient);
                    mail.BCC += "; "+recipient;
                }

                //distributionList.AddMembers(recipientInformation.Recipients);
                //distributionList.Save();
            }
            else errorDelegation(MSG_SERVER_UNAVAILABLE);
        }
        #endregion
    }
}
