using RapChieuPhim.Dao;
using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapChieuPhim.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
       [HttpPost]
        public bool Login(string username,string password)
        {
            var dao = new TaiKhoanDao();
            
                TaiKhoan taiKhoan = dao.checkTaikhoan(username,password);
            if (taiKhoan != null)
            {
                Session.Add("USERSESSIO",taiKhoan);
                return true;

            }
            return false;
        }
        [HttpPost]
        public bool Register(string username,string email, string password)
        {
            Boolean check = true;
          
                var dao = new TaiKhoanDao();
          
            TaiKhoan taiKhoan = new TaiKhoan();

                taiKhoan.TenDangNhap = email;
                taiKhoan.MatKhau = password;
                taiKhoan.TinhTrang = true;
                taiKhoan.NgayDangKy = DateTime.Now;
                dao.SaveTaiKhoan(taiKhoan);

            
          
            return check;
       
        }
        public ActionResult Logout(string username, string email, string password)
        {

            Session.RemoveAll();

            return Redirect("/Home");

        }

    }
}