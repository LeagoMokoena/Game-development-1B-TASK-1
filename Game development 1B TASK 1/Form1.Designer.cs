
namespace Game_development_1B_TASK_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.Mapdisplay = new System.Windows.Forms.Label();
            this.txtPlayerStatus = new System.Windows.Forms.RichTextBox();
            this.btnSelectEnemy = new System.Windows.Forms.ComboBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.txtAttackStatus = new System.Windows.Forms.RichTextBox();
            this.enemyStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(608, 435);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(535, 464);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(679, 464);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(608, 493);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // Mapdisplay
            // 
            this.Mapdisplay.AutoSize = true;
            this.Mapdisplay.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Mapdisplay.Location = new System.Drawing.Point(132, 78);
            this.Mapdisplay.Name = "Mapdisplay";
            this.Mapdisplay.Size = new System.Drawing.Size(68, 18);
            this.Mapdisplay.TabIndex = 4;
            this.Mapdisplay.Text = "label1";
            this.Mapdisplay.Click += new System.EventHandler(this.Mapdisplay_Click);
            // 
            // txtPlayerStatus
            // 
            this.txtPlayerStatus.Location = new System.Drawing.Point(535, 95);
            this.txtPlayerStatus.Name = "txtPlayerStatus";
            this.txtPlayerStatus.Size = new System.Drawing.Size(219, 96);
            this.txtPlayerStatus.TabIndex = 5;
            this.txtPlayerStatus.Text = "";
            this.txtPlayerStatus.TextChanged += new System.EventHandler(this.txtPlayerStatus_TextChanged);
            // 
            // btnSelectEnemy
            // 
            this.btnSelectEnemy.FormattingEnabled = true;
            this.btnSelectEnemy.Location = new System.Drawing.Point(535, 197);
            this.btnSelectEnemy.Name = "btnSelectEnemy";
            this.btnSelectEnemy.Size = new System.Drawing.Size(219, 23);
            this.btnSelectEnemy.TabIndex = 6;
            this.btnSelectEnemy.SelectedIndexChanged += new System.EventHandler(this.btnSelectEnemy_SelectedIndexChanged);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(535, 304);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(219, 23);
            this.btnAttack.TabIndex = 7;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // txtAttackStatus
            // 
            this.txtAttackStatus.Location = new System.Drawing.Point(535, 333);
            this.txtAttackStatus.Name = "txtAttackStatus";
            this.txtAttackStatus.Size = new System.Drawing.Size(219, 96);
            this.txtAttackStatus.TabIndex = 8;
            this.txtAttackStatus.Text = "";
            // 
            // enemyStatus
            // 
            this.enemyStatus.Location = new System.Drawing.Point(535, 227);
            this.enemyStatus.Name = "enemyStatus";
            this.enemyStatus.Size = new System.Drawing.Size(219, 71);
            this.enemyStatus.TabIndex = 9;
            this.enemyStatus.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 528);
            this.Controls.Add(this.enemyStatus);
            this.Controls.Add(this.txtAttackStatus);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.btnSelectEnemy);
            this.Controls.Add(this.txtPlayerStatus);
            this.Controls.Add(this.Mapdisplay);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label Mapdisplay;
        private System.Windows.Forms.RichTextBox txtPlayerStatus;
        private System.Windows.Forms.ComboBox btnSelectEnemy;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.RichTextBox txtAttackStatus;
        private System.Windows.Forms.RichTextBox enemyStatus;
    }
}

