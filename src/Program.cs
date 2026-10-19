using DoAn_QuanLySinhVien;
using System;
using System.Text;
using Spectre.Console;

public class Program {        
	public static void Main() {
		Console.Clear();
		Banner.Inbanner(Banner.BannerDoAnTinHoc);
		QuanLyGiangVien quanlygiangvien = new QuanLyGiangVien();
		var luachonmau = HamPhuProgram.ChonMau();
		int luachontruoc = 0;
		while (true) {
			Console.Clear();
			Banner.Inbanner(Banner.BannerXacThuc);
			AnsiConsole.Write(
				new Panel(
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
				.AddChoices(0, 1, 2, 3, 4)
				.WrapAround(true)
				.HighlightStyle(new Style(luachonmau))
				.DefaultValue(luachontruoc)
				.UseConverter(x => x switch {
					0 => Markup.Escape("[00] Thông tin"),
					1 => Markup.Escape("[01] Đăng nhập"),
					2 => Markup.Escape("[02] Đăng ký"),
					3 => Markup.Escape("[03] Xem tài khoản giảng viên"),
					4 => Markup.Escape("[04] Thoát"),
					_ => ""
				})
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if(luachon == 0){
				ThongTin.InThongTin();
				continue;
			} else if (luachon == 1) {
				GiangVien? giangvien = quanlygiangvien.DangNhap();
				if (giangvien == null) {
					Mau.InCanhBao("Đăng nhập không thành công, vui lòng thử lại !");
				}
				else {
					MenuGiangVien(giangvien, quanlygiangvien, ref luachonmau);
				}
			}
			else if (luachon == 2) {
				quanlygiangvien.DangKy();
			}
			else if (luachon == 3) {
				quanlygiangvien.XemThongTinTaiKhoanGiangVien();
			}
			else if (luachon == 4) {
				Console.Clear();
				Banner.Inbanner(Banner.BannerTamBiet);
				break;
			}
			HamPhuProgram.DungChuongTrinh();
		}
	}

	private static void MenuGiangVien(GiangVien giangvien, QuanLyGiangVien quanlygiangvien, ref Color luachonmau) {
		int luachontruoc = 1;
		while (true) {
			Console.Clear();
			Banner.Inbanner(Banner.BannerGiangVien);
			HamPhuQuanLyGiangVien.InTieuDe(giangvien);
			List<int> danhsachchon = new List<int>();
			for (int i = 1; i <= giangvien.SoLopDay; i++) {
				danhsachchon.Add(i);
			}
			// không dùng menu mặc định vì sẽ bị đôn lên khi giảng viên dạy n lớp
			// số lượng lớp không mặc định được
			int suathongtin = giangvien.SoLopDay + 1;
			int suasolop = giangvien.SoLopDay + 2;
			int dangxuat = giangvien.SoLopDay + 3;
			danhsachchon.Add(suathongtin);
			danhsachchon.Add(suasolop);
			danhsachchon.Add(dangxuat);
			Console.WriteLine("  (↑ ↓) MENU");
			var luachon = AnsiConsole.Prompt(
				new SelectionPrompt<int>()
				.AddChoices(danhsachchon)
				.WrapAround(true)
				.HighlightStyle(new Style(luachonmau))
				.DefaultValue(luachontruoc)
				.UseConverter(x => x switch {
					_ when x <= giangvien.SoLopDay 
						=> Markup.Escape("[" + x.ToString("D2") + "] Quản lý lớp " + x),
					_ when x == suathongtin 
						=> Markup.Escape("[" + x.ToString("D2") + "] Sửa thông tin giảng viên"),
					_ when x == suasolop 
						=> Markup.Escape("[" + x.ToString("D2") + "] Sửa số lớp dạy"),
					_ when x == dangxuat 
						=> Markup.Escape("[" + x.ToString("D2") + "] Đăng xuất"),
					_ => ""
				})
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if (luachon >= 1 && luachon <= giangvien.SoLopDay) {
				if (luachon <= giangvien.DanhSachLop.Count) {
					Lop lop = giangvien.DanhSachLop[luachon - 1];
					GiangVien gvtheolop = new GiangVien(
						giangvien.MaGiangVien,
						giangvien.TenGiangVien,
						giangvien.MatKhau,
						lop.MaLop,
						lop.TenLop
					);
					MenuQuanLySinhVien(gvtheolop, ref luachonmau);
				}
				else {
					Mau.InCanhBao("Lớp này chưa có thông tin. Chọn Sửa số lớp dạy để khai báo lớp trước.");
				}
			}
			else if (luachon == suathongtin) {
				quanlygiangvien.SuaThongTinGiangVien(giangvien);
			}
			else if (luachon == suasolop) {
				quanlygiangvien.SuaSoLopDay(giangvien);
			}
			else if (luachon == dangxuat) {
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
	private static void MenuQuanLySinhVien(GiangVien giangvien, ref Color luachonmau) {
		QuanLySinhVien quanlysinhvien = new QuanLySinhVien(giangvien);
		int luachontruoc = 0;
		while (true) {
			Console.Clear();
            Banner.Inbanner(Banner.BannerChinh);
			HamPhuQuanLyGiangVien.InTieuDe(giangvien);
			Console.WriteLine("  (↑ ↓) MENU");
			var luachon = AnsiConsole.Prompt(
				new SelectionPrompt<int>()
				.AddChoices(0, 1, 2, 3, 4, 5, 6, 7, 8)
				.WrapAround(true)
				.HighlightStyle(new Style(luachonmau))
				.DefaultValue(luachontruoc)
				.UseConverter(x => x switch {
					0 => Markup.Escape("[00] Thay màu"),
					1 => Markup.Escape("[01] Xem danh sách"),
					2 => Markup.Escape("[02] Thêm sinh viên"),
					3 => Markup.Escape("[03] Sửa thông tin"),
					4 => Markup.Escape("[04] Lọc thông tin"),
					5 => Markup.Escape("[05] Sắp xếp thông tin"),
					6 => Markup.Escape("[06] Xóa thông tin"),
					7 => Markup.Escape("[07] Thống kê"),
					8 => Markup.Escape("[08] Đăng xuất"),
					_ => ""
				})
			);
			luachontruoc = luachon;
			Console.WriteLine();
			if (luachon == 0) {
				luachonmau = HamPhuProgram.ChonMau();
				continue;
			}
			else if (luachon == 1) {
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
