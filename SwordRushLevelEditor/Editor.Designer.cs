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
            this.groupBoxMap = new System.Windows.Forms.GroupBox();
            this.groupBoxTiles = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonBrown = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.groupBoxCurrent = new System.Windows.Forms.GroupBox();
            this.pictureBoxSelected = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonLayerChange = new System.Windows.Forms.Button();
            this.groupBoxTiles.SuspendLayout();
            this.groupBoxCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.AutoSize = true;
            this.groupBoxMap.Location = new System.Drawing.Point(213, 7);
            this.groupBoxMap.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxMap.Size = new System.Drawing.Size(700, 600);
            this.groupBoxMap.TabIndex = 0;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Map";
            // 
            // groupBoxTiles
            // 
            this.groupBoxTiles.Controls.Add(this.label6);
            this.groupBoxTiles.Controls.Add(this.label5);
            this.groupBoxTiles.Controls.Add(this.label4);
            this.groupBoxTiles.Controls.Add(this.label3);
            this.groupBoxTiles.Controls.Add(this.label2);
            this.groupBoxTiles.Controls.Add(this.label1);
            this.groupBoxTiles.Controls.Add(this.buttonBlack);
            this.groupBoxTiles.Controls.Add(this.buttonRed);
            this.groupBoxTiles.Controls.Add(this.buttonBlue);
            this.groupBoxTiles.Controls.Add(this.buttonBrown);
            this.groupBoxTiles.Controls.Add(this.buttonGray);
            this.groupBoxTiles.Controls.Add(this.buttonGreen);
            this.groupBoxTiles.Location = new System.Drawing.Point(8, 7);
            this.groupBoxTiles.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxTiles.Name = "groupBoxTiles";
            this.groupBoxTiles.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxTiles.Size = new System.Drawing.Size(192, 291);
            this.groupBoxTiles.TabIndex = 1;
            this.groupBoxTiles.TabStop = false;
            this.groupBoxTiles.Text = "TileSelector";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "bottom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Wall/top";
            this.label4.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "SR Enemy/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Empty Floor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player";
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(104, 216);
            this.buttonBlack.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(84, 72);
            this.buttonBlack.TabIndex = 5;
            this.buttonBlack.UseVisualStyleBackColor = false;
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Firebrick;
            this.buttonRed.Location = new System.Drawing.Point(104, 123);
            this.buttonRed.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(84, 72);
            this.buttonRed.TabIndex = 4;
            this.buttonRed.UseVisualStyleBackColor = false;
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonBlue.Location = new System.Drawing.Point(4, 216);
            this.buttonBlue.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(84, 72);
            this.buttonBlue.TabIndex = 3;
            this.buttonBlue.UseVisualStyleBackColor = false;
            // 
            // buttonBrown
            // 
            this.buttonBrown.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonBrown.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonBrown.Location = new System.Drawing.Point(4, 123);
            this.buttonBrown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonBrown.Name = "buttonBrown";
            this.buttonBrown.Size = new System.Drawing.Size(84, 72);
            this.buttonBrown.TabIndex = 2;
            this.buttonBrown.UseVisualStyleBackColor = false;
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.Color.LightGray;
            this.buttonGray.Location = new System.Drawing.Point(104, 29);
            this.buttonGray.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(84, 72);
            this.buttonGray.TabIndex = 1;
            this.buttonGray.UseVisualStyleBackColor = false;
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(4, 29);
            this.buttonGreen.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(84, 72);
            this.buttonGreen.TabIndex = 0;
            this.buttonGreen.UseVisualStyleBackColor = false;
            // 
            // groupBoxCurrent
            // 
            this.groupBoxCurrent.Controls.Add(this.pictureBoxSelected);
            this.groupBoxCurrent.Location = new System.Drawing.Point(8, 301);
            this.groupBoxCurrent.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxCurrent.Name = "groupBoxCurrent";
            this.groupBoxCurrent.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBoxCurrent.Size = new System.Drawing.Size(192, 123);
            this.groupBoxCurrent.TabIndex = 2;
            this.groupBoxCurrent.TabStop = false;
            this.groupBoxCurrent.Text = "Current Tile";
            // 
            // pictureBoxSelected
            // 
            this.pictureBoxSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxSelected.Location = new System.Drawing.Point(36, 18);
            this.pictureBoxSelected.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureBoxSelected.Name = "pictureBoxSelected";
            this.pictureBoxSelected.Size = new System.Drawing.Size(118, 99);
            this.pictureBoxSelected.TabIndex = 0;
            this.pictureBoxSelected.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(112, 513);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 83);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(26, 513);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(70, 83);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonLayerChange
            // 
            this.buttonLayerChange.Location = new System.Drawing.Point(26, 441);
            this.buttonLayerChange.Name = "buttonLayerChange";
            this.buttonLayerChange.Size = new System.Drawing.Size(159, 57);
            this.buttonLayerChange.TabIndex = 5;
            this.buttonLayerChange.Text = "Change Layer";
            this.buttonLayerChange.UseVisualStyleBackColor = true;
            this.buttonLayerChange.Click += new System.EventHandler(this.buttonLayerChange_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 611);
            this.Controls.Add(this.buttonLayerChange);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxCurrent);
            this.Controls.Add(this.groupBoxTiles);
            this.Controls.Add(this.groupBoxMap);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Editor";
            this.Text = "Editor";
            this.groupBoxTiles.ResumeLayout(false);
            this.groupBoxTiles.PerformLayout();
            this.groupBoxCurrent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button buttonLayerChange;
    }
}