using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TripleDesSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (textBox2.Text != "")
                    {
                        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                        UTF8Encoding utf8 = new UTF8Encoding();
                        TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider
                        {
                            Key = md5.ComputeHash(utf8.GetBytes(textBox1.Text)),
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        };
                        ICryptoTransform trans = tDES.CreateEncryptor();
                        textBox3.Text = BitConverter.ToString(trans.TransformFinalBlock(utf8.GetBytes(textBox2.Text), 0, utf8.GetBytes(textBox2.Text).Length));
                        textBox4.Text = textBox3.TextLength.ToString();
                    }
                    else
                    {
                        textBox2.Focus();
                        MessageBox.Show("Plain text not specified.", "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    textBox1.Focus();
                    MessageBox.Show("Key not specified.", "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
