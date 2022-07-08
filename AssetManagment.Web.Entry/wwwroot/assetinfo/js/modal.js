var btnAdd = document.querySelector(".btn-add");
var nModal = document.querySelector("#addAssetModel");
var ibtn = document.querySelector("#insertInfoBtn");

var modalNumber = nModal.querySelector('.modal-number');
var modalCategory = nModal.querySelector('.modal-category');
var modalName = nModal.querySelector('.modal-name');
var modalSpec = nModal.querySelector('.modal-spec');
var modalState = nModal.querySelector('.modal-state');
var modalRegion = nModal.querySelector('.modal-region');
var modalStorage = nModal.querySelector('.modal-storage');
var modalDepartment = nModal.querySelector('.modal-department');
var modalUser = nModal.querySelector('.modal-user');
var modalAddTime = nModal.querySelector('.modal-add-time');
var modalPickupTime = nModal.querySelector('.modal-pickup-time');
var modalUnit = nModal.querySelector('.modal-unit');
var modalSource = nModal.querySelector('.modal-source');

var myModal = new bootstrap.Modal(nModal, {
    keyboard: false
})
nModal.addEventListener('show.bs.modal', function () {

});
ibtn.addEventListener("click", function () {
    axios.post('/api/asset-api/asset-info', {
        'id': 0,
        'createTime': modalAddTime.value,
        'userId': modalUser.value,
        'assetNumber': modalNumber.value,
        'categoryId': modalCategory.value,
        'assetName': modalName.value,
        'assetSpec': modalSpec.value,
        'assetStatusId': modalState.value,
        'regionId': modalRegion.value,
        'assetStorageId': modalStorage.value,
        'departmentId': modalDepartment.value,
        'assetUsersId': modalUser.value,
        'createTime': modalAddTime.value,
        'pickupTime': modalPickupTime.value,
        'assetUnit': modalUnit.value,
        'sourceId': modalSource.value,
    }).then(data => {
        myModal.hide();
    }).catch(err => {
        alert('添加失败');
    });
});