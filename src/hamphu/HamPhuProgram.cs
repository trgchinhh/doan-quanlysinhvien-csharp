using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
	internal class HamPhuProgram {
		// hàm phụ cho hàm main 

		public static void DungChuongTrinh() {
			Console.Write("Nhấn phím bất kỳ để tiếp tục ...");
			Console.ReadKey();
		}

		public static string[] MenuDangNhap = {
			"[01] Thông tin",
			"[02] Đăng nhập",
			"[03] Đăng ký",
			"[04] Xem tài khoản giảng viên",
			"[05] Thoát"
		};

		public static string[] MenuGiangVien = {
			"[01] Quản lý lớp",
			"[02] Sửa thông tin giảng viên",
			"[03] Đăng xuất"
		};

		public static string[] MenuQuanLySinhVien = {
		    "[01] Xem danh sách",
		    "[02] Thêm sinh viên",
		    "[03] Sửa thông tin",
		    "[04] Lọc thông tin",
		    "[05] Sắp xếp thông tin",
		    "[06] Xóa thông tin",
		    "[07] Thống kê",
		    "[08] Quay lại"
		};

	}
}
