<p align="center">
  <img height="250" src="img/logo.png"/>
</p>

<p align="center">
  <a href="https://github.com/trgchinhh/quanlysinhvien-sqlserver">
    <img src="https://img.shields.io/badge/Language-C%23-512BD4.svg" alt="Language"/>
  </a>
  <a href="LICENSE">
    <img src="https://img.shields.io/badge/License-MIT-green.svg" alt="License"/>
  </a>
  <a href="https://github.com/trgchinhh">
    <img src="https://img.shields.io/badge/Author-Tr%C6%B0%E1%BB%9Dng%20Chinh-yellow" alt="Author"/>
  </a>
</p>

## Quản lý sinh viên C#

Dự án này mô phỏng một hệ thống quản lý sinh viên dưới dạng ứng dụng console (CLI), được xây dựng bằng C#. Chương trình hướng đến việc mô phỏng quy trình quản lý trong môi trường thực tế, bao gồm đăng nhập và đăng xuất tài khoản giảng viên, quản lý lớp học, quản lý thông tin sinh viên, ghi log theo dõi hành động người dùng, hệ thống và lưu trữ dữ liệu vào cơ sở dữ liệu SQL Server.

![quanlysinhvien-sqlserver demo](docs/quanlysinhvien-sqlserver.gif)

## Dự án được xây dựng với mục tiêu

- Rèn luyện tư duy lập trình OOP thông qua một project nhỏ 
- Làm quen việc tổ chức mã nguồn, tách module hiệu quả 
- Mô phỏng hệ thống đăng nhập / đăng ký, tài khoản giảng viên 
- Lưu dữ liệu vào cơ sở dữ liệu thật (SQL server)
- Tập viết logging cơ bản cho hệ thống

## Kiến trúc hệ thống vận hành 

```bash
┌───────────────────────────────────────┐
│           KẾT NỐI DATABASE            │
├───────────────────────────────────────┤
│ • Kết nối SQL Server                  │
│ • Kiểm tra kết nối thành công ?       │
└───────────────────┬───────────────────┘
                    │ (*) Thành công
                    │ (✗) Thất bại: báo lỗi và thoát
┌───────────────────┴───────────────────┐
│             MENU CHỌN MÀU             │
├───────────────────────────────────────┤
│ • [01] Màu đỏ                         │
│ • [02] Màu xanh lá                    │
│ • [03] Màu vàng                       │
│ • [04] Màu cam                        │
│ • [05] Màu xanh ngọc                  │
│ • [06] Màu xanh cyan                  │
│ • [07] Màu mặc định                   │
│ • [08] Thoát                          │
└───────────────────┬───────────────────┘
                    │
┌───────────────────┴───────────────────┐
│            MENU TÀI KHOẢN             │
├───────────────────────────────────────┤
│ • [01] Đăng nhập                      │
│ • [02] Đăng ký                        │
│ • [03] Xem tài khoản giảng viên mẫu   │
│ • [04] Thoát                          │
└───────────────────┬───────────────────┘
                    │ (*) Đăng nhập thành công
                    │ (✗) Sai 3 lần: thoát
┌───────────────────┴───────────────────┐
│          CHƯƠNG TRÌNH CHÍNH           │
├───────────────────────────────────────┤
│ • [00] Thay màu                       │
│ • [01] Xem danh sách                  │
│ • [02] Thêm sinh viên                 │
│ • [03] Sửa thông tin                  │
│ • [04] Lọc thông tin                  │
│ • [05] Sắp xếp thông tin              │
│ • [06] Xóa thông tin                  │
│ • [07] Thống kê                       │
│ • [08] Đăng xuất (về menu tài khoản)  │
└───────────────────────────────────────┘
```
> Lưu ý: Mỗi giảng viên khi tạo tài khoản phải tạo luôn lớp của mình, vì 1 tài khoản Gv chỉ chủ nhiệm 1 lớp 

## Cơ sở dữ liệu 

Dự án sử dụng SQL server để lưu trữ thông tin
Các bảng dữ liệu chính bao gồm: 
- Tài khoản giảng viên 
- Thông tin lớp 
- Thông tin sinh viên
- Kèm quan hệ giữa các bảng 

## Yêu cầu hệ thống 

- Nếu dùng text editor như Vscode, Sublime text, Vim, ...
  + Cài đặt .NET SDK (trình biên dịch C#)
- Nếu dùng Visual Studio thì cài .NET sẵn trong app

## Clone dự án về máy 
```bash
git clone https://github.com/trgchinhh/quanlysinhvien-sqlserver.git
cd quanlysinhvien-sqlserver/
```

## Lưu trữ dữ liệu

Chương trình tự tạo thư mục `database` khi khởi chạy. Thông tin giảng viên được lưu trong `database/datagiangvien.txt`; mỗi giảng viên có thư mục riêng chứa `tenlop.txt` và `sinhvien.txt`. Mỗi dòng trong các tệp là một bản ghi, các trường cách nhau bằng dấu chấm phẩy. Không cần cài SQL Server hoặc cấu hình tệp `.env`.


## Biên dịch và khởi chạy 
```bash
dotnet run 
```


## Một số giới hạn 

Đây là dự án phục vụ mục đích học tập và mô phỏng
Hệ thống quản lý nên sẽ có những lỗi không mong muốn phát sinh trong quá trình thử nghiệm 

Môt số thành phần sẽ được tiếp tục cải thiện 

- [x] Cơ chế xác thực đăng nhập / đăng ký 
- [x] Kiểm tra và chuẩn hóa nội dung đầu vào
- [x] Thiết kế cơ sở dữ liệu 
- [x] Phát triển tính năng thống kê
- [ ] Cải thiện bảo mật tài khoản
- [x] Bổ sung hệ thống theo dõi Logging

![demo](img/demo.png)

## Tác giả
**Nguyễn Trường Chinh (NTC++)**<br>
**Ủng hộ:** [Nếu bạn thấy hữu ích hãy ủng hộ mình](https://github.com/sponsors/trgchinhh)<br>
**GitHub:** [https://github.com/trgchinhh](https://github.com/trgchinhh)

---

> 📌 Dự án nhỏ được phát triển với mục đích học tập và nghiên cứu. Mọi góp ý và đóng góp đều được hoan nghênh. Nếu thấy hữu ích thì cho mình xin 1 sao cho repo này !!!
