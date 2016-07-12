var CRMHelper =
{
    CheckStatus: function(ajaxmsg, callback) {

        if (ajaxmsg.Status == "1") {
            $.ligerDialog.warn(ajaxmsg.msg);
            return;
        } else if (ajaxmsg.Status == "2") {
            $.ligerDialog.warn('未登录，请重新登陆', function() {
                window.top.location = "/admin/login/login";
            });
         
        } else if (ajaxmsg.Status=="0") {
            $.ligerDialog.success(ajaxmsg.msg);
            callback();
        } else if (ajaxmsg.Status=="3") {
            $.ligerDialog.error(ajaxmsg.msg);
        } else {
            $.ligerDialog.error("未知错误！");
        }
     
    }

}