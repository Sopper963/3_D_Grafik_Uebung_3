using System.Windows.Forms;
using OpenTK.Graphics;


namespace Übung_03
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        
        private SceneManager sceneManager;
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            glControl1 = new OpenTK.GLControl.GLControl();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(651, 1);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(151, 453);
            treeView1.TabIndex = 0;
            // 
            // glControl1
            // 
            glControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl1.APIVersion = new Version(3, 3, 0, 0);
            glControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl1.IsEventDriven = true;
            glControl1.Location = new Point(249, 1);
            glControl1.Name = "glControl1";
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glControl1.SharedContext = null;
            glControl1.Size = new Size(396, 421);
            glControl1.TabIndex = 1;
            glControl1.Click += glControl1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip1.Location = new Point(0, 425);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(111, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(250, 421);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(651, 1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(151, 125);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Controls.Add(glControl1);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private OpenTK.GLControl.GLControl glControl1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
    public class SceneManager : TreeView
    {
        private TreeNode rootNode;
        public SceneManager() 
        { 
            rootNode = new TreeNode("Root");
            Nodes.Add(rootNode);

            NodeMouseClick += OnNodeMouseClick;
            ItemDrag += OnItemDrag;
            DragEnter += OnDragEnter;
            DragDrop += OnDragDrop;
        }
        private void OnItemDrag(object sender, ItemDragEventArgs e)
        {
            // Hier kommt der Code für das Ereignis "ItemDrag" hin
        }

        private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Casting e.Node to GameObject, if applicable
            GameObject gameObj = e.Node as GameObject; // Dies funktioniert, wenn GameObject von TreeNode erbt

            if (gameObj != null)
            {
                // Hier kannst du mit dem GameObject-Objekt arbeiten
                MessageBox.Show("GameObject clicked: " + gameObj.Text);
            }

            if (e.Button == MouseButtons.Right)
            {
                // Erstelle ein ContextMenuStrip anstelle eines ContextMenu
                ContextMenuStrip menuStrip = new ContextMenuStrip();

                // Beispielmenüeintrag mit Tag erstellen
                ToolStripMenuItem menuItem = new ToolStripMenuItem("Menu text");
                menuItem.Tag = "SomeAction";  // Setzt das Tag für spätere Identifikation
                menuStrip.Items.Add(menuItem);  // Zum ContextMenuStrip hinzufügen

                // Event-Handler für ItemClicked hinzufügen
                menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStrip_ItemClicked);


                menuItem.Tag = "Tag can be used to identify action";  // Tag für Identifikation setzen
                menuStrip.Items.Add(menuItem);  // Zum ContextMenuStrip hinzufügen


                // Erstelle die Menüeinträge als ToolStripMenuItem
                ToolStripMenuItem addGameObject = new ToolStripMenuItem("Add GameObject", null, (s, ev) => AddGameObject(e.Node));
                ToolStripMenuItem deleteNode = new ToolStripMenuItem("Delete Node", null, (s, ev) => DeleteNode(e.Node));

                // Füge die ToolStripMenuItems zum ContextMenuStrip hinzu
                menuStrip.Items.Add(addGameObject);
                if (e.Node != rootNode)
                {
                    menuStrip.Items.Add(deleteNode);
                }
                e.Node.ContextMenuStrip = menuStrip;
                // Zeige das Kontextmenü an der Stelle des Mausklicks an
               menuStrip.Show(this, e.Location);
            }

        }
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Tag-Wert vom geklickten Element abrufen
            var tagValue = e.ClickedItem.Tag;  // Tag ist vom Typ object, kann also umgewandelt werden

            // Beispielhafte Auswertung des Tag-Wertes
            if (tagValue != null && tagValue.ToString() == "SomeAction")
            {
                MessageBox.Show("Action identified by Tag executed!");
                // Führe die entsprechende Aktion hier aus
            }
        }

        public void AddGameObject(TreeNode parentNode) 
        {
            TreeNode newNode = new TreeNode("GameObject");
            parentNode.Nodes.Add(newNode);  
            parentNode.Expand();
        }

        private void DeleteNode(TreeNode node) 
        {
            if (node != rootNode) 
            { 
                node.Remove();
            }
            else 
            {
                MessageBox.Show("Der Root-Knoten kann nicht gelöscht werden");
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e) 
        {
            if (e.Data.GetDataPresent(typeof(TreeNode))) 
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void OnDragDrop(object sender, DragEventArgs e) 
        {
            if (e.Data.GetData(typeof(TreeNode)) is TreeNode draggedNode) 
            {
                //Aktuelle Position (Drop-Postion) ermitteln
                Point targetPoint = PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = GetNodeAt(targetPoint);

                //Verschieben, wenn Zielknoten nicht Root ist
                if (targetNode != null && targetNode != rootNode && draggedNode != rootNode) 
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Remove(draggedNode);   
                    targetNode.Expand();
                }
            }
        }
            public GameObject AddNode(string childNodeName)
            {
                var node = new GameObject(childNodeName);
                this.Nodes.Add(node);  // Füge den Knoten zu der TreeView-Instanz hinzu
                return node;
            }

            // Methode, um ein Kindknoten hinzuzufügen
            public GameObject AddChildNode(GameObject parent, string childNodeName)
            {
                var childNode = new GameObject(childNodeName);
                parent.Nodes.Add(childNode);  // Füge den Kindknoten zum Elternknoten hinzu
                return childNode;
            }
    }
  
}
