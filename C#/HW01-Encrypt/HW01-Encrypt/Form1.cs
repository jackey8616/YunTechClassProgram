using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String AesEncrypt(String inputData, String inputKey) {
            string encrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Encoding.UTF8.GetBytes(inputData);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return encrypt;
        }

        public String AesDecrpt(String inputData, String inputKey) {
            string decrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(inputData);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return decrypt;
        }

        public String DesEncrypt(String inpuData, String inputKey) {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
            byte[] dataByteArray = Encoding.UTF8.GetBytes(inpuData);

            des.Key = key;
            des.IV = iv;
            string encrypt = "";
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                encrypt = Convert.ToBase64String(ms.ToArray());
            }
            return encrypt;
        }

        public String DesDecrypt(String inputData, String inputKey) {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(inputKey));
            des.Key = key;
            des.IV = iv;

            byte[] dataByteArray = Convert.FromBase64String(inputData);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        private void encryptAesBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = this.AesEncrypt(inputBox.Text, keyBox.Text);
        }

        private void decryptAesBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = this.AesDecrpt(inputBox.Text, keyBox.Text);
        }

        private void swapBtn_Click(object sender, EventArgs e)
        {
            String buff = inputBox.Text;
            inputBox.Text = outputBox.Text;
            outputBox.Text = buff;
        }

        private void clearInputBtn_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
        }

        private void clearOutputBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = "";
        }

        private void clearKeyBtn_Click(object sender, EventArgs e)
        {
            keyBox.Text = "";
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            outputBox.Text = "";
            keyBox.Text = "";
        }

        private void keyRandomBtn_Click(object sender, EventArgs e)
        {

        }

        private void desEncryptBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = DesEncrypt(inputBox.Text, keyBox.Text);
        }

        private void desDecryptBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = DesDecrypt(inputBox.Text, keyBox.Text);
        }
    }
}
