using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz4_1
{
    public partial class Form1 : Form
    {
        //ToolBar toolBar;
        ToolStrip ts;
        ImageList list;
        StreamWriter w;
        string filename;
        private ToolStripContainer toolStripContainer1;
        public Form1()
        {
            InitializeComponent();

            //toolBar = new ToolBar();
            ts = new ToolStrip();
            toolStripContainer1 = new ToolStripContainer();

            list = new ImageList();
            list.ImageSize = new Size(30,30);
            list.Images.Add(new Bitmap("new.png"));
            list.Images.Add(new Bitmap("open.png"));
            list.Images.Add(new Bitmap("cansel.png"));
            list.Images.Add(new Bitmap("save.png"));

            list.Images.Add(new Bitmap("copy.png"));
            list.Images.Add(new Bitmap("cut.png"));
            list.Images.Add(new Bitmap("paste.png"));
            list.Images.Add(new Bitmap("config.png"));

            //toolBar.ImageList = list;
            ts.ImageList = list;

            ToolStripButton toolBarButton1 = new ToolStripButton();
            toolBarButton1.ImageIndex = 0;
            toolBarButton1.Click += new EventHandler(tsClick);
            ToolStripButton toolBarButton2 = new ToolStripButton();
            toolBarButton2.ImageIndex = 1;
            toolBarButton2.Click += new EventHandler(tsClick);
            ToolStripButton toolBarButton3 = new ToolStripButton();
            toolBarButton3.ImageIndex = 2;
            toolBarButton3.Click += new EventHandler(tsClick);
            ToolStripButton toolBarButton4 = new ToolStripButton();
            toolBarButton4.ImageIndex = 3;
            toolBarButton4.Click += new EventHandler(tsClick);

            ToolStripSeparator separator1 = new ToolStripSeparator();

            ToolStripButton toolBarButton5 = new ToolStripButton();
            toolBarButton5.ImageIndex = 4;
            toolBarButton5.Click += new EventHandler(tsClick);
            ToolStripButton toolBarButton6 = new ToolStripButton();
            toolBarButton6.ImageIndex = 5;
            toolBarButton6.Click += new EventHandler(tsClick);
            ToolStripButton toolBarButton7 = new ToolStripButton();
            toolBarButton7.ImageIndex = 6;
            toolBarButton7.Click += new EventHandler(tsClick);
            ToolStripSeparator separator2 = new ToolStripSeparator();
            
            ToolStripButton toolBarButton8 = new ToolStripButton();
            toolBarButton8.ImageIndex = 7;
            toolBarButton8.Click += new EventHandler(tsClick);

            ts.Items.Add(toolBarButton1);
            ts.Items.Add(toolBarButton2);
            ts.Items.Add(toolBarButton3);
            ts.Items.Add(toolBarButton4);
            ts.Items.Add(separator1);
            ts.Items.Add(toolBarButton5);
            ts.Items.Add(toolBarButton6);
            ts.Items.Add(toolBarButton7);
            ts.Items.Add(separator2);
            ts.Items.Add(toolBarButton8);

            Controls.Add(ts);
            textBox1.ContextMenuStrip = contextMenuStrip1;
            //
        }

        private void tsClick(object sender, System.EventArgs e)
        {
            ToolStripButton toolBarButton = sender as ToolStripButton;
            MessageBox.Show(Convert.ToString(toolBarButton.ImageIndex));
        }
        void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.createNewDocument();
        }
        private void createNewDocument()
        {
            if(textBox1.Text != "")
            {
                if(MessageBox.Show("Сохранить изменения?","Новый документ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.filename != null)
                    {
                        w = new StreamWriter(this.filename);
                        w.WriteLine(textBox1.Text);
                        w.Close();
                    }
                    else
                    {
                        this.saveFile();
                    }
                }
                this.filename = null;
                textBox1.Text = "";
                
            }
        }
        private void saveFile()
        {
            SaveFileDialog f2;
            f2 = new SaveFileDialog();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                this.filename = f2.FileName;
                w = new StreamWriter (this.filename);
                w.WriteLine(textBox1.Text);
                w.Close();
            }
        }
        private void openNewDocument()
        {
            OpenFileDialog f1;
            
            f1 = new OpenFileDialog();
            f1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            f1.FilterIndex = 1;
            if (f1.ShowDialog() == DialogResult.OK)
            {
                StreamReader r = File.OpenText(f1.FileName);
                this.filename = f1.FileName;
                textBox1.Text = r.ReadToEnd();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFile();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.filename != null)
            {
                w = new StreamWriter(this.filename);
                w.WriteLine(textBox1.Text);
                w.Close();
            }
            else
            {
                this.saveFile();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openNewDocument();
        }
    }
}
