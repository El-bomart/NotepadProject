
namespace MyNotepad
{
    public partial class MyNotepad : Form
    {

        private string currentFilePath = "";

        private const string FORM_TITTLE = "My Notepad"; // Holds the title of the window


        private void SaveFileAs()
        {
            using (var saveFileDlg = new SaveFileDialog())
            {
                saveFileDlg.Title = "Save Note"; // Title to show on OpenFileDialog window
                saveFileDlg.Filter = "Text files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf"; 
                saveFileDlg.DefaultExt = "txt";
                saveFileDlg.AddExtension = true;


                var dialogResult = saveFileDlg.ShowDialog(); // It's either OK or CANCEL


                if (dialogResult == DialogResult.OK)
                {
                    currentFilePath = saveFileDlg.FileName; // Updates the current file path

                    // 

                    try
                    {
                        if(Path.GetExtension(currentFilePath).ToLower() == "rft" || Path.GetExtension(currentFilePath).ToLower() == ".rft")
                        {
                            notepadBox.SaveFile(currentFilePath);
                        }
                        else
                        {
                            File.WriteAllText(currentFilePath, notepadBox.Text);
                        }

                        this.Text = $"{FORM_TITTLE} - {Path.GetFileNameWithoutExtension(currentFilePath)}";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save file: {Path.GetFileName(currentFilePath)}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs();
            }

            else
            {
                try
                {
                    if (Path.GetExtension(currentFilePath).ToLower() == "rft" || Path.GetExtension(currentFilePath).ToLower() == ".rft")
                    {
                        notepadBox.SaveFile(currentFilePath);
                    }
                    else
                    {
                        File.WriteAllText(currentFilePath, notepadBox.Text);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save file: {Path.GetFileName(currentFilePath)}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void CloseFile()
        {
            //
            if(this.Text.Contains("*"))
            {
                var result = MessageBox.Show("There is an unsaved file currently opened. Would like to save it first?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    // Save file function call here

                }
            }

            notepadBox.Clear();
            this.Text = FORM_TITTLE; // Set app title back to initial value
        }

        // Used to open files
        private void GetFile()
        {
            using (var fileDlg = new OpenFileDialog())
            {
                fileDlg.Title = "Select a text file to open"; // Title to show on OpenFileDialog window
                fileDlg.Filter = "Text files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf";
                fileDlg.Multiselect = false; // Only one file can be selected


                var dialogResult = fileDlg.ShowDialog(); // Get the result of the file dialog. It's either OK or CANCEL


                if (dialogResult == DialogResult.OK)
                {
                    currentFilePath = fileDlg.FileName; // Updates the current file path

                    // Open and loading file to noteBox

                    try
                    {
                        notepadBox.LoadFile(currentFilePath, RichTextBoxStreamType.PlainText);
                        

                        this.Text = $"{FORM_TITTLE} - {Path.GetFileNameWithoutExtension(currentFilePath)}"; // Showing which file is currently open in 'My Notepad'
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open file: {Path.GetFileName(currentFilePath)}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }






        public MyNotepad()
        {
            InitializeComponent();
        }

        private void MyNotepad_Load(object sender, EventArgs e)
        {

        }

        private void menuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // ============================= OPERATIONS IN THE FILE MENU ================================================


        // 1. Create a new txt file
        private void newFile_Click(object sender, EventArgs e)
        {

        }

        // 2. Open an existing txt file
        private void openFile_Click(object sender, EventArgs e)
        {
            // Open a file
            if(!string.IsNullOrEmpty(currentFilePath))
            {
                var confirm = MessageBox.Show("You must close the current file before you can open another one.\nProceed?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                    CloseFile();
                else
                    return;
            }

            GetFile();
        }

        // 3. Save a currently open file
        private void saveFile_Click(object sender, EventArgs e)
        {
            // Save a file

            if (string.IsNullOrEmpty(notepadBox.Text))
            {
                MessageBox.Show("Cannot save an empty note!");
                return;
            }
            SaveFile();
        }


        // 4. Save a currently open file under a new filename
        private void saveAsFile_Click(object sender, EventArgs e)
        {
            // Save a file at new path

            if(string.IsNullOrEmpty(notepadBox.Text))
            {
                MessageBox.Show("Cannot save an empty note!");
                return;
            }
            SaveFileAs();
        }

        // 5. Exit application
        private void exitFile_Click(object sender, EventArgs e)
        {
            // Exit app

            if(this.Text.Contains("*"))
            {
                var result = MessageBox.Show($"You have an unsaved file opened. If you close, all the changes will be lost.\nWould you llike to save it before closing?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveFile_Click(sender, e);
                }
                else if(result == DialogResult.No)
                {
                    this.Close(); // Close the app
                }
                else
                {
                    notepadBox.Focus();
                }
            }

            else
            {
                this.Close();
            }
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            // Close a file

            CloseFile();
        }

        // ============================= END OF FEATURES IN FILE MENU =================================================




        // ============================= BEGIIN EDIT MENU =============================================================
        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void timeDateEdit_Click(object sender, EventArgs e)
        {

        }

        private void fontEdit_Click(object sender, EventArgs e)
        {

        }

        // ============================= END OF EDIT MENU =============================================================




        // ============================= BEGIN OF VIEW MENU ============================================================
        private void zoomInView_Click(object sender, EventArgs e)
        {

        }

        private void zoomOutView_Click(object sender, EventArgs e)
        {

        }

        private void restorView_Click(object sender, EventArgs e)
        {

        }



        // ============================= END OF VIEW MENU ==============================================================

        // Rich text box: text is displayed and edited here
        private void notepadBox_TextChanged(object sender, EventArgs e)
        {

        }



      

    }
}


























/*
 * ***************************************  DESIGNING THE FORM  *********************************************
 * 
 * ================================= CONTROLS AND THEIR (NAMES) =============================================
 * 
 * Form: MyNotePad
 * 
 * MenuStrip: menuBar
 *                  - File: fileMenu
 *                                  - New: newFile
 *                                  - Open: openFile
 *                                  - Save: saveFile
 *                                  - Save AS: saveAsFile
 *                                  - Exit: exitFile
 *                                  *****************
 *                 - Edit: editMenu
 *                                  - Time/Date: timeDateEdit
 *                                  - Font: fontEdit
 *                                  *****************
 *                 - View: viewMenu
 *                                  - Zoom In: zoomInView
 *                                  - Zoom Out: zoomOutView
 *                                  - Restor: restorView
 *                                  *********************
 *                                  
 * RichTextBox: notepadBox
 * 
 */