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
            groupBoxCurrent = new GroupBox();
            pictureBoxSelected = new PictureBox();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonLayerChange = new Button();
            buttonGreen = new Button();
            buttonGray = new Button();
            buttonBrown = new Button();
            buttonBlue = new Button();
            buttonRed = new Button();
            buttonBlack = new Button();
            label2 = new Label();
            label6 = new Label();
            buttonPurple = new Button();
            groupBoxTiles = new GroupBox();
            groupBoxLayer = new GroupBox();
            labelLayer = new Label();
            groupBoxCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelected).BeginInit();
            groupBoxTiles.SuspendLayout();
            groupBoxLayer.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMap
            // 
            groupBoxMap.AutoSize = true;
            groupBoxMap.Location = new Point(243, 10);
            groupBoxMap.Margin = new Padding(1, 2, 1, 2);
            groupBoxMap.Name = "groupBoxMap";
            groupBoxMap.Padding = new Padding(1, 2, 1, 2);
            groupBoxMap.Size = new Size(800, 800);
            groupBoxMap.TabIndex = 0;
            groupBoxMap.TabStop = false;
            groupBoxMap.Text = "Map";
            // 
            // groupBoxCurrent
            // 
            groupBoxCurrent.Controls.Add(pictureBoxSelected);
            groupBoxCurrent.Location = new Point(9, 411);
            groupBoxCurrent.Margin = new Padding(1, 2, 1, 2);
            groupBoxCurrent.Name = "groupBoxCurrent";
            groupBoxCurrent.Padding = new Padding(1, 2, 1, 2);
            groupBoxCurrent.Size = new Size(219, 128);
            groupBoxCurrent.TabIndex = 2;
            groupBoxCurrent.TabStop = false;
            groupBoxCurrent.Text = "Current Tile";
            // 
            // pictureBoxSelected
            // 
            pictureBoxSelected.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxSelected.Location = new Point(58, 23);
            pictureBoxSelected.Margin = new Padding(1, 2, 1, 2);
            pictureBoxSelected.Name = "pictureBoxSelected";
            pictureBoxSelected.Size = new Size(101, 101);
            pictureBoxSelected.TabIndex = 0;
            pictureBoxSelected.TabStop = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(128, 718);
            buttonSave.Margin = new Padding(1, 2, 1, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(83, 76);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save File";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(30, 718);
            buttonLoad.Margin = new Padding(1, 2, 1, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(80, 76);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load File";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonLayerChange
            // 
            buttonLayerChange.Location = new Point(30, 636);
            buttonLayerChange.Margin = new Padding(3, 4, 3, 4);
            buttonLayerChange.Name = "buttonLayerChange";
            buttonLayerChange.Size = new Size(182, 76);
            buttonLayerChange.TabIndex = 5;
            buttonLayerChange.Text = "Change Layer";
            buttonLayerChange.UseVisualStyleBackColor = true;
            buttonLayerChange.Click += buttonLayerChange_Click;
            // 
            // buttonGreen
            // 
            buttonGreen.BackColor = Color.Green;
            buttonGreen.Location = new Point(5, 184);
            buttonGreen.Margin = new Padding(1, 2, 1, 2);
            buttonGreen.Name = "buttonGreen";
            buttonGreen.Size = new Size(96, 46);
            buttonGreen.TabIndex = 0;
            buttonGreen.Text = "N/A";
            buttonGreen.UseVisualStyleBackColor = false;
            buttonGreen.Click += buttonGreen_Click;
            // 
            // buttonGray
            // 
            buttonGray.BackColor = Color.LightGray;
            buttonGray.Location = new Point(119, 184);
            buttonGray.Margin = new Padding(1, 2, 1, 2);
            buttonGray.Name = "buttonGray";
            buttonGray.Size = new Size(96, 46);
            buttonGray.TabIndex = 1;
            buttonGray.Text = "Wall";
            buttonGray.UseVisualStyleBackColor = false;
            buttonGray.Click += buttonGray_Click;
            // 
            // buttonBrown
            // 
            buttonBrown.BackColor = Color.DarkGoldenrod;
            buttonBrown.Cursor = Cursors.No;
            buttonBrown.Location = new Point(5, 234);
            buttonBrown.Margin = new Padding(1, 2, 1, 2);
            buttonBrown.Name = "buttonBrown";
            buttonBrown.Size = new Size(96, 45);
            buttonBrown.TabIndex = 2;
            buttonBrown.Text = "N/A";
            buttonBrown.UseVisualStyleBackColor = false;
            buttonBrown.Click += buttonBrown_Click;
            // 
            // buttonBlue
            // 
            buttonBlue.BackColor = Color.LightSkyBlue;
            buttonBlue.Location = new Point(119, 284);
            buttonBlue.Margin = new Padding(1, 2, 1, 2);
            buttonBlue.Name = "buttonBlue";
            buttonBlue.Size = new Size(96, 65);
            buttonBlue.TabIndex = 3;
            buttonBlue.Text = "Player";
            buttonBlue.UseVisualStyleBackColor = false;
            buttonBlue.Click += buttonBlue_Click;
            // 
            // buttonRed
            // 
            buttonRed.BackColor = Color.Firebrick;
            buttonRed.Location = new Point(119, 235);
            buttonRed.Margin = new Padding(1, 2, 1, 2);
            buttonRed.Name = "buttonRed";
            buttonRed.Size = new Size(96, 45);
            buttonRed.TabIndex = 4;
            buttonRed.Text = "SR Enemy";
            buttonRed.UseVisualStyleBackColor = false;
            buttonRed.Click += buttonRed_Click;
            // 
            // buttonBlack
            // 
            buttonBlack.BackColor = Color.Black;
            buttonBlack.Location = new Point(5, 350);
            buttonBlack.Margin = new Padding(1, 2, 1, 2);
            buttonBlack.Name = "buttonBlack";
            buttonBlack.Size = new Size(96, 43);
            buttonBlack.TabIndex = 5;
            buttonBlack.UseVisualStyleBackColor = false;
            buttonBlack.Click += buttonBlack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 328);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 7;
            label2.Text = "Empty Floor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 86);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 11;
            // 
            // buttonPurple
            // 
            buttonPurple.BackColor = Color.Purple;
            buttonPurple.ForeColor = Color.Black;
            buttonPurple.Location = new Point(5, 283);
            buttonPurple.Margin = new Padding(2, 2, 2, 2);
            buttonPurple.Name = "buttonPurple";
            buttonPurple.Size = new Size(96, 43);
            buttonPurple.TabIndex = 12;
            buttonPurple.Text = "N/A";
            buttonPurple.UseVisualStyleBackColor = false;
            buttonPurple.Click += buttonPurple_Click;
            // 
            // groupBoxTiles
            // 
            groupBoxTiles.Controls.Add(buttonPurple);
            groupBoxTiles.Controls.Add(label6);
            groupBoxTiles.Controls.Add(label2);
            groupBoxTiles.Controls.Add(buttonBlack);
            groupBoxTiles.Controls.Add(buttonRed);
            groupBoxTiles.Controls.Add(buttonBlue);
            groupBoxTiles.Controls.Add(buttonBrown);
            groupBoxTiles.Controls.Add(buttonGray);
            groupBoxTiles.Controls.Add(buttonGreen);
            groupBoxTiles.Location = new Point(9, 10);
            groupBoxTiles.Margin = new Padding(1, 2, 1, 2);
            groupBoxTiles.Name = "groupBoxTiles";
            groupBoxTiles.Padding = new Padding(1, 2, 1, 2);
            groupBoxTiles.Size = new Size(219, 397);
            groupBoxTiles.TabIndex = 1;
            groupBoxTiles.TabStop = false;
            groupBoxTiles.Text = "TileSelector";
            // 
            // groupBoxLayer
            // 
            groupBoxLayer.Controls.Add(labelLayer);
            groupBoxLayer.Location = new Point(9, 543);
            groupBoxLayer.Margin = new Padding(2, 2, 2, 2);
            groupBoxLayer.Name = "groupBoxLayer";
            groupBoxLayer.Padding = new Padding(2, 2, 2, 2);
            groupBoxLayer.Size = new Size(219, 87);
            groupBoxLayer.TabIndex = 6;
            groupBoxLayer.TabStop = false;
            groupBoxLayer.Text = "Current Layer:";
            // 
            // labelLayer
            // 
            labelLayer.AutoSize = true;
            labelLayer.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelLayer.Location = new Point(34, 34);
            labelLayer.Margin = new Padding(2, 0, 2, 0);
            labelLayer.Name = "labelLayer";
            labelLayer.Size = new Size(160, 46);
            labelLayer.TabIndex = 0;
            labelLayer.Text = "Collisions";
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 814);
            Controls.Add(groupBoxLayer);
            Controls.Add(buttonLayerChange);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(groupBoxCurrent);
            Controls.Add(groupBoxTiles);
            Controls.Add(groupBoxMap);
            Margin = new Padding(1, 2, 1, 2);
            Name = "Editor";
            Text = "Editor";
            groupBoxCurrent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelected).EndInit();
            groupBoxTiles.ResumeLayout(false);
            groupBoxTiles.PerformLayout();
            groupBoxLayer.ResumeLayout(false);
            groupBoxLayer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxMap;
        private GroupBox groupBoxCurrent;
        private Button buttonSave;
        private Button buttonLoad;
        private PictureBox pictureBoxSelected;
        private Button buttonLayerChange;
        private Button buttonGreen;
        private Button buttonGray;
        private Button buttonBrown;
        private Button buttonBlue;
        private Button buttonRed;
        private Button buttonBlack;
        private Label label2;
        private Label label6;
        private Button buttonPurple;
        private GroupBox groupBoxTiles;
        private GroupBox groupBoxLayer;
        private Label labelLayer;
    }
}