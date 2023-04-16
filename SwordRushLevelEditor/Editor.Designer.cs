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
            this.groupBoxCurrent = new System.Windows.Forms.GroupBox();
            this.pictureBoxSelected = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonLayerChange = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonGray = new System.Windows.Forms.Button();
            this.buttonBrown = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonPurple = new System.Windows.Forms.Button();
            this.groupBoxTiles = new System.Windows.Forms.GroupBox();
            this.groupBoxLayer = new System.Windows.Forms.GroupBox();
            this.labelLayer = new System.Windows.Forms.Label();
            this.groupBoxCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).BeginInit();
            this.groupBoxTiles.SuspendLayout();
            this.groupBoxLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.AutoSize = true;
            this.groupBoxMap.Location = new System.Drawing.Point(304, 12);
            this.groupBoxMap.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxMap.Size = new System.Drawing.Size(1000, 1000);
            this.groupBoxMap.TabIndex = 0;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Map";
            // 
            // groupBoxCurrent
            // 
            this.groupBoxCurrent.Controls.Add(this.pictureBoxSelected);
            this.groupBoxCurrent.Location = new System.Drawing.Point(11, 384);
            this.groupBoxCurrent.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxCurrent.Name = "groupBoxCurrent";
            this.groupBoxCurrent.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxCurrent.Size = new System.Drawing.Size(274, 205);
            this.groupBoxCurrent.TabIndex = 2;
            this.groupBoxCurrent.TabStop = false;
            this.groupBoxCurrent.Text = "Current Tile";
            // 
            // pictureBoxSelected
            // 
            this.pictureBoxSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxSelected.Location = new System.Drawing.Point(51, 30);
            this.pictureBoxSelected.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBoxSelected.Name = "pictureBoxSelected";
            this.pictureBoxSelected.Size = new System.Drawing.Size(169, 165);
            this.pictureBoxSelected.TabIndex = 0;
            this.pictureBoxSelected.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(160, 855);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 138);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(37, 855);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(100, 138);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load File";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonLayerChange
            // 
            this.buttonLayerChange.Location = new System.Drawing.Point(37, 735);
            this.buttonLayerChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLayerChange.Name = "buttonLayerChange";
            this.buttonLayerChange.Size = new System.Drawing.Size(227, 95);
            this.buttonLayerChange.TabIndex = 5;
            this.buttonLayerChange.Text = "Change Layer";
            this.buttonLayerChange.UseVisualStyleBackColor = true;
            this.buttonLayerChange.Click += new System.EventHandler(this.buttonLayerChange_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(6, 48);
            this.buttonGreen.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(120, 58);
            this.buttonGreen.TabIndex = 0;
            this.buttonGreen.Text = "N/A";
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.Color.LightGray;
            this.buttonGray.Location = new System.Drawing.Point(149, 48);
            this.buttonGray.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.Size = new System.Drawing.Size(120, 58);
            this.buttonGray.TabIndex = 1;
            this.buttonGray.Text = "Wall";
            this.buttonGray.UseVisualStyleBackColor = false;
            this.buttonGray.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // buttonBrown
            // 
            this.buttonBrown.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonBrown.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonBrown.Location = new System.Drawing.Point(6, 135);
            this.buttonBrown.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonBrown.Name = "buttonBrown";
            this.buttonBrown.Size = new System.Drawing.Size(120, 56);
            this.buttonBrown.TabIndex = 2;
            this.buttonBrown.Text = "N/A";
            this.buttonBrown.UseVisualStyleBackColor = false;
            this.buttonBrown.Click += new System.EventHandler(this.buttonBrown_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonBlue.Location = new System.Drawing.Point(149, 220);
            this.buttonBlue.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(120, 81);
            this.buttonBlue.TabIndex = 3;
            this.buttonBlue.Text = "Player";
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Firebrick;
            this.buttonRed.Location = new System.Drawing.Point(149, 135);
            this.buttonRed.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(120, 56);
            this.buttonRed.TabIndex = 4;
            this.buttonRed.Text = "SR Enemy";
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(6, 303);
            this.buttonBlack.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(120, 54);
            this.buttonBlack.TabIndex = 5;
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonBlack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Empty Floor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 11;
            // 
            // buttonPurple
            // 
            this.buttonPurple.BackColor = System.Drawing.Color.Purple;
            this.buttonPurple.ForeColor = System.Drawing.Color.Black;
            this.buttonPurple.Location = new System.Drawing.Point(6, 220);
            this.buttonPurple.Name = "buttonPurple";
            this.buttonPurple.Size = new System.Drawing.Size(120, 54);
            this.buttonPurple.TabIndex = 12;
            this.buttonPurple.Text = "N/A";
            this.buttonPurple.UseVisualStyleBackColor = false;
            this.buttonPurple.Click += new System.EventHandler(this.buttonPurple_Click);
            // 
            // groupBoxTiles
            // 
            this.groupBoxTiles.Controls.Add(this.buttonPurple);
            this.groupBoxTiles.Controls.Add(this.label6);
            this.groupBoxTiles.Controls.Add(this.label2);
            this.groupBoxTiles.Controls.Add(this.buttonBlack);
            this.groupBoxTiles.Controls.Add(this.buttonRed);
            this.groupBoxTiles.Controls.Add(this.buttonBlue);
            this.groupBoxTiles.Controls.Add(this.buttonBrown);
            this.groupBoxTiles.Controls.Add(this.buttonGray);
            this.groupBoxTiles.Controls.Add(this.buttonGreen);
            this.groupBoxTiles.Location = new System.Drawing.Point(11, 12);
            this.groupBoxTiles.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxTiles.Name = "groupBoxTiles";
            this.groupBoxTiles.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBoxTiles.Size = new System.Drawing.Size(274, 368);
            this.groupBoxTiles.TabIndex = 1;
            this.groupBoxTiles.TabStop = false;
            this.groupBoxTiles.Text = "TileSelector";
            // 
            // groupBoxLayer
            // 
            this.groupBoxLayer.Controls.Add(this.labelLayer);
            this.groupBoxLayer.Location = new System.Drawing.Point(11, 603);
            this.groupBoxLayer.Name = "groupBoxLayer";
            this.groupBoxLayer.Size = new System.Drawing.Size(274, 109);
            this.groupBoxLayer.TabIndex = 6;
            this.groupBoxLayer.TabStop = false;
            this.groupBoxLayer.Text = "Current Layer:";
            // 
            // labelLayer
            // 
            this.labelLayer.AutoSize = true;
            this.labelLayer.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLayer.Location = new System.Drawing.Point(42, 42);
            this.labelLayer.Name = "labelLayer";
            this.labelLayer.Size = new System.Drawing.Size(191, 54);
            this.labelLayer.TabIndex = 0;
            this.labelLayer.Text = "Collisions";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 1018);
            this.Controls.Add(this.groupBoxLayer);
            this.Controls.Add(this.buttonLayerChange);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxCurrent);
            this.Controls.Add(this.groupBoxTiles);
            this.Controls.Add(this.groupBoxMap);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Editor";
            this.Text = "Editor";
            this.groupBoxCurrent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).EndInit();
            this.groupBoxTiles.ResumeLayout(false);
            this.groupBoxTiles.PerformLayout();
            this.groupBoxLayer.ResumeLayout(false);
            this.groupBoxLayer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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