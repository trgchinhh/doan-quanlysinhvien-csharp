using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLySinhVien {
    internal class ThongTin {
        public static string thongtin = @"
        ┌──────────────────────────────────────────────────────────────────────────────────┐
        │                        CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN                            │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Thông tin                                                                        │
        │                                                                                  │
        │ Giáo viên hướng dẫn: Trần Quốc Trường                                            │
        │ Sinh viên thực hiện: Nguyễn Bảo Lam                                              │
        │ Ngôn ngữ: C#                                                                     │
        │ Đề tài: Xây dựng chương trình quản lý sinh viên console                          │ 
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Giới thiệu                                                                       │
        │                                                                                  │
        │ Chương trình mô phỏng các vận hành của các ứng dụng/web quản lý sinh viên trong  │
        │ thực tế gồm nhiều tài khoản thầy cô, mỗi thầy cô quản lý một lớp của mình gồm    │
        │ nhiều tính năng cơ bản của một hệ thống quản lý. Ngoài ra, chương trình còn      │
        │ lưu trữ tên lớp, sinh viên từng lớp vào database local bằng các file text (.txt) │
        │ theo từng folder tên giảng viên.                                                 │
        ├──────────────────────────────────────────────────────────────────────────────────┤
        │ Tìm hiểu nghiệp vụ cơ bản                                                        │
        │                                                                                  │
        │ - Quản lý tài khoản giảng viên: đăng nhập, đăng xuất và cập nhật thông tin       │
        │   giảng viên                                                                     │
        │ - Quản lý một lớp học cho mỗi giảng viên                                         │
        │ - Lưu thông tin lớp học gồm mã lớp, tên lớp và giảng viên phụ trách              │
        │ - Quản lý danh sách sinh viên theo từng lớp                                      │
        │ - Lưu thông tin sinh viên gồm họ tên, mã số sinh viên và điểm                    │
        │ - Thêm sinh viên mới vào lớp                                                     │
        │ - Sửa thông tin sinh viên                                                        │
        │ - Xóa sinh viên khỏi lớp                                                         │
        │ - Hiển thị danh sách sinh viên, điểm và học lực                                  │
        │ - Tìm kiếm thông tin sinh viên theo tên, mã số (chưa)                            │
        │ - Lọc sinh viên theo tên, mã số, điểm hoặc học lực                               │
        │ - Sắp xếp danh sách sinh viên theo tên, mã số hoặc điểm                          │
        │ - Thống kê sĩ số, điểm trung bình, điểm cao nhất và điểm thấp nhất của lớp       │
        │ - Tự động sao lưu dữ liệu vào các tệp văn bản để sử dụng lại khi mở chương trình │
        └──────────────────────────────────────────────────────────────────────────────────┘
";
        
        // in thông báo theo trang (dễ đọc từ đầu ko cần phải scroll lên )
        public static void InThongTin(){
            Console.Clear();
            Console.WriteLine(thongtin);
            HamPhuProgram.DungChuongTrinh();
        }
    }
}