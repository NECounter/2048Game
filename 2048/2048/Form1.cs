using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class GameMain : Form
    {
        public GameMain()
        {
            InitializeComponent();
        }

        private Button[,] blocks = new Button[4, 4];  //面板上方块的集合
        private bool isStart = false;  //游戏是否开始

        /// <summary>
        /// 程序启动时加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameMain_Load(object sender, EventArgs e)
        {
            for(int i = 0; i<=15; i++)
            {
                Button btm = new Button();
                btm.Dock = DockStyle.Fill;
                btm.Font = new Font("微软雅黑", 38F, FontStyle.Bold, GraphicsUnit.Point, 134);
                btm.Text = (i + 1).ToString();
                btm.BackColor = Color.White;
                Gamepad.Controls.Add(btm, i % 4, i / 4);
                blocks[i / 4, i % 4] = btm;
            }
            ColorChange(blocks);
        }

        /// <summary>
        /// 重写ProcessCmdKey，让窗体响应按键事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(isStart == false)//没有开始游戏，不响应按键
            {
                return false;
            }
            
            if (GameOver(blocks) == true) //游戏结束弹窗
            {
                MessageBox.Show("游戏结束啦！");
                isStart = false;
                return false;
            }

            if (keyData == Keys.Up) //上
            {
                UpKey(blocks);
            }
            if (keyData == Keys.Down) //下
            {
                DownKey(blocks);
            }
            if (keyData == Keys.Left) //左
            {
                LeftKey(blocks);
            }

            if (keyData == Keys.Right) //右
            {
                RightKey(blocks);
            }

            return true;

        }

        /// <summary>
        /// 点击开始游戏，清空面板，并且随机出现一个方块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear(blocks);
            RandomShow(blocks);
            ColorChange(blocks);
            isStart = true;
        }

        /// <summary>
        /// 根据数值，改变颜色
        /// </summary>
        /// <param name="blocks"></param>
        private void ColorChange(Button[,] blocks)
        {
            for(int i = 0; i<=3; i++)
            {
                for(int j = 0; j <=3; j++)
                {
                    switch (blocks[i,j].Text)
                    {
                        case "2": blocks[i,j].BackColor = Color.LightBlue; break;
                        case "4": blocks[i, j].BackColor = Color.MediumTurquoise; break;
                        case "8": blocks[i, j].BackColor = Color.DarkTurquoise; break;
                        case "16": blocks[i, j].BackColor = Color.Cyan; break;
                        case "32": blocks[i, j].BackColor = Color.LightSeaGreen; break;
                        case "64": blocks[i, j].BackColor = Color.MediumSeaGreen; break;
                        case "128": blocks[i, j].BackColor = Color.RoyalBlue; break;
                        case "256": blocks[i, j].BackColor = Color.Navy; break;
                        case "512": blocks[i, j].BackColor = Color.SlateBlue; break;
                        case "1024": blocks[i, j].BackColor = Color.DarkSlateBlue; break;
                        case "2048": blocks[i, j].BackColor = Color.Red; break;
                        case "4096": blocks[i, j].BackColor = Color.Firebrick; break;
                        case "8192": blocks[i, j].BackColor = Color.Maroon; break;
                        case "16384": blocks[i, j].BackColor = Color.Purple; break;
                        default:
                            blocks[i, j].BackColor = Color.White; //缺省颜色为白色
                            break;
                    }
                }
            }      
        }

        /// <summary>
        /// 随机出现方块
        /// </summary>
        /// <param name="blocks"></param>
        private void RandomShow(Button[,] blocks)
        {
            if(blocks[0, 0].Text != "" &&
               blocks[0, 1].Text != "" &&
               blocks[0, 2].Text != "" &&
               blocks[0, 3].Text != "" &&
               blocks[1, 0].Text != "" &&
               blocks[1, 1].Text != "" &&
               blocks[1, 2].Text != "" &&
               blocks[1, 3].Text != "" &&
               blocks[2, 0].Text != "" &&
               blocks[2, 1].Text != "" &&
               blocks[2, 2].Text != "" &&
               blocks[2, 3].Text != "" &&
               blocks[3, 0].Text != "" &&
               blocks[3, 1].Text != "" &&
               blocks[3, 2].Text != "" &&
               blocks[3, 3].Text != "")  //填满之后不出现方块
            {
                return;
            }
            

            Random rdm = new Random(); //新随机数算子
            int rdmBlockIndex = 0;  //随机方块索引
            do
            {
                rdmBlockIndex = rdm.Next(16);

            } while (blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text != "");  //产生随机数，直到随机索引所在的方块没有被占用

            switch (rdm.Next(0, 10)) //出现2，4 的比率为 4：1
            {
                case 0:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2";break;
                case 1:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 2:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 3:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 4:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "4"; break;
                case 5:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 6:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 7:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                case 8:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "4"; break;
                case 9:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2"; break;
                default:
                    blocks[rdmBlockIndex / 4, rdmBlockIndex % 4].Text = "2";
                    break;
            }      
        }

        /// <summary>
        /// 清除所有方块
        /// </summary>
        /// <param name="blocks"></param>
        private void Clear(Button[,] blocks)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    blocks[i, j].Text = "";        
                }
            }
        }

        /// <summary>
        /// 方向上
        /// </summary>
        /// <param name="blocks"></param>
        private void UpKey(Button[,] blocks)
        {
            for(int i = 1; i <= 3; i++)
            {
                for(int j = 0; j <= 3; j++)
                {
                    if(i == 1)
                    {
                        if (blocks[i - 1, j].Text == "")
                        {
                            blocks[i - 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == blocks[i, j].Text)
                        {
                            if (blocks[i, j].Text != "")
                            {
                                blocks[i - 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            }
                            blocks[i, j].Text = "";
                        }
                    }
                    if(i == 2)
                    {
                        if(blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text == "")
                        {
                            blocks[i - 2, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text != "" && blocks[i, j].Text != blocks[i - 2, j].Text)
                        {
                            blocks[i - 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text != "" && blocks[i, j].Text == blocks[i - 2, j].Text)
                        {
                            blocks[i - 2, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text != "" && blocks[i - 2, j].Text != "" && blocks[i, j].Text == blocks[i - 1, j].Text)
                        {
                            blocks[i - 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                    if(i == 3)
                    {
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text == "" && blocks[i - 3, j].Text == "")
                        {
                            blocks[i - 3, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text == "" && blocks[i - 3, j].Text != "" && blocks[i, j].Text != blocks[i - 3, j].Text)
                        {
                            blocks[i - 2, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text == "" && blocks[i - 3, j].Text != "" && blocks[i, j].Text == blocks[i - 3, j].Text)
                        {
                            blocks[i - 3, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text != "" && blocks[i - 3, j].Text != "" && blocks[i, j].Text != blocks[i - 2, j].Text)
                        {
                            blocks[i - 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text == "" && blocks[i - 2, j].Text != "" && blocks[i - 3, j].Text != "" && blocks[i, j].Text == blocks[i - 2, j].Text)
                        {
                            blocks[i - 2, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i - 1, j].Text != "" && blocks[i - 2, j].Text != "" && blocks[i - 3, j].Text != "" && blocks[i, j].Text == blocks[i - 1, j].Text)
                        {
                            blocks[i - 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }
                   
                }
            }
            RandomShow(blocks);
            ColorChange(blocks);
        }

        /// <summary>
        /// 方向下
        /// </summary>
        /// <param name="blocks"></param>
        private void DownKey(Button[,] blocks)
        {
            for (int i = 2; i>= 0; i--)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (i == 2)
                    {
                        if (blocks[i + 1, j].Text == "")
                        {
                            blocks[i + 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == blocks[i, j].Text)
                        {
                            if (blocks[i, j].Text != "")
                            {
                                blocks[i + 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            }
                            blocks[i, j].Text = "";
                        }
                    }
                    if (i == 1)
                    {
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text == "")
                        {
                            blocks[i + 2, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text != "" && blocks[i, j].Text != blocks[i + 2, j].Text)
                        {
                            blocks[i + 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text != "" && blocks[i, j].Text == blocks[i + 2, j].Text)
                        {
                            blocks[i + 2, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text != "" && blocks[i + 2, j].Text != "" && blocks[i, j].Text == blocks[i + 1, j].Text)
                        {
                            blocks[i + 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                    if (i == 0)
                    {
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text == "" && blocks[i + 3, j].Text == "")
                        {
                            blocks[i + 3, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text == "" && blocks[i + 3, j].Text != "" && blocks[i, j].Text != blocks[i + 3, j].Text)
                        {
                            blocks[i + 2, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text == "" && blocks[i + 3, j].Text != "" && blocks[i, j].Text == blocks[i + 3, j].Text)
                        {
                            blocks[i + 3, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text != "" && blocks[i + 3, j].Text != "" && blocks[i, j].Text != blocks[i + 2, j].Text)
                        {
                            blocks[i + 1, j].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text == "" && blocks[i + 2, j].Text != "" && blocks[i + 3, j].Text != "" && blocks[i, j].Text == blocks[i + 2, j].Text)
                        {
                            blocks[i + 2, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i + 1, j].Text != "" && blocks[i + 2, j].Text != "" && blocks[i + 3, j].Text != "" && blocks[i, j].Text == blocks[i + 1, j].Text)
                        {
                            blocks[i + 1, j].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                }
            }
            RandomShow(blocks);
            ColorChange(blocks);
        }

        /// <summary>
        /// 方向左
        /// </summary>
        /// <param name="blocks"></param>
        private void LeftKey(Button[,] blocks)
        {
            for (int j = 1; j <= 3; j++)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (j == 1)
                    {
                        if (blocks[i, j - 1].Text == "")
                        {
                            blocks[i, j - 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == blocks[i, j].Text)
                        {
                            if (blocks[i, j].Text != "")
                            {
                                blocks[i, j - 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            }
                            blocks[i, j].Text = "";
                        }
                    }
                    if (j == 2)
                    {
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text == "")
                        {
                            blocks[i, j - 2].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text != "" && blocks[i, j].Text != blocks[i, j - 2].Text)
                        {
                            blocks[i, j - 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text != "" && blocks[i, j].Text == blocks[i, j - 2].Text)
                        {
                            blocks[i, j - 2].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text != "" && blocks[i, j - 2].Text != "" && blocks[i, j].Text == blocks[i, j - 1].Text)
                        {
                            blocks[i, j - 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                    if (j == 3)
                    {
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text == "" && blocks[i, j - 3].Text == "")
                        {
                            blocks[i, j - 3].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text == "" && blocks[i, j - 3].Text != "" && blocks[i, j].Text != blocks[i, j - 3].Text)
                        {
                            blocks[i, j - 2].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text == "" && blocks[i, j - 3].Text != "" && blocks[i, j].Text == blocks[i, j - 3].Text)
                        {
                            blocks[i, j - 3].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text != "" && blocks[i, j - 3].Text != "" && blocks[i, j].Text != blocks[i, j - 2].Text)
                        {
                            blocks[i, j - 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text == "" && blocks[i, j - 2].Text != "" && blocks[i, j - 3].Text != "" && blocks[i, j].Text == blocks[i, j - 2].Text)
                        {
                            blocks[i, j - 2].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j - 1].Text != "" && blocks[i, j - 2].Text != "" && blocks[i, j - 3].Text != "" && blocks[i, j].Text == blocks[i, j - 1].Text)
                        {
                            blocks[i, j - 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                }
            }
            RandomShow(blocks);
            ColorChange(blocks);
        }

        /// <summary>
        /// 方向右
        /// </summary>
        /// <param name="blocks"></param>
        private void RightKey(Button[,] blocks)
        {
            for (int j = 2; j >= 0; j--)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (j == 2)
                    {
                        if (blocks[i, j + 1].Text == "")
                        {
                            blocks[i, j + 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == blocks[i, j].Text)
                        {
                            if (blocks[i, j].Text != "")
                            {
                                blocks[i, j + 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            }
                            blocks[i, j].Text = "";
                        }
                    }
                    if (j == 1)
                    {
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text == "")
                        {
                            blocks[i, j + 2].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text != "" && blocks[i, j].Text != blocks[i, j + 2].Text)
                        {
                            blocks[i, j + 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text != "" && blocks[i, j].Text == blocks[i, j + 2].Text)
                        {
                            blocks[i, j + 2].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text != "" && blocks[i, j + 2].Text != "" && blocks[i, j].Text == blocks[i, j + 1].Text)
                        {
                            blocks[i, j + 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                    if (j == 0)
                    {
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text == "" && blocks[i, j + 3].Text == "")
                        {
                            blocks[i, j + 3].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text == "" && blocks[i, j + 3].Text != "" && blocks[i, j].Text != blocks[i, j + 3].Text)
                        {
                            blocks[i, j + 2].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text == "" && blocks[i, j + 3].Text != "" && blocks[i, j].Text == blocks[i, j + 3].Text)
                        {
                            blocks[i, j + 3].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text != "" && blocks[i, j + 3].Text != "" && blocks[i, j].Text != blocks[i, j + 2].Text)
                        {
                            blocks[i, j + 1].Text = blocks[i, j].Text;
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text == "" && blocks[i, j + 2].Text != "" && blocks[i, j + 3].Text != "" && blocks[i, j].Text == blocks[i, j + 2].Text)
                        {
                            blocks[i, j + 2].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                        if (blocks[i, j + 1].Text != "" && blocks[i, j + 2].Text != "" && blocks[i, j + 3].Text != "" && blocks[i, j].Text == blocks[i, j + 1].Text)
                        {
                            blocks[i, j + 1].Text = (2 * Convert.ToInt16(blocks[i, j].Text)).ToString();
                            blocks[i, j].Text = "";
                        }
                    }

                }
            }
            RandomShow(blocks);
            ColorChange(blocks);
        }

        /// <summary>
        /// 游戏结束判断
        /// </summary>
        /// <param name="blocks"></param>
        /// <returns></returns>
        private bool GameOver(Button[,] blocks)
        {
            bool isGameOver = true;
            for (int i = 0; i <= 3; i++) 
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (blocks[i, j].Text == "") //如果还有空余的方块，直接判定游戏未结束并退出结束判断
                    {
                        return false;
                    }
                    
                }

            }

            for (int i = 1; i <= 2; i++) //判断两两相邻的方块里的数字都不相等，即为游戏结束
            {
                for (int j = 1; j <= 2; j++) 
                {
                    if (blocks[i, j].Text == blocks[i + 1, j].Text || 
                        blocks[i, j].Text == blocks[i - 1, j].Text || 
                        blocks[i, j].Text == blocks[i, j + 1].Text ||
                        blocks[i, j].Text == blocks[i, j - 1].Text)
                    {
                        isGameOver = false;
                    }
                }

            }

            if(blocks[0, 0].Text == blocks[0, 1].Text ||
               blocks[0, 0].Text == blocks[1, 0].Text ||
               blocks[0, 3].Text == blocks[0, 2].Text ||
               blocks[0, 3].Text == blocks[1, 3].Text ||
               blocks[3, 0].Text == blocks[2, 0].Text ||
               blocks[3, 0].Text == blocks[3, 1].Text ||
               blocks[3, 3].Text == blocks[2, 3].Text ||
               blocks[3, 3].Text == blocks[3, 2].Text ||

               blocks[0, 1].Text == blocks[0, 2].Text ||
               blocks[3, 1].Text == blocks[3, 2].Text ||
               blocks[1, 0].Text == blocks[2, 0].Text ||
               blocks[1, 3].Text == blocks[2, 3].Text)
            {
                isGameOver = false;
            }

            return isGameOver;
        }
    }
}
