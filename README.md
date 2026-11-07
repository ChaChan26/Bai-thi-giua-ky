Ứng dụng WinForms quản lý sản phẩm theo loại. Solution gồm ba project theo luồng GUI → BUS → DAL → MySQL.

| Project | Nhiệm vụ |
| --- | --- |
| `QuanLySanPham.GUI` | Form nhập liệu, bảng sản phẩm, phím tắt và hộp thoại xác nhận |
| `QuanLySanPham.BUS` | Chuẩn hóa dữ liệu, kiểm tra điều kiện lưu, mã trùng và khóa chính khi sửa |
| `QuanLySanPham.DAL` | Entity, DbContext, truy vấn và lưu bằng EF Core, thư mục Migrations |

## Kết nối và chạy ứng dụng

1. Trên Windows, cài .NET 10 SDK và khởi động MySQL 8.4.
2. Mở [App.config](QuanLySanPham.GUI/App.config) và sửa chuỗi kết nối `QuanLySanPham` theo máy đang chạy. Ví dụ với MySQL cục bộ ở cổng mặc định:

   ```text
   Server=127.0.0.1;Port=3306;Database=qlsp;User ID=ten_tai_khoan;Password=mat_khau;
   ```

   Thay tên tài khoản, mật khẩu và cổng theo cấu hình MySQL của máy chạy. Tài khoản cần quyền tạo CSDL `qlsp` nếu chưa có và áp dụng migration trên CSDL đó. Đặt `MySqlServerVersion` theo phiên bản máy chủ, ví dụ `8.4.0-mysql`. Điền `MaSinhVien` và `HoTenSinhVien` trong cùng tệp để hiện trên tiêu đề form.

3. Mở `QuanLySanPham.slnx` bằng Visual Studio có workload **.NET desktop development**, chọn `QuanLySanPham.GUI` làm Startup Project rồi nhấn **Ctrl+F5**. Hoặc mở PowerShell tại thư mục chứa solution và chạy:

   ```powershell
   dotnet run --project .\QuanLySanPham.GUI
   ```

Khi mở form, EF Core tự áp dụng migration còn thiếu. Migration đầu tạo hai bảng `LoaiSanPham` và `SanPham`, thêm ba loại và năm sản phẩm mẫu. Dữ liệu mẫu được thêm một lần nên các thay đổi vẫn còn sau khi mở lại ứng dụng.

Có thể áp dụng migration trước khi mở form bằng hai lệnh sau, chạy tại thư mục chứa solution. Nếu ứng dụng đang mở, đóng form trước khi chạy lệnh để Visual Studio hoặc .NET CLI có thể build lại project.

```powershell
dotnet tool restore
dotnet ef database update --project .\QuanLySanPham.DAL --startup-project .\QuanLySanPham.GUI
```

## Thao tác trên form

- Nhấn **Mới** để bỏ chọn dòng và nhập sản phẩm mới. Nhấn **Nhập** hoặc **Enter** để lưu.
- Chọn một dòng để điền thông tin vào form và bật **Sửa**, **Xóa**. Khi sửa, mã sản phẩm được giữ nguyên.
- Nhập số lượng nguyên dương. Với đơn giá, nhập liền chữ số và dùng dấu phẩy nếu có phần thập phân, ví dụ `450000,50`.
- Xác nhận khi xóa hoặc khi đóng form bằng **Thoát**, **Esc** hay nút **X**.
