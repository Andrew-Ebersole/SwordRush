using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SwordRushLevelEditor
{
    //Joshua Leong
    //Purpose: Allows the user to edit, save, and load maps from level files
    //Requirments: uses the form class
    public partial class Editor : Form
    {
        //fields
        private Color selectedColor;
        private PictureBox[,] map;
        private bool saved;
        private int width;
        private int height;
        bool load;

        /// <summary>
        /// parameterized constructor for the editor form
        /// </summary>
        /// <param name="width">width of the map being created</param>
        /// <param name="height">height of the map being created</param>
        /// <param name="load">whether a map be being created or loaded</param>
        public Editor(int width, int height, bool load)
        {

            InitializeComponent();

            //initialize fields
            this.width = width;
            this.height = height;
            this.load = load;
            saved = true;
            map = new PictureBox[width, height];
            selectedColor = Color.Black;

            //set text and color of form and selected box
            this.Text = "Level Editor";
            pictureBoxSelected.BackColor = selectedColor;

            //creates a blank map when a new map is created
            if (!load)
            {
                int tileSize = (groupBoxMap.Size.Height - 25) / height;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        map[j, i] = new PictureBox();
                        groupBoxMap.Controls.Add(map[j, i]);
                        map[j, i].Location = new Point(j * tileSize + 10, i * tileSize + 20);
                        map[j, i].Size = new Size(tileSize, tileSize);
                        map[j, i].Click += ChangeTileColor;
                        map[j, i].BackColor = selectedColor;




                    }
                }
            }
            else //loads a new map if load was selected
            {
                LoadMap();
                this.load = false;
            }

            //sets window to auto size
            this.AutoSize = true;
        }

        /// <summary>
        /// changes selected color to green
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Green;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// chnages selected color to gray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGray_Click(object sender, EventArgs e)
        {
            selectedColor = Color.LightGray;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// changes selected color to brown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrown_Click(object sender, EventArgs e)
        {
            selectedColor = Color.DarkGoldenrod;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// changes selected color to red
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRed_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Firebrick;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// changes selected color to light blue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBlue_Click(object sender, EventArgs e)
        {
            selectedColor = Color.LightSkyBlue;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// changes selected color to black
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Black;
            pictureBoxSelected.BackColor = selectedColor;
        }

        /// <summary>
        /// sets the click tile to the selected color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTileColor(object? sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox tileReference = (PictureBox)sender;
                tileReference.BackColor = selectedColor;
                if (!this.Text.Contains("*"))
                {
                    this.Text += "*";
                }
            }
        }

        /// <summary>
        /// opens file dialog and saves current map as a level file in specified location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //open save file dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save a level file.";
            saveDialog.Filter = "Text Files|*.txt";
            saveDialog.FileName = "Level";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveDialog.OpenFile()))
                {
                    
                    //write each tile's color
                    for (int i = 0; i < map.GetLength(1); i++)
                    {
                        for (int j = 0; j < map.GetLength(0); j++)
                        {

                            if (map[j, i].BackColor == Color.Green)
                            {
                                writer.Write("0");
                            }
                            else if (map[j, i].BackColor == Color.LightGray)
                            {
                                writer.Write("1");
                            }
                            else if (map[j, i].BackColor == Color.DarkGoldenrod)
                            {
                                writer.Write("0");
                            }
                            else if (map[j, i].BackColor == Color.Firebrick)
                            {
                                writer.Write("2");
                            }
                            else if (map[j, i].BackColor == Color.LightSkyBlue)
                            {
                                writer.Write("3");
                            }
                            else if (map[j, i].BackColor == Color.Black)
                            {
                                writer.Write("0");
                            }
                            if (j < map.GetLength(0) - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        if (i < map.GetLength(1) - 1)
                        {
                            writer.Write("\n");
                        }
                    }
                }
                //show successful save message
                MessageBox.Show("File saved successfully", "File saved");

                //change window text
                if (Text.Contains("*"))
                {
                    Text = Text.Substring(0, Text.IndexOf("*"));
                }
            }
        }

        /// <summary>
        /// runs load method when load button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {

            LoadMap();

        }

        /// <summary>
        /// checks if there are unsaved changes when closing form and warns user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you want to quit?",
                "Unsaved changes", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        }


        /// <summary>
        /// loads a map from a file and replaces old map
        /// </summary>
        private void LoadMap()
        {


            //open file dialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open a level file.";
            fileDialog.Filter = "Text Files|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //delete old array
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        groupBoxMap.Controls.Remove(map[j, i]);
                    }
                }



                //read file
                using (StreamReader reader = new StreamReader(fileDialog.OpenFile()))
                {
                    //create new picture box array
                    map = new PictureBox[width, height];
                    int tileSize = (groupBoxMap.Size.Height - 25) / height;
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            map[j, i] = new PictureBox();
                            groupBoxMap.Controls.Add(map[j, i]);
                            map[j, i].Location = new Point(j * tileSize + 10, i * tileSize + 20);
                            map[j, i].Size = new Size(tileSize, tileSize);
                            map[j, i].Click += ChangeTileColor;
                        }
                    }




                    //color new tiles
                    string[][] tiles = new string[height][];
                    for (int i = 0; i < height; i++)
                    {
                        tiles[i] = reader.ReadLine()!.Split(",");
                        for (int j = 0; j < width; j++)
                        {
                            if (tiles[i][j] == "4")
                            {
                                map[j, i].BackColor = Color.Green;
                            }
                            else if (tiles[i][j] == "1")
                            {
                                map[j, i].BackColor = Color.LightGray;
                            }
                            else if (tiles[i][j] == "5")
                            {
                                map[j, i].BackColor = Color.DarkGoldenrod;
                            }
                            else if (tiles[i][j] == "2")
                            {
                                map[j, i].BackColor = Color.Firebrick;
                            }
                            else if (tiles[i][j] == "3")
                            {
                                map[j, i].BackColor = Color.LightSkyBlue;
                            }
                            else if (tiles[i][j] == "0")
                            {
                                map[j, i].BackColor = Color.Black;
                            }
                        }
                    }
                }

                //change window text
                if (Text.Contains("*"))
                {
                    Text = Text.Substring(0, Text.IndexOf("*"));
                }
                if (!Text.Contains("-"))
                {
                    Text += $" - {fileDialog.SafeFileName}";
                }

                //show completion message
                MessageBox.Show("File loaded successfully", "File loaded");

            }
            else if (load)//if load is canceled close form
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
