using System.Drawing;
using System.Windows.Forms;



namespace CNLConfiguration
{

    //Custom MessageBox that can display clickable links

    static class LinkMessageBox
    {
        private static Form form; //Window
        private static string curLink = null; //Save used link for LinkClicked event

        public static DialogResult Show(string caption, string text, string link)
        {
            curLink = link;

            //Initialize Form
            form = new Form();
            form.Size = new Size(350, 170);
            form.Text = caption;
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;

            //Initialize Linklabel (used for content including link)
            LinkLabel lbl = new LinkLabel();
            int start = text.IndexOf("<a>"); //<a> and </a> indicate beginning and end of link
            
            //get rid of <a> tag and determine link area
            int length = -1;
            if(start != -1)
            {
                text = text.Substring(0, start) + text.Substring(start + 3);
                length = text.IndexOf("</a>")-start;
                if(length > 0)
                {
                    text = text.Substring(0, start + length) + text.Substring(start + length + 4);
                    lbl.LinkArea = new LinkArea(start, length); //set link area
                }
            }
            
            if(start < 0 || length < 0) //If link tags are non existent or corrupted
            {
                lbl.LinkArea = new LinkArea(0, 0);
            }

            lbl.Text = text;
            lbl.Font = new Font("Arial", 10f);
            lbl.AutoSize = true;
            lbl.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
            form.Controls.Add(lbl);

            //Add OK button
            Button btn1 = new Button();
            btn1.Text = "Ok";
            btn1.Size = new Size(72, 23);
            form.Controls.Add(btn1);
            form.AcceptButton = btn1;
            btn1.DialogResult = DialogResult.OK;

            //Set component locations
            lbl.Location = new Point((form.ClientSize.Width - lbl.Width) / 2, 20);
            btn1.Location = new Point((form.ClientSize.Width - btn1.Width) / 2, form.ClientSize.Height - btn1.Height - 10);

            return form.ShowDialog();
        }


        //Method executed when link is clicked
        private static void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(curLink != null)
            {
                System.Diagnostics.Process.Start(curLink);
            }
        }
    }
}
