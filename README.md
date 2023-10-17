# DBMS_Final_Project
Quản lý chuỗi cửa hàng bán xe hơi


TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT TP. HỒ CHÍ MINH
KHOA CÔNG NGHỆ THÔNG TIN
NGÀNH CÔNG NGHỆ THÔNG TIN
---------------
 

ĐỀ TÀI CUỐI KỲ MÔN HỆ QUẢN TRỊ CSDL
TÊN ĐỀ TÀI:

QUẢN LÝ CHUỖI CỬA HÀNG XE ÔTÔ

GVHD: TS. Nguyễn Thành Sơn
Lớp HP: DBMS330284_23_1_03
Nhóm thực hiện: Nhóm 03
Học kỳ: 1
Năm học: 2023 – 2024







Tp. Hồ Chí Minh ngày …, tháng…, năm 2023

DANH SÁCH SINH VIÊN NHÓM THỰC HIỆN
HỌC KÌ 1 NĂM HỌC 2023-2024
Nhóm 03
Đề tài: Quản lý chuỗi cửa hàng xe ôtô
21110900	Sú Minh Luân
21110512	Nguyễn Việt Khoa
21110927	Nguyễn Xuân Thể
21110665	Đặng Gia Thuận

NHẬN XÉT CỦA GV
																																																																																																																																															

Tp. Hồ Chí Minh, ngày …, tháng…, năm 2023
Giảng viên chấm điểm





