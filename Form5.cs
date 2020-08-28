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
    public partial class Form5 : Form
    {
        private List<String> List;
        public Form5()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(@"./listes/");
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                listBox1.Items.Add(fichier.Name);

            }
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
        public void see_list(String list_name)
        {
          
            open(list_name);

            foreach (String s in List)
            {
                listBox2.Items.Add(s);
            }
            
        }
        


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            for (int i = (listBox2.SelectedIndex - 1); i >= 0; i--)
            {
                listBox2.Items.RemoveAt(i);

            }
            see_list(listBox1.Text);
        }
    }
}
