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

        public String AesEncrypt(String inputData) {
            string encrypt = "";
            try {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes("1111111"));
                aes.IV = md5.ComputeHash(Encoding.UTF8.GetBytes("1111111"));
                byte[] dataByteArray = Encoding.UTF8.GetBytes(inputData);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(ms.ToArray());
                    }
                }
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return encrypt;
        }

        public String AesDecrpt(String inputData) {
            string decrypt = "";
            try {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes("1111111"));
                aes.IV = md5.ComputeHash(Encoding.UTF8.GetBytes("1111111"));
                byte[] dataByteArray = Convert.FromBase64String(inputData);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write)) {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return decrypt;
        }

        public String DesEncrypt(String inpuData) {
            string encrypt = "";
            try {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] dataByteArray = Encoding.UTF8.GetBytes(inpuData);

                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(Encoding.UTF8.GetBytes("11111111"), Encoding.UTF8.GetBytes("11111111")), CryptoStreamMode.Write))               {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(ms.ToArray());
                    }
                }
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return encrypt;
        }

        public String DesDecrypt(String inputData) {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] dataByteArray = Convert.FromBase64String(inputData);
            using (MemoryStream ms = new MemoryStream()) {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(Encoding.UTF8.GetBytes("11111111"), Encoding.UTF8.GetBytes("11111111")), CryptoStreamMode.Write)) {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        private void encryptAesBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = this.AesEncrypt(inputBox.Text);
        }

        private void decryptAesBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = this.AesDecrpt(inputBox.Text);
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
        
        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void desEncryptBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = DesEncrypt(inputBox.Text);
        }

        private void desDecryptBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = DesDecrypt(inputBox.Text);
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                inputBox.Text = sr.ReadToEnd();
                sr.Close();
            }
            aesEncryptBtn.Enabled = true;
            desEncryptBtn.Enabled = true;
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.FileName);
                sw.Write(outputBox.Text);
                sw.Close();
            }
        }
    }
}