CHƯƠNG 1. TỔNG QUAN VỀ HỆ THỐNG
1. Đặc tả bài toán
- Cửa hàng ô tô là nơi bán các loại xe ô tô con phục vụ mục đích đi lại, vận chuyển hàng hóa của khách hàng. Sản phẩm của cửa hàng có đa dạng thương hiệu, màu sắc, đáp ứng được sở thích cũng như nhu cầu của nhiều khách hàng. Ngoài việc bán các loại xe ô tô con, cửa hàng còn cung cấp dịch vụ bảo dưỡng và bảo hành xe.
- Bên cạnh quản lý các loại xe và phụ tùng, cửa hàng còn phải quản lý thêm số lượng lớn nhân viên với nhiều chức vụ khác nhau:
•	Nhân viên tư vấn - bán hàng sẽ hỗ trợ tư vấn các dịch vụ của cửa hàng và mô tả thông tin mặt hàng cho khách hàng có nhu cầu
•	Nhân viên bảo dưỡng/bảo hành sẽ phụ trách các dịch vụ bảo dưỡng/bảo hành xe cho khách hàng
•	Nhân viên quản lý kho hàng có nhiệm vụ nhập hàng từ nhà cung cấp và lập báo cáo về số lượng
•	Nhân viên thu ngân sẽ tạo lập hóa đơn thanh toán, đồng thời lưu thông tin khách hàng và mặt hàng hoặc dịch vụ mà khách hàng đã yêu cầu
•	Người quản lý: phụ trách việc quản lý toàn bộ nhân viên và các hoạt động tại chi nhánh làm việc
-	Mỗi nhân viên của cửa hàng được nhận biết thông qua mã nhân viên và các thông tin như tên nhân viên, số CCCD, ngày sinh, giới tính, địa chỉ, số điện thoại, chức vụ, tình trạng làm việc, mã chi nhánh nơi làm việc.
- Mỗi nhân viên sẽ được cấp một tài khoản để sử dụng ứng dụng của cửa hàng. Tài khoản bao gồm: tên đăng nhập là mã nhân viên, mật khẩu, chức vụ, hình ảnh.
- Cửa hàng xe ô tô có nhiều chi nhánh. Mỗi chi nhánh có mã chi nhánh để nhận biết, tên chi nhánh, địa chỉ của chi nhánh. Mỗi chi nhánh quản lý nhiều nhân viên.
- Cửa hàng sẽ nhập xe và phụ tùng từ nhiều nhà cung cấp khác nhau cho mỗi chi nhánh của cửa hàng. Mỗi nhà cung cấp có: mã nhà cung cấp, tên nhà cung cấp, số điện thoại, địa chỉ. 
- Cửa hàng kinh doanh nhiều loại xe, thuộc nhiều hãng khác nhau, cho khách hàng lựa chọn. Để quản lý cửa hàng một cách thuận tiện, cửa hàng sẽ nhập xe từ nhà cũng cấp theo các lô. Thông tin mỗi lô xe bao gồm: Mã lô xe, tên xe, phiên bản xe, loại xe, hãng xe, xuất xứ, số chỗ, giá xe bán, màu xe, động cơ, kích thước, trọng lượng, trọng tải, tốc độ tối đa, hệ thống phanh, công nghệ an toàn, hình ảnh.
•	Động cơ bao gồm: Loại động cơ, dung tích (cc), công suất (mã lực)/vòng tua(vòng/phút), mô-men xoắn(Nm)/vòng tua(vòng/phút), loại nhiên liệu.
•	Kích thước: Chiều dài, chiều rộng, chiều cao, chiều dài cơ sở, khoảng sáng gầm, bán kính quay vòng
•	Hệ thống phanh bao gồm: bộ điều khiển phanh, bộ phận truyền lực phanh, phanh trước, phanh sau
•	Công nghệ an toàn bao gồm: cảnh báo phương tiện, móc ghế an toàn, túi khí, cảnh báo điểm mù, cảm biến lùi, camera lùi.
- Với mỗi chiếc xe cụ thể trong từng lô xe sẽ được đánh mã số xe riêng biệt và mã lô xe tương ứng
- Phụ tùng xe gồm có: Mã phụ tùng, loại phụ tùng, tên phụ tùng, thương hiệu, xuất xứ, giá, chất lượng, hình ảnh.
- Mỗi khi cửa hàng nhập xe hoặc phụ tùng, cửa hàng phải lưu trữ phiếu nhập để tiện cho việc thống kê chi tiêu. Thông tin phiếu nhập bao gồm : mã phiếu nhập, mã nhà cung cấp, mã chi nhánh, ngày nhập. Đối với mỗi mặt hàng như xe hoặc phụ tùng thì sẽ có chi tiết phiếu nhập riêng.
•	Chi tiết phiếu nhập xe: Mã phiếu nhập, mã lô xe, giá nhập, số lượng.
•	Chi tiết phiếu nhập phụ tùng: Mã phiếu nhập, mã phụ tùng, giá nhập, số lượng.
- Khi khách hàng đến chi nhánh để sử dụng dịch vụ, thông tin của khách hàng sẽ được lưu vào hệ thống chung của doanh nghiệp. Thông tin của khách hàng gồm: mã khách hàng, họ tên khách hàng, ngày sinh, giới tính, số điện thoại, địa chỉ, số CCCD.
- Mỗi khi khách hàng mua xe từ cửa hàng thì sẽ có hóa đơn thanh toán. Mỗi hóa đơn thanh toán bao gồm các thông tin: Mã hóa đơn, mã khách hàng, mã nhân viên, ngày lập hóa đơn, tình trạng hóa đơn, tổng tiền. Ngoài thông trên hóa đơn còn có các thông tin chi tiết như: Mã hóa đơn, mã xe, ngày nhận xe, các loại phí, số tiền đã trả.
•	Các loại phí bao gồm: phí trước bạ, phí sử dụng đường bộ, bảo hiểm trách nhiệm dân sự, phí đăng kí biển số, phí đăng kiểm.
- Khi mua xe khách hàng sẽ được ký hợp đồng. Hợp đồng bảo hành gồm: Mã hợp đồng, mã xe, ngày ký bảo hành, thời hạn bảo hành, tình trạng bảo hành.
- Khi có hư hại trong phạm vi được bảo hành và xe còn trong thời hạn bảo hành, thì khách hàng sẽ được hỗ trợ bảo hành. Phiếu bảo hành gồm các thông tin như: Mã phiếu bảo hành, mã hợp đồng, mã nhân viên thực hiện, ngày nhận, ngày trả xe. Thời hạn bảo hành là từ 2 đến 4 năm tùy theo từng loại xe.
- Cửa hàng cung cấp dịch vụ bảo dưỡng cho khách hàng khi mua xe thuộc các chi nhánh của doanh nghiệp. Bảo dưỡng xe có các thông tin sau: Mã bảo dưỡng, tên bảo dưỡng, phí bảo dưỡng, loại bảo dưỡng.
- Mỗi khi khách hàng có sử dụng dịch vụ bảo dưỡng, cửa hàng sẽ xuất phiếu bảo dưỡng. Thông tin trên phiếu bảo dưỡng bao gồm: mã phiếu bảo dưỡng, mã khách hàng, mã nhân viên bảo dưỡng, tổng tiền, ngày lập phiếu. Và sẽ xuất hóa đơn bảo dưỡng cho từng dịch vụ bảo dưỡng, bao gồm: Mã phiếu, mã bảo dưỡng, thành tiền.
2. Nghiệp vụ của bài toán
- Bài toán quản lý cửa hàng xe ô tô là một nghiệp vụ quản lý kinh doanh trong lĩnh vực mua bán và kỹ thuật ô tô. Nó liên quan tới việc quản lý nhân viên, quản lý hàng hóa, doanh thu và điều hành chuỗi cửa hàng ô tô. Nhân viên là cốt lõi, là người đại diện cho cửa hàng để giao tiếp và cung cấp các dịch vụ cho khách hàng. Vì vậy chúng ta cần xây dựng một đội ngũ nhân viên được đào tạo chuyên nghiệp về các quy trình tác nghiệp, văn hóa phục vụ, cách ứng xử, xử lý trong mọi tình huống…
- Quản lý nhân viên: Khi tuyển dụng nhân sự, cửa hàng cần đưa ra một số quy định (số ngày làm mỗi tuần, giờ làm mỗi ngày, không được nghỉ quá số ngày quy định, số buổi đi trễ cho phép…) và nhân viên khi ứng tuyển phải đồng ý với các quy định trên. Nhân viên khi được tuyển sẽ trải qua khóa đào tạo về nghiệp vụ, quy trình làm việc ở vị trí của nhân viên đó. Người quản lý theo dõi và giám sát các nhân sự, góp ý những điểm thiếu sót và đưa ra lời khen để làm động lực cho nhân viên.
o	Quy trình khi khách đến cửa hàng
Bước 1: Tiếp đón khách hàng: Nhân viên bán hàng cần chào đón khách hàng một cách thân thiện và niềm nở, hỏi thăm nhu cầu của khách hàng. 
Bước 2: Tư vấn khách hàng: Nhân viên bán hàng cần tư vấn cho khách hàng về các loại xe, phụ tùng với giá cả, các chương trình khuyến mãi,... để khách hàng có thể lựa chọn được chiếc xe, phụ tùng xe phù hợp với nhu cầu và ngân sách của mình.
Bước 3: Cho khách hàng lái thử xe: Nếu khách hàng mua xe,   cho khách hàng lái thử xe là một cách hiệu quả để khách hàng có thể trải nghiệm trực tiếp chiếc xe và đưa ra quyết định mua hàng. Đối với trường hợp hư hỏng sẽ có biện pháp xử lý thích hợp. 
Bước 4: Thương lượng giá cả: Nếu khách hàng đã chọn được chiếc xe hay loại phụ tùng, nhân viên bán hàng sẽ thương lượng giá cả với khách hàng. Sau khi chốt được giá với khách hàng, nhân viên sẽ hỏi khách có thẻ thành viên của cửa hàng chưa, nếu chưa thì xin thông tin của khách để tạo thẻ thành viên. 
Bước 5: Hỗ trợ khách hàng làm thủ tục mua bán, sử dụng dịch vụ:  
- Nếu khách hàng đồng ý mua mặt hàng, nhân viên bán hàng sẽ hỗ trợ khách hàng làm các thủ tục mua, bao gồm:
        + Ký hợp đồng mua bán xe
        + Lập hồ sơ vay vốn (nếu khách hàng mua xe trả góp)
        + Đăng ký xe
        + Bàn giao xe 
    - Nếu khách hàng xác định sử dụng dịch vụ, thì nhân viên sẽ hỗ trợ khách hàng làm thủ tục 
