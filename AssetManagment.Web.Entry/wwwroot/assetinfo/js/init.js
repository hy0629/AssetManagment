var tablebody = document.querySelector("#tablebody");
axios.get("/api/asset-api/asset-infos").then(response => {
    var d = response.data.data;
    var html = "";
    for (var i = 0; i < d.length; i++) {
        html += TablebodyHtml(headerDefined, d[i]);
    }

    tablebody.innerHTML = html;


}).catch(err => {

});



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

window.headerDefined = headerDefined;

function TableHeadHtml(list) {
    if (list == undefined) return;
    var keys = Object.keys(list);
    var headlist = keys.map(key => `<th>${list[key]}</th>`);
    return `<tr>${headlist.join('')}</tr>`;
}

var head = document.querySelector("#tablehead");
head.innerHTML = TableHeadHtml(headerDefined);


function TablebodyHtml(list, data) {
    if (list == undefined) return "";

    var keys = Object.keys(list);

    var items = keys.map(key => `<td>${data[key] == null ? '' : data[key]}</td>`)
    return `<tr>${items.join('')}</tr>`;
}

