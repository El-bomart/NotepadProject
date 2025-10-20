
namespace MyNotepad
{
    public partial class MyNotepad : Form
    {
        private const string FORM_TITTLE = "My Notepad";                                                // Holds the title of the window

        private const string DEFAULT_NAME = $"{FORM_TITTLE} | Untitled*";
        private string currentFilePath = "";
        private string defaultExtension = ".txt";                                                       // Default extension for new files

        private bool isNoteLoaded = false;                                                              // True if the file has just been loaded, false otherwise
        private bool isNoteModified = false;                                                            // True if the note has been modified, false otherwise
        private bool cancelCreateNewNote = false;                                                       // I use this to avoid clearing notepadBox if the user chooses cancel when prompted to save unsaved changes




        public MyNotepad()
        {
            InitializeComponent();
        }

        private void MyNotepad_Load(object sender, EventArgs e)
        {

        }




        private void SaveFileAs()
        {
            using (var saveFileDlg = new SaveFileDialog())
            {
                saveFileDlg.Title = "Save Note";                                                            // Title to show on OpenFileDialog window
                saveFileDlg.Filter = "Text files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf";

                saveFileDlg.DefaultExt = defaultExtension;
                saveFileDlg.AddExtension = true;


                var dialogResult = saveFileDlg.ShowDialog();                                                // It's either OK or CANCEL


                if (dialogResult == DialogResult.OK)
                {
                    currentFilePath = saveFileDlg.FileName;                                                 // Updates the current file path

                    // 

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

                        this.Text = $"{FORM_TITTLE} | {Path.GetFileNameWithoutExtension(currentFilePath)}";
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
            if (string.IsNullOrEmpty(currentFilePath) || this.Text == DEFAULT_NAME)
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
            string fileContent = notepadBox.Text;                                                               // Store current content of the note so that Trim() cannot modified the content of notepadBox
            if (!string.IsNullOrEmpty(fileContent.Trim()) || string.IsNullOrEmpty(currentFilePath))             // Only prompt to save if there is something written in the note, excluding whitespace
            {
                if (this.Text.Contains("*") || this.Text == DEFAULT_NAME)
                {
                    var result = MessageBox.Show("Would like to save the changes of the current note first?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Save file function call here
                        SaveFile();

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        cancelCreateNewNote = true;
                        return;                                                                                  // Do nothing and return to the note
                    }
                }
            }
            notepadBox.Clear();
            this.Text = FORM_TITTLE;                                                                            // Set app title back to initial value
            currentFilePath = "";                                                                               // Clear current file path
        }

        // Used to open files
        private void GetFile()
        {
            using (var fileDlg = new OpenFileDialog())
            {
                fileDlg.Title = "Select a text file to open";                                                   // Title to show on OpenFileDialog window
                fileDlg.Filter = "Text files (*.txt)|*.txt|Rich text files (*.rtf)|*.rtf";
                fileDlg.Multiselect = false;                                                                    // Only one file can be selected


                var dialogResult = fileDlg.ShowDialog();                                                        // Get the result of the file dialog. It's either OK or CANCEL


                if (dialogResult == DialogResult.OK)
                {
                    currentFilePath = fileDlg.FileName;                                                         // Updates the current file path

                    // Open and loading file to noteBox

                    try
                    {
                        notepadBox.LoadFile(currentFilePath, RichTextBoxStreamType.PlainText);


                        this.Text = $"{FORM_TITTLE} - {Path.GetFileNameWithoutExtension(currentFilePath)}";     // Showing which file is currently open in 'My Notepad'

                        isNoteLoaded = true;                                                                    // Mark that the note has been loaded
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open file: {Path.GetFileName(currentFilePath)}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void CreateNewNote(bool passCloseTest = false)
        {


           if(!passCloseTest)
            {
                if ((!string.IsNullOrEmpty(currentFilePath) && this.Text.Contains("*")) || (this.Text == DEFAULT_NAME && !string.IsNullOrEmpty(notepadBox.Text)))
                {
                    CloseFile();                                                               // Close note before creating a new one if there is an unsaved note or a file open
                }
                if (cancelCreateNewNote)
                {
                    cancelCreateNewNote = false;                                             // Reset the flag
                    return;                                                                 // Do nothing and return to the note
                }
                notepadBox.Clear();
            }
            
            this.Text = DEFAULT_NAME;                                                       // Set app title to 'Untitled'
            notepadBox.Focus();                                                             // Put cursor focus on the note box so the user can start typing.
            currentFilePath = "";                                                           // Clear current file path
        }


        private void ChangeFont()
        {
            using (var fontDlg = new FontDialog())
            {
                if (fontDlg.ShowDialog() == DialogResult.OK)
                {
                    notepadBox.Font = fontDlg.Font;
                    defaultExtension = ".rtf";                                              // Change default extension to .rtf when font is changed
                }

            }
        }




        private void menuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // No operations is needed here
        }

        // ============================= BEGGIN OPERATIONS IN FILE MENU ====================================================================================================================

        // 1. Create a new txt file
        private void newFile_Click(object sender, EventArgs e)
        {
            CreateNewNote();
        }

        // 2. Open an existing txt file
        private void openFile_Click(object sender, EventArgs e)
        {
            // Open a file
            string fileContent = notepadBox.Text;                                       // Store current content of the note so that Trim() cannot modified the content of notepadBox

            if ((!string.IsNullOrEmpty(currentFilePath) && this.Text.Contains("*")) || (!string.IsNullOrEmpty(fileContent.Trim()) && isNoteModified))
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

            if (string.IsNullOrEmpty(notepadBox.Text))
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

            string filecontent = notepadBox.Text;                                       // Store current content of the note so that Trim() cannot modified the content of notepadBox

            if (this.Text.Contains("*") && !string.IsNullOrEmpty(currentFilePath) || (!string.IsNullOrEmpty(filecontent.Trim() ) ) )
            {
                var result = MessageBox.Show($"You have an unsaved note opened. If you close, all the changes will be lost.\nWould you like to save it before closing?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveFile_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    this.Close();                           // Close the app
                }
                else
                {
                    notepadBox.Focus();
                }
            }


            this.Close();
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            // Close a note

            CloseFile();
        }

        // ============================= END OF FEATURES IN FILE MENU =====================================================




        // ============================= BEGIIN EDIT MENU =================================================================
        private void editMenu_Click(object sender, EventArgs e)
        {
            // No operations is needed here
        }

        private void timeDateEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath) && string.IsNullOrEmpty(notepadBox.Text))
            {
                CreateNewNote();                                            // You can't just add stuff outside of a note!
            }
            notepadBox.SelectedText = DateTime.Now.ToString("f");
        }

        private void fontEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath) && string.IsNullOrEmpty(notepadBox.Text))
            {
                CreateNewNote();                                            // You can't change fonts when there's no notes!
            }
            ChangeFont();
        }

        // ============================= END OF EDIT MENU ===================================================================




        // ============================= BEGIN OF VIEW MENU =================================================================

        private void zoomInView_Click(object sender, EventArgs e)
        {
            notepadBox.ZoomFactor += 0.1f;

        }

        private void zoomOutView_Click(object sender, EventArgs e)
        {
            notepadBox.ZoomFactor -= 0.1f;
        }

        private void restorView_Click(object sender, EventArgs e)
        {
            notepadBox.ZoomFactor = 1.0f;
        }

        // ============================= END OF VIEW MENU =================================================================









        // Rich text box: text is displayed and edited here
        private void notepadBox_TextChanged(object sender, EventArgs e)
        {

            if (isNoteLoaded && !this.Text.Contains("*"))
            {
                this.Text = $"{this.Text}*";                                 // Add asterisk to title to indicate unsaved changes
                isNoteLoaded = false;
                isNoteModified = true;
            }
            else if (string.IsNullOrEmpty(currentFilePath) && !string.IsNullOrEmpty(notepadBox.Text))
            {
                CreateNewNote(true);                             // Add asterisk to title to indicate unsaved changes
                isNoteModified = true;
                return;
            }

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
 * *************************************************************************************************************
 */