Bước 6: Chăm sóc khách hàng sau bán hàng 
Sau khi khách hàng mua mặt hàng, nhân viên bán hàng cần tiếp tục chăm sóc khách hàng, giải đáp thắc mắc và hỗ trợ khách hàng trong quá trình sử dụng.
- Quản lý hàng hóa, quản lý doanh thu và điều hành cửa hàng bán ô tô có thể chia thành 3 giai đoạn chính:
•	Giai đoạn 1: Lập kế hoạch 
Trong giai đoạn này, chủ cửa hàng cần xác định các mục tiêu kinh doanh cụ thể, như tăng doanh thu, mở rộng thị trường, nâng cao chất lượng dịch vụ,... Từ đó, xây dựng kế hoạch quản lý hàng hóa, doanh thu và điều hành cửa hàng phù hợp. 
•	Giai đoạn 2: Thực hiện kế hoạch 
        - Quản lý hàng hóa:
            Cửa hàng cần triển khai các kế hoạch đã đề ra. Cụ thể:
+ Nhập hàng: Đảm bảo chất lượng, số lượng, chủng loại hàng hóa phù hợp với nhu cầu thị trường.
+ Lưu kho: Sắp xếp khoa học, hợp lý để dễ dàng tìm kiếm, kiểm kê.
+ Xuất hàng: Phân phối hàng hóa đến tay khách hàng một cách nhanh chóng, chính xác.
        -  Quản lý doanh thu: 
+ Theo dõi doanh thu theo từng tháng, quý, năm.
+ Phân tích doanh thu để xác định các yếu tố ảnh hưởng đến doanh thu.
+ Đưa ra các giải pháp để tăng doanh thu.
        -  Điều hành cửa hàng: 
+ Quản lý nhân sự: Tuyển dụng, đào tạo, đánh giá, khen thưởng, kỷ luật nhân viên.
+ Quản lý tài chính: Theo dõi thu chi, báo cáo tài chính.
+ Quản lý khách hàng: Xây dựng mối quan hệ tốt đẹp với khách hàng, chăm sóc khách hàng sau bán hàng.
•	Giai đoạn 3: Đánh giá, điều chỉnh 
Trong giai đoạn này, chủ cửa hàng cần đánh giá hiệu quả của các hoạt động quản lý hàng hóa, doanh thu và điều hành cửa hàng, tiếp thu các ý kiến phản hồi từ khách hàng về cửa hàng. Từ đó, có những điều chỉnh kịp thời để đảm bảo hoạt động kinh doanh hiệu quả.
3. Chức năng bài toán
- Quản lý Phụ tùng xe ô tô
+ Thêm, sửa, xóa thông tin của phụ tùng (mã, tên, số lượng,...)
+ Tìm kiếm theo thông tin phụ tùng
+ Quản lý số lượng, hàng tồn kho, thời gian tồn kho của phụ tùng
+ Quản lý số lượng bán ra của phụ tùng
+ Quản lý giá bán của phụ tùng
- Quản lý bán xe
+ Thêm, sửa, xóa thông tin chi tiết xe hơi (mã, tên, số lượng,...)
+ Tìm kiếm theo thông tin xe
+ Quản lý số lượng, thời gian tồn kho của xe
+ Quản lý số lượng bán ra của xe
+ Quản lý giá bán của xe
- Quản lý nhân viên
+ Thêm, sửa, xóa thông tin của nhân viên (mã, họ tên,...)
+ Tìm kiếm theo thông tin nhân viên
+ Phân quyền theo nhóm
+ Lọc thông tin nhân viên
- Quản lý khách hàng
+ Thêm, sửa dữ liệu thông tin khách hàng
+ Tìm kiếm theo thông tin khách hàng
+ Thông kê sử dụng dịch vụ của khách hàng
- Quản lý mua hàng
+ Xuất hóa đơn
+ Quản lý chi tiết hóa đơn
- Quản lý tài chính
+ Thống kê chi thu của từng chi nhánh theo tháng, quý, năm(có thể chọn tháng, quý, năm tương ứng), thống kê theo từng loại xe, hãng xe
4. Phân quyền
- Phân quyền trong bài toán quản lý cửa hàng bán xe ô tô là cấp quyền và truy cập của nhân viên đến các tài nguyên và thông tin cửa hàng cũng như các thông tin về vật tư.
- Việc phân quyền này đảm bảo an toàn thông tin của khách hàng, an toàn dữ liệu với tài sản của cửa hàng. Tránh làm lộ thông tin, sai sót trong quá trình quản lý và sử dụng
- Thông qua chức vụ, trình độ và một số yếu tố mà quyền hạn của nhân viên trong cửa hàng xe sẽ được phân ra khác nhau. Cụ thể như sau:
1. Nhân viên tư vấn - bán hàng 
Những nhân viên này sẽ có quyền truy cập thông tin cơ bản của cửa hàng, như là: 
- Số lượng hàng hóa còn trong cửa hàng, giá cả của các hàng hóa này, cũng như là số lượng ở các chi nhánh và nhà cung cấp.
- Quyền yêu cầu nhập thêm các hàng hóa tương ứng.
- Quyền truy cập thông tin của khách hàng.
Từ đó dễ dàng nắm bắt những thông tin mới nhất, tư vấn khách hàng dễ dàng hơn, giúp cho lựa chọn của khách hàng tốt hơn, giải quyết các vấn đề xảy ra trong và sau khi mua hàng.
2. Nhân viên thu ngân 
Nhân viên thu ngân sẽ được quyền truy cập đến những thông tin liên quan đến tài chính, như: 
- Giá xe, giá phụ kiện
- Thông tin khách hàng
- Thông tin chi tiết về các giao dịch được thực hiên
- Quyền quản lý ngân sách, thu thập, chi phí, phân phối thu mua hàng hóa.
Từ đó đưa ra các thống kê cho cửa hàng, giúp dễ dàng quản lý chặt chẽ những vấn đề liên quan đến tài chính, tránh hiện tượng thiếu hụt, mất mát, đưa ra những số liệu chính xác nhất, nâng cao năng suất của cửa hàng.
3. Nhân viên sửa chữa, bảo dưỡng
Nhân viên bảo dưỡng có quyền sử dụng các trang thiết bị và vật tư trong cửa hàng, nhưng phải có báo cáo lại. Đồng thời phải xem xét về những mặt hàng được dùng nhiều để nhập thêm số lượng, cũng như giảm bớt những mặt hàng không cần thiết. Ngoài ra, nhân viên bảo dưỡng còn có quyền sử dụng xe để kiểm tra và bảo dưỡng định kỳ, qua đó có thể đảm bảo thiết bị của cửa hàng sẽ luôn ở trạng thái tốt nhất, làm hài lòng khách hàng với những dịch vụ kèm theo khi mua sản phẩm.
4. Nhân viên kho hàng 
Quyền của nhân viên kho hàng là sử dụng kho như:
- Truy cập thông tin hàng hóa
- Thống kê trang thiết bị
- Quản lý lịch trình
- Theo dõi hàng (tìm kiếm)
Từ đó thực hiện nhiệm vụ sắp xếp, đảm bảo nhu cầu cho khách hàng, đảm bảo hàng hóa sẽ luôn đầy đủ và ở trong tình trạng tốt nhất.
5. Quản lý 
Quyền hạn của người quản lý sẽ nhiều hơn những nhân viên khác và sẽ là người quản lý các nhân viên của cửa hàng. Quản lý là người đứng ra để nhận yêu cầu từ giám đốc và giao nhiệm vụ cho các nhân viên, là người thúc đẩy và quản lý quá trình làm việc của nhân viên, để đảm bảo mọi khâu đều liền mạch, ổn định, nâng cao hiệu suất làm việc của mọi người, cũng là người quản lý thu chi, là người nhận đề xuất của nhân viên và báo cáo.
5. Thuế nhập xe - nhập phụ tùng
- Thuế nhập xe:
    + Thuế nhập khẩu: áp dụng cho các xe đến từ nước ngoài, có thể dao động từ 56→74% giá trị xe
    + Thuế tiêu thụ đặc biệt: tất cả các mẫu xe dù được sản xuất trong nước hay nhập khẩu đều phải nộp thuế này. Tùy từng chủng loại, dung tích xi lanh và công nghệ sử dụng, mỗi loại xe có mức thuế tiêu thụ đặc biệt khác nhau.
    + Thuế giá trị gia tăng: 10% giá trị xe cho tất cả các dòng xe
    ⇒ Giá nhập xe:
