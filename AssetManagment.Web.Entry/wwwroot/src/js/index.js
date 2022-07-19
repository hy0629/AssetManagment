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

var defaultheadDefined = {
    "code": "编号",
    "name": "名称",
    "note": "备注"
}

window.headDefined = {
    "assetinfo": {
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
    },
    "default": {
        "code": "编号",
        "name": "名称",
        "note": "备注"
    }
}

function safeValue(value) {
    if (value == null || value == undefined) {
        return "";
    }
    return value;
}

//表头
function generateTableHead(dict, target) {
    var keys = Object.keys(dict);
    var tdl = keys.map(val => {
        return `<th>${safeValue(dict[val])}</th>`;
    });
    var html = `<tr><th style="width: 120px;"><div class="form-check"><input class="form-check-input" type="checkbox" id="select_cbtn"/><label for="select_cbtn">选择</label></div></th>${tdl.join('')}<td>操作</td></tr>`;
    target.innerHTML = html;

    registerBodyEvent(document.querySelector('table thead input[type="checkbox"]'));
}


var DELETECLASS = ".btn_delete";
var EDITCLASS = ".btn_edit";

var op_html = `<td>
                    <button class="${DELETECLASS} btn mx-2 btn-danger btn-sm">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                          <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                          <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                        </svg>
                    </button>
                    <button class="${EDITCLASS} btn btn-primary btn-sm">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                            <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"/>
                        </svg>
                    </button>
                </td>`;
var c_html = `<td><input class="form-check-input" type="checkbox"/></td>`;

//表体
function generateTableBody(dict, data, target) {
    if (!(data instanceof Array)) return;
    var html = "";
    var keys = Object.keys(dict);

    data.forEach(d => {
        var tdl = keys.map(val => {
            return `<td class="justify-content-center">${safeValue(d[val])}</td>`
        });
        html += `<tr data-id="${d.value}"><td><input class="form-check-input" type="checkbox"/></td>${tdl.join('')}${op_html}</tr>`;
    });

  
    target.innerHTML = html;
}

//路径高亮
window.addEventListener('load', function () {
    var pathname = window.location.pathname;
    var pathlist = pathname.split('/');

    pathlist = pathlist.splice(1);

    pathlist.forEach(path => {
        var q = `.nav-link[data-path="${path}"]`;
        var link = document.querySelector(q);
        if (link != undefined) {
            link.classList.add("active");
        }
    });
});
//

function registerSelectEvent(target) {
    target.addEventListener('click', function () {
        var trs = document.querySelectorAll('tbody tr input[type="checkbox"]');
        trs.forEach(el => {
            el.checked = target.checked ? true: false;
        })
    });
}

function registerBodyEvent(target) {

}

//curd
function add(url, content, callback) {
    return new Promise((resole, reject) => {
        axios.post(url, content).then(response =>
        {
            if (response.data.code !== 200) {
                reject(response);
            } else {
                resolve(response.data.data);
            }
            callback(response.data.data);
        }).catch(err => { reject(err); });
    });
}

function initTable(target, dict, option = { hasCheckbox: true, hasControls: true }) {
    if (target == undefined || target == null) return;
    if (!target.classList.contains('table')) {
        target.classList.add('table');
    }

    var hasCheckbox = option.hasCheckbox;
    var hasControls = option.hasControls;

    var keys = Object.keys(dict);

    var thl = keys.map(key => {
        return `<th>${safeValue(dict[key])}</th>`;
    });
    var html = `<thead><tr>${hasCheckbox ? '<th style="width: 120px;"><div class="form-check"><input class="form-check-input c-head" type="checkbox" id="select_cbtn"/><label for="select_cbtn">选择</label></div></th>' : ''}${thl.join('')}${hasControls ? '<th>操作</th>' : ''}</tr></thead><tbody></tbody>`;

    var range = document.createRange();
    range.selectNodeContents(target);
    var doc = range.createContextualFragment(html);
    console.log(doc);
    target.appendChild(doc);

    if (hasCheckbox) {
        target.addEventListener('click', function (event) {
            if (event.target == undefined || event.target == null) return;
            if (!event.target.classList.contains('form-check-input')) return;

            var checkbox = event.target;
            var ch = document.querySelector('table thead .form-check-input');
            var cs = document.querySelectorAll('table tbody .form-check-input');

            cs = Array.from(cs);

            if (checkbox.classList.contains('c-head')) {
                cs.forEach(el => {
                    el.checked = checkbox.checked;
                });
            } else {
                ch.checked = cs.every(el => el.checked == true);
            }
        });
    }

    target.initData = function (data) {
        var tbody = document.querySelector('tbody');
        var trh = "";

        if (data instanceof Array) {
            var trl = data.map(d => {
                var tdl = keys.map(key => {
                    return `<td>${safeValue(d[key])}</td>`;
                });
                return `<tr>${hasCheckbox ? c_html : ''}${tdl.join('')}${hasControls ? op_html : ''}</tr>`;
            });
            trh = trl.join('');
        } else {
            var tdl = keys.map(key => {
                return `<td>${safeValue(data[key])}</td>`;
            });
            trh = `<tr>${hasCheckbox ? c_html : ''}${tdl.join('')}${hasControls ? op_html : ''}</tr>`;
        }
        console.log(trh);
        tbody.innerHTML = trh;
    }
}

//注册公共方法
window.generateTableBody = generateTableBody;
window.generateTableHead = generateTableHead;
window.registerSelectEvent = registerSelectEvent;
window.initTable = initTable;
