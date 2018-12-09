var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.delete').off('click').on('click', function (f) {
            f.preventDefault();
            var result = confirm("Bạn có chắc chắn sẽ xóa dữ liệu?");
            if (result) {
                var btn = $(this);
                var id = btn.data('id');
                $.ajax({
                    url: "/Admin/Accountmanagement/Delete",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        if (data.data == false) {
                            alert("Không thể xóa");
                            return;
                        }
                        alert("Xóa thành công");
                        location.reload("/Admin/AccountManagement/Index");
                    }
                })
            }
        })
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Accountmanagement/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function(response){
                    console.log(response);
                    if(response.status == 0){
                        btn.text('Kích hoạt');
                    }
                    if (response.status == 1) {
                        btn.text('Khóa');
                    }
                    if (response.status == 2) {
                        btn.text('Kích hoạt');
                        alert("Tài khoản đang đăng nhập, không thể khóa");
                    }
                }
            })
        })

    }
}
user.init();