Nội địa = Giá xe + Thuế tiêu thụ đặc biêt + Thuế giá trị gia tăng
Nhập khẩu = Giá xe + Thuế nhập khẩu + Thuế tiêu thụ đặc biệt + Thuế giá trị gia tăng
⇒ Giá niêm yết = Giá nhập xe * tỉ lệ lợi nhuận (15→20%)
- Thuế mua xe (Áp dụng cho khách mua xe):
+ Phí trước bạ: 10 → 15%, tùy thành phố.
+ Phí cấp biển số: 20.000.000 VNĐ (TPHCM và Hà Nội); 1.000.000 VNĐ (các thành phố trực thuộc tỉnh, Trung Ương không phải Hà Nội và TPHCM) và 200.000 VNĐ đối với các khu vực còn lại
+ Phí đăng kiểm: 240.000 VNĐ → 560.000 VNĐ(một lần kiểm định)
+ Phí sử dụng đường bộ (1 năm): 1.430.000 VNĐ tùy theo tải trọng xe.
+ Bảo hiểm trách nhiệm dân sự (1 năm): 437.000 VNĐ
+ Phí sử dụng đường bộ + bảo hiểm xe
⇒ Giá lăn bánh = Giá niêm yết + Phí trước bạ + Phí cấp biển số + Phí đăng kiểm 
- Phụ tùng
+ Thuế giá trị gia tăng: 10% giá nhập phụ tùng
+ Thuế nhập khẩu thông thường: tùy thuộc vào từng loại phụ tùng mà có giá trị thuế khác nhau, thuế nhập khẩu thông thường có thể dao động từ 4→40% giá nhập phụ tùng
+ Thuế nhập khẩu ưu đãi: có thể dao động từ 3→25% giá nhập phụ tùng
⇒ Giá nhập:
Nội địa = Giá phụ tùng + Thuế giá trị gia tăng
Nhập khẩu = Giá phụ tùng + Thuế giá trị gia tăng + Thuế nhập khẩu thông thường/Thuế nhập khẩu ưu đãi
- Bảng giá dịch vụ bảo dưỡng
+ Kiểm tra lốp xe: 80.000 VNĐ
+ Thay dầu nhớt ô tô định kỳ: 200.000 VNĐ
+ Vệ sinh hệ thống phanh thắng: 200.000 VNĐ
+ Vệ sinh khoang máy Ô tô: 900.000 VNĐ
+ Rửa xe tự động: 50.000 VNĐ
+ Thay lọc xăng: 100.000VNĐ
+ Thay lọc gió xe ô tô: 20.000VNĐ
+ Bảo dưỡng máy đề xe ô tô: 200.000VNĐ
+ Thay bugi xe ô tô: 100.000VNĐ
+ Thông súc bình xăng hoặc thùng dầu xe ô tô: 350.000VNĐ
6. Thống kê (Doanh thu, lợi nhuận)
- Tổng chi bao gồm:
Tổng chi phí nhập xe + nhập phụ tùng + lương nhân viên + cơ sở vật chất
- Doanh thu: Tổng số tiền bán xe và tổng số tiền từ các dịch vụ mà doanh nghiệp đã cung cấp cho khách hàng.
Tổng doanh thu = Doanh thu bán xe + Doanh thu bảo dưỡng
- Lợi nhuận: Số tiền thu được khi trừ tất cả chi phí
Lợi nhuận = Doanh thu - Tổng chi
 
