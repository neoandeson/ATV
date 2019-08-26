using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.ListForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ATV_Advertisment.Common
{
    public static class Utilities
    {
        public static Hashtable OpenedForms = new Hashtable();
        public static Hashtable MenuItemNames = new Hashtable();

        public static void ShowMessage(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool IsNumberic(string strNum, out int number)
        {
            bool isNumeric = int.TryParse(strNum, out number);
            return isNumeric;
        }

        public static DateTime GetServerDateTimeNow()
        {
            DateTime dt;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT GETDATE()", conn);
                conn.Open();

                dt = (DateTime)cmd.ExecuteScalar();
            };
            return dt;
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<int, string> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static Form OpenFormByName(string formName, out bool isLogout)
        {
            Form form = null;
            bool isFunctionLogout = false;
            if (!string.IsNullOrWhiteSpace(formName))
            {
                formName = formName.Trim();

                //Check if form is opened
                if (OpenedForms.Contains(formName))
                {
                    form = (Form)OpenedForms[formName];
                    form.Dispose();
                    if (form.IsDisposed)
                    {
                        OpenedForms.Remove(formName);
                        form = null;
                    }
                }

                switch (formName)
                {
                    case "Danh mục khách hàng":
                        ListCustomerForm listCustomerForm = new ListCustomerForm();
                        form = (Form)listCustomerForm;
                        break;
                    //case "Advertisement":
                    //    AdvertisementForm advertisementForm = new AdvertisementForm();
                    //    form = (Form)advertisementForm;
                    //    break;

                    case "Logout":
                        Session.Logout();
                        isFunctionLogout = true;
                        break;
                    case "Exit":
                        Application.Exit();
                        break;

                }

                if (form != null)
                {
                    form.Owner = GlobalForm.ActiveForm;
                    form.MdiParent = GlobalForm.ActiveForm;
                    form.ShowInTaskbar = true;
                    form.BringToFront();
                    form.TopMost = true;
                    form.MinimizeBox = true;
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.CenterScreen;

                    form.Show();

                    if (!OpenedForms.Contains(formName))
                    {
                        OpenedForms.Add(formName, form);
                    }
                }
            }

            isLogout = isFunctionLogout;
            return form;
        }
    }
}
