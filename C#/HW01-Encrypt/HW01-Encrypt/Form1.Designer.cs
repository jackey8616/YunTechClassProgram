namespace HW01_Encrypt
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.inputBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.aesEncryptBtn = new System.Windows.Forms.Button();
            this.aesDecryptBtn = new System.Windows.Forms.Button();
            this.swapBtn = new System.Windows.Forms.Button();
            this.clearInputBtn = new System.Windows.Forms.Button();
            this.clearOutputBtn = new System.Windows.Forms.Button();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.desEncryptBtn = new System.Windows.Forms.Button();
            this.desDecryptBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(42, 35);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputBox.Size = new System.Drawing.Size(537, 91);
            this.inputBox.TabIndex = 0;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(42, 265);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(537, 91);
            this.outputBox.TabIndex = 1;
            // 
            // aesEncryptBtn
            // 
            this.aesEncryptBtn.Location = new System.Drawing.Point(41, 169);
            this.aesEncryptBtn.Name = "aesEncryptBtn";
            this.aesEncryptBtn.Size = new System.Drawing.Size(75, 23);
            this.aesEncryptBtn.TabIndex = 2;
            this.aesEncryptBtn.Text = "AES Encrypt";
            this.aesEncryptBtn.UseVisualStyleBackColor = true;
            this.aesEncryptBtn.Click += new System.EventHandler(this.encryptAesBtn_Click);
            // 
            // aesDecryptBtn
            // 
            this.aesDecryptBtn.Location = new System.Drawing.Point(41, 198);
            this.aesDecryptBtn.Name = "aesDecryptBtn";
            this.aesDecryptBtn.Size = new System.Drawing.Size(75, 23);
            this.aesDecryptBtn.TabIndex = 4;
            this.aesDecryptBtn.Text = "AES Decrypt";
            this.aesDecryptBtn.UseVisualStyleBackColor = true;
            this.aesDecryptBtn.Click += new System.EventHandler(this.decryptAesBtn_Click);
            // 
            // swapBtn
            // 
            this.swapBtn.Location = new System.Drawing.Point(503, 169);
            this.swapBtn.Name = "swapBtn";
            this.swapBtn.Size = new System.Drawing.Size(75, 52);
            this.swapBtn.TabIndex = 5;
            this.swapBtn.Text = "Swap";
            this.swapBtn.UseVisualStyleBackColor = true;
            this.swapBtn.Click += new System.EventHandler(this.swapBtn_Click);
            // 
            // clearInputBtn
            // 
            this.clearInputBtn.Location = new System.Drawing.Point(341, 169);
            this.clearInputBtn.Name = "clearInputBtn";
            this.clearInputBtn.Size = new System.Drawing.Size(75, 23);
            this.clearInputBtn.TabIndex = 6;
            this.clearInputBtn.Text = "Clear Input";
            this.clearInputBtn.UseVisualStyleBackColor = true;
            this.clearInputBtn.Click += new System.EventHandler(this.clearInputBtn_Click);
            // 
            // clearOutputBtn
            // 
            this.clearOutputBtn.Location = new System.Drawing.Point(341, 198);
            this.clearOutputBtn.Name = "clearOutputBtn";
            this.clearOutputBtn.Size = new System.Drawing.Size(75, 23);
            this.clearOutputBtn.TabIndex = 7;
            this.clearOutputBtn.Text = "Clear Output";
            this.clearOutputBtn.UseVisualStyleBackColor = true;
            this.clearOutputBtn.Click += new System.EventHandler(this.clearOutputBtn_Click);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Location = new System.Drawing.Point(422, 198);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(75, 23);
            this.clearAllBtn.TabIndex = 9;
            this.clearAllBtn.Text = "Clear All";
            this.clearAllBtn.UseVisualStyleBackColor = true;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // desEncryptBtn
            // 
            this.desEncryptBtn.Location = new System.Drawing.Point(122, 169);
            this.desEncryptBtn.Name = "desEncryptBtn";
            this.desEncryptBtn.Size = new System.Drawing.Size(75, 23);
            this.desEncryptBtn.TabIndex = 11;
            this.desEncryptBtn.Text = "DES Encrypt";
            this.desEncryptBtn.UseVisualStyleBackColor = true;
            this.desEncryptBtn.Click += new System.EventHandler(this.desEncryptBtn_Click);
            // 
            // desDecryptBtn
            // 
            this.desDecryptBtn.Location = new System.Drawing.Point(122, 198);
            this.desDecryptBtn.Name = "desDecryptBtn";
            this.desDecryptBtn.Size = new System.Drawing.Size(75, 23);
            this.desDecryptBtn.TabIndex = 12;
            this.desDecryptBtn.Text = "DES Decrypt";
            this.desDecryptBtn.UseVisualStyleBackColor = true;
            this.desDecryptBtn.Click += new System.EventHandler(this.desDecryptBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(203, 169);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 13;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Location = new System.Drawing.Point(203, 198);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.saveFileBtn.TabIndex = 14;
            this.saveFileBtn.Text = "Save File";
            this.saveFileBtn.UseVisualStyleBackColor = true;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 383);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.desDecryptBtn);
            this.Controls.Add(this.desEncryptBtn);
            this.Controls.Add(this.clearAllBtn);
            this.Controls.Add(this.clearOutputBtn);
            this.Controls.Add(this.clearInputBtn);
            this.Controls.Add(this.swapBtn);
            this.Controls.Add(this.aesDecryptBtn);
            this.Controls.Add(this.aesEncryptBtn);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Name = "Form1";
            this.Text = "HW01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button aesEncryptBtn;
        private System.Windows.Forms.Button aesDecryptBtn;
        private System.Windows.Forms.Button swapBtn;
        private System.Windows.Forms.Button clearInputBtn;
        private System.Windows.Forms.Button clearOutputBtn;
        private System.Windows.Forms.Button clearAllBtn;
        private System.Windows.Forms.Button desEncryptBtn;
        private System.Windows.Forms.Button desDecryptBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Button saveFileBtn;
    }
}