2. Thiết kế cơ sở dữ liệu mức logic
Từ sơ đồ thực thể kết hợp (ERD), ta có các lược đồ quan hệ
CHINHANH(maChiNhanh, tenChiNhanh, diaChi)
NHANVIEN(maNhanVien, hoTenNhanVien, CCCD, ngaySinh, gioiTinh, diaChi, soDienThoai, chucVu, tinhTrangLamViec, hinhAnh, maChiNhanh)
TAIKHOAN(tenDangNhap, matKhau, chucVu)
NHACUNGCAP(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai)
LOXE(maLoXe, tenXe, mauSac, giaBan, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, tocDoToiDa, trongLuong, canhBaoPhuongTien, canhBaoDiemMu, tuiKhi, mocGheAnToan, camBienLui, cameraLui, phanhSau, phanhTruoc, boTruyenLuc, boDieuKhien, mucTieuThuNhienLieu, loaiNhienLieu, congSuatDongCo, dungTichDongCo, loaiDongCo, momenXoan, khoanSangGam, chieuDaiCoSo, dai, rong, cao, banKinhQuayVong, hinhAnh).
XE(maXe, maLoXe)
PHUTUNG(maPhuTung, loaiPhuTung, tenPhuTung, thuongHieu, xuatXu, giaBan, chatLuong, hinhAnh).
PHIEUNHAP(maPhieuNhap, ngayNhap, maNhaCungCap, maChiNhanh)
CHITIETPHIEUNHAPXE(maChiTietPhieuNhap, maXe, maPhieuNhap, giaNhap, soLuong)
CHITIETPHIEUNHAPPHUTUNG(maChiTietPhieuNhap, maPhuTung, maPhieuNhap, giaNhap, soLuong)
KHACHHANG(maKhachHang, hoTenKhachHang, ngaySinh, gioiTinh, CCCD, diaChi, so DienThoai).
HOADON(maHoaDon, maKhachHang, maNhanVienThucHien, ngayLapHoaDon, tongTien, tinhTrang)
CHITIETHOADONXE(maChiTietHoaDonXe, maHoaDon, maXe, ngayNhanXe, soTienDaTra, phiDangKyBienSo, phiDangKiem, phiTruocBa, baoHiemTrachNhiemDanSu, phiSuDungDuongBo)
CHITIETHOADONPHUTUNG(maChiTietHoaDonPhuTung, maHoaDon, maPhuTung, soTienDaTra)
HOPDONGBAOHANH(maHopDongBaoHanh, maXe, maKhachHang, ngayKyBaoHanh, thoiHanBaoHanh, tinhTrang)
PHIEUBAOHANH(maPhieuBaoHanh, maHopDongBaoHanh, maNhanVienThucHien, ngayNhanXe, ngayTraXe, ngayLapPhieu).
DICHVUBAODUONG(maBaoDuong, tenBaoDuong, loaiBaoDuong, phiBaoDuong).
PHIEUBAODUONG(maPhieuBaoDuong, maKhachHang, maNhanVienThucHien, ngayLapPhieu, tongTien).
HOADONBAODUONG(maHoaDonBaoDuong, maBaoDuong, maPhieuBaoDuong, thanhTien).
 
3. Các ràng buộc cần có
STT	TABLE	RÀNG BUỘC
1	CHINHANH	Ràng buộc khóa chính maChiNhanh
2	NHANVIEN	Ràng buộc khóa chính maNhanVien, ràng buộc khóa ngoại maChiNhanh tham chiếu dến CHINHANH
3	TAIKHOAN	Ràng buộc khóa chính tenDangNhap, ràng buộc khóa ngoại maNhanVien tham chiếu đến NHANVIEN
4	NHACUNGCAP	Ràng buộc khóa chính maNhaCungCap
5	LOXE	Ràng buộc khóa chính maLoXe
6	XE	Ràng buộc khóa chính maXe
7	PHUTUNG	Ràng buộc khóa chính maPhuTung
8	PHIEUNHAP	Ràng buộc khóa chính maPhieuNhap, ràng buộc khóa ngoại maNhaCungCap tham chiếu đến CUNGCAP, ràng buộc khóa ngoại maChiNhanh tham chiếu đến CHINHANH
9	CHITIETPHIEUNHAPXE	Ràng buộc khóa chính maChiTietPhieuNhapXe, ràng buộc khóa ngoại maXe tham chiếu đến XE, ràng buộc khóa ngoại maPhieuNhap tham chiếu đến PHIEUNHAP
10	CHITIETNHIEUNHAPPHUTUNG	Ràng buộc khóa chính maChiTietPhieuNhapPhuTung, ràng buộc khóa ngoại maPhuTung tham chiếu đến PHUTUNG, ràng buộc khóa ngoại maPhieuNhap tham chiếu đến PHIEUNHAP
11	KHACHHANG	Ràng buộc khóa chính maKhachHang
12	HOADON	Ràng buộc khóa chính maHoaDon, ràng buộc khóa ngoại maKhachHang tham chiếu đến KHACHHANG, ràng buộc khóa ngoại maNhanVienThucHien tham chiếu đến NHANVIEN
13	CHITIETHOADONXE	Ràng buộc khóa chính maChiTietHoaDonXe, ràng buộc khóa ngoại maHoaDon tham chiếu đến HOADON, ràng buộc khóa ngoại maXe tham chiếu đến XE
14	CHITIETHOADONPHUTUNG	Ràng buộc khóa chính maChiTietHoaDonPhuTung, ràng buộc khóa ngoại maHoaDon tham chiếu đến HOADON, ràng buộc khóa ngoại maPhuTung tham chiếu đến PHUTUNG
15	HOPDONGBAOHANH	Ràng buộc khóa chính maHopDongBaoHanh, ràng buộc khóa ngoại maXe tham chiếu đến XE, ràng buộc khóa ngoại maKhachHang tham chiếu đến KHACHHANG
16	PHIEUBAOHANH	Ràng buộc khóa chính maPhieuBaoHanh, ràng buộc khóa ngoại maHopDongBaoHanh tham chiếu đến HOPDONGBAOHANH, ràng buộc khóa ngoại maNhanVienThucHien tham chiếu đến NHANVIEN
17	DICHVUBAODUONG	Ràng buộc khóa chính maBaoDuong
18	PHIEUBAODUONG	Ràng buộc khóa chính maPhieuBaoDuong, ràng buộc khóa ngoại maKhachHang tham chiếu đến KHACHHANG, ràng buộc khóa ngoại maNhanVienThucHien tham chiếu đến NHANVIEN
19	CHITIETPHIEUBAODUONG	Ràng buộc khóa chính maChiTietPhieuBaoDuong, ràng buộc khóa ngoại maBaoDuong tham chiếu đến DICHVUBAODUONG, ràng buộc khóa ngoại maPhieuBaoDuong tham chiếu đến PHIEUBAODUONG






 
CHƯƠNG 2. PHÂN TÍCH THIẾT KẾ HỆ THỐNG
1. Thiết kế cơ sở dữ liệu mức quan niệm 
Từ mô tả về dữ liệu cần có ở phần mô tả của bài toán ta hình thành được sơ đồ thực thể kết hợp (ERD)
 

 
4. Cài đặt CSDL và các ràng buộc
Bảng chi nhánh
create table CHINHANH(
	maChiNhanh nvarchar(20) primary key,
	tenChiNhanh nvarchar(50) not null,
	diaChi nvarchar(255) not null,
)
Bảng nhân viên
create table NHANVIEN( 
	maNhanVien nvarchar(20) primary key,
	hoTenNhanVien nvarchar(50) not null,
	CCCD nvarchar(20) check (len(CCCD) = 12) unique,
	ngaySinh date check (DateDiff(year, ngaySinh, GetDate()) >= 18),
	gioiTinh nvarchar(5),
	diaChi nvarchar(255),
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11) unique,
	chucVu nvarchar(50),
	tinhTrangLamViec bit default 1,
	maChiNhanh nvarchar(20),
	foreign key (maChiNhanh) references CHINHANH(maChiNhanh)
)
Bảng tài khoản
create table TAIKHOAN(
	tenDangNhap nvarchar(20) primary key,	
	matKhau nvarchar(50) not null,
	chucVu nvarchar(50),
	maNhanVien nvarchar(20),
	foreign key (maNhanVien) references NHANVIEN(maNhanVien)
	on delete cascade -- Nhân viên xóa thì tải khoản cũng sẽ xóa
	on update cascade -- Nhân viên đổi mã thì tài khoản cũng đổi theo
)
 
