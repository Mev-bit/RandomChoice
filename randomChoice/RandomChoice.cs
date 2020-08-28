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
    public partial class Form1 : Form
    {
        private List<String> List;

        public Form1()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(@"./listes/");
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                listBox1.Items.Add(fichier.Name);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public String random(String name_List)
        {
            List<String> l;
            Random rnd = new Random();
            String ret = null;
            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamReader rd = new StreamReader("./listes/" + name_List))
            {
                l = xs.Deserialize(rd) as List<String>;
            }
            int i = rnd.Next(1, l.Count);
            Console.Out.Write(l.Count);
            ret = l[i];

            return ret;
        }
        
        private void add_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(listBox1.Text != null && listBox1.Text != "")
            {
                label2.Text = random(listBox1.Text);
            }
            else { }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            Form5.Show();
            this.Hide();
        }
    }
}
