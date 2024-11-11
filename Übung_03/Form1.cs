using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.GLControl;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Übung_03
{
    public partial class Form1 : Form
    {
        private GLControl gLControl = null!;  // Das bedeutet "gLControl ist sicher nicht null", aber wird später initialisiert.


        private void glControl1_Click(object sender, EventArgs e)
        {
            // Code für das Click-Event von glControl1
        }

        public Form1()
        {
            InitializeComponent();
            InitializeGLControl();

            //TableLayoutPanel erstellen
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            SceneManager sceneManager = new SceneManager();
            tableLayoutPanel.Controls.Add(sceneManager, 0,0);

            Controls.Add(tableLayoutPanel);
        }

        private void InitializeGLControl()
        {
            gLControl = new GLControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(gLControl);

            gLControl.Load += GlControl_Load;
            gLControl.Resize += GlControl_Resize;
            gLControl.Paint += GlControl_Paint;
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, gLControl.Width / (float)gLControl.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref perspective);
        }

        private void GlControl_Paint(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.MidnightBlue);

            gLControl.SwapBuffers();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
