namespace MyNotepad
{
    partial class NotepadForm
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
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            Menu = new ToolStripMenuItem();
            fileMenu = new ToolStripMenuItem();
            newMenu = new ToolStripMenuItem();
            openMenu = new ToolStripMenuItem();
            saveMenu = new ToolStripMenuItem();
            saveAsMenu = new ToolStripMenuItem();
            exitMenu = new ToolStripMenuItem();
            View = new ToolStripMenuItem();
            zoomInView = new ToolStripMenuItem();
            zoomOutView = new ToolStripMenuItem();
            writeBox = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu, View });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1273, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            Menu.DropDownItems.AddRange(new ToolStripItem[] { fileMenu, newMenu, openMenu, saveMenu, saveAsMenu, exitMenu });
            Menu.Name = "Menu";
            Menu.ShortcutKeys = Keys.Control | Keys.N;
            Menu.Size = new Size(50, 20);
            Menu.Text = "Menu";
            // 
            // fileMenu
            // 
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(186, 22);
            fileMenu.Text = "File";
            // 
            // newMenu
            // 
            newMenu.Name = "newMenu";
            newMenu.ShortcutKeys = Keys.Control | Keys.N;
            newMenu.Size = new Size(186, 22);
            newMenu.Text = "New";
            // 
            // openMenu
            // 
            openMenu.Name = "openMenu";
            openMenu.ShortcutKeys = Keys.Control | Keys.O;
            openMenu.Size = new Size(186, 22);
            openMenu.Text = "Open";
            // 
            // saveMenu
            // 
            saveMenu.Name = "saveMenu";
            saveMenu.ShortcutKeys = Keys.Control | Keys.S;
            saveMenu.Size = new Size(186, 22);
            saveMenu.Text = "Save";
            // 
            // saveAsMenu
            // 
            saveAsMenu.Name = "saveAsMenu";
            saveAsMenu.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsMenu.Size = new Size(186, 22);
            saveAsMenu.Text = "Save As";
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.ShortcutKeys = Keys.Alt | Keys.F4;
            exitMenu.Size = new Size(186, 22);
            exitMenu.Text = "Exit";
            // 
            // View
            // 
            View.DropDownItems.AddRange(new ToolStripItem[] { zoomInView, zoomOutView });
            View.Name = "View";
            View.Size = new Size(44, 20);
            View.Text = "View";
            // 
            // zoomInView
            // 
            zoomInView.Name = "zoomInView";
            zoomInView.ShortcutKeys = Keys.Control | Keys.Q;
            zoomInView.Size = new Size(174, 22);
            zoomInView.Text = "Zoom In";
            // 
            // zoomOutView
            // 
            zoomOutView.Name = "zoomOutView";
            zoomOutView.ShortcutKeys = Keys.Control | Keys.W;
            zoomOutView.Size = new Size(174, 22);
            zoomOutView.Text = "Zoom Out";
            // 
            // writeBox
            // 
            writeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            writeBox.Location = new Point(0, 27);
            writeBox.Name = "writeBox";
            writeBox.Size = new Size(1273, 717);
            writeBox.TabIndex = 1;
            writeBox.Text = "dkhvfdsln";
            writeBox.UseWaitCursor = true;
            // 
            // NotepadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 745);
            Controls.Add(writeBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "NotepadForm";
            Text = "My Notepad";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newMenu;
        private ToolStripMenuItem openMenu;
        private ToolStripMenuItem saveMenu;
        private ToolStripMenuItem saveAsMenu;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem View;
        private ToolStripMenuItem zoomInView;
        private ToolStripMenuItem zoomOutView;
        private RichTextBox writeBox;
    }
}
