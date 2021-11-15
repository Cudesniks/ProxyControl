using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Чтение ключа
            RegistryKey Key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
          radioButton1.Checked = Key?.GetValue("ProxyEnable")?.ToString() == "1" ? true : false;
          radioButton2.Checked = Key?.GetValue("ProxyEnable")?.ToString() == "0" ? true : false;
            
      

       
            Key.Close();

            //Картинки

            //ДОН
            if (radioButton1.Checked == true) pictureBox1.Visible = true;
            else pictureBox1.Visible = false;
            pictureBox1.Refresh();

            //Дом
            if (radioButton2.Checked == true) pictureBox2.Visible = true;
            else pictureBox2.Visible = false;
            pictureBox1.Refresh();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
            saveKey.SetValue("ProxyEnable", 1, RegistryValueKind.DWord);
            saveKey.Close();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
            saveKey.SetValue("ProxyEnable", 0, RegistryValueKind.DWord);
            saveKey.Close();
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;

        }
    }
}
