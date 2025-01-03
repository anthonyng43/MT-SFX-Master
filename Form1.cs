using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

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
        private byte[] referenceBytesHeader5jp;
        private byte[] referenceBytesBody5jp;
        private byte[] referenceBytesHeader5en;
        private byte[] referenceBytesBody5en;
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
            LoadReferenceHeader5jp();
            LoadReferenceBody5jp();
            LoadReferenceHeader5en();
            LoadReferenceBody5en();
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
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceNames = new[]
                {
                    "MT_SFX_Master.Resources.body1", // sfx 1 to 89 (sfx 91 included)
                    "MT_SFX_Master.Resources.sfx90mt6", // sfx 90 for mt6
                    "MT_SFX_Master.Resources.body2mt6" // sfx 92 to 120
                };

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (var resourceName in resourceNames)
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null)
                            {
                                throw new Exception($"Resource '{resourceName}' not found. Ensure it is embedded correctly.");
                            }
                            stream.CopyTo(memoryStream);
                        }
                    }

                    referenceBytesBody6 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference files:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceHeader5jp()
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
                    referenceBytesHeader5jp = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceBody5jp()
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceNames = new[]
                {
                    "MT_SFX_Master.Resources.body1", // sfx 1 to 89 (sfx 91 included)
                    "MT_SFX_Master.Resources.sfx90mt5", // sfx 90
                    "MT_SFX_Master.Resources.sfx92",
                    "MT_SFX_Master.Resources.sfx93",
                    "MT_SFX_Master.Resources.sfx94"
                };

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (var resourceName in resourceNames)
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null)
                            {
                                throw new Exception($"Resource '{resourceName}' not found. Ensure it is embedded correctly.");
                            }
                            stream.CopyTo(memoryStream);
                        }
                    }

                    referenceBytesBody5jp = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference files:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceHeader5en()
        {
            try
            {
                // Get the assembly and resource stream
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("MT_SFX_Master.Resources.header5en"))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    if (stream == null)
                    {
                        throw new Exception("Resource not found. Ensure 'header' is embedded correctly.");
                    }

                    stream.CopyTo(memoryStream);
                    referenceBytesHeader5en = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReferenceBody5en()
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceNames = new[]
                {
                    "MT_SFX_Master.Resources.body1", // sfx 1 to 89 (sfx 91 included)
                    "MT_SFX_Master.Resources.sfx90mt5", // sfx 90
                    "MT_SFX_Master.Resources.sfx92",
                };

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (var resourceName in resourceNames)
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null)
                            {
                                throw new Exception($"Resource '{resourceName}' not found. Ensure it is embedded correctly.");
                            }
                            stream.CopyTo(memoryStream);
                        }
                    }

                    referenceBytesBody5en = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference files:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceNames = new[]
                {
                    "MT_SFX_Master.Resources.body1", // sfx 1 to 89 (sfx 91 included)
                    "MT_SFX_Master.Resources.sfx90mt5", // sfx 90
                };

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (var resourceName in resourceNames)
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream == null)
                            {
                                throw new Exception($"Resource '{resourceName}' not found. Ensure it is embedded correctly.");
                            }
                            stream.CopyTo(memoryStream);
                        }
                    }

                    referenceBytesBody4 = memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load embedded reference files:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to convert big-endian PCM data to little-endian
        private byte[] ConvertBigEndianToLittleEndian(byte[] bigEndianData)
        {
            byte[] littleEndianData = new byte[bigEndianData.Length];
            for (int i = 0; i < bigEndianData.Length; i += 2)
            {
                if (i + 1 < bigEndianData.Length)
                {
                    littleEndianData[i] = bigEndianData[i + 1];
                    littleEndianData[i + 1] = bigEndianData[i];
                }
            }
            return littleEndianData;
        }

        // browse button
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = false;

            button2.Visible = false;
            button4.Visible = false;

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
                            label4.Text = "Loaded Version:\nMT6 Series JP";
                            break;

                        case 94:
                            referenceBytesHeader = referenceBytesHeader5jp;
                            referenceBytesBody = referenceBytesBody5jp;
                            trackBytes = 0x1A0;
                            label4.Text = "Loaded Version:\nMT5DXP JP";
                            break;

                        case 92:
                            referenceBytesHeader = referenceBytesHeader5en;
                            referenceBytesBody = referenceBytesBody5en;
                            trackBytes = 0x190;
                            label4.Text = "Loaded Version:\nMT5 EN";
                            break;

                        case 91:
                            referenceBytesHeader = referenceBytesHeader4;
                            referenceBytesBody = referenceBytesBody4;
                            trackBytes = 0x190;
                            label4.Text = "Loaded Version:\nMT4 JP";
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
                    dataGridView1.Columns.Add("SfxRate", "Sfx Rate");

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

                    var previewButton = new DataGridViewButtonColumn
                    {
                        Name = "PlayDataButton",
                        HeaderText = "",
                        Text = "Play",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(previewButton);

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

                        fs.Seek(songOffset + 0xC0, SeekOrigin.Begin);
                        int songRate = reader.ReadInt32();
                        
                        switch(trackIndex)
                        {
                            case 68:
                                songRate = 88200;
                                break;

                            case 93:
                                songRate = 96000;
                                break;

                            case 94:
                                songRate = 96000;
                                break;
                        }

                        dataGridView1.Rows.Add(
                            $"Track {trackIndex}",
                            $"0x{i:X}",
                            $"0x{songOffset:X}",
                            $"{startOffset:X}",
                            $"{endOffset:X}",
                            $"{duration:X}",
                            $"{songRate} Hz"
                        );

                        trackIndex++;
                    }
                    label1.Text = "SYSTEM.nub is Loaded";
                    label4.Location = new System.Drawing.Point(351, 35);
                    label4.Size = new System.Drawing.Size(150, 30);
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
            string sfxRateValue = dataGridView1.Rows[e.RowIndex].Cells["SfxRate"]?.Value?.ToString()?.Replace(" Hz", "");

            int startOffset = Convert.ToInt32(songStartHex, 16);
            int duration = Convert.ToInt32(songDurationHex, 16);
            if (string.IsNullOrEmpty(songStartHex) || string.IsNullOrEmpty(songDurationHex) || string.IsNullOrEmpty(sfxRateValue))
            {
                MessageBox.Show("One or more required fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(sfxRateValue, out int songRate))
            {
                MessageBox.Show($"Invalid sample rate: {sfxRateValue}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "PlayDataButton")
            {
                try
                {
                    using (FileStream fs = new FileStream(currentFilePath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        fs.Seek(startOffset, SeekOrigin.Begin);
                        byte[] rawData = reader.ReadBytes(duration);

                        // Convert from big-endian to little-endian
                        byte[] littleEndianData = ConvertBigEndianToLittleEndian(rawData);

                        // Open playback window
                        PlaybackForm playbackForm = new PlaybackForm(littleEndianData, songRate, 16, 1);
                        playbackForm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading raw data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            referenceBytesHeader = referenceBytesHeader5jp;
                            referenceBytesBody = referenceBytesBody5jp;
                            break;

                        case 92:
                            referenceBytesHeader = referenceBytesHeader5en;
                            referenceBytesBody = referenceBytesBody5en;
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

    public partial class PlaybackForm : Form
    {
        private IWavePlayer waveOut;
        private WaveStream waveStream;
        private byte[] audioData;
        private WaveFormat waveFormat;
        private bool isLooping;

        public PlaybackForm(byte[] audioData, int sampleRate, int bitDepth, int channels)
        {
            InitializePlay();

            this.audioData = audioData;
            this.waveFormat = new WaveFormat(sampleRate, bitDepth, channels);

            this.FormClosed += PlaybackForm_FormClosed;
        }

        private void PlaybackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAudio();
        }

        private void PlayOnceButton_Click(object sender, EventArgs e)
        {
            PlayAudio(false);
        }

        private void PlayLoopButton_Click(object sender, EventArgs e)
        {
            PlayAudio(true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopAudio();
        }

        private void PlayAudio(bool loop)
        {
            StopAudio(); // Stop any existing playback

            isLooping = loop;
            MemoryStream ms = new MemoryStream(audioData);
            waveStream = new RawSourceWaveStream(ms, waveFormat);

            if (loop)
            {
                waveStream = new LoopStream(waveStream);
            }

            waveOut = new WaveOutEvent();
            waveOut.Init(waveStream);
            waveOut.Play();
        }

        private void StopAudio()
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            waveOut = null;

            waveStream?.Dispose();
            waveStream = null;
        }
    }

    // LoopStream class to handle looping
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
        }

        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        public override long Length => sourceStream.Length;

        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    sourceStream.Position = 0; // Restart the stream
                }
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}
