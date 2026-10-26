using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class DuLieuMauGiangVien {

        // dữ liệu mẫu giảng viên + lớp phụ trách (mỗi giảng viên quản lý 1 lớp)
        public static List<GiangVien> danhsachgiangvienmau = new List<GiangVien> {
            new GiangVien {
                MaGiangVien = "GV001", TenGiangVien = "Trịnh Thanh Duy",   MatKhau = "123456", MaLop = "OOP1",   TenLop = "Lập trình hướng đối tượng"
            },
            new GiangVien {
                MaGiangVien = "GV002", TenGiangVien = "Nguyễn Lạc An Thu",  MatKhau = "123456", MaLop = "CSDL1",  TenLop = "Cơ sở dữ liệu"
            },
            new GiangVien {
                MaGiangVien = "GV003", TenGiangVien = "Lê Hoàng Nguyên",      MatKhau = "123456", MaLop = "IPC1",   TenLop = "Mạng máy tính"
            },
            new GiangVien {
                MaGiangVien = "GV004", TenGiangVien = "Đỗ Đức Hào", MatKhau = "123456", MaLop = "MHUD1",  TenLop = "Mã hóa ứng dụng"
            },
            new GiangVien {
                MaGiangVien = "GV005", TenGiangVien = "Trần Quốc Trường",    MatKhau = "123456", MaLop = "KTLT1",  TenLop = "Kỹ thuật lập trình"
            },
            new GiangVien {
                MaGiangVien = "GV006", TenGiangVien = "Nguyễn Thị Thu Vân",   MatKhau = "123456", MaLop = "NMLT1",  TenLop = "Nhập môn lập trình"
            },
            new GiangVien {
                MaGiangVien = "GV007", TenGiangVien = "Trịnh Thanh Duy",    MatKhau = "123456", MaLop = "CTDLGT1", TenLop = "Cấu trúc dữ liệu và giải thuật"
            },
            new GiangVien {
                MaGiangVien = "GV008", TenGiangVien = "Lê Triệu Ngọc Đức",    MatKhau = "123456", MaLop = "QTCSDL1", TenLop = "Hệ quản trị cơ sở dữ liệu"
            },
            new GiangVien {
                MaGiangVien = "GV009", TenGiangVien = "Ngô Thị Lan",     MatKhau = "123456", MaLop = "LTWEB1",  TenLop = "Lập trình web"
            },
            new GiangVien {
                MaGiangVien = "GV010", TenGiangVien = "Lý Quốc Khánh",   MatKhau = "123456", MaLop = "LTWIN1",  TenLop = "Lập trình Windows"
            }
        };
    }
}
