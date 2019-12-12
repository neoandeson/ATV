using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Forms.AdminForms
{
    public partial class CreateAccountForm : CommonForm
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private bool CheckExistUsername()
        {
            UserService userService = null;
            bool result = false;
            try
            {
                userService = new UserService();
                string username = txtUsername.Text.Trim();
                bool existed = userService.CheckExistUserName(username);
                if (existed)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userService = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserService userService = null;

            try
            {
                bool existed = CheckExistUsername();
                userService = new UserService();
                if (existed)
                {
                    Utilities.ShowError("Username đã tồn tại");
                } else
                {
                    string username = txtUsername.Text.Trim();
                    string fullName = txtFullName.Text.Trim();

                    userService.CreateUser(username, fullName);
                    Utilities.ShowMessage("Đã tạo tài khoản username: " + username + " với mật khẩu mặc định.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userService = null;
            }
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            bool existed = CheckExistUsername();
            if (existed)
            {
                Utilities.ShowError("Username đã tồn tại");
            }
        }
    }
}
