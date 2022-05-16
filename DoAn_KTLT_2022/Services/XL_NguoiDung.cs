using DoAn_KTLT_2022.Entities;
using DoAn_KTLT_2022.DAL;
namespace DoAn_KTLT_2022.Services
{
    public class XL_NguoiDung
    {
        public static bool CheckPassWord(string a, string b)
        {
            if (a == null || b == null || a != b)
            {
                return false;
            }
            return true;    
        }

        public static bool DangKy(string userName, string passWord, string fullName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord) || string.IsNullOrEmpty(fullName))
            {
                return false;
            }
            NGUOIDUNG? user = LuuTruNguoiDung.TimNguoiDung(userName);
            if (user != null)
            {
                return false;
            }
            else
            {
                NGUOIDUNG newUser;
                newUser.UserName = userName;
                newUser.PassWord = passWord;
                newUser.FullName = fullName;
                return LuuTruNguoiDung.ThemNguoiDung(newUser);
            }
        }

        public static NGUOIDUNG? DangNhap(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                return null;
            }
            NGUOIDUNG? user = LuuTruNguoiDung.TimNguoiDung(userName);
            if (user != null  && user.Value.PassWord == passWord)
            {
                return user;
            }
            return null;
        }    
    }
}
