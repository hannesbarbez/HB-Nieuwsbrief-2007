using System;
using System.Collections.Generic;
using System.Drawing;
using HB_Nieuwsbrief.Data;
using HB_NieuwsbriefDatabaseConnection;

namespace HB_Nieuwsbrief.Logic
{
    [Serializable]
    public class Configuration
    {
        #region Constants
        private const string EMPTY = "";
        private const string ERROR_LOADING_CONFIGURATION = "Bij het opstarten van de HB Nieuwsbrief Toolbar werd geen of corrupte configuratie aangetroffen. Gelieve uw instellingen resp. in te vullen of te corrigeren.";
        private const float DEFAULT_FONT_HEIGHT = 8;
        private const string DEFAULT_FONT_COLOR = "Black";
        #endregion
        #region Fields
        private ErrorDelegation errorDelegation;
        #endregion
        #region Properties
        /// <summary>
        /// Serializes as a form of hidden back-up system
        /// </summary>
        public List<string> Recipients { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Table { get; set; }
        public string Row { get; set; }
        public string Background { get; set; }
        public string Logo { get; set; }
        public string Font { get; set; }
        public string Color { get; set; }
        #endregion
        #region Methods
        public void Save()
        {
            ConfigurationSource.Write(this);
        }
        public void EraseOld()
        {
            ConfigurationSource.EraseOld();
        }
        public void LoadRecipientsFromDataSource(SynchronizationDelegation sd)
        {
            DataSource source = new DataSource(Server, Database, User, Password, Row, Table);
            string[] recipients = source.GetRecipients();
            Recipients.Clear();

            if (recipients != null)
            {
                foreach (string recipient in recipients)
                {
                    Recipients.Add(recipient);
                    sd(recipients.Length);
                }
            }
        }
        #endregion
        #region Static Methods
        /// <summary>
        /// Extracts the filename without the path
        /// </summary>
        /// <param name="path">the path to look into</param>
        /// <returns>the name of the file</returns>
        public static string DeriveFileNameFromPath(string path)
        {
            //Derive filename background
            string[] splittedPath = path.Split(new char[] { '\\' });
            string fileName = splittedPath[splittedPath.Length - 1];
            return fileName;
        }
        public static bool DoesPathExist(string path)
        {
            return ConfigurationSource.DoesPathExist(path);
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Sets a new, empty configuration 
        /// </summary>
        public Configuration()
        {
            // Set a default font...
            Font font = new Font(FontFamily.GenericSansSerif, DEFAULT_FONT_HEIGHT);
            // ...to be converted...
            FontConverter converter = new FontConverter();
            // ...to a string because a Font object doesn't have a parameterless
            // constructor and as such cannot be serialized
            Font = converter.ConvertToString(font);
            // Serializable, dynamic equivalent of a string array
            Recipients = new List<string>();

            Color = DEFAULT_FONT_COLOR;
            Server = EMPTY;
            Database = EMPTY;
            User = EMPTY;
            Password = EMPTY;
            Row = EMPTY;
            Table = EMPTY;
            Background = EMPTY;
            Logo = EMPTY;
        }
        /// <summary>
        /// Tries to load a configuration from XML. If none or corrupt XML found, a default
        /// Configuration is loaded.
        /// </summary>
        /// <param name="errorDelegation">Delegation called when no or corrupt XML is found.</param>
        public Configuration(ErrorDelegation errorDelegation)
        {
            this.errorDelegation = errorDelegation;
            try
            {
                Configuration loadedConfiguration = ConfigurationSource.Load();
                this.Recipients = loadedConfiguration.Recipients;
                this.Background = loadedConfiguration.Background;
                this.Database = loadedConfiguration.Database;
                this.Password = loadedConfiguration.Password;
                this.Server = loadedConfiguration.Server;
                this.Table = loadedConfiguration.Table;
                this.Color = loadedConfiguration.Color;
                this.User = loadedConfiguration.User;
                this.Font = loadedConfiguration.Font;
                this.Logo = loadedConfiguration.Logo;
                this.Row = loadedConfiguration.Row;
            }
            catch
            {
                errorDelegation(ERROR_LOADING_CONFIGURATION);
                new Configuration();
            }
        }
        public Configuration(string server, string database, string user, string password, string row, string table, string background, string logo, string font, string color)
        {
            this.Background = background;
            this.Database = database;
            this.Password = password;
            this.Server = server;
            this.Color = color;
            this.Table = table;
            this.Logo = logo;
            this.Font = font;
            this.User = user;
            this.Row = row;
        }
        #endregion
    }
}