using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendEmail.Adapters;
using SendEmail.Util;
using SendEmail.Model;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        private ChilkatEmailAdapter _adapter;
        public Form1()
        {
            InitializeComponent();
            _adapter = new ChilkatEmailAdapter(ChilkatEmailAdapterHelper.GetUnlockKey());
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            var email = new Email();
            email.From = "capture.test111@gmail.com";
            email.Body = richBody.Text;
            email.Subject = txtSubject.Text;
            email.AddToRecipient(txtRecipient.Text);
            try
            {
                _adapter.SendEmail(ChilkatEmailAdapterHelper.GetSendEmailConfiguration(), email);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