Bảng nhà cung cấp
create table NHACUNGCAP(
	maNhaCungCap nvarchar(20) primary key,
	tenNhaCungCap nvarchar(50) not null,
	diaChi nvarchar(255) not null,
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11),
)

Bảng Lô xe
create table LOXE(
	maLoXe nvarchar(20) primary key,
	tenXe nvarchar(50), 
	mauSac nvarchar(20), 
	giaBan money check (giaBan > 0), 
	soChoNgoi integer check (soChoNgoi >= 2) default 4, 
	xuatXu nvarchar(50), 
	hangXe nvarchar(50), 
	loaiXe nvarchar(50), 
	phienBanXe nvarchar(50),
	tocDoToiDa integer check (tocDoToiDa > 0), 
	trongLuong integer check (trongLuong > 0),
	trongTai integer check (trongTai > 0),
	canhBaoPhuongTien nvarchar(50), 
	canhBaoDiemMu nvarchar(50), 
	tuiKhi nvarchar(50), 
	mocGheAnToan nvarchar(50), 
	camBienLui nvarchar(50), 
	cameraLui nvarchar(50), 
	phanhSau nvarchar(50), 
	phanhTruoc nvarchar(50), 
	boTruyenLuc nvarchar(50), 
	boDieuKhien nvarchar(50), 
	loaiNhienLieu nvarchar(50), 
	congSuatDongCo integer check (congSuatDongCo > 0), 
	dungTichDongCo integer check (dungTichDongCo > 0), 
	loaiDongCo nvarchar(50), 
	momenXoan integer check (momenXoan > 0), 
	khoanSangGam integer check (khoanSangGam > 0), 
	chieuDaiCoSo integer check (chieuDaiCoSo > 0), 
	chieuDai integer check (chieuDai > 0), 
	chieuRong integer check (chieuRong > 0), 
	chieuCao integer check (chieuCao > 0), 
	banKinhQuayVong integer check (banKinhQuayVong > 0),
	hinhAnh nvarchar(200)
)



Bảng Xe
CREATE TABLE XE(
	maXe nvarchar(20) primary key, 
	maLoXe nvarchar(20)
	foreign key (maLoXe) references LOXE(maLoXe)
)
Bảng Phụ tùng
CREATE TABLE PHUTUNG(
	maPhuTung nvarchar(20) primary key, 
	loaiPhuTung nvarchar(50), 
	tenPhuTung nvarchar(50), 
	thuongHieu nvarchar(50),
	xuatXu nvarchar(50), 
	giaBan money check (giaBan > 0), 
	chatLuong nvarchar(50),
hinhAnh nvarchar(200)
)
Bảng Phiếu nhập
create table PHIEUNHAP(
	maPhieuNhap nvarchar(20) primary key,
	ngayNhap date default GETDATE(),
	maNhaCungCap nvarchar(20),
	maChiNhanh nvarchar(20),
	foreign key (maNhaCungCap) references NHACUNGCAP(maNhaCungCap),
	foreign key (maChiNhanh) references CHINHANH(maChiNhanh)
)
Bảng Chi tiết phiếu nhập xe
create table PHIEUNHAP(
	maPhieuNhap nvarchar(20) primary key,
	ngayNhap date default GETDATE(),
	maNhaCungCap nvarchar(20),
	maChiNhanh nvarchar(20),
	foreign key (maNhaCungCap) references NHACUNGCAP(maNhaCungCap),
	foreign key (maChiNhanh) references CHINHANH(maChiNhanh)
)





Bảng Chi tiết phiếu nhập phụ tùng
create table CHITIETPHIEUNHAPPHUTUNG(
	maChiTietPhieuNhapPhuTung nvarchar(20) primary key,
	maPhuTung nvarchar(20),
	maPhieuNhap nvarchar(20),
	giaNhap money check (giaNhap > 0),
	soLuong integer check(soLuong > 0),
	foreign key (maPhuTung) references PHUTUNG(maPhuTung),
	foreign key (maPhieuNhap) references PHIEUNHAP(maPhieuNhap)
)

