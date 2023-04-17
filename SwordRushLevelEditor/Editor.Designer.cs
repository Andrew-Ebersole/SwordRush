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
            buttonAqua = new Button();
            buttonPink = new Button();
            buttonOlive = new Button();
            buttonIndigo = new Button();
            buttonTan = new Button();
            buttonGold = new Button();
            buttonTeal = new Button();
            buttonOrange = new Button();
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
            groupBoxMap.Location = new Point(213, 8);
            groupBoxMap.Margin = new Padding(1, 2, 1, 2);
            groupBoxMap.Name = "groupBoxMap";
            groupBoxMap.Padding = new Padding(1, 2, 1, 2);
            groupBoxMap.Size = new Size(700, 600);
            groupBoxMap.TabIndex = 0;
            groupBoxMap.TabStop = false;
            groupBoxMap.Text = "Map";
            // 
            // groupBoxCurrent
            // 
            groupBoxCurrent.Controls.Add(pictureBoxSelected);
            groupBoxCurrent.Location = new Point(9, 322);
            groupBoxCurrent.Margin = new Padding(1, 2, 1, 2);
            groupBoxCurrent.Name = "groupBoxCurrent";
            groupBoxCurrent.Padding = new Padding(1, 2, 1, 2);
            groupBoxCurrent.Size = new Size(192, 96);
            groupBoxCurrent.TabIndex = 2;
            groupBoxCurrent.TabStop = false;
            groupBoxCurrent.Text = "Current Tile";
            // 
            // pictureBoxSelected
            // 
            pictureBoxSelected.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxSelected.Location = new Point(51, 17);
            pictureBoxSelected.Margin = new Padding(1, 2, 1, 2);
            pictureBoxSelected.Name = "pictureBoxSelected";
            pictureBoxSelected.Size = new Size(88, 76);
            pictureBoxSelected.TabIndex = 0;
            pictureBoxSelected.TabStop = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(112, 538);
            buttonSave.Margin = new Padding(1, 2, 1, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(73, 57);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Save File";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(26, 538);
            buttonLoad.Margin = new Padding(1, 2, 1, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(70, 57);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load File";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonLayerChange
            // 
            buttonLayerChange.Location = new Point(26, 477);
            buttonLayerChange.Name = "buttonLayerChange";
            buttonLayerChange.Size = new Size(159, 57);
            buttonLayerChange.TabIndex = 5;
            buttonLayerChange.Text = "Change Layer";
            buttonLayerChange.UseVisualStyleBackColor = true;
            buttonLayerChange.Click += buttonLayerChange_Click;
            // 
            // buttonGreen
            // 
            buttonGreen.BackColor = Color.Green;
            buttonGreen.Location = new Point(4, 129);
            buttonGreen.Margin = new Padding(1, 2, 1, 2);
            buttonGreen.Name = "buttonGreen";
            buttonGreen.Size = new Size(84, 34);
            buttonGreen.TabIndex = 0;
            buttonGreen.Text = "N/A";
            buttonGreen.UseVisualStyleBackColor = false;
            buttonGreen.Click += buttonGreen_Click;
            // 
            // buttonGray
            // 
            buttonGray.BackColor = Color.LightGray;
            buttonGray.Location = new Point(104, 129);
            buttonGray.Margin = new Padding(1, 2, 1, 2);
            buttonGray.Name = "buttonGray";
            buttonGray.Size = new Size(84, 34);
            buttonGray.TabIndex = 1;
            buttonGray.Text = "Wall";
            buttonGray.UseVisualStyleBackColor = false;
            buttonGray.Click += buttonGray_Click;
            // 
            // buttonBrown
            // 
            buttonBrown.BackColor = Color.DarkGoldenrod;
            buttonBrown.Cursor = Cursors.No;
            buttonBrown.Location = new Point(4, 166);
            buttonBrown.Margin = new Padding(1, 2, 1, 2);
            buttonBrown.Name = "buttonBrown";
            buttonBrown.Size = new Size(84, 34);
            buttonBrown.TabIndex = 2;
            buttonBrown.Text = "LR Enemy";
            buttonBrown.UseVisualStyleBackColor = false;
            buttonBrown.Click += buttonBrown_Click;
            // 
            // buttonBlue
            // 
            buttonBlue.BackColor = Color.LightSkyBlue;
            buttonBlue.Location = new Point(104, 204);
            buttonBlue.Margin = new Padding(1, 2, 1, 2);
            buttonBlue.Name = "buttonBlue";
            buttonBlue.Size = new Size(84, 32);
            buttonBlue.TabIndex = 3;
            buttonBlue.Text = "Player";
            buttonBlue.UseVisualStyleBackColor = false;
            buttonBlue.Click += buttonBlue_Click;
            // 
            // buttonRed
            // 
            buttonRed.BackColor = Color.Firebrick;
            buttonRed.Location = new Point(104, 167);
            buttonRed.Margin = new Padding(1, 2, 1, 2);
            buttonRed.Name = "buttonRed";
            buttonRed.Size = new Size(84, 34);
            buttonRed.TabIndex = 4;
            buttonRed.Text = "SR Enemy";
            buttonRed.UseVisualStyleBackColor = false;
            buttonRed.Click += buttonRed_Click;
            // 
            // buttonBlack
            // 
            buttonBlack.BackColor = Color.Black;
            buttonBlack.Location = new Point(4, 262);
            buttonBlack.Margin = new Padding(1, 2, 1, 2);
            buttonBlack.Name = "buttonBlack";
            buttonBlack.Size = new Size(84, 32);
            buttonBlack.TabIndex = 5;
            buttonBlack.UseVisualStyleBackColor = false;
            buttonBlack.Click += buttonBlack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 246);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 7;
            label2.Text = "Empty Floor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 64);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 11;
            // 
            // buttonPurple
            // 
            buttonPurple.BackColor = Color.Purple;
            buttonPurple.ForeColor = Color.Black;
            buttonPurple.Location = new Point(4, 203);
            buttonPurple.Margin = new Padding(2);
            buttonPurple.Name = "buttonPurple";
            buttonPurple.Size = new Size(84, 32);
            buttonPurple.TabIndex = 12;
            buttonPurple.Text = "N/A";
            buttonPurple.UseVisualStyleBackColor = false;
            buttonPurple.Click += buttonPurple_Click;
            // 
            // groupBoxTiles
            // 
            groupBoxTiles.Controls.Add(buttonAqua);
            groupBoxTiles.Controls.Add(buttonPink);
            groupBoxTiles.Controls.Add(buttonOlive);
            groupBoxTiles.Controls.Add(buttonIndigo);
            groupBoxTiles.Controls.Add(buttonTan);
            groupBoxTiles.Controls.Add(buttonGold);
            groupBoxTiles.Controls.Add(buttonTeal);
            groupBoxTiles.Controls.Add(buttonOrange);
            groupBoxTiles.Controls.Add(buttonPurple);
            groupBoxTiles.Controls.Add(label6);
            groupBoxTiles.Controls.Add(label2);
            groupBoxTiles.Controls.Add(buttonBlack);
            groupBoxTiles.Controls.Add(buttonRed);
            groupBoxTiles.Controls.Add(buttonBlue);
            groupBoxTiles.Controls.Add(buttonBrown);
            groupBoxTiles.Controls.Add(buttonGray);
            groupBoxTiles.Controls.Add(buttonGreen);
            groupBoxTiles.Location = new Point(8, 8);
            groupBoxTiles.Margin = new Padding(1, 2, 1, 2);
            groupBoxTiles.Name = "groupBoxTiles";
            groupBoxTiles.Padding = new Padding(1, 2, 1, 2);
            groupBoxTiles.Size = new Size(192, 311);
            groupBoxTiles.TabIndex = 1;
            groupBoxTiles.TabStop = false;
            groupBoxTiles.Text = "TileSelector";
            // 
            // buttonAqua
            // 
            buttonAqua.BackColor = Color.Aquamarine;
            buttonAqua.Location = new Point(104, 275);
            buttonAqua.Margin = new Padding(3, 2, 3, 2);
            buttonAqua.Name = "buttonAqua";
            buttonAqua.Size = new Size(82, 32);
            buttonAqua.TabIndex = 18;
            buttonAqua.Text = "N/A";
            buttonAqua.UseVisualStyleBackColor = false;
            buttonAqua.Click += buttonAqua_Click;
            // 
            // buttonPink
            // 
            buttonPink.BackColor = Color.Pink;
            buttonPink.Location = new Point(104, 239);
            buttonPink.Margin = new Padding(3, 2, 3, 2);
            buttonPink.Name = "buttonPink";
            buttonPink.Size = new Size(82, 32);
            buttonPink.TabIndex = 17;
            buttonPink.Text = "N/A";
            buttonPink.UseVisualStyleBackColor = false;
            buttonPink.Click += buttonPink_Click;
            // 
            // buttonOlive
            // 
            buttonOlive.BackColor = Color.Olive;
            buttonOlive.Location = new Point(104, 16);
            buttonOlive.Margin = new Padding(3, 2, 3, 2);
            buttonOlive.Name = "buttonOlive";
            buttonOlive.Size = new Size(82, 34);
            buttonOlive.TabIndex = 16;
            buttonOlive.Text = "N/A";
            buttonOlive.UseVisualStyleBackColor = false;
            buttonOlive.Click += buttonOlive_Click;
            // 
            // buttonIndigo
            // 
            buttonIndigo.BackColor = Color.Indigo;
            buttonIndigo.Location = new Point(6, 16);
            buttonIndigo.Margin = new Padding(3, 2, 3, 2);
            buttonIndigo.Name = "buttonIndigo";
            buttonIndigo.Size = new Size(82, 34);
            buttonIndigo.TabIndex = 15;
            buttonIndigo.Text = "N/A";
            buttonIndigo.UseVisualStyleBackColor = false;
            buttonIndigo.Click += buttonIndigo_Click;
            // 
            // buttonTan
            // 
            buttonTan.BackColor = Color.Tan;
            buttonTan.Location = new Point(106, 56);
            buttonTan.Margin = new Padding(3, 2, 3, 2);
            buttonTan.Name = "buttonTan";
            buttonTan.Size = new Size(82, 34);
            buttonTan.TabIndex = 14;
            buttonTan.Text = "N/A";
            buttonTan.UseVisualStyleBackColor = false;
            buttonTan.Click += buttonTan_Click;
            // 
            // buttonGold
            // 
            buttonGold.BackColor = Color.Gold;
            buttonGold.Location = new Point(6, 56);
            buttonGold.Margin = new Padding(3, 2, 3, 2);
            buttonGold.Name = "buttonGold";
            buttonGold.Size = new Size(82, 34);
            buttonGold.TabIndex = 13;
            buttonGold.Text = "N/A";
            buttonGold.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonGold.UseVisualStyleBackColor = false;
            buttonGold.Click += buttonGold_Click;
            // 
            // buttonTeal
            // 
            buttonTeal.BackColor = Color.Teal;
            buttonTeal.Location = new Point(106, 91);
            buttonTeal.Margin = new Padding(3, 2, 3, 2);
            buttonTeal.Name = "buttonTeal";
            buttonTeal.Size = new Size(82, 34);
            buttonTeal.TabIndex = 0;
            buttonTeal.Text = "N/A";
            buttonTeal.UseVisualStyleBackColor = false;
            buttonTeal.Click += buttonTeal_Click;
            // 
            // buttonOrange
            // 
            buttonOrange.BackColor = Color.Orange;
            buttonOrange.Location = new Point(6, 91);
            buttonOrange.Margin = new Padding(3, 2, 3, 2);
            buttonOrange.Name = "buttonOrange";
            buttonOrange.Size = new Size(82, 34);
            buttonOrange.TabIndex = 0;
            buttonOrange.Text = "N/A";
            buttonOrange.UseVisualStyleBackColor = false;
            buttonOrange.Click += buttonOrange_Click;
            // 
            // groupBoxLayer
            // 
            groupBoxLayer.Controls.Add(labelLayer);
            groupBoxLayer.Location = new Point(8, 421);
            groupBoxLayer.Margin = new Padding(2);
            groupBoxLayer.Name = "groupBoxLayer";
            groupBoxLayer.Padding = new Padding(2);
            groupBoxLayer.Size = new Size(192, 52);
            groupBoxLayer.TabIndex = 6;
            groupBoxLayer.TabStop = false;
            groupBoxLayer.Text = "Current Layer:";
            // 
            // labelLayer
            // 
            labelLayer.AutoSize = true;
            labelLayer.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelLayer.Location = new Point(28, 16);
            labelLayer.Margin = new Padding(2, 0, 2, 0);
            labelLayer.Name = "labelLayer";
            labelLayer.Size = new Size(131, 37);
            labelLayer.TabIndex = 0;
            labelLayer.Text = "Collisions";
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 610);
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
        private Button buttonOrange;
        private Button buttonTeal;
        private Button buttonOlive;
        private Button buttonIndigo;
        private Button buttonTan;
        private Button buttonGold;
        private Button buttonAqua;
        private Button buttonPink;
    }
}