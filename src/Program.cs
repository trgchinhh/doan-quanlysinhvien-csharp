using DoAn_QuanLySinhVien;
using System;
using System.Text;
using Spectre.Console;

public class Program {        
	public static void Main() {
		Console.Clear();
		Banner.Inbanner(Banner.BannerDoAnTinHoc);
		QuanLyGiangVien quanlygiangvien = new QuanLyGiangVien();
		int luachontruoc = 0;
		while (true) {
			Console.Clear();
			Banner.Inbanner(Banner.BannerXacThuc);
			AnsiConsole.Write(
				new Panel(
					$"Dùng phím [yellow]{Markup.Escape("↑ ↓")}[/] để điều khiển mũi tên menu\n" +
					$"Dùng phím [yellow]{Markup.Escape("Enter")}[/] để chọn\n\n" +
					$"- Chọn [yellow]{Markup.Escape("[01]")}[/] để đăng nhập\n" +
					$"- Chọn [yellow]{Markup.Escape("[02]")}[/] để tự tạo tài khoản mới\n" +
					$"- Chọn [yellow]{Markup.Escape("[03]")}[/] để xem tài khoản đăng nhập mẫu"
				)
				.Header($"Hướng dẫn")
			);
			Console.WriteLine();
			Console.WriteLine("  (↑ ↓) MENU");
			var luachon = AnsiConsole.Prompt(
				new SelectionPrompt<int>()
				.AddChoices(1, 2, 3, 4, 5)
				.WrapAround(true)
				.HighlightStyle(Mau.Maumacdinh)
				.DefaultValue(luachontruoc)
				.UseConverter(x => Markup.Escape(
					HamPhuProgram.MenuDangNhap[x-1]
				))
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if(luachon == 1){
				ThongTin.InThongTin();
				continue;
			} else if (luachon == 2) {
				GiangVien giangvien = quanlygiangvien.DangNhap();
				if (giangvien == null) {
					Mau.InCanhBao("Đăng nhập không thành công, vui lòng thử lại !");
				}
				else {
					MenuGiangVien(giangvien, quanlygiangvien);
				}
			}
			else if (luachon == 3) {
				quanlygiangvien.DangKy();
			}
			else if (luachon == 4) {
				quanlygiangvien.XemThongTinTaiKhoanGiangVien();
			}
			else if (luachon == 5) {
				Console.Clear();
				Banner.Inbanner(Banner.BannerTamBiet);
				break;
			}
			HamPhuProgram.DungChuongTrinh();
		}
	}

	private static void MenuGiangVien(GiangVien giangvien, QuanLyGiangVien quanlygiangvien) {
		int luachontruoc = 1;
		while (true) {
			Console.Clear();
			Banner.Inbanner(Banner.BannerGiangVien);
			HamPhuQuanLyGiangVien.InTieuDe(giangvien);
			Console.WriteLine("  (↑ ↓) MENU");
			var luachon = AnsiConsole.Prompt(
				new SelectionPrompt<int>()
				.AddChoices(1, 2, 3)
				.WrapAround(true)
				.HighlightStyle(Mau.Maumacdinh)
				.DefaultValue(luachontruoc)
				.UseConverter(x => Markup.Escape(
					HamPhuProgram.MenuGiangVien[x-1]
				))
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if (luachon == 1) {
				MenuQuanLySinhVien(giangvien);
			}
			else if (luachon == 2) {
				quanlygiangvien.SuaThongTinGiangVien(giangvien);
			}
			else if (luachon == 3) {
				Mau.InThanhCong($"Tạm biệt giảng viên {giangvien.TenGiangVien} !");
				return;
			}
			else {
				Mau.InCanhBao("(!) Vui lòng chọn đúng !");
			}
			HamPhuProgram.DungChuongTrinh();
		}
	}

	// menu quản lý sinh viên
	private static void MenuQuanLySinhVien(GiangVien giangvien) {
		QuanLySinhVien quanlysinhvien = new QuanLySinhVien(giangvien);
		int luachontruoc = 0;
		while (true) {
			Console.Clear();
            Banner.Inbanner(Banner.BannerChinh);
			HamPhuQuanLyGiangVien.InTieuDe(giangvien);
			Console.WriteLine("  (↑ ↓) MENU");
			var luachon = AnsiConsole.Prompt(
				new SelectionPrompt<int>()
				.AddChoices(1, 2, 3, 4, 5, 6, 7, 8)
				.WrapAround(true)
				.HighlightStyle(Mau.Maumacdinh)
				.DefaultValue(luachontruoc)
				.UseConverter(x => Markup.Escape(
					HamPhuProgram.MenuQuanLySinhVien[x-1]
				))
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if (luachon == 1) {
				quanlysinhvien.InDanhSachSinhVien();
			}
			else if (luachon == 2) {
				quanlysinhvien.ThemThongTinSinhVien();
			}
			else if (luachon == 3) {
				quanlysinhvien.SuaThongTinSinhVien();
			}
			else if (luachon == 4) {
				quanlysinhvien.LocThongTinSinhVien();
			}
			else if (luachon == 5) {
				quanlysinhvien.SapXepThongTinSinhVien();
			}
			else if (luachon == 6) {
				quanlysinhvien.XoaThongTinSinhVien();
			}
			else if (luachon == 7) {
				quanlysinhvien.ThongKeThongTinSinhVien();
			}
			else if (luachon == 8) {
				Mau.InThanhCong($"Tạm biệt giảng viên {giangvien.TenGiangVien} !");
				return;
			}
			else {
				Mau.InCanhBao("(!) Vui lòng chọn đúng !");
			}
			HamPhuProgram.DungChuongTrinh();
		}
	}
}