using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyVersion("1.1.*")] //Set Version


namespace CNLConfiguration
{


    public partial class MainForm : Form
    {
        public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version + " (CNL: 1.1)"; //Version in string form to be displayed

        private bool applyChanges = true; //If true changes will be applied on window close
        private string[] curSaveData; //The data that is currently saved to the save file
        private bool[] valueChanged = new bool[(int) SaveLoad.Data.LENGTH]; //True if value at that index has been changed compared to save-file

        public MainForm()
        {
            InitializeComponent();

            //Set up tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            string retryToolTip = "Retry connecting <n> times/infinitely if first login attempt fails";
            toolTip.SetToolTip(this.retryLbl, retryToolTip);
            toolTip.SetToolTip(this.timesLbl, retryToolTip);
            toolTip.SetToolTip(this.retryInfinitBox, retryToolTip);

            string checkConToolTip = "Check if you are still logged in every <n> minutes, otherwhise close app after login";
            toolTip.SetToolTip(this.checkConBox, checkConToolTip);
            toolTip.SetToolTip(this.everyLbl, checkConToolTip);
            toolTip.SetToolTip(this.minutesLbl, checkConToolTip);

            string applyToolTip = "Closing this window will also apply changes";
            toolTip.SetToolTip(this.applyBtn, applyToolTip);

            string cancelToolTip = "Close window without saving";
            toolTip.SetToolTip(this.cancelBtn, cancelToolTip);


            //Load savedata
            if (SaveLoad.SaveFileExists())
            {
                curSaveData = SaveLoad.LoadSave();
                ApplySaveData();
            }
            else
            {
                curSaveData = null;
            }

            if(curSaveData == null)
            {
                applyBtn.Enabled = true;
                //Update checkConlbls
                checkConBox_CheckedChanged(this, null);
            }
        }

        //Method fired when retry infinitely checkbox changed
        private void retryInfinitBox_CheckedChanged(object sender, EventArgs e)
        {
            if (retryInfinitBox.Checked)
            {
                //Disable retry input
                timesLbl.ForeColor = Color.Gray;
                retryInput.Enabled = false;
                CheckValueChange("-1", (int) SaveLoad.Data.RETRY);
            }
            else
            {
                //Enable retry input
                timesLbl.ForeColor = Color.Black;
                retryInput.Enabled = true;
                CheckValueChange(retryInput.Text, (int)SaveLoad.Data.RETRY);
            }
        }

        //Method fired when check connection after login checkbox checked
        private void checkConBox_CheckedChanged(object sender, EventArgs e)
        {
            Color newColor;
            if (checkConBox.Checked)
            {
                //Enable check connection value input
                newColor = Color.Black;
                CheckValueChange(checkInput.Text, (int)SaveLoad.Data.CHECK);
            }
            else
            {
                //Disable check connection value input
                newColor = Color.Gray;
                CheckValueChange("", (int)SaveLoad.Data.CHECK);
            }

            everyLbl.ForeColor = newColor;
            minutesLbl.ForeColor = newColor;
            checkInput.Enabled = checkConBox.Checked;
        }

        //Method fired when cancel button clicked
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Close without saving
            applyChanges = false;
            this.Close();
        }

