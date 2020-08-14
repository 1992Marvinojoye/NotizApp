using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Notiz> Notizen = new List<Notiz>();
        public int RegisterCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            

            Action<string> msg = s => { MessageBox.Show(s); };
            var Savefile = "Notizen.jason";

            if (File.Exists(Savefile))
            {
                String JASONString = File.ReadAllText(Savefile);

                var ser = JsonConvert.DeserializeObject<List<NotizProperty>>(JASONString);

                var datenliste = ser;
                msg(JASONString);
                foreach (var NZ in datenliste)
                {                    
                    var n = new Notiz(NZ.BrushFarbe);
                    n.Title = "Old " + NZ.Title;
                    n.textBox.Background = NZ.BrushFarbe;
                    n.textBox.Text = NZ.Text;
                    n.Property.IDRegister.Add(RegisterCounter++, n.Property.Title);
                    n.Show();
                    Notizen.Add(n);
                }
            }
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            // Notiz Fenster Laden
            // Farbe von Button auf Fenster Übertragen
            var ButtonFarbe = ((Button) sender).Background;
            var n = new Notiz(ButtonFarbe);
            n.Property.Text = "Inset u re Text";
            n.Show();
            n.Property.IDRegister.Add(RegisterCounter++, n.Property.Title);
            n.Property.BrushFarbe = ButtonFarbe;
            Notizen.Add(n);
            // Notiz Fenster Display
            var JasonTEXT = JsonConvert.SerializeObject(value: n.Property, formatting: Formatting.Indented);
            MessageBox.Show(JasonTEXT);
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var Savefile = "Notizen.jason";
            var datenliste = new List<NotizProperty>();

            foreach (var NZ in Notizen)
            {
                if (NZ.IsLoaded)
                {
                    
                    //NZ.Property.Text = NZ.textBox.Text;
                    NZ.Property.Text = NZ.textBox.Text;
                    datenliste.Add(NZ.Property);   
                    NZ.Close();
                }
            }
            var JasonTEXT = JsonConvert.SerializeObject(datenliste, Formatting.Indented);
            //MessageBox.Show(JasonTEXT);
            File.WriteAllText(Savefile, JasonTEXT);
        }
    }
}



/*
                FileStream f = new FileStream(path: Savefile, mode: FileMode.Create);
                XmlSerializer x = new XmlSerializer(type: typeof(Notizdaten));
                f.Close();

                //List<Notizdaten> datenliste = new List<Notizdaten>();

                foreach (Notiz item in Notizen) if(item.IsLoaded)
                {
                     //datenliste.Add(item.Daten);
                     //x.Serialize(f, item.);
                };

                //MessageBox.Show((datenliste));
                /*
                Parallel.ForEach(notizen, item =>
                {
                    if (item.IsLoaded) { 
                        datenliste.Add(item.Daten);
                    }
                });

                x.Serialize(f, datenliste);
                f.Close();
                */
//foreach (var ng in notizen)new Thread(delegate { ng.Close(); }).Start());
//Parallel.ForEach(notizen,nc => new Thread(delegate { nc.Close(); }).Start());