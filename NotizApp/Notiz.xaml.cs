using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotizApp
{
    public class NotizProperty
    {
        // Property Auto
        #region 
        private Hashtable DIDRegister = new Hashtable();
        private String DTitle = String.Empty;
        private String DText = String.Empty;
        private String DFarbe = String.Empty;
        private Brush DBrushFarbe = Brushes.AliceBlue;
        private DateTime DZeit = DateTime.Now;
        #endregion

        // Property  Get { return Gender } Set { Gender = value }
        #region 
        public Hashtable IDRegister
        {
            get { return DIDRegister; }
            set { DIDRegister = value; }
        }

        public string Title
        {
            get { return DTitle; }
            set { DTitle = value; }
        }

        public string Text
        {
            get { return DText; }
            set { DText = value; }
        }

        /*
        public String Farbe
        {
            get
            {
                String tpss = JsonConvert.SerializeObject(BrushFarbe, Formatting.Indented);
                Brush jFarbe = JsonConvert.DeserializeObject<Brush>(tpss);
                return DFarbe = JsonConvert.SerializeObject(jFarbe, Formatting.Indented);
            }
            set { DFarbe = value; }
        }
        */

        public Brush BrushFarbe
        {
            get { return DBrushFarbe; }
            set { DBrushFarbe = value; }
        }

        public DateTime Zeit
        {
            get { return DZeit; }
            set { DZeit = value; }
        }
        #endregion
    }

    /// <summary>
    ///     Interaktionslogik für Notiz.xaml
    /// </summary>

    public partial class Notiz : Window
    {
        public NotizProperty Property = new NotizProperty();

        public Notiz()
        {
            InitializeComponent();
            new Notiz(Property.BrushFarbe);
        }

        public Notiz(Brush far)
        {
            InitializeComponent();
            Title += Property.Zeit.ToString(" dd MMM yyyy hh:mm:ss");
            Property.Title = Title;
            Property.BrushFarbe = far;
            textBox.Background = Property.BrushFarbe;
            //textBox.AppendText(Property.Text);
            textBox.Text = Property.Text;

        }

        
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            /*
            var JasonTEXT = JsonConvert.SerializeObject(value: Property, formatting: Formatting.Indented);
            MessageBox.Show(JasonTEXT);
            */
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}