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
            this.encryptAesBtn = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.decryptAesBtn = new System.Windows.Forms.Button();
            this.swapBtn = new System.Windows.Forms.Button();
            this.clearInputBtn = new System.Windows.Forms.Button();
            this.clearOutputBtn = new System.Windows.Forms.Button();
            this.clearKeyBtn = new System.Windows.Forms.Button();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.keyRandomBtn = new System.Windows.Forms.Button();
            this.desEncryptBtn = new System.Windows.Forms.Button();
            this.desDecryptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(42, 35);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(537, 91);
            this.inputBox.TabIndex = 0;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(42, 265);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(537, 91);
            this.outputBox.TabIndex = 1;
            // 
            // encryptAesBtn
            // 
            this.encryptAesBtn.Location = new System.Drawing.Point(42, 184);
            this.encryptAesBtn.Name = "encryptAesBtn";
            this.encryptAesBtn.Size = new System.Drawing.Size(75, 23);
            this.encryptAesBtn.TabIndex = 2;
            this.encryptAesBtn.Text = "AES Encrypt";
            this.encryptAesBtn.UseVisualStyleBackColor = true;
            this.encryptAesBtn.Click += new System.EventHandler(this.encryptAesBtn_Click);
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(42, 132);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(456, 27);
            this.keyBox.TabIndex = 3;
            // 
            // decryptAesBtn
            // 
            this.decryptAesBtn.Location = new System.Drawing.Point(42, 213);
            this.decryptAesBtn.Name = "decryptAesBtn";
            this.decryptAesBtn.Size = new System.Drawing.Size(75, 23);
            this.decryptAesBtn.TabIndex = 4;
            this.decryptAesBtn.Text = "AES Decrypt";
            this.decryptAesBtn.UseVisualStyleBackColor = true;
            this.decryptAesBtn.Click += new System.EventHandler(this.decryptAesBtn_Click);
            // 
            // swapBtn
            // 
            this.swapBtn.Location = new System.Drawing.Point(504, 184);
            this.swapBtn.Name = "swapBtn";
            this.swapBtn.Size = new System.Drawing.Size(75, 52);
            this.swapBtn.TabIndex = 5;
            this.swapBtn.Text = "Swap";
            this.swapBtn.UseVisualStyleBackColor = true;
            this.swapBtn.Click += new System.EventHandler(this.swapBtn_Click);
            // 
            // clearInputBtn
            // 
            this.clearInputBtn.Location = new System.Drawing.Point(342, 184);
            this.clearInputBtn.Name = "clearInputBtn";
            this.clearInputBtn.Size = new System.Drawing.Size(75, 23);
            this.clearInputBtn.TabIndex = 6;
            this.clearInputBtn.Text = "Clear Input";
            this.clearInputBtn.UseVisualStyleBackColor = true;
            this.clearInputBtn.Click += new System.EventHandler(this.clearInputBtn_Click);
            // 
            // clearOutputBtn
            // 
            this.clearOutputBtn.Location = new System.Drawing.Point(342, 213);
            this.clearOutputBtn.Name = "clearOutputBtn";
            this.clearOutputBtn.Size = new System.Drawing.Size(75, 23);
            this.clearOutputBtn.TabIndex = 7;
            this.clearOutputBtn.Text = "Clear Output";
            this.clearOutputBtn.UseVisualStyleBackColor = true;
            this.clearOutputBtn.Click += new System.EventHandler(this.clearOutputBtn_Click);
            // 
            // clearKeyBtn
            // 
            this.clearKeyBtn.Location = new System.Drawing.Point(423, 184);
            this.clearKeyBtn.Name = "clearKeyBtn";
            this.clearKeyBtn.Size = new System.Drawing.Size(75, 23);
            this.clearKeyBtn.TabIndex = 8;
            this.clearKeyBtn.Text = "Clear Key";
            this.clearKeyBtn.UseVisualStyleBackColor = true;
            this.clearKeyBtn.Click += new System.EventHandler(this.clearKeyBtn_Click);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Location = new System.Drawing.Point(423, 213);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(75, 23);
            this.clearAllBtn.TabIndex = 9;
            this.clearAllBtn.Text = "Clear All";
            this.clearAllBtn.UseVisualStyleBackColor = true;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // keyRandomBtn
            // 
            this.keyRandomBtn.Location = new System.Drawing.Point(504, 132);
            this.keyRandomBtn.Name = "keyRandomBtn";
            this.keyRandomBtn.Size = new System.Drawing.Size(75, 27);
            this.keyRandomBtn.TabIndex = 10;
            this.keyRandomBtn.Text = "Random";
            this.keyRandomBtn.UseVisualStyleBackColor = true;
            this.keyRandomBtn.Click += new System.EventHandler(this.keyRandomBtn_Click);
            // 
            // desEncryptBtn
            // 
            this.desEncryptBtn.Location = new System.Drawing.Point(123, 184);
            this.desEncryptBtn.Name = "desEncryptBtn";
            this.desEncryptBtn.Size = new System.Drawing.Size(75, 23);
            this.desEncryptBtn.TabIndex = 11;
            this.desEncryptBtn.Text = "DES Encrypt";
            this.desEncryptBtn.UseVisualStyleBackColor = true;
            this.desEncryptBtn.Click += new System.EventHandler(this.desEncryptBtn_Click);
            // 
            // desDecryptBtn
            // 
            this.desDecryptBtn.Location = new System.Drawing.Point(123, 213);
            this.desDecryptBtn.Name = "desDecryptBtn";
            this.desDecryptBtn.Size = new System.Drawing.Size(75, 23);
            this.desDecryptBtn.TabIndex = 12;
            this.desDecryptBtn.Text = "DES Decrypt";
            this.desDecryptBtn.UseVisualStyleBackColor = true;
            this.desDecryptBtn.Click += new System.EventHandler(this.desDecryptBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 383);
            this.Controls.Add(this.desDecryptBtn);
            this.Controls.Add(this.desEncryptBtn);
            this.Controls.Add(this.keyRandomBtn);
            this.Controls.Add(this.clearAllBtn);
            this.Controls.Add(this.clearKeyBtn);
            this.Controls.Add(this.clearOutputBtn);
            this.Controls.Add(this.clearInputBtn);
            this.Controls.Add(this.swapBtn);
            this.Controls.Add(this.decryptAesBtn);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.encryptAesBtn);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button encryptAesBtn;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Button decryptAesBtn;
        private System.Windows.Forms.Button swapBtn;
        private System.Windows.Forms.Button clearInputBtn;
        private System.Windows.Forms.Button clearOutputBtn;
        private System.Windows.Forms.Button clearKeyBtn;
        private System.Windows.Forms.Button clearAllBtn;
        private System.Windows.Forms.Button keyRandomBtn;
        private System.Windows.Forms.Button desEncryptBtn;
        private System.Windows.Forms.Button desDecryptBtn;
    }
}