Bảng Khách hàng
CREATE TABLE KHACHHANG(
	maKhachHang nvarchar(20) primary key,
	hoTenKhachHang nvarchar(50) not null, 
	ngaySinh date check (DateDiff(year, ngaySinh, GetDate()) >= 18), 
	gioiTinh nvarchar(5), 
	CCCD nvarchar(20) check (len(CCCD) = 12) unique, 
	diaChi nvarchar(255), 
	soDienThoai nvarchar(20) check (len(soDienThoai) = 10 or len(soDienThoai) = 11) unique,
)

Bảng Hóa đơn
create table HOADON(
	maHoaDon nvarchar(20) primary key,
	ngayLapHoaDon nvarchar(50) default GETDATE(),
	tongTien money check (tongTien > 0),
	tinhTrang nvarchar(50) Check (tinhTrang = N'Chưa thanh toán' or tinhTrang = N'Đã thanh toán') default N'Chưa thanh toán',
	maKhachHang nvarchar(20), 
	maNhanVienThucHien nvarchar(20)
	foreign key (maKhachHang) references KHACHHANG(maKhachHang),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)




Bảng Chi tiết hóa đơn xe 
create table CHITIETHOADONXE(
	maChiTietHoaDon nvarchar(20) primary key,
	ngayNhanXe nvarchar(50),
	soTienDaTra money check (soTienDaTra >= 0),
	phiDangKyBienSo money check (phiDangKyBienSo >= 0),
	phiDangKiem money check (phiDangKiem >= 0),
	phiTruocBa money check (phiTruocBa >= 0),
	phiBaoHiemTrachNhiemDanSu money check (phiBaoHiemTrachNhiemDanSu >= 0),
	phiSuDungDuongBo money check (phiSuDungDuongBo >= 0),
	maHoaDon nvarchar(20), 
	maXe nvarchar(20),
	foreign key (maHoaDon) references HOADON(maHoaDon),
	foreign key (maXe) references XE(maXe)
)
Bảng Chi tiết hóa đơn phụ tùng
create table CHITIETHOADONPHUTUNG(
	maChiTietHoaDonPhuTung nvarchar(20) primary key,
	soTienDaTra money check (soTienDaTra >= 0),
	maHoaDon nvarchar(20), 
	maPhuTung nvarchar(20),
	foreign key (maHoaDon) references HOADON(maHoaDon),
	foreign key (maPhuTung) references PHUTUNG(maPhuTung)
)
Bảng Hóa đơn bảo hành
CREATE TABLE HOPDONGBAOHANH(
	maHopDongBaoHanh nvarchar(20) primary key, 
	maXe nvarchar(20),
	ngayKyBaoHanh date, 
	thoiHanBaoHanh date, 
	tinhTrang nvarchar(20) check (tinhTrang = N'Còn bảo hành' or tinhTrang = N'Hết hạn'),
	foreign key (maXe) references XE(maXe)
)







Bảng Phiếu bảo hành
CREATE TABLE PHIEUBAOHANH(
	maPhieuBaoHanh nvarchar(20) primary key, 
	maHopDongBaoHanh nvarchar(20),
	maNhanVienThucHien nvarchar(20),
	ngayNhanXe date,
	ngayTraXe date,
	ngayLapPhieu date,
	foreign key (maHopDongBaoHanh) references HOPDONGBAOHANH(maHopDongBaoHanh),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)
Bảng Dịch vụ bảo dưỡng
CREATE TABLE DICHVUBAODUONG(
	maBaoDuong nvarchar(20) primary key, 
	tenBaoDuong nvarchar(50) not null, 
	loaiBaoDuong nvarchar(50) not null,
	phiBaoDuong money check (phiBaoDuong >= 0),
)
Bảng Phiếu bảo dưỡng
CREATE TABLE PHIEUBAODUONG(
	maPhieuBaoDuong nvarchar(20) primary key, 
	ngayLapPhieu date default GetDate(), 
	tongTien money check (tongTien >= 0),
	maKhachHang nvarchar(20), 
	maNhanVienThucHien nvarchar(20), 
	foreign key (maKhachHang) references KHACHHANG(maKhachHang),
	foreign key (maNhanVienThucHien) references NHANVIEN(maNhanVien)
)
Bảng Chi tiết phiếu bảo dưỡng
create table CHITIETPHIEUBAODUONG(
	maChiTietPhieuBaoDuong nvarchar(20) primary key,
	maBaoDuong nvarchar(20),
	maPhieuBaoDuong nvarchar(20),
	thanhTien money check (thanhTien >= 0),
	foreign key (maBaoDuong) references DICHVUBAODUONG(maBaoDuong),
	foreign key (maPhieuBaoDuong) references PHIEUBAODUONG(maPhieuBaoDuong)
)
 
5. Các View
a. Xem danh sách nhân viên còn làm việc
CREATE VIEW v_DSNhanVienConLamViec as
SELECT hotenNhanVien, CCCD, ngaySinh, gioiTinh, soDienThoai
FROM NHANVIEN as nv
WHERE nv.tinhTrangLamViec = 1

b. Xem danh sách chi nhánh
CREATE VIEW v_DSChiNhanh as
SELECT * 
FROM CHINHANH

c. Xem danh sách nhà cung cấp
CREATE VIEW v_DSNhaCungCap as
SELECT *
FROM NHACUNGCAP

d. Xem danh sách xe
CREATE VIEW v_DSXeConTrongKho as
SELECT maXe, tenXe, mauSac, soChoNgoi, xuatXu, hangXe, loaiXe, phienBanXe, pn.soLuong
FROM XE, PHIEUNHAP as pn
WHERE pn.soLuong > 0

e. Xem danh sách nhân viên có chức vụ là quản lý
CREATE or alter VIEW v_NhanVienQuanLy as
select nv.maNhanVien, nv.hoTenNhanVien, nv.soDienThoai, cn.maChiNhanh, cn.tenChiNhanh
from NHANVIEN as nv, CHINHANH as cn
where nv.maChiNhanh = cn.maChiNhanh and nv.chucVu = 'Quản lý'

f. Xem danh sách xe có xuất xứ từ Nhật Bản
create or alter view v_XeXuatXuNhatBan as
select tenXe, giaBan, soChoNgoi,loaiXe, loaiDongCo, loaiNhienLieu
from LOXE where xuatXu = 'Nhật Bản'

