using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlTest;
using System.Diagnostics;

namespace SubBusContrainer
{
    public partial class ProductContrainer : UserControl
    {
        private Graphics m_g;
        private Pen m_pen;
        private Panel _p;
        private Bitmap m_image;
        private string m_name;
       // private Graphics m_imageG;
        public event EventHandler<ControlBaseRemoveEventArgs> ControlBaseRemoveEvent;
        
        public ProductContrainer(string BusModelName)
        {
            InitializeComponent();
            m_name = BusModelName;
            _p = new Panel();
            this.SizeChanged += Panel_Product_SizeChanged;
         
        }
        /// <summary>
        /// 
        /// </summary>
        public  void Init()
        {
            this.AllowDrop = true;
           
            _p.Height = 4;
            _p.Width = this.Width;
            _p.Left = 0;
            _p.Top = this.Height / 2 - 2;
            _p.BackColor = Color.Red;
            this.Controls.Add(_p);    

            m_pen = new Pen(Color.Red, 3);

            BusModel userControl1 = new BusModel(new Point(100, 100));
            userControl1.Name = m_name;
            userControl1.ControlMoveEvent += RefushLine;
            this.Controls.Add(userControl1);
            RefushLine();
        }
        private void panel_Product_DragDrop(object sender, DragEventArgs e)
        {
            Point point = this.PointToClient(new Point(e.X, e.Y));

            object info = e.Data.GetData(typeof(string));
            SubBusModel userControl1 = new SubBusModel( point);
            userControl1.Name = info.ToString();
            userControl1.ControlMoveEvent += RefushLine;
            this.Controls.Add(userControl1);

            RefushLine();
        }

        private void panel_Product_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
                e.Effect = DragDropEffects.Copy;
        }

        private void panel_Product_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void Panel_Product_VisibleChanged(object sender, EventArgs e)
        {
            _p.Width = this.Width;
            _p.Top = this.Height / 2 - 2;
            m_g.Clear(this.BackColor);
            m_g = this.CreateGraphics();
            foreach (var member in this.Controls)
            {
                ControlBase control = member as ControlBase;
                if (control != null)
                {
                    DrawLine(control, m_g);
                }
            }
        }

        private void Panel_Product_SizeChanged(object sender, EventArgs e)
        {
            
            this.SuspendLayout();
            _p.Width = this.Width;
            _p.Top = this.Height / 2 - 2;           
            RefushLine();
            this.ResumeLayout();
        }
        private void RefushLine(object sender, ControlMoveEventArgs e)
        {
            
            if (e.info == "LeftMouseDown")
            {
                m_image = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(m_image);
                g.Clear(this.BackColor);
                foreach (var member in this.Controls)
                {
                    ControlBase control = member as ControlBase;
                    if (control != null && control != (ControlBase)sender)
                    {
                        DrawLine(control, g);
                    }
                }
                g.Dispose();
                this.BackgroundImage = m_image;
            }
            else if (e.info == "LeftMouseUp")
            {
                m_image = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(m_image);
                g.Clear(this.BackColor);
                foreach (var member in this.Controls)
                {
                    ControlBase control = member as ControlBase;
                    if (control != null)
                    {
                        DrawLine(control, g);
                    }
                }
                g.Dispose();
                this.BackgroundImage = m_image;
            }
           else if(e.info== "LeftMouseMove")
            {
                ControlBase controlBase = sender as ControlBase;
                controlBase.Left += e.MoveX;
                controlBase.Top += e.MoveY;

            }
        }
        private void RefushLine()
        {

            m_image = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(m_image);
            g.Clear(this.BackColor);
            foreach (var member in this.Controls)
            {
                ControlBase control = member as ControlBase;
                if (control != null)
                {
                    DrawLine(control, g);
                }
            }
            g.Dispose();
            this.BackgroundImage = m_image;
        }
        private void DrawLine(ControlBase control,Graphics g)
        {
            if (control.Top > this.Height / 2)
            {
                g.DrawLine(m_pen, new Point(control.Left + control.Width / 2, control.Top), new Point(control.Left + control.Width / 2, this.Height / 2));
                g.FillEllipse(new System.Drawing.SolidBrush(Color.Gray), new Rectangle(control.Left + control.Width / 2 - 5, this.Height / 2 - 5, 10, 10));
            }
            else
            {
                g.DrawLine(m_pen, new Point(control.Left + control.Width / 2, control.Top + control.Height), new Point(control.Left + control.Width / 2, this.Height / 2));
                g.FillEllipse(new System.Drawing.SolidBrush(Color.Gray), new Rectangle(control.Left + control.Width / 2 - 5, this.Height / 2 - 5, 10, 10));
            }
            
        }
        public void AddSubProduct(string subproductname)
        {
            if (CheckExit(subproductname))
            {
                throw new Exception("已存在当前名称的产品");
            }
            Point point=new Point();
            foreach(var member in this.Controls)
            {
                ControlBase controlBase = member as ControlBase;
                if(controlBase!=null)
                {
                    point.X = controlBase.Left + 20;
                    point.Y = controlBase.Top + 20;
                    break;
                }
            }
            SubBusModel userControl1 = new SubBusModel(point);
            
            userControl1.Name = subproductname;
            userControl1.ControlMoveEvent += RefushLine;
            this.Controls.Add(userControl1);
            userControl1.BringToFront();
            userControl1.Focus();
            RefushLine();
            //DrawLine(userControl1, m_g);
            //m_g.Flush();
        }
        private bool CheckExit(string subproductname)
        {
            foreach (var member in this.Controls)
            {
                SubBusModel _controlBase = member as SubBusModel;
                if (_controlBase != null)
                {
                    if (_controlBase.Name == subproductname)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void RemoveSubProduct(string subproductname)
        {
            foreach (var member in this.Controls)
            {
                SubBusModel _controlBase = member as SubBusModel;
                if (_controlBase != null)
                {
                    if (_controlBase.Name == subproductname)
                    {
                        _controlBase.Dispose();
                        break;
                    }
                }
            }
            RefushLine();

        }
        public void ShowProperty(string subproductname)
        {
            foreach (var member in this.Controls)
            {
                ControlBase _controlBase = member as ControlBase;
                if (_controlBase != null)
                {
                    if (_controlBase.Name == subproductname)
                    {
                        _controlBase.ShowProperty();
                        break;
                    }
                }
            }

        }
        public List<ControlBase> EnumProduct()
        {
            List<ControlBase> controlBasesList = new List<ControlBase>();
            foreach(var mem in this.Controls)
            {
                ControlBase controlbase = mem as ControlBase;
                if (controlbase != null)
                    controlBasesList.Add(controlbase);

            }
            return controlBasesList;
        }
        private void panel_Product_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is SubBusModel)
            {
                SubBusModel SubBusModel = e.Control as SubBusModel;
                ControlBaseRemoveEventArgs controlBaseRemoveEventArgs = new ControlBaseRemoveEventArgs();
                controlBaseRemoveEventArgs.ControlName = SubBusModel.Name;
                OnControlReMoveEvent(controlBaseRemoveEventArgs);
            }
        }
        private void OnControlReMoveEvent(ControlBaseRemoveEventArgs e)
        {
            if(ControlBaseRemoveEvent!=null)
            {
                ControlBaseRemoveEvent(this, e);
            }
        }
    }
    public  class  ControlBaseRemoveEventArgs:EventArgs
    {
        public string ControlName { get; set; }
    }
}
