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
        
    },
    getFunctionByPermiss:function(url,callback) {
        $.post('/admin/Function/GetFunctionsByUser', { url: url }, function (itemobject, status) {
            for (var i = 0; i < itemobject.length; i++) {
                if (itemobject[i].click) {
                    //动态执行一个字符串，将结果覆盖原来的click的值

                    var strt = eval(itemobject[i].click);
                    itemobject[i].click = eval(itemobject[i].click);
                }
            }
            callback(itemobject);
        });
    }

}