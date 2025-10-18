namespace MyNotepad
{
    partial class MyNotepad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyNotepad));
            menuBar = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            newFile = new ToolStripMenuItem();
            openFile = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveAsFile = new ToolStripMenuItem();
            exitFile = new ToolStripMenuItem();
            closeMenu = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            timeDateEdit = new ToolStripMenuItem();
            fontEdit = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            zoomInView = new ToolStripMenuItem();
            zoomOutView = new ToolStripMenuItem();
            restorView = new ToolStripMenuItem();
            notepadBox = new RichTextBox();
            menuBar.SuspendLayout();
            SuspendLayout();
            // 
            // menuBar
            // 
            menuBar.BackColor = SystemColors.MenuBar;
            menuBar.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu });
            menuBar.Location = new Point(0, 0);
            menuBar.Name = "menuBar";
            menuBar.Size = new Size(1121, 24);
            menuBar.TabIndex = 0;
            menuBar.Text = "Menu";
            menuBar.ItemClicked += menuBar_ItemClicked;
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newFile, openFile, saveFile, saveAsFile, closeMenu, exitFile });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "File";
            // 
            // newFile
            // 
            newFile.Name = "newFile";
            newFile.ShortcutKeys = Keys.Control | Keys.N;
            newFile.Size = new Size(180, 22);
            newFile.Text = "New";
            newFile.Click += newFile_Click;
            // 
            // openFile
            // 
            openFile.Name = "openFile";
            openFile.ShortcutKeys = Keys.Control | Keys.O;
            openFile.Size = new Size(180, 22);
            openFile.Text = "Open";
            openFile.Click += openFile_Click;
            // 
            // saveFile
            // 
            saveFile.Name = "saveFile";
            saveFile.ShortcutKeys = Keys.Control | Keys.S;
            saveFile.Size = new Size(180, 22);
            saveFile.Text = "Save";
            saveFile.Click += saveFile_Click;
            // 
            // saveAsFile
            // 
            saveAsFile.Name = "saveAsFile";
            saveAsFile.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            saveAsFile.Size = new Size(180, 22);
            saveAsFile.Text = "Save As";
            saveAsFile.Click += saveAsFile_Click;
            // 
            // exitFile
            // 
            exitFile.Name = "exitFile";
            exitFile.ShortcutKeys = Keys.Alt | Keys.F4;
            exitFile.Size = new Size(180, 22);
            exitFile.Text = "Exit";
            exitFile.Click += exitFile_Click;
            // 
            // closeMenu
            // 
            closeMenu.Name = "closeMenu";
            closeMenu.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
            closeMenu.Size = new Size(180, 22);
            closeMenu.Text = "Close";
            closeMenu.Click += closeMenu_Click;
            // 
            // editMenu
            // 
            editMenu.DropDownItems.AddRange(new ToolStripItem[] { timeDateEdit, fontEdit });
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(39, 20);
            editMenu.Text = "Edit";
            editMenu.Click += editMenu_Click;
            // 
            // timeDateEdit
            // 
            timeDateEdit.Name = "timeDateEdit";
            timeDateEdit.ShortcutKeys = Keys.F5;
            timeDateEdit.Size = new Size(149, 22);
            timeDateEdit.Text = "Time/Date";
            timeDateEdit.Click += timeDateEdit_Click;
            // 
            // fontEdit
            // 
            fontEdit.Name = "fontEdit";
            fontEdit.Size = new Size(149, 22);
            fontEdit.Text = "Font";
            fontEdit.Click += fontEdit_Click;
            // 
            // viewMenu
            // 
            viewMenu.DropDownItems.AddRange(new ToolStripItem[] { zoomInView, zoomOutView, restorView });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(44, 20);
            viewMenu.Text = "View";
            // 
            // zoomInView
            // 
            zoomInView.Name = "zoomInView";
            zoomInView.ShortcutKeys = Keys.Control | Keys.W;
            zoomInView.Size = new Size(180, 22);
            zoomInView.Text = "Zoom In";
            zoomInView.Click += zoomInView_Click;
            // 
            // zoomOutView
            // 
            zoomOutView.Name = "zoomOutView";
            zoomOutView.ShortcutKeys = Keys.Control | Keys.Q;
            zoomOutView.Size = new Size(180, 22);
            zoomOutView.Text = "Zoom Out";
            zoomOutView.Click += zoomOutView_Click;
            // 
            // restorView
            // 
            restorView.Name = "restorView";
            restorView.ShortcutKeys = Keys.Control | Keys.R;
            restorView.Size = new Size(180, 22);
            restorView.Text = "Restor";
            restorView.Click += restorView_Click;
            // 
            // notepadBox
            // 
            notepadBox.BackColor = Color.Black;
            notepadBox.Dock = DockStyle.Fill;
            notepadBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            notepadBox.ForeColor = Color.White;
            notepadBox.Location = new Point(0, 24);
            notepadBox.Name = "notepadBox";
            notepadBox.Size = new Size(1121, 648);
            notepadBox.TabIndex = 1;
            notepadBox.Text = "";
            notepadBox.TextChanged += notepadBox_TextChanged;
            // 
            // MyNotepad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1121, 672);
            Controls.Add(notepadBox);
            Controls.Add(menuBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuBar;
            Name = "MyNotepad";
            Text = "My Notepad";
            Load += MyNotepad_Load;
            menuBar.ResumeLayout(false);
            menuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuBar;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem viewMenu;
        private ToolStripMenuItem newFile;
        private ToolStripMenuItem openFile;
        private ToolStripMenuItem saveFile;
        private ToolStripMenuItem saveAsFile;
        private ToolStripMenuItem exitFile;
        private ToolStripMenuItem timeDateEdit;
        private ToolStripMenuItem fontEdit;
        private ToolStripMenuItem zoomInView;
        private ToolStripMenuItem zoomOutView;
        private ToolStripMenuItem restorView;
        private RichTextBox notepadBox;
        private ToolStripMenuItem closeMenu;
    }
}
