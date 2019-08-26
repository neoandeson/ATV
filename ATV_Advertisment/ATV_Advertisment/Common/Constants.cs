using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.Common
{
    public static class Constants
    {
        public static class CommonStatus
        {
            public static int ACTIVE = 1;
            public static int DISABLE = 0;
            public static int DELETE = -1;
        }

        public static class CommonMessage
        {
            public static string INVALID_LOGIN = "Thông tin đăng nhâp không đúng";
            public static string UNAUTHORIZED = "Không có quyền truy cập";
            public static string ALREADY_LOGIN = "Tài khoản hiện đang được đăng nhập";

            public static string APPLICATION_IS_RUNNING = "Ứng dụng đang chạy";
            public static string ADD_SUCESSFULLY = "Thêm mới thành công";
            public static string EDIT_SUCESSFULLY = "Cập nhật thành công";
            public static string DELETE_SUCESSFULLY = "Xóa thành công";
            public static string UPDATE_SUCESSFULLY = "Cập nhật thành công";
        }

        public static class ADGVText
        {
            //Customers
            public static string Name = "Tên";
            public static string Code = "Mã";
            public static string Address = "Địa chỉ";
            public static string TaxCode = "Mã số thuế";
        }

        public static class BusinessLogType
        {

        }

        public static class SystemLogType
        {

        }

        #region Controls
        public static class ControlsAttribute
        {
            public static int TEXTBOX_WIDTH_SMALL = 100;
            public static int TEXTBOX_WIDTH_NORMAL = 140;
            public static int TEXTBOX_HEIGHT = 26;

            public static int GV_WIDTH_NORMAL = 120;
        }
        #endregion
    }
}
