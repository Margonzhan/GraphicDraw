using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ControlTest;
using System.Diagnostics;
namespace DragTest
{
    public partial class Form1 : Form
    {
       
        private SubBusContrainer.ProductContrainer productContrainer1;
        public Form1()
        {
            InitializeComponent();
            
            Init();
            
        }
        private void Init()
        {           

           
        }

        

       


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("123", "waring");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string _name = DateTime.Now.ToString("hh_mm_ss");
            // treeView_ProductInfo.Nodes.Add(_name);
            productContrainer1 = new SubBusContrainer.ProductContrainer(_name);
            productContrainer1.ControlBaseRemoveEvent += treeviewContrainer1.ProductContrainer_ControlBaseRemoveEvent;
            productContrainer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(productContrainer1);
            productContrainer1.Init();
            treeviewContrainer1.ProductContrainer = productContrainer1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          List<ControlBase> controlBases=  productContrainer1.EnumProduct();
            if(controlBases.Count>0)
            {
                controlBases.ElementAt(0).Left += 50;
                controlBases.ElementAt(0).Top += 50;
            }
        }
    }
}
