var RecipeModel = function () {
    /*---------------------------------------------------
    ------- localStorage SET
    ----------------------------------------------------*/
    this.addToLocalStorageObject = function (key, value) {
        var existing = localStorage.getItem('recipe');
        existing = existing ? JSON.parse(existing) : this.recipe;
        existing[key] = value;
        localStorage.setItem('recipe', JSON.stringify(existing));
    };
    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
    this.recipe = {};
    this.recipe.name = "";
    this.recipe.cookingtimeH = "";
    this.recipe.cookingtimeM = "";
    this.recipe.portions = "";

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    this.recipe.products = new Array();
    this.selectedProducts = [];
    this.addProductEvent = new Event(this);
    this.setProductsAsCompletedEvent = new Event(this);
    this.deleteProductsEvent = new Event(this);
    this.deleteProductEvent = new Event(this);
    this.editProductEvent = new Event(this);
    this.saveProductEvent = new Event(this);

    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    this.recipe.instructions = [];
    this.addInstructionEvent = new Event(this);
    this.deleteInstructionEvent = new Event(this);
    this.editInstructionEvent = new Event(this);
    this.saveInstructionEvent = new Event(this);

    /*---------------------------------------------------
    ------- localStorage GET
    ----------------------------------------------------*/
    var recipe = JSON.parse(localStorage.getItem('recipe'));
    if (recipe !== null)
        this.recipe = recipe;
    else
        localStorage.setItem('recipe', JSON.stringify(this.recipe));

};

RecipeModel.prototype = {
    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
    addName: function (recipe) {
        console.log("model.addName()");
        this.recipe.name = recipe.name;
        this.addToLocalStorageObject('name', this.recipe.name);
   },

    addCookingtimeH: function (recipe) {
        console.log("model.addCookingtimeH()");
        this.recipe.cookingtimeH = recipe.cookingtimeH;
        this.addToLocalStorageObject('cookingtimeH', this.recipe.cookingtimeH);
   },

    addCookingtimeM: function (recipe) {
        console.log("model.addCookingtimeM()");
        this.recipe.cookingtimeM = recipe.cookingtimeM;
        this.addToLocalStorageObject('cookingtimeM', this.recipe.cookingtimeM);
   },

    addPortions: function (recipe) {
        console.log("model.addPortions()");
        this.recipe.portions = recipe.portions;
        this.addToLocalStorageObject('portions', this.recipe.portions);
   },

    getName: function () {
        return this.recipe.name;
    },

    getCookingtimeH: function () {
        return this.recipe.cookingtimeH;
    },

    getCookingtimeM: function () {
        return this.recipe.cookingtimeM;
    },

    getPortions: function () {
        return this.recipe.portions;
    },

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    addProduct: function (product) {
        this.recipe.products.push({
            name: product.name,
            mass: product.mass,
            pricePerKg: product.pricePerKg,
            priceTotal: product.pricePerKg * (product.mass / 1000)
        });
        console.log("model.addProduct()" + this.recipe.products.length);
        this.addToLocalStorageObject('products', this.recipe.products);
        this.addProductEvent.notify();
    },

    getProducts: function () {
        return this.recipe.products;
    },

    setSelectedProduct: function (productIndex) {
        this.selectedProducts.push(productIndex);
    },

    unselectProduct: function (productIndex) {
        this.selectedProducts.splice(productIndex, 1);
    },

    setProductsAsCompleted: function () {
        var selectedProducts = this.selectedProducts;
        for (var index in selectedProducts) {
            this.recipe.products[selectedProducts[index]].productStatus = 'completed';
        }

        this.setProductsAsCompletedEvent.notify();

        this.selectedProducts = [];

    },

    deleteProduct: function (products) {
        console.log("model.deleteProduct() "+products.index);
        this.recipe.products.splice(products.index, 1);
        this.addToLocalStorageObject('products', this.recipe.products);
        this.deleteProductEvent.notify();
    },

    deleteProducts: function () {
        var selectedProducts = this.selectedProducts.sort();

        for (var i = selectedProducts.length - 1; i >= 0; i--) {
            this.recipe.products.splice(this.selectedProducts[i], 1);
        }

        // clear the selected products
        this.selectedProducts = [];

        this.deleteProductsEvent.notify();

    },

    editProduct: function (instructions) {
        console.log("model.editProduct() "+instructions.index);
    },

    saveProduct: function (products) {
        console.log("model.saveProduct() "+ products.name);
        this.recipe.products[products.index].name = products.name;
        this.recipe.products[products.index].mass = products.mass;
        this.recipe.products[products.index].pricePerKg = products.pricePerKg;
        this.addToLocalStorageObject('products', this.recipe.products);
        this.saveProductEvent.notify();
    },


    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    addInstruction: function (instruction) {
        var length = Object.keys(this.recipe.instructions).length;
        this.recipe.instructions.push({
            id: length + 1,
            number: length + 1,
            name: instruction.name
        });
        this.addToLocalStorageObject('instructions', this.recipe.instructions);
        this.addInstructionEvent.notify();
    },

    deleteInstruction: function (instructions) {
        console.log("model.deleteInstruction() "+instructions.index);
        this.recipe.instructions.splice(instructions.index, 1);
        this.addToLocalStorageObject('instructions', this.recipe.instructions);
        this.deleteInstructionEvent.notify();
    },

    editInstruction: function (instructions) {
        console.log("model.editInstruction() "+instructions.index);
    },

    saveInstruction: function (instructions) {
        console.log("model.saveInstruction() "+ instructions.name);
        this.recipe.instructions[instructions.index].name = instructions.name;
        this.addToLocalStorageObject('instructions', this.recipe.instructions);
        this.saveInstructionEvent.notify();
    },

    getInstructions: function () {
        return this.recipe.instructions;
    }
};