        //Filter for textboxes to only enable number input
        private void Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        //Set textBox values to "0" if they lose focus but are still empty
        private void Input_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (String.IsNullOrEmpty(box.Text))
            {
                box.Text = "0";
            }
        }

        //Method fired when default button pressed
        private void defaultBtn_Click(object sender, EventArgs e)
        {
            //Apply default values to advanced settings
            this.retryInfinitBox.Checked = false;
            this.retryInput.Text = "5";
            this.checkConBox.Checked = false;
            this.checkInput.Text = "15";
            this.showDebugBox.Checked = false;
        }

        //Method fired when apply button pressed
        private void applyBtn_Click(object sender, EventArgs e)
        {
            curSaveData = GetNewSaveData();
            SaveLoad.Save(curSaveData);

            //Reset valueChanged array and disable apply button
            for(int i = 0; i<valueChanged.Length; i++)
            {
                valueChanged[i] = false;
            }
            applyBtn.Enabled = false;
        }

        //Method fired when text inputs of Username or Password changed
        private void UnameInput_TextChanged(object sender, EventArgs e)
        {
            CheckValueChange(unameInput.Text, (int) SaveLoad.Data.USER);
        }
        private void passwInput_TextChanged(object sender, EventArgs e)
        {
            CheckValueChange(passwInput.Text, (int)SaveLoad.Data.PW);
        }

        //Check if new input given in "newValue" for element given in "index" is different from current saved value
        private void CheckValueChange(string newValue, int index)
        {
            
            if (curSaveData == null) //If there is no saved data always enable apply button
            {
                applyBtn.Enabled = true;
                return;
            }
            if (index >= curSaveData.Length || !newValue.Equals(curSaveData[index])) //If index of element to be checked exceeds curSaveData length 
            {                                                                        //(for backwards compatibility, normally index should never exceed curSaveData length 
                valueChanged[index] = true;                                          //unless this option was not saved in previous version) or if newValue differs from 
                applyBtn.Enabled = true;                                             //curSaveData at that index enable apply button and set valueChanged to true
                return;
            }
            else
            {
                valueChanged[index] = false;
            }


            //Check if any value still differs from saved data if not disable apply button
            foreach(bool changed in valueChanged)
                if (changed)
                    return;
            applyBtn.Enabled = false;
        }

        //Method fired when text of retry value or check after login value textbox changed
        private void retryInput_TextChanged(object sender, EventArgs e)
        {
            CheckValueChange(retryInput.Text, (int)SaveLoad.Data.RETRY);
        }
        private void checkInput_TextChanged(object sender, EventArgs e)
        {
            CheckValueChange(checkInput.Text, (int)SaveLoad.Data.CHECK);
        }


        //Method fired when show debug window checkbox checked
        private void showDebugBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showDebugBox.Checked)
            {
                CheckValueChange("1", (int)SaveLoad.Data.DEBUG);
            }
            else
            {
                CheckValueChange("0", (int)SaveLoad.Data.DEBUG);
            }
        }


        //Method fired when window is closing
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (applyChanges && applyBtn.Enabled)
            {
                Console.WriteLine("Closing with saving!");
                curSaveData = GetNewSaveData();
                SaveLoad.Save(curSaveData);
            }
            else
            {
                Console.WriteLine("Closing without saving!");
            }
        }


        

        //Creates string array with current window data where each index is its own value to be saved
        //The values are saved in the order of SaveLoad.Data enum order
        private string[] GetNewSaveData()
        {
            string[] newSaveData = new string[(int) SaveLoad.Data.LENGTH];
            newSaveData[(int) SaveLoad.Data.USER] = unameInput.Text;
            newSaveData[(int) SaveLoad.Data.PW] = passwInput.Text;
            if (retryInfinitBox.Checked)
            {
                newSaveData[(int)SaveLoad.Data.RETRY] = "-1";
            }
            else
            {
                newSaveData[(int)SaveLoad.Data.RETRY] = retryInput.Text;
            }
            if (checkConBox.Checked)
            {
                newSaveData[(int)SaveLoad.Data.CHECK] = checkInput.Text;
            }
            else
            {
                newSaveData[(int)SaveLoad.Data.CHECK] = "";
            }
            if (showDebugBox.Checked)
            {
                newSaveData[(int)SaveLoad.Data.DEBUG] = "1";
            }
            else
            {
                newSaveData[(int)SaveLoad.Data.DEBUG] = "0";
            }


            return newSaveData;
        }

        //Apply data from curSaveData to Window elements
        private void ApplySaveData()
        {
            if(curSaveData == null)
            {
                return;
            }
            try
            {
                unameInput.Text = curSaveData[(int)SaveLoad.Data.USER];
                passwInput.Text = curSaveData[(int)SaveLoad.Data.PW];
                if (int.Parse(curSaveData[(int)SaveLoad.Data.RETRY]) == -1)
                {
                    retryInfinitBox.Checked = true;
                }
                else
                {
                    retryInput.Text = curSaveData[(int)SaveLoad.Data.RETRY];
                }
                if (String.IsNullOrEmpty(curSaveData[(int)SaveLoad.Data.CHECK]))
                {
                    checkConBox.Checked = false;
                    checkConBox_CheckedChanged(this, null);
                }
                else
                {
                    checkConBox.Checked = true;
                    checkInput.Text = curSaveData[(int)SaveLoad.Data.CHECK];
                }
                if(curSaveData.Length>(int) SaveLoad.Data.LENGTH-1 && int.Parse(curSaveData[(int)SaveLoad.Data.DEBUG]) == 1) //This configuration is optional for downwards compatibility reasons 
                {
                    showDebugBox.Checked = true;
                }
                else
                {
                    showDebugBox.Checked = false;
                }
                
            }
            catch(Exception)
            {
                //Unexpected value in one of the loaded saveData, ask user to delete save file and create a new one, should normally only happen if user messed with save file (damn those incredulous users) or if graceful degredation failed
                curSaveData = null;
                Console.WriteLine("Fatal Error! SaveData corrupted!");
                DialogResult result = MessageBox.Show("The save-file seems to have corrupted! Do you want to delete it and create a new one?", "CNL-Options Error", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    deleteSaveFile();
                    applyBtn.Enabled = true;
                }
                else
                {
                    return;
                }
            }
        }

        //Method fired when delete all data toolstrip item clicked
        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSaveFile();
        }

        //Actually deletes the save file
        private void deleteSaveFile()
        {
            if (SaveLoad.SaveFileExists())
            {
                SaveLoad.DeleteSave();
                applyBtn.Enabled = true;
                MessageBox.Show(this, "The save-file has been deleted!", "Success", MessageBoxButtons.OK);
            }
            else //Save file does not exist, tell user
            {
                MessageBox.Show(this, "The save-file does not exist!", "Error", MessageBoxButtons.OK);
            }
        }

        //Method fired when help toolstrip item clicked
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkMessageBox.Show("CNL - Help", "Need help with CNL?\nPlease visit <a>ArztSamuel.github.io</a> for detailed help.", "http://arztsamuel.github.io/en/projects/csharp/cnl/help.html");
        }

        //Method fired when whoMadeThis toolstrip item clicked
        private void whoMadeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkMessageBox.Show("Who Made CNL", "This software was made by Samuel Arzt.\nContact me under \nsarzt.mmt-b2015@fh-salzburg.ac.at \nor visit my website: <a>ArztSamuel.github.io</a>", "http://arztsamuel.github.io");
        }

        //Method fired when info toolstrip item clicked
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkMessageBox.Show("CNL - Info","CNL - CampusNetLogin\nVersion: " + VERSION + "\n2016 - Samuel Arzt\nFor updates visit <a>ArztSamuel.github.io</a>!", "http://arztsamuel.github.io/en/projects/csharp/cnl/cnl.html");
        }
    }
}
