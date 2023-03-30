namespace SwordRushLevelEditor
{
    partial class Editor
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
            groupBoxMap = new GroupBox();
            groupBoxTiles = new GroupBox();
            buttonBlack = new Button();
            buttonRed = new Button();
            buttonBlue = new Button();
            buttonBrown = new Button();
            buttonGray = new Button();
            buttonGreen = new Button();
            groupBoxCurrent = new GroupBox();
            pictureBoxSelected = new PictureBox();
            buttonSave = new Button();
            buttonLoad = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBoxTiles.SuspendLayout();
            groupBoxCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelected).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMap
            // 
            groupBoxMap.AutoSize = true;
            groupBoxMap.Location = new Point(243, 10);
            groupBoxMap.Margin = new Padding(2);
            groupBoxMap.Name = "groupBoxMap";
            groupBoxMap.Padding = new Padding(2);
            groupBoxMap.Size = new Size(800, 800);
            groupBoxMap.TabIndex = 0;
            groupBoxMap.TabStop = false;
            groupBoxMap.Text = "Map";
            // 
            // groupBoxTiles
            // 
            groupBoxTiles.Controls.Add(label6);
            groupBoxTiles.Controls.Add(label5);
            groupBoxTiles.Controls.Add(label4);
            groupBoxTiles.Controls.Add(label3);
            groupBoxTiles.Controls.Add(label2);
            groupBoxTiles.Controls.Add(label1);
            groupBoxTiles.Controls.Add(buttonBlack);
            groupBoxTiles.Controls.Add(buttonRed);
            groupBoxTiles.Controls.Add(buttonBlue);
            groupBoxTiles.Controls.Add(buttonBrown);
            groupBoxTiles.Controls.Add(buttonGray);
            groupBoxTiles.Controls.Add(buttonGreen);
            groupBoxTiles.Location = new Point(10, 10);
            groupBoxTiles.Margin = new Padding(2);
            groupBoxTiles.Name = "groupBoxTiles";
            groupBoxTiles.Padding = new Padding(2);
            groupBoxTiles.Size = new Size(220, 388);
            groupBoxTiles.TabIndex = 1;
            groupBoxTiles.TabStop = false;
            groupBoxTiles.Text = "TileSelector";
            // 
            // buttonBlack
            // 
            buttonBlack.BackColor = Color.Black;
            buttonBlack.Location = new Point(119, 288);
            buttonBlack.Margin = new Padding(2);
            buttonBlack.Name = "buttonBlack";
            buttonBlack.Size = new Size(96, 96);
            buttonBlack.TabIndex = 5;
            buttonBlack.UseVisualStyleBackColor = false;
            buttonBlack.Click += buttonBlack_Click;
            // 
            // buttonRed
            // 
            buttonRed.BackColor = Color.Firebrick;
            buttonRed.Location = new Point(119, 164);
            buttonRed.Margin = new Padding(2);
            buttonRed.Name = "buttonRed";
            buttonRed.Size = new Size(96, 96);
            buttonRed.TabIndex = 4;
            buttonRed.UseVisualStyleBackColor = false;
            buttonRed.Click += buttonRed_Click;
            // 
            // buttonBlue
            // 
            buttonBlue.BackColor = Color.LightSkyBlue;
            buttonBlue.Location = new Point(5, 288);
            buttonBlue.Margin = new Padding(2);
            buttonBlue.Name = "buttonBlue";
            buttonBlue.Size = new Size(96, 96);
            buttonBlue.TabIndex = 3;
            buttonBlue.UseVisualStyleBackColor = false;
            buttonBlue.Click += buttonBlue_Click;
            // 
            // buttonBrown
            // 
            buttonBrown.BackColor = Color.DarkGoldenrod;
            buttonBrown.Location = new Point(5, 164);
            buttonBrown.Margin = new Padding(2);
            buttonBrown.Name = "buttonBrown";
            buttonBrown.Size = new Size(96, 96);
            buttonBrown.TabIndex = 2;
            buttonBrown.UseVisualStyleBackColor = false;
            buttonBrown.Click += buttonBrown_Click;
            // 
            // buttonGray
            // 
            buttonGray.BackColor = Color.LightGray;
            buttonGray.Location = new Point(119, 39);
            buttonGray.Margin = new Padding(2);
            buttonGray.Name = "buttonGray";
            buttonGray.Size = new Size(96, 96);
            buttonGray.TabIndex = 1;
            buttonGray.UseVisualStyleBackColor = false;
            buttonGray.Click += buttonGray_Click;
            // 
            // buttonGreen
            // 
            buttonGreen.BackColor = Color.Green;
            buttonGreen.Location = new Point(5, 39);
            buttonGreen.Margin = new Padding(2);
            buttonGreen.Name = "buttonGreen";
            buttonGreen.Size = new Size(96, 96);
            buttonGreen.TabIndex = 0;
            buttonGreen.UseVisualStyleBackColor = false;
            buttonGreen.Click += buttonGreen_Click;
            // 
            // groupBoxCurrent
            // 
            groupBoxCurrent.Controls.Add(pictureBoxSelected);
            groupBoxCurrent.Location = new Point(10, 402);
            groupBoxCurrent.Margin = new Padding(2);
            groupBoxCurrent.Name = "groupBoxCurrent";
            groupBoxCurrent.Padding = new Padding(2);
            groupBoxCurrent.Size = new Size(220, 164);
            groupBoxCurrent.TabIndex = 2;
            groupBoxCurrent.TabStop = false;
            groupBoxCurrent.Text = "Current Tile";
            // 
            // pictureBoxSelected
            // 
            pictureBoxSelected.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxSelected.Location = new Point(42, 24);
            pictureBoxSelected.Margin = new Padding(2);
            pictureBoxSelected.Name = "pictureBoxSelected";
            pictureBoxSelected.Size = new Size(134, 132);
            pictureBoxSelected.TabIndex = 0;
            pictureBoxSelected.TabStop = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 571);
            buttonSave.Margin = new Padding(2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(181, 110);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save File";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(30, 694);
            buttonLoad.Margin = new Padding(2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(181, 110);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load File";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 266);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 6;
            label1.Text = "Player";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 266);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 7;
            label2.Text = "Empty Floor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 142);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 8;
            label3.Text = "SR Enemy";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 17);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 9;
            label4.Text = "Wall";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 17);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 10;
            label5.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 142);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 11;
            label6.Text = "N/A";
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 814);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(groupBoxCurrent);
            Controls.Add(groupBoxTiles);
            Controls.Add(groupBoxMap);
            Margin = new Padding(2);
            Name = "Editor";
            Text = "Editor";
            FormClosing += Editor_FormClosing;
            groupBoxTiles.ResumeLayout(false);
            groupBoxTiles.PerformLayout();
            groupBoxCurrent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelected).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxMap;
        private GroupBox groupBoxTiles;
        private GroupBox groupBoxCurrent;
        private Button buttonSave;
        private Button buttonLoad;
        private Button buttonBlack;
        private Button buttonRed;
        private Button buttonBlue;
        private Button buttonBrown;
        private Button buttonGray;
        private Button buttonGreen;
        private PictureBox pictureBoxSelected;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}