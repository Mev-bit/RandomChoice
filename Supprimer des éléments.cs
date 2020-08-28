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
    public partial class Form4 : Form
    {
        private List<String> List;
        private XmlSerializer xs;
        public Form4()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(@"./listes/");
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                listBox1.Items.Add(fichier.Name);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            open(listBox1.Text);
            removeElement(textBox1.Text);
            save(listBox1.Text);
        }
        public void removeElement(String elem)
        {
            if (elem != null)
            {
                List.Remove(elem);
            }
            else
            {
                Console.Out.Write("removeElement(): elem is null");
            }
        }

        public void open(String name_List)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamReader rd = new StreamReader("./listes/" + name_List))
            {
                this.List = xs.Deserialize(rd) as List<String>;
            }
        }
        public void save(String name_List)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamWriter wr = new StreamWriter("./listes/" + name_List ))
            {
                xs.Serialize(wr, List);
            }
            verif.Text = "Suppresion réussi !";


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
