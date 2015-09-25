namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newName = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.personsLabel = new System.Windows.Forms.Label();
            this.list = new System.Windows.Forms.Button();
            this.clean = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(13, 22);
            this.newName.Name = "newName";
            this.newName.Size = new System.Drawing.Size(192, 20);
            this.newName.TabIndex = 0;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(212, 22);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(60, 20);
            this.add.TabIndex = 1;
            this.add.Text = "Adicionar";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // personsLabel
            // 
            this.personsLabel.AutoSize = true;
            this.personsLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personsLabel.Location = new System.Drawing.Point(15, 84);
            this.personsLabel.Name = "personsLabel";
            this.personsLabel.Size = new System.Drawing.Size(46, 16);
            this.personsLabel.TabIndex = 2;
            this.personsLabel.Text = "vazio!";
            // 
            // list
            // 
            this.list.Location = new System.Drawing.Point(212, 55);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(60, 22);
            this.list.TabIndex = 3;
            this.list.Text = "Listar";
            this.list.UseVisualStyleBackColor = true;
            this.list.Click += new System.EventHandler(this.list_Click);
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(212, 84);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(60, 26);
            this.clean.TabIndex = 4;
            this.clean.Text = "Limpar";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.infoLabel.Location = new System.Drawing.Point(15, 55);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(28, 13);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Info!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.list);
            this.Controls.Add(this.personsLabel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.newName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label personsLabel;
        private System.Windows.Forms.Button list;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Label infoLabel;
    }
}

