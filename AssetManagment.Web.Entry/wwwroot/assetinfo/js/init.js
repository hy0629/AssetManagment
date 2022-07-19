var headerDefined = {
    "asset_number": "资产编号",
    "asset_category": "资产类别",
    "asset_name": "名称",
    "asset_spec": "规格",
    "asset_unit": "计量单位",
    "price": "价值",
    "asset_state": "资产状况",
    "asset_source": "资产来源",
    "region": "所属地区",
    "storage": "存放位置",
    "department": "使用部门",
    "member": "使用人员",
    "used_time": "领取时间",
    "record_time": "登记时间",
    "note": "备注",
    "service_life": "使用年限"
}

function safeValue(value) {
    if (value == null || value == undefined) {
        return "";
    }
    return value;
}

//表头
function generateTableHead(dict, callback) {
    var keys = Object.keys(dict);
    var tdl = keys.map(val => {
        return `<th>${safeValue(dict[val])}</th>`;
    });
    var html = `<tr>${tdl.join('')}</tr>`;
    var doc = document.createRange().createContextualFragment(html);
    if (typeof callback == 'function') {
        callback(doc);
    }
    return doc;
}

//表体
function generateTableBody(dict, data, callback) {
    var keys = Object.keys(dict);
    var tdl = keys.map(val => {
        return `<td>${safeValue(data[val])}</td>`
    });
    var html = `<tr>${tdl.join('')}</tr>`
    var doc = document.createRange().createContextualFragment(html);
    if (typeof callback == 'function') {
        callback(doc);
    }
    return doc;
}

//路径高亮
var pathname = window.location.pathname;
var pathlist = pathname.split('/');
var navlist = document.querySelectorAll('.nav-link');

pathlist = pathlist.splice(1);

pathlist.forEach(path => {
    var link = document.querySelector(`.nav-link[data-path="${path}"]`);
    if (link != undefined) {
        link.classList.add("active");
    }
});
//

//注册公共方法
window.header_defined = headerDefined;
window.generateTableBody = generateTableBody;
window.generateTableHead = generateTableHead;
