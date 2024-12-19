using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_SFX_Master
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string currentFilePath;
        private byte[] referenceBytesHeader6;
        private byte[] referenceBytesBody6;
        private byte[] referenceBytesHeader5;
        private byte[] referenceBytesBody5;
        private byte[] referenceBytesHeader4;
        private byte[] referenceBytesBody4;

        // load
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowDrop = true;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            dataGridView1.DragDrop += dataGridView1_DragDrop;

            label2.Visible = false;
            label4.Visible = false;

            button2.Visible = false;
            button4.Visible = false;

            LoadReferenceHeader6();
            LoadReferenceBody6();
            LoadReferenceHeader5();
            LoadReferenceBody5();
            LoadReferenceHeader4();
            LoadReferenceBody4();
        }

        // load function
        private void LoadReferenceHeader6()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.header6"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesHeader6 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceBody6()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.body6"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesBody6 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceHeader5()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.header5"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesHeader5 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceBody5()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.body5"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesBody5 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceHeader4()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.header4"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesHeader4 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceBody4()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.body4"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesBody4 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // browse button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "NUB Files (*.nub)|*.nub";
            openFileDialog.FileName = "SYSTEM.nub";
            label1.Text = "SYSTEM.nub is not Loaded";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetFileName(openFileDialog.FileName) == "SYSTEM.nub")
                {
                    string filePath = openFileDialog.FileName;
                    PopulateTrackData(filePath);
                }
                else
                {
                    label1.Text = "SYSTEM.nub is not Loaded";
                }
            }
        }

        // drop file
        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow copying the file
            }
            else
            {
                e.Effect = DragDropEffects.None; // Do not allow other types
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // Retrieve the file paths
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null && filePaths.Length > 0)
                {
                    string filePath = filePaths[0]; // Take the first file

                    // Validate the file name
                    if (Path.GetFileName(filePath).Equals("SYSTEM.nub", StringComparison.OrdinalIgnoreCase))
                    {
                        PopulateTrackData(filePath);    // Call your method to process the file
                    }
                    else
                    {
                        MessageBox.Show(
                            "The dropped file is not a valid SYSTEM.nub file.",
                            "Invalid File",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while processing the dropped file: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // main function
        private void PopulateTrackData(string filePath)
        {
            try
            {
                currentFilePath = filePath; // Store the file path

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    label1.Text = "SYSTEM.nub is not Loaded";
                    label3.Visible = true;

                    if (fs.Length < 0x6380) // Ensure the file size is sufficient
                    {
                        MessageBox.Show("File is too small or corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get header hex
                    fs.Seek(0x10, SeekOrigin.Begin);
                    int fileHeaderHex = reader.ReadInt32();

                    fs.Seek(0, SeekOrigin.Begin);
                    byte[] fileHeaderBytes = reader.ReadBytes(fileHeaderHex);

                    // track count
                    fs.Seek(0xC, SeekOrigin.Begin);
                    int trackCount = reader.ReadInt32();

                    byte[] referenceBytesHeader;
                    byte[] referenceBytesBody;
                    int trackBytes;

                    switch (trackCount)
                    {
                        case 120:
                            referenceBytesHeader = referenceBytesHeader6;
                            referenceBytesBody = referenceBytesBody6;
                            trackBytes = 0x200;
                            label4.Text = "Loaded Version: MT6";
                            break;

                        case 94:
                            referenceBytesHeader = referenceBytesHeader5;
                            referenceBytesBody = referenceBytesBody5;
                            trackBytes = 0x1A0;
                            label4.Text = "Loaded Version: MT5";
                            break;

                        case 91:
                            referenceBytesHeader = referenceBytesHeader4;
                            referenceBytesBody = referenceBytesBody4;
                            trackBytes = 0x190;
                            label4.Text = "Loaded Version: MT4";
                            break;

                        default:
                            MessageBox.Show($"Unexpected track count: {trackCount}. Please verify the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Exit if the track count is not recognized
                    }

                    if (referenceBytesHeader == null || referenceBytesHeader.Length < fileHeaderHex)
                    {
                        MessageBox.Show("Reference header bytes are not loaded or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Compare the file header with the reference bytes
                    if (!fileHeaderBytes.SequenceEqual(referenceBytesHeader.Take(fileHeaderHex)))
                    {
                        MessageBox.Show("Loaded file header does not match the reference bytes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Compare the file body
                    fs.Seek(fileHeaderHex, SeekOrigin.Begin);
                    byte[] fileBodyBytes = reader.ReadBytes((int)(fs.Length - fileHeaderHex));
                    if (!fileBodyBytes.SequenceEqual(referenceBytesBody.Take(fileBodyBytes.Length)))
                    {
                        label2.Visible = true;
                        label2.Text = "Modified: True";
                    }

                    if (fileBodyBytes.SequenceEqual(referenceBytesBody.Take(fileBodyBytes.Length)))
                    {
                        label2.Visible = true;
                        label2.Text = "Modified: False";
                    }

                    dataGridView1.Columns.Add("TrackNumber", "Track Number");
                    dataGridView1.Columns.Add("TrackOffset", "Track Offset");
                    dataGridView1.Columns.Add("SfxOffset", "Sfx Offset");
                    dataGridView1.Columns.Add("SfxStart", "Sfx Start");
                    dataGridView1.Columns.Add("SfxEnd", "Sfx End");
                    dataGridView1.Columns.Add("SfxDuration", "Sfx Duration");

                    var viewDataButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "ViewDataButton",
                        HeaderText = "",
                        Text = "View",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(viewDataButtonColumn);

                    var exportDataButton = new DataGridViewButtonColumn
                    {
                        Name = "ExportDataButton",
                        HeaderText = "",
                        Text = "Export",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(exportDataButton);

                    var replaceDataButton = new DataGridViewButtonColumn
                    {
                        Name = "ReplaceDataButton",
                        HeaderText = "",
                        Text = "Replace",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(replaceDataButton);

                    // Read track list from 0x20 depends on loaded version
                    fs.Seek(0x20, SeekOrigin.Begin);
                    int trackIndex = 1;

                    for (int i = 0x20; i < trackBytes; i += 4)
                    {
                        if (trackIndex > trackCount) break;
                        int songOffset = trackBytes + (trackIndex - 1) * 0xD0;

                        if (songOffset + 0xD0 > fs.Length)
                        {
                            MessageBox.Show($"Track {trackIndex} song data exceeds file size.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        fs.Seek(songOffset + 0x14, SeekOrigin.Begin);
                        int duration = reader.ReadInt32();

                        fs.Seek(songOffset + 0x18, SeekOrigin.Begin);
                        int startOffset = reader.ReadInt32() + fileHeaderHex;
                        int endOffset = startOffset + duration;

                        fs.Seek(startOffset, SeekOrigin.Begin);
                        byte[] rawData = reader.ReadBytes(duration);                        

                        dataGridView1.Rows.Add(
                            $"Track {trackIndex}",
                            $"0x{i:X}",
                            $"0x{songOffset:X}",
                            $"{startOffset:X}",
                            $"{endOffset:X}",
                            $"{duration:X}"
                        );

                        trackIndex++;
                    }
                    label1.Text = "SYSTEM.nub is Loaded";
                    label2.Visible = true;
                    label3.Visible = false;
                    label4.Visible = true;

                    button2.Visible = true;
                    button4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for DataGridView CellClick
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                // Ignore clicks on headers or invalid cells
                return;
            }
            
            if (dataGridView1.Columns[e.ColumnIndex] == null)
            {
                return;
            }

            string songStartHex = dataGridView1.Rows[e.RowIndex].Cells["SfxStart"].Value.ToString();
            string songDurationHex = dataGridView1.Rows[e.RowIndex].Cells["SfxDuration"].Value.ToString();

            int startOffset = Convert.ToInt32(songStartHex, 16);
            int duration = Convert.ToInt32(songDurationHex, 16);

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ViewDataButton")
            {
                try
                {
                    using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        fs.Seek(startOffset, SeekOrigin.Begin);
                        byte[] rawData = reader.ReadBytes(duration);
                        string rawDataHex = BitConverter.ToString(rawData).Replace("-", " ");

                        // Show the raw data in a new form
                        using (Form viewForm = new Form())
                        {
                            viewForm.Text = $"Raw Data for Track {e.RowIndex + 1}";
                            viewForm.Size = new Size(600, 400);

                            TextBox textBox = new TextBox
                            {
                                Multiline = true,
                                ReadOnly = true,
                                ScrollBars = ScrollBars.Vertical,
                                Dock = DockStyle.Fill,
                                Text = rawDataHex
                            };

                            viewForm.Controls.Add(textBox);
                            viewForm.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading raw data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ExportDataButton")
            {
                try
                {
                    using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        fs.Seek(startOffset, SeekOrigin.Begin);
                        byte[] rawData = reader.ReadBytes(duration);

                        // Prompt user to save the file
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(saveFileDialog.FileName, rawData);
                                MessageBox.Show("Raw data successfully exported.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading raw data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ReplaceDataButton")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = openFileDialog.FileName;

                    try
                    {
                        // Read the raw data from the selected file
                        byte[] rawData;
                        using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                        using (BinaryReader reader = new BinaryReader(fs))
                        {
                            rawData = reader.ReadBytes((int)fs.Length); // Read the entire file
                        }

                        if (rawData.Length > duration)
                        {
                            MessageBox.Show($"Loaded file exceed the duration limit.\nOperation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Create a buffer with the exact size of the duration
                        byte[] fullData = new byte[duration];

                        // Copy the raw data into the buffer
                        Array.Copy(rawData, fullData, rawData.Length);

                        // Fill the remaining bytes with 0x00 (if any)
                        for (int i = rawData.Length; i < duration; i++)
                        {
                            fullData[i] = 0x00;
                        }

                        string origCopy = currentFilePath + ".orig";
                        if (!File.Exists(origCopy))
                        {
                            File.Copy(currentFilePath, origCopy);
                        }

                        string backupFilePath = currentFilePath + ".bak";
                        File.Copy(currentFilePath, backupFilePath, overwrite: true);

                        using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            fs.Seek(startOffset, SeekOrigin.Begin);
                            fs.Write(fullData, 0, fullData.Length); // Write the full data (including padding) to the specified offset
                        }

                        PopulateTrackData(currentFilePath);

                        MessageBox.Show("Data successfully replaced.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error replacing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        // read raw bytes
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Title = "Select File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;

                try
                {
                    byte[] rawData;
                    using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        rawData = reader.ReadBytes((int)fs.Length); // Read the entire file
                    }

                    string rawDataHex = BitConverter.ToString(rawData).Replace("-", " ");

                    using (Form viewForm = new Form())
                    {
                        viewForm.Text = "Raw Data";
                        viewForm.Size = new Size(600, 400);

                        TextBox textBox = new TextBox
                        {
                            Multiline = true,
                            ReadOnly = true,
                            ScrollBars = ScrollBars.Vertical,
                            Dock = DockStyle.Fill,
                            Text = rawDataHex
                        };

                        viewForm.Controls.Add(textBox);
                        viewForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // export all track
        private void button2_Click(object sender, EventArgs e)
        {
            ExportRawDataFromDataGrid(dataGridView1, currentFilePath);
        }

        private void ExportRawDataFromDataGrid(DataGridView dataGridView, string currentFilePath)
        {
            if (label1.Text != "SYSTEM.nub is Loaded")
            {
                MessageBox.Show("SYSTEM.nub file is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select Save Location";
                saveFileDialog.Filter = "All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        string songStartHex = dataGridView.Rows[i].Cells["SfxStart"].Value.ToString();
                        string songDurationHex = dataGridView.Rows[i].Cells["SfxDuration"].Value.ToString();

                        int startOffset = Convert.ToInt32(songStartHex, 16);
                        int duration = Convert.ToInt32(songDurationHex, 16);

                        fs.Seek(startOffset, SeekOrigin.Begin);
                        byte[] rawData = reader.ReadBytes(duration);

                        string savePath = Path.Combine(
                            Path.GetDirectoryName(saveFileDialog.FileName),
                            $"{Path.GetFileNameWithoutExtension(saveFileDialog.FileName)} {i + 1}{Path.GetExtension(saveFileDialog.FileName)}"
                        );
                        File.WriteAllBytes(savePath, rawData);
                    }

                    MessageBox.Show("Raw data successfully exported.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // restore to default
        private void button4_Click(object sender, EventArgs e)
        {
            if (label2.Text != "Modified: True")
            {
                MessageBox.Show("Loaded SYSTEM.nub file is not Modified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.ReadWrite))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    // Get header hex
                    fs.Seek(0x10, SeekOrigin.Begin);
                    int fileHeaderHex = reader.ReadInt32();

                    // track count
                    fs.Seek(0xC, SeekOrigin.Begin);
                    int trackCount = reader.ReadInt32();

                    byte[] referenceBytesHeader;
                    byte[] referenceBytesBody;

                    switch (trackCount)
                    {
                        case 120:
                            referenceBytesHeader = referenceBytesHeader6;
                            referenceBytesBody = referenceBytesBody6;
                            break;

                        case 94:
                            referenceBytesHeader = referenceBytesHeader5;
                            referenceBytesBody = referenceBytesBody5;
                            break;

                        case 91:
                            referenceBytesHeader = referenceBytesHeader4;
                            referenceBytesBody = referenceBytesBody4;
                            break;

                        default:
                            MessageBox.Show($"Unexpected track count: {trackCount}. Please verify the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Exit if the track count is not recognized
                    }

                    if (referenceBytesBody == null || referenceBytesBody.Length == 0)
                    {
                        MessageBox.Show("Reference bytes are not loaded. Please check LoadReferenceBody().", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (fs.Length < 0x6800)
                    {
                        MessageBox.Show("The loaded file is too small or corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    fs.Seek(fileHeaderHex, SeekOrigin.Begin); // Start writing
                    fs.Write(referenceBytesBody, 0, referenceBytesBody.Length); // Write the entire reference body
                }
                PopulateTrackData(currentFilePath);

                MessageBox.Show("Bytes restored to default successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restore bytes:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