g. Xem số xe đã bán theo chi nhánh
CREATE or ALTER VIEW v_SoXeDaBan as
SELECT cn.maChiNhanh, cn.maXe, CASE WHEN hd.daBan IS NULL 
                               THEN 0 
                               ELSE hd.daBan END 
                               AS daBan
FROM (SELECT distinct cn.maChiNhanh, x.maXe
	FROM CHINHANH as cn, PHIEUNHAP as pn, CHITIETPHIEUNHAPXE as pnx, XE as x
	WHERE cn.maChiNhanh = pn.maChiNhanh 
             and pn.maPhieuNhap = pnx.maPhieuNhap 
             and pnx.maXe = x.maXe) as cn 
LEFT OUTER JOIN 
(SELECT cn.maChiNhanh, hdx.maXe, count(*) daBan				
FROM NHANVIEN as nv,CHINHANH as cn, HOADON as hd, CHITIETHOADONXE as hdx 
WHERE nv.maChiNhanh = cn.maChiNhanh and hd.maNhanVienThucHien = nv.maNhanVien and hd.maHoaDon = hdx.maHoaDon 
GROUP BY cn.maChiNhanh, hdx.maXe) as hd 
on hd.maChiNhanh = cn.maChiNhanh and hd.maXe = cn.maXe


 

h. Xem danh sách xe theo từng chi nhánh
CREATE or AlTER VIEW v_KhoXeTheoChiNhanh as
SELECT distinct cn.maChiNhanh, cn.maXe, (cn.soLuong - hd.daBan) as Conlai
FROM (SELECT pn.maChiNhanh, ctpn.maXe, sum(ctpn.soLuong) as soLuong 
      FROM PHIEUNHAP as pn, CHITIETPHIEUNHAPXE as ctpn
      WHERE pn.maPhieuNhap = ctpn.maPhieuNhap
      GROUP BY pn.maChiNhanh, ctpn.maXe) as cn, v_SoXeDaBan as hd
WHERE cn.maChiNhanh = hd.maChiNhanh and cn.maXe = hd.maXe

6. Các Trigger
a. Set tên đăng nhập mặc định là mã nhân viên
create or alter trigger trg_ThemTaiKhoan
on NHANVIEN
for insert
as
begin
	declare @taiKhoan nvarchar(20), @chucVu nvarchar(50)
	select @taiKhoan = maNhanVien, @chucVu = chucVu from inserted
	insert into TAIKHOAN values (@taiKhoan, '1', @chucVu, @taiKhoan)
end

b. Tạo trigger khi sửa mã nhân viên thì tài khoản cũng sẽ cập nhật theo
create or alter trigger trg_CapNhatTaiKhoan
on NHANVIEN
for update
as
begin
	declare @taiKhoanCu nvarchar(20), @taiKhoanMoi nvarchar(20)
	set @taiKhoanMoi = (select maNhanVien from inserted)
	set @taiKhoanCu = (select maNhanVien from deleted)
	Update TAIKHOAN
	set tenDangNhap = @taiKhoanMoi, maNhanVien = @taiKhoanMoi
	where tenDangNhap = @taiKhoanCu
end

c. Thay đổi trạng thái hóa đơn khi thanh toán đủ	
CREATE or ALTER TRIGGER tg_ThayDoiTrangThaiHoaDon on CHITIETHOADONXE 
for update, insert as
BEGIN
	DECLARE @soTienDaTra money, @maHoaDon nvarchar(20), @tongTien money
	SELECT @soTienDaTra = ins.soTienDaTra, @maHoaDon = ins.maHoaDon 	FROM inserted as ins
	SElECT @tongTien = hd.tongTien 						FROM HOADON as hd 								WHERE hd.maHoaDon = @maHoaDon
	IF @tongTien <= @soTienDaTra
	BEGIN 
		UPDATE HOADON 
		SET tinhTrang = N'Đã Thanh Toán'
		WHERE maHoaDon = @maHoaDon
	END
END

d. Tự động gán mã xe theo lô khi nhập lô xe
CREATE or ALTER TRIGGER tg_TaoMaXe on CHITIETPHIEUNHAPXE
AFTER INSERT as
BEGIN
	DECLARE @maLoXe nvarchar(20), @soLuong int, @maChiNhanh nvarchar(20)
	SELECT @maLoXe = ins.maLoXe, @soLuong = ins.soLuong, @maChiNhanh = pn.maChiNhanh FROM inserted as ins, PHIEUNHAP as pn
	WHERE pn.maPhieuNhap = ins.maPhieuNhap
	WHILE @soLuong > 0
	BEGIN
		DECLARE @maXe nvarchar(20)
		SET @maXe = CONCAT(@maLoXe,'_', @maChiNhanh, REPLICATE('0', 4-LEN(@soLuong)),str(@soLuong, LEN(@soLuong))) 
		INSERT INTO XE(maXe, maLoXe)
		Values (@maXe, @maLoXe)
		SET @soLuong = @soLuong - 1
	END
END

e. Không cho phép 2 người quản lý cùng 1 chi nhánh
CREATE or ALTER TRIGGER tg_MotQuanLy on NHANVIEN
AFTER UPDATE, INSERT as
BEGIN 
	DECLARE @maChiNhanh nvarchar(20), @chucVu nvarchar(50), @count int, @maNhanVien nvarchar(20)
	SELECT @maChiNhanh = ins.maChiNhanh, @chucVu = ins.chucVu, @maNhanVien = ins.maNhanVien, @count = nv.soluong FROM inserted as ins, (SELECT nv.maChiNhanh, count(nv.maNhanVien) as soluong
																						FROM NHANVIEN as nv 
																						WHERE nv.chucVu = N'Quản lý' 
																						GROUP BY nv.maChiNhanh) as nv
																WHERE ins.maChiNhanh = nv.maChiNhanh
	IF @chucVu = N'Quản lý' and @count > 1
	BEGIN
		PRINT N'Không thể thêm quản lý'
		UPDATE NHANVIEN
		SET chucVu = null
		WHERE maNhanVien = @maNhanVien
	END
END

