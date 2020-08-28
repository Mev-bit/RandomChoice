using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace RandomChoice
{
    public partial class Form3 : Form
    {
        private String name;
        private List<String> List;
        private XmlSerializer xs;
        public Form3()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(@"./listes/");
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                listBox1.Items.Add(fichier.Name);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            open(listBox1.Text);
            
            addElement(elem.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void open(String name_List)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamReader rd = new StreamReader("./listes/" + name_List))
            {
                this.List = xs.Deserialize(rd) as List<String>;
            }
        }
        public void addElement(String elem)
        {
            if (elem != null)
            {
                List.Add(elem);
                save(listBox1.Text);
            }
            else
            {
                Console.Out.Write("addElement(): elem is null");
            }
        }
        public void save(String name_List)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamWriter wr = new StreamWriter("./listes/" +name_List))
            {
                xs.Serialize(wr, List);
            }
            verif.Text = "Ajout réussi !";


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
