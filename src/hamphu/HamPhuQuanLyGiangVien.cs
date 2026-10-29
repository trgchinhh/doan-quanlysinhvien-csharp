using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class HamPhuQuanLyGiangVien {
        // in tiêu đề chương trình kèm lớp và giảng viên đang đăng nhập
        public static void InTieuDe(GiangVien giangvien) {
            giangvien.XuatThongTin();
            Console.WriteLine();
        }

        public static void InHuongDanDangNhap(int lanthu, int soluonglanthu) {
            AnsiConsole.Write(
                new Panel(
                    "[yellow]Tài khoản mẫu[/]\n" +
                    "[yellow] - Mã tài khoản:[/] GV001 -> GV005\n" + 
                    "[yellow] - Mật khẩu:[/] 123456"
                )
                .Header($"Đăng nhập giảng viên (lần {lanthu}/[red]{soluonglanthu}[/])")
            );
            Console.WriteLine();
        }

        // panel hướng dẫn ở màn hình đăng ký giảng viên
        public static void InHuongDanDangKy() {
            AnsiConsole.Write(
                new Panel(
                    "- Giảng viên mới tạo tài khoản và lớp phụ trách\n" +
                    "- Nhập mã giáo viên, mã lớp, tên lớp, môn phụ trách\n" +
                    "- Lớp mới tạo chưa có sinh viên, thêm sinh viên ở menu quản lý"
                )
                .Header("Đăng ký giảng viên")
            );
            Console.WriteLine();
        }

        public static string NhapMatKhau(int lan) {
            if (lan == 1) {
                Mau.InNhap("Nhập mật khẩu: ");
            }
            else {
                Mau.InNhap("Xác nhận mật khẩu: ");
            }
            string matkhau = Console.ReadLine();
            return matkhau;
        }
    }
}
