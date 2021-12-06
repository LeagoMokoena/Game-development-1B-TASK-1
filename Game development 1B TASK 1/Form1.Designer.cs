
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
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txBoughtItem = new System.Windows.Forms.RichTextBox();
            this.btnWeapon3 = new System.Windows.Forms.Button();
            this.btnWeapon2 = new System.Windows.Forms.Button();
            this.btnWeapon1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(545, 431);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 46);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(435, 463);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(100, 50);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(654, 463);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(100, 50);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(545, 495);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 50);
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
            this.txtPlayerStatus.Location = new System.Drawing.Point(435, 95);
            this.txtPlayerStatus.Name = "txtPlayerStatus";
            this.txtPlayerStatus.Size = new System.Drawing.Size(319, 96);
            this.txtPlayerStatus.TabIndex = 5;
            this.txtPlayerStatus.Text = "";
            this.txtPlayerStatus.TextChanged += new System.EventHandler(this.txtPlayerStatus_TextChanged);
            // 
            // btnSelectEnemy
            // 
            this.btnSelectEnemy.FormattingEnabled = true;
            this.btnSelectEnemy.Location = new System.Drawing.Point(435, 197);
            this.btnSelectEnemy.Name = "btnSelectEnemy";
            this.btnSelectEnemy.Size = new System.Drawing.Size(319, 23);
            this.btnSelectEnemy.TabIndex = 6;
            this.btnSelectEnemy.SelectedIndexChanged += new System.EventHandler(this.btnSelectEnemy_SelectedIndexChanged);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(435, 304);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(319, 23);
            this.btnAttack.TabIndex = 7;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // txtAttackStatus
            // 
            this.txtAttackStatus.Location = new System.Drawing.Point(435, 333);
            this.txtAttackStatus.Name = "txtAttackStatus";
            this.txtAttackStatus.Size = new System.Drawing.Size(319, 96);
            this.txtAttackStatus.TabIndex = 8;
            this.txtAttackStatus.Text = "";
            // 
            // enemyStatus
            // 
            this.enemyStatus.Location = new System.Drawing.Point(435, 227);
            this.enemyStatus.Name = "enemyStatus";
            this.enemyStatus.Size = new System.Drawing.Size(319, 71);
            this.enemyStatus.TabIndex = 9;
            this.enemyStatus.Text = "";
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Location = new System.Drawing.Point(435, 56);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(319, 23);
            this.btnSaveMap.TabIndex = 10;
            this.btnSaveMap.Text = "Save";
            this.btnSaveMap.UseVisualStyleBackColor = true;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(435, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(319, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txBoughtItem);
            this.groupBox1.Controls.Add(this.btnWeapon3);
            this.groupBox1.Controls.Add(this.btnWeapon2);
            this.groupBox1.Controls.Add(this.btnWeapon1);
            this.groupBox1.Location = new System.Drawing.Point(767, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 505);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "The shop";
            // 
            // txBoughtItem
            // 
            this.txBoughtItem.Location = new System.Drawing.Point(6, 345);
            this.txBoughtItem.Name = "txBoughtItem";
            this.txBoughtItem.Size = new System.Drawing.Size(297, 154);
            this.txBoughtItem.TabIndex = 3;
            this.txBoughtItem.Text = "";
            // 
            // btnWeapon3
            // 
            this.btnWeapon3.Location = new System.Drawing.Point(6, 182);
            this.btnWeapon3.Name = "btnWeapon3";
            this.btnWeapon3.Size = new System.Drawing.Size(297, 74);
            this.btnWeapon3.TabIndex = 2;
            this.btnWeapon3.Text = "button3";
            this.btnWeapon3.UseVisualStyleBackColor = true;
            this.btnWeapon3.Click += new System.EventHandler(this.btnWeapon3_Click);
            // 
            // btnWeapon2
            // 
            this.btnWeapon2.Location = new System.Drawing.Point(6, 102);
            this.btnWeapon2.Name = "btnWeapon2";
            this.btnWeapon2.Size = new System.Drawing.Size(297, 74);
            this.btnWeapon2.TabIndex = 1;
            this.btnWeapon2.Text = "button2";
            this.btnWeapon2.UseVisualStyleBackColor = true;
            this.btnWeapon2.Click += new System.EventHandler(this.btnWeapon2_Click);
            // 
            // btnWeapon1
            // 
            this.btnWeapon1.Location = new System.Drawing.Point(6, 22);
            this.btnWeapon1.Name = "btnWeapon1";
            this.btnWeapon1.Size = new System.Drawing.Size(297, 74);
            this.btnWeapon1.TabIndex = 0;
            this.btnWeapon1.Text = "button1";
            this.btnWeapon1.UseVisualStyleBackColor = true;
            this.btnWeapon1.Click += new System.EventHandler(this.btnWeapon1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSaveMap);
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
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnWeapon2;
        private System.Windows.Forms.Button btnWeapon1;
        private System.Windows.Forms.RichTextBox txBoughtItem;
        private System.Windows.Forms.Button btnWeapon3;
    }
}

