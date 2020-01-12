namespace BodyCamSercher
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.save_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ik_name = new System.Windows.Forms.TextBox();
            this.number_txt = new System.Windows.Forms.TextBox();
            this.alert_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.Location = new System.Drawing.Point(112, 174);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(99, 23);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Инвентарный номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Учреждение №";
            // 
            // ik_name
            // 
            this.ik_name.Location = new System.Drawing.Point(100, 102);
            this.ik_name.Name = "ik_name";
            this.ik_name.Size = new System.Drawing.Size(109, 20);
            this.ik_name.TabIndex = 4;
            // 
            // number_txt
            // 
            this.number_txt.Location = new System.Drawing.Point(13, 58);
            this.number_txt.Name = "number_txt";
            this.number_txt.Size = new System.Drawing.Size(196, 20);
            this.number_txt.TabIndex = 5;
            // 
            // alert_lbl
            // 
            this.alert_lbl.AutoSize = true;
            this.alert_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alert_lbl.ForeColor = System.Drawing.Color.SpringGreen;
            this.alert_lbl.Location = new System.Drawing.Point(44, 9);
            this.alert_lbl.Name = "alert_lbl";
            this.alert_lbl.Size = new System.Drawing.Size(0, 20);
            this.alert_lbl.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 205);
            this.Controls.Add(this.alert_lbl);
            this.Controls.Add(this.number_txt);
            this.Controls.Add(this.ik_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(237, 244);
            this.MinimumSize = new System.Drawing.Size(237, 244);
            this.Name = "Form2";
            this.Text = "Добавить видеорегистратор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ik_name;
        private System.Windows.Forms.TextBox number_txt;
        private System.Windows.Forms.Label alert_lbl;
        private System.Windows.Forms.Timer timer1;
    }
}