namespace HW02_MST
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
            this.readFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.primBtn = new System.Windows.Forms.Button();
            this.kruskalBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.drawZone = new System.Windows.Forms.PictureBox();
            this.drawBtn = new System.Windows.Forms.Button();
            this.drawMstBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawZone)).BeginInit();
            this.SuspendLayout();
            // 
            // readFileBtn
            // 
            this.readFileBtn.Location = new System.Drawing.Point(704, 12);
            this.readFileBtn.Name = "readFileBtn";
            this.readFileBtn.Size = new System.Drawing.Size(190, 23);
            this.readFileBtn.TabIndex = 0;
            this.readFileBtn.Text = "1. Read";
            this.readFileBtn.UseVisualStyleBackColor = true;
            this.readFileBtn.Click += new System.EventHandler(this.readFileBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            this.openFileDialog1.Tag = "";
            // 
            // primBtn
            // 
            this.primBtn.Enabled = false;
            this.primBtn.Location = new System.Drawing.Point(789, 41);
            this.primBtn.Name = "primBtn";
            this.primBtn.Size = new System.Drawing.Size(105, 23);
            this.primBtn.TabIndex = 1;
            this.primBtn.Text = "3.1 Prim MST";
            this.primBtn.UseVisualStyleBackColor = true;
            this.primBtn.Click += new System.EventHandler(this.primBtn_Click);
            // 
            // kruskalBtn
            // 
            this.kruskalBtn.Enabled = false;
            this.kruskalBtn.Location = new System.Drawing.Point(789, 70);
            this.kruskalBtn.Name = "kruskalBtn";
            this.kruskalBtn.Size = new System.Drawing.Size(105, 23);
            this.kruskalBtn.TabIndex = 2;
            this.kruskalBtn.Text = "3.2 Kruskal MST";
            this.kruskalBtn.UseVisualStyleBackColor = true;
            this.kruskalBtn.Click += new System.EventHandler(this.kruskalBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(704, 99);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(190, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "5. Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(704, 128);
            this.outputTxt.Multiline = true;
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.ReadOnly = true;
            this.outputTxt.Size = new System.Drawing.Size(190, 310);
            this.outputTxt.TabIndex = 4;
            // 
            // drawZone
            // 
            this.drawZone.Location = new System.Drawing.Point(12, 12);
            this.drawZone.Name = "drawZone";
            this.drawZone.Size = new System.Drawing.Size(686, 426);
            this.drawZone.TabIndex = 5;
            this.drawZone.TabStop = false;
            // 
            // drawBtn
            // 
            this.drawBtn.Enabled = false;
            this.drawBtn.Location = new System.Drawing.Point(704, 41);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(85, 23);
            this.drawBtn.TabIndex = 6;
            this.drawBtn.Text = "2. Draw";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.drawBtn_Click);
            // 
            // drawMstBtn
            // 
            this.drawMstBtn.Enabled = false;
            this.drawMstBtn.Location = new System.Drawing.Point(704, 70);
            this.drawMstBtn.Name = "drawMstBtn";
            this.drawMstBtn.Size = new System.Drawing.Size(85, 23);
            this.drawMstBtn.TabIndex = 7;
            this.drawMstBtn.Text = "4. Draw MST";
            this.drawMstBtn.UseVisualStyleBackColor = true;
            this.drawMstBtn.Click += new System.EventHandler(this.drawMstBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.drawMstBtn);
            this.Controls.Add(this.drawBtn);
            this.Controls.Add(this.drawZone);
            this.Controls.Add(this.outputTxt);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.kruskalBtn);
            this.Controls.Add(this.primBtn);
            this.Controls.Add(this.readFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button primBtn;
        private System.Windows.Forms.Button kruskalBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox outputTxt;
        private System.Windows.Forms.PictureBox drawZone;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.Button drawMstBtn;
    }
}

