using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections;
using System.IO;

namespace 记事本.Properties
{
    public partial class Formchild : Form
    {
        public Formchild()
        {
            InitializeComponent();
            timer1.Enabled = true;
           toolStripStatusLabel4.Text = "时间：" + DateTime.Now.ToString();
        }
        private OpenFileDialog OFD = new OpenFileDialog();
        private SaveFileDialog SFD = new SaveFileDialog();
        private bool richboxTextHasChanged = false;
        private void Formchild_Load(object sender, EventArgs e)
        {
            OFD.FileName = "";

            OFD.Filter = "TXT FILE(*.txt)|*.txt";

            SFD.Filter = "TXT FILE(*.txt)|*.txt";
        }

        private void FtMs_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.Font = fd.Font;
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richboxTextHasChanged = true;
        }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")//如果鼠标选中了文本内容 
            {                this.剪切ToolStripMenuItem.Enabled = true;
                this.复制ToolStripMenuItem.Enabled = true;
                this.剪切ToolStripMenuItem.Enabled = true;
                this.复制ToolStripMenuItem.Enabled = true;
            }            else//如果鼠标没有选中文本内容     
            {                this.剪切ToolStripMenuItem.Enabled = false;
                this.复制ToolStripMenuItem.Enabled = false;
                this.剪切ToolStripMenuItem.Enabled = false;
                this.复制ToolStripMenuItem.Enabled = false;
            }      
    }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                  
            OFD.FileName = "";
            this.Text = "记事本";
            this.richTextBox1.Clear();
            this.richboxTextHasChanged = false;
            }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFD.ShowDialog();
            if (OFD.FileName != "")
            {
                richTextBox1.LoadFile(OFD.FileName, RichTextBoxStreamType.PlainText);
                this.Text = OFD.FileName + "-记事本";
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OFD.FileName != "" || richTextBox1.Text!="")
            {
                MessageBox.Show("是否确认保存更改？", "提示", MessageBoxButtons.OKCancel);
                richTextBox1.SaveFile(OFD.FileName, RichTextBoxStreamType.PlainText);
            }
            else
                MessageBox.Show("请先打开文本文件", "信息提示", MessageBoxButtons.OK);
           
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(SFD.FileName, RichTextBoxStreamType.PlainText);
            }
           
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                MessageBox.Show("文件未保存，是否直接退出？", "提示", MessageBoxButtons.YesNo);
              
            }
            else
            {
                this.Dispose();
                this.Close();
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(System.DateTime.Now.ToString());
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
          toolStripStatusLabel4.Text = "时间：" + DateTime.Now.ToString();
        }

        private void ToolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int line = richTextBox1.GetLineFromCharIndex(index);
            int col = richTextBox1.SelectionStart - index + 1;
            toolStripStatusLabel1.Text = "第" + line.ToString() + "行，第" + col.ToString() + "列";
        }

        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            int index = richTextBox1.GetFirstCharIndexOfCurrentLine();
            int line = richTextBox1.GetLineFromCharIndex(index) + 1;
            int col = richTextBox1.SelectionStart - index + 1;
          toolStripStatusLabel1.Text = "第 " + line.ToString() + " 行，第 " + col.ToString() + " 列";
           
        }
    }
    }

