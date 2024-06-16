const tblProduct = "products";
let productId = null;
getProductTable();

function createProduct(productName, productPrice, productDescription) {
  let lst = getProducts();
  const requestModel = {
    id: uuidv4(),
    productName: productName,
    productPrice: productPrice,
    productDescription: productDescription,
  };
  lst.push(requestModel);

  const jsonProduct = JSON.stringify(lst);
  localStorage.setItem(tblProduct, jsonProduct);
  successMessage("Saving Successful");
  clearControls();
}

function editProduct(id) {
  let lst = getProducts();
  const items = lst.filter((x) => x.id === id);

  if (items.length == 0) {
    console.log("no data found");
    errorMessage("no data found");
    return;
  }
  let item = items[0];
  productId = item.id;
  $("#txtProductName").val(item.productName);
  $("#txtProductPrice").val(item.productPrice);
  $("#txtProductDescription").val(item.productDescription);
}

function updateProduct(id, productName, productPrice, productDescription) {
  let lst = getProducts();
  const items = lst.filter((x) => x.id === id);

  if (items.length == 0) {
    console.log("no data found");
    errorMessage("no data found");
    return;
  }

  const item = items[0];
  item.productName = productName;
  item.productPrice = productPrice;
  item.productDescription = productDescription;

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblProduct, jsonBlog);
  successMessage("Updating Successful.");
  clearControls();
}

function deleteProduct(id) {
  confirmMessage("Are you sure you want to delete?").then(function (value) {
    let lst = getProducts();
    const items = lst.filter((x) => x.id === id);

    if (items.length == 0) {
      console.log("no data found");
      return;
    }

    lst = lst.filter((x) => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblProduct, jsonBlog);
    successMessage("Deleting Successful.");
    getProductTable();
  });
}

function getProductTable() {
  const lst = getProducts();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    const htmlRow = `
        <tr>
            <td>${++count}</td>
            <td>${item.productName}</td>
            <td>${item.productPrice}</td>
            <td>${item.productDescription}</td>
            <td>
                <button type="button" class="btn btn-warning" onclick="editProduct('${
                  item.id
                }')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteProduct('${
                  item.id
                }')">Delete</button>
                <button type="button" class="btn btn-success" onclick="addToCart('${
                  item.id
                }')">Add To Cart</button>
            </td>          
        </tr>
        `;
    htmlRows += htmlRow;
  });
  $("#tbody").html(htmlRows);
  new DataTable("#productTable");
}

function getProducts() {
  const products = localStorage.getItem(tblProduct);
  let lst = [];
  if (products !== null) {
    lst = JSON.parse(products);
  }
  return lst;
}

$("#btnSave").click(function () {
  const productName = $("#txtProductName").val();
  const productPrice = $("#txtProductPrice").val();
  const productDescription = $("#txtProductDescription").val();

  if (productId === null) {
    createProduct(productName, productPrice, productDescription);
  } else {
    updateProduct(productId, productName, productPrice, productDescription);
    productId = null;
  }
  getProductTable();
});

function clearControls() {
  $("#txtProductName").val("");
  $("#txtProductPrice").val("");
  $("#txtProductDescription").val("");
  $("#txtProductName").focus();
}
