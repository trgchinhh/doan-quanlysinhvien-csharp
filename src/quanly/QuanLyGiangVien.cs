using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
	internal class QuanLyGiangVien {
		private List<GiangVien> danhsachgiangvien = new List<GiangVien>();
		private List<Lop> danhsachlop = new List<Lop>();
		private Dulieu dulieu = new Dulieu();
		private const int solandangnhaptoida = 3;

		public QuanLyGiangVien() {
			// Nếu ko kết nối được với tệp dữ liệu thì exit 
			if(!dulieu.KiemTra()){
				Console.WriteLine("Thoát chương trình !");
				Environment.Exit(0);
			}
			this.Napdulieulopvagiangvien();
			HamPhuProgram.DungChuongTrinh();
		}

		// nạp lại lớp + giảng viên từ tệp dữ liệu (sau khi đăng ký tài khoản mới)
		public void NapLaiDanhSach() {
			this.danhsachlop = dulieu.NapDanhSachLop();
			this.danhsachgiangvien = dulieu.NapDanhSachGiangVien();
		}

		// nạp lớp + giảng viên, nếu tệp dữ liệu chưa có thì nạp dữ liệu mẫu
		private void Napdulieulopvagiangvien() {
			try {
				this.NapLaiDanhSach();
				if (this.danhsachlop.Count == 0) {
					Mau.InCanhBao("Tệp dữ liệu chưa có lớp và giảng viên, đang nạp dữ liệu mẫu ...");
					List<Lop> danhsachlopgoc = new List<Lop>(DuLieuMauGiangVien.danhsachlopmau);
					this.danhsachlop = new List<Lop>();
					this.danhsachgiangvien = new List<GiangVien>(DuLieuMauGiangVien.danhsachgiangvienmau);
					for (int i = 0; i < this.danhsachgiangvien.Count; i++) {
						GiangVien gv = this.danhsachgiangvien[i];
						string malopgoc = gv.MaLop;
						string tenlopgoc = "";
						foreach (Lop lopgoc in danhsachlopgoc) {
							if (lopgoc.MaLop == malopgoc) {
								tenlopgoc = lopgoc.TenLop;
								break;
							}
						}
						gv.DanhSachLop.Clear();
						gv.SoLopDay = 3;
						for (int j = 1; j <= 3; j++) {
						Lop lopmoi = new Lop(malopgoc + j, tenlopgoc + " - Lớp " + j);
						lopmoi.TenLopGoc = tenlopgoc;
							lopmoi.MaGiangVien = gv.MaGiangVien;
							lopmoi.SoThuTu = j;
							this.danhsachlop.Add(lopmoi);
							gv.DanhSachLop.Add(lopmoi);
							if (j == 1) {
								gv.MaLop = lopmoi.MaLop;
								gv.TenLop = lopmoi.TenLop;
							}
						}
					}
					dulieu.LuuDuLieu(this.danhsachlop, this.danhsachgiangvien);
					Mau.InThanhCong("Đã nạp xong !");
				}
				QuanLySinhVien.NapDuLieuMauTatCaLop(this.danhsachgiangvien, dulieu);
			}
			catch (Exception ex) {
				Mau.InLoi($"Lỗi nạp dữ liệu giảng viên: {ex.Message}");
				Mau.InCanhBao("Kiểm tra thư mục database và các tệp dữ liệu.");
			}
		}

		// đăng ký tài khoản cho giảng viên mới kèm lớp phụ trách
		public GiangVien? DangKy() {
			Console.Clear();
			Banner.Inbanner(Banner.BannerDangKy);
			HamPhuQuanLyGiangVien.InHuongDanDangKy();
			string magiangvien;
			while (true) {
				Console.Write("(?) Nhập mã giảng viên: ");
				magiangvien = Console.ReadLine()!.Trim().ToUpper();
				if (magiangvien.Length == 0) {
					Mau.InCanhBao("Bỏ trống mã giảng viên, hủy đăng ký !");
					return null;
				}
				if (this.TonTaiGiangVien(magiangvien)) {
					Mau.InCanhBao("Mã giảng viên đã tồn tại, hãy nhập mã khác !");
					continue;
				}
				break;
			}
			Console.Write("(?) Nhập tên giảng viên: ");
			string tengiangvien = Console.ReadLine()!.Trim();
			if (tengiangvien.Length == 0) {
				Mau.InCanhBao("Bỏ trống tên giảng viên, hủy đăng ký !");
				return null;
			}
			string matkhau;
			// nhâp mật khẩu lần 1 
			while (true) {
				matkhau = HamPhuQuanLyGiangVien.NhapMatKhau(1);
				if (matkhau.Length == 0) {
					Mau.InCanhBao("Bỏ trống mật khẩu, hủy đăng ký !");
					return null;
				}
				if (matkhau.Length < 6) {
					Mau.InCanhBao("Mật khẩu phải có tối thiểu 6 ký tự !");
					continue;
				}
				break;
			}
			// nhập mật khẩu lần 2 xác nhận MK
			while (true) {
				string nhaplai = HamPhuQuanLyGiangVien.NhapMatKhau(2);
				if (nhaplai.Length == 0) {
					Mau.InCanhBao("Bỏ trống mật khẩu nhập lại, hủy đăng ký !");
					return null;
				}
				if (nhaplai == matkhau) {
					break;
				}
				Mau.InCanhBao("Hai mật khẩu không khớp, hãy nhập lại !");
			}

			Lop? lop = this.NhapLopPhuTrach();
			if (lop == null) {
				return null;
			}

			var giangvienmoi = new GiangVien(magiangvien, tengiangvien, matkhau, lop.MaLop, lop.TenLop);
			lop.MaGiangVien = magiangvien;
			lop.SoThuTu = 1;
			giangvienmoi.SoSinhVienLop = 0;
			try {
				this.danhsachgiangvien.Add(giangvienmoi);
				dulieu.LuuDuLieu(this.danhsachlop, this.danhsachgiangvien);
			}
			catch (Exception ex) {
				this.danhsachgiangvien.Remove(giangvienmoi);
				Mau.InLoi($"Lỗi đăng ký: {ex.Message}");
				return null;
			}
			Console.WriteLine();
			Mau.InThanhCong(
				$"Đăng ký thành công !\n" +
				$"    - Tài khoản: {giangvienmoi.MaGiangVien}\n" +
				$"    - Giảng viên: {giangvienmoi.TenGiangVien}\n" +
				$"    - Quản lý lớp: {giangvienmoi.LayTenLopDayDu()}\n" +
				$"    - Lớp mới chưa có sinh viên, hãy thêm sinh viên ở menu quản lý\n" +
				$"Hãy đăng nhập lại bằng tài khoản vừa tạo !"
			);
			return giangvienmoi;
		}

		// Các hàm chính 
		// đăng nhập bằng tài khoản giảng viên, trả về null nếu đăng nhập thất bại
		public GiangVien? DangNhap() {
			for (int lanthu = 1; lanthu <= solandangnhaptoida; lanthu++) {
				Console.Clear();
				Banner.Inbanner(Banner.BannerDangNhap);
				HamPhuQuanLyGiangVien.InHuongDanDangNhap(lanthu, solandangnhaptoida);

				Console.Write("(?) Nhập mã giảng viên: ");
				string magiangvien = Console.ReadLine()!.Trim().ToUpper();
				if (magiangvien.Length == 0) {
					Mau.InCanhBao("Bỏ trống mã giảng viên, hủy đăng nhập !");
					return null;
				}

				string matkhau = HamPhuQuanLyGiangVien.NhapMatKhau(1);
				if (matkhau.Length == 0) {
					Mau.InCanhBao("Bỏ trống mật khẩu, hủy đăng nhập !");
					return null;
				}
				try {
					GiangVien? giangvien = null;
					for (int i = 0; i < this.danhsachgiangvien.Count; i++) {
						if (this.danhsachgiangvien[i].MaGiangVien == magiangvien && this.danhsachgiangvien[i].MatKhau == matkhau) {
							giangvien = this.danhsachgiangvien[i];
							giangvien.SoSinhVienLop = dulieu.NapDanhSachSinhVien(giangvien.MaLop).Count;
						}
					}
					if (giangvien == null) {
						Mau.InLoi("Sai mã giảng viên hoặc mật khẩu !");
						HamPhuProgram.DungChuongTrinh();
						continue;
					}
					Console.WriteLine();
					Mau.InThanhCong(
						$"Đăng nhập thành công !\n" +
						$"Chào mừng\n" +
						$"    - Giảng viên: {giangvien.TenGiangVien}\n" +
						$"    - Quản lý lớp: {giangvien.LayTenLopDayDu()}\n"
					);
					HamPhuProgram.DungChuongTrinh();
					return giangvien;
				}
				catch (Exception ex) {
					Mau.InLoi($"Lỗi đăng nhập: {ex.Message}");
					HamPhuProgram.DungChuongTrinh();
				}
			}
			Console.WriteLine();
			Mau.InLoi($"Sai quá {solandangnhaptoida} lần, vui lòng thử lại !");
			return null;
		}

		// nhập lớp phụ trách, lớp đã có sẵn và chưa có giảng viên thì dùng luôn, còn lại tạo lớp mới
		private Lop? NhapLopPhuTrach() {
			string malop;
			while (true) {
				Console.Write("(?) Nhập mã lớp: ");
				malop = Console.ReadLine()!.Trim().ToUpper();
				if (malop.Length == 0) {
					Mau.InCanhBao("Bỏ trống mã lớp, hủy đăng ký !");
					return null;
				}
				if (this.LopDaCoGiangVien(malop)) {
					Mau.InCanhBao("Lớp đã có giảng viên phụ trách, hãy nhập mã lớp khác !");
					continue;
				}
				break;
			}
			Console.Write("(?) Nhập tên lớp: ");
			string tenlop = Console.ReadLine()!.Trim();
			if (tenlop.Length == 0) {
				Mau.InCanhBao("Bỏ trống tên lớp, hủy đăng ký !");
				return null;
			}
			var lopmoi = new Lop(malop, tenlop);
			this.danhsachlop.Add(lopmoi);
			Mau.InThanhCong($"Đã tạo lớp mới {lopmoi.LayTenLopDayDu()}");
			return lopmoi;
		}

		// mã giảng viên đã tồn tại trong tệp dữ liệu chưa
		private bool TonTaiGiangVien(string magiangvien) {
			for(int i = 0; i < this.danhsachgiangvien.Count; i++){
				if(this.danhsachgiangvien[i].MaGiangVien == magiangvien){
					return true;
				}
			}
			return false;
		}

		//lớp đã có giảng viên phụ trách chưa (mỗi lớp chỉ 1 giảng viên)
		private bool LopDaCoGiangVien(string malop) {
			for(int i = 0; i < this.danhsachgiangvien.Count; i++){
				foreach (Lop lop in this.danhsachgiangvien[i].DanhSachLop) {
					if(this.danhsachgiangvien[i].MaLop == malop || lop.MaLop == malop){
						return true;
					}
				}
			}
			return false;
		}

		public void SuaThongTinGiangVien(GiangVien giangvien) {
			Console.Write("Nhập tên giảng viên mới (Enter để giữ nguyên): ");
			string tenmoi = Console.ReadLine()!.Trim();
			if (tenmoi != "") {
				giangvien.TenGiangVien = tenmoi;
			}
			this.dulieu.LuuDuLieu(this.danhsachlop, this.danhsachgiangvien);
			Mau.InThanhCong("Đã lưu thông tin giảng viên");
		}

		public void SuaSoLopDay(GiangVien giangvien) {
			Console.Write("Nhập số lớp muốn dạy: ");
			if (!int.TryParse(Console.ReadLine(), out int solopmoi) || solopmoi < 1) {
				Mau.InCanhBao("Số lớp phải từ 1 trở lên");
				return;
			}
			while (giangvien.DanhSachLop.Count < solopmoi) {
				Lop? lop = this.NhapLopPhuTrach();
				if (lop == null) {
					return;
				}
				lop.MaGiangVien = giangvien.MaGiangVien;
				lop.SoThuTu = giangvien.DanhSachLop.Count + 1;
				giangvien.DanhSachLop.Add(lop);
			}
			giangvien.SoLopDay = solopmoi;
			this.dulieu.LuuDuLieu(this.danhsachlop, this.danhsachgiangvien);
			Mau.InThanhCong("Đã lưu số lớp giảng dạy");
		}

		// hàm tính tổng sinh viên của giảng viên 
        public int TinhVaIn(bool coin = false){
        	int tongsinhvien = 0;
            for (int i = 0; i < this.danhsachgiangvien.Count; i++) {
                int sosinhvien = 0;
                for (int j = 0; j < this.danhsachgiangvien[i].DanhSachLop.Count 
                      && j < this.danhsachgiangvien[i].SoLopDay; j++) {
                    sosinhvien += dulieu.NapDanhSachSinhVien(this.danhsachgiangvien[i].DanhSachLop[j].MaLop).Count;
                }
            	tongsinhvien += sosinhvien;
                if(coin){
	                this.danhsachgiangvien[i].XuatThongTinTaiKhoan(i + 1, sosinhvien);
                }
            }
            return tongsinhvien;
        }

		// in thông tin tài khoản của các giảng viên kèm lớp phụ trách và sĩ số lớp
		public void XemThongTinTaiKhoanGiangVien() {
			Console.Clear();
			Banner.Inbanner(Banner.BannerTaiKhoanMau);
			try {
				Mau.InThanhCong("Thông tin tài khoản giảng viên\n");
				Console.WriteLine(
					$"{"STT",-5} {"Mã GV",-10} {"Tên giảng viên",-20} {"Mã lớp",-10} {"Tên lớp",-34} {"Sĩ số lớp",-12}"
				);
				Console.WriteLine(new string('─', 100));
				int tongsoluongsinhvien = TinhVaIn(true);
				Console.WriteLine(new string('─', 100));
				Console.WriteLine(
					$"{"Tổng cộng", -82} {tongsoluongsinhvien + " sinh viên", -10}"
				);
			}
			catch (Exception ex) {
				Mau.InLoi($"Lỗi xem thông tin tài khoản: {ex.Message}");
				return;
			}
			Console.WriteLine();
			Mau.InThanhCong(
				$"Tổng cộng {this.danhsachlop.Count} lớp và {this.danhsachgiangvien.Count} tài khoản giảng viên"
			);
		}
	}
}
