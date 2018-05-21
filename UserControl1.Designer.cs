namespace WindowsFormsApp1
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mapFind = new System.Windows.Forms.Button();
            this.mapName = new System.Windows.Forms.Label();
            this.difficultyName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mapInfo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.mapInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 20);
            this.textBox1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Write your username (or ID) below";
            // 
            // mapFind
            // 
            this.mapFind.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapFind.Location = new System.Drawing.Point(122, 120);
            this.mapFind.Name = "mapFind";
            this.mapFind.Size = new System.Drawing.Size(242, 39);
            this.mapFind.TabIndex = 40;
            this.mapFind.Text = "Find me some maps!";
            this.mapFind.UseVisualStyleBackColor = true;
            this.mapFind.Click += new System.EventHandler(this.mapFind_Click);
            // 
            // mapName
            // 
            this.mapName.AutoSize = true;
            this.mapName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapName.Location = new System.Drawing.Point(8, 38);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(87, 17);
            this.mapName.TabIndex = 0;
            this.mapName.Text = "Map name: ";
            // 
            // difficultyName
            // 
            this.difficultyName.AutoSize = true;
            this.difficultyName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyName.Location = new System.Drawing.Point(8, 63);
            this.difficultyName.Name = "difficultyName";
            this.difficultyName.Size = new System.Drawing.Size(108, 17);
            this.difficultyName.TabIndex = 1;
            this.difficultyName.Text = "Difficulty name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mods (not supported yet)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // mapInfo
            // 
            this.mapInfo.Controls.Add(this.button2);
            this.mapInfo.Controls.Add(this.label3);
            this.mapInfo.Controls.Add(this.mapName);
            this.mapInfo.Controls.Add(this.label4);
            this.mapInfo.Controls.Add(this.difficultyName);
            this.mapInfo.Location = new System.Drawing.Point(45, 206);
            this.mapInfo.Name = "mapInfo";
            this.mapInfo.Size = new System.Drawing.Size(425, 119);
            this.mapInfo.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "This is what you should play";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(393, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 30);
            this.button2.TabIndex = 45;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapInfo);
            this.Controls.Add(this.mapFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(529, 524);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.mapInfo.ResumeLayout(false);
            this.mapInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mapFind;
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Label difficultyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel mapInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}
