using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class DuLieuMauGiangVien {

        // dữ liệu mẫu giảng viên + lớp phụ trách
        public static List<Lop> danhsachlopmau = new List<Lop> {
            new Lop {MaLop = "OOP",    TenLop = "Lập trình hướng đối tượng"},
            new Lop {MaLop = "CSDL",   TenLop = "Cơ sở dữ liệu"},
            new Lop {MaLop = "IPC",    TenLop = "Mạng máy tính"},
            new Lop {MaLop = "MHUD",   TenLop = "Mã hóa ứng dụng"},
            new Lop {MaLop = "KTLT",   TenLop = "Kỹ thuật lập trình"},
            new Lop {MaLop = "NMLT",   TenLop = "Nhập môn lập trình"},
            new Lop {MaLop = "CTDLGT", TenLop = "Cấu trúc dữ liệu và giải thuật"},
            new Lop {MaLop = "QTCSDL", TenLop = "Hệ quản trị cơ sở dữ liệu"},
            new Lop {MaLop = "LTWEB",  TenLop = "Lập trình web"},
            new Lop {MaLop = "LTWIN",  TenLop = "Lập trình Windows"}
        };

        public static List<GiangVien> danhsachgiangvienmau = new List<GiangVien> {
            new GiangVien {
                MaGiangVien = "GV001", TenGiangVien = "Nguyễn Văn An",   MatKhau = "123456", MaLop = "OOP"
            },
            new GiangVien {
                MaGiangVien = "GV002", TenGiangVien = "Trần Minh Bình",  MatKhau = "123456", MaLop = "CSDL"
            },
            new GiangVien {
                MaGiangVien = "GV003", TenGiangVien = "Lê Thị Cúc",      MatKhau = "123456", MaLop = "IPC"
            },
            new GiangVien {
                MaGiangVien = "GV004", TenGiangVien = "Phạm Quang Dũng", MatKhau = "123456", MaLop = "MHUD"
            },
            new GiangVien {
                MaGiangVien = "GV005", TenGiangVien = "Hoàng Thị Em",    MatKhau = "123456", MaLop = "KTLT"
            },
            new GiangVien {
                MaGiangVien = "GV006", TenGiangVien = "Đặng Văn Phúc",   MatKhau = "123456", MaLop = "NMLT"
            },
            new GiangVien {
                MaGiangVien = "GV007", TenGiangVien = "Vũ Thị Giang",    MatKhau = "123456", MaLop = "CTDLGT"
            },
            new GiangVien {
                MaGiangVien = "GV008", TenGiangVien = "Bùi Minh Hải",    MatKhau = "123456", MaLop = "QTCSDL"
            },
            new GiangVien {
                MaGiangVien = "GV009", TenGiangVien = "Ngô Thị Lan",     MatKhau = "123456", MaLop = "LTWEB"
            },
            new GiangVien {
                MaGiangVien = "GV010", TenGiangVien = "Lý Quốc Khánh",   MatKhau = "123456", MaLop = "LTWIN"
            }
        };
    }
}