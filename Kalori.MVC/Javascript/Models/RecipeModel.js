var RecipeModel = function () {
    //recipe
    this.recipe = {};
    this.recipe.name = "";
    this.recipe.cookingtimeH = "";

    //products
    this.recipe.products = [];
    this.selectedProducts = [];
    this.addProductEvent = new Event(this);
    this.setProductsAsCompletedEvent = new Event(this);
    this.deleteProductsEvent = new Event(this);

    //instructions
    this.recipe.instructions = [];
    this.addInstructionEvent = new Event(this);

    //check if stored data
    var recipe = JSON.parse(localStorage.getItem('recipe'));
    if (recipe !== null)
        this.recipe = recipe;
    else
        localStorage.setItem('recipe', JSON.stringify(this.recipe));

};

RecipeModel.prototype = {
    //recipe
    // TODO Get item from localstorage
    addName: function (recipe) {
        console.log("model.addName()");
        this.recipe.name = recipe.name;
        localStorage.setItem('recipe', JSON.stringify(recipe));
        //this.recipeNameEvent.notify();
    },

    // TODO Get item from localstorage
    addCookingtimeH: function (recipe) {
        console.log("model.addCookingtimeH)");
        this.recipe.cookingtimeH = recipe.cookingTimeH;
        localStorage.setItem('recipe', JSON.stringify(recipe));
        //this.recipeNameEvent.notify();
    },

    getName: function () {
        return this.recipe.name;
    },

    getCookingtimeH: function () {
        return this.recipe.cookingtimeH;
    },

    //products
    addProduct: function (ingredient) {
        this.recipe.products.push({
            productName: ingredient.name,
            productMass: ingredient.mass,
            productPricePerKg: ingredient.pricePerKg,
            productPriceTotal: ingredient.pricePerKg * (ingredient.mass / 1000),
            productStatus: 'uncompleted'
        });
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


    deleteProducts: function () {
        var selectedProducts = this.selectedProducts.sort();

        for (var i = selectedProducts.length - 1; i >= 0; i--) {
            this.recipe.products.splice(this.selectedProducts[i], 1);
        }

        // clear the selected products
        this.selectedProducts = [];

        this.deleteProductsEvent.notify();

    },

    //instructions
    addInstruction: function (instruction) {
        var length = Object.keys(this.recipe.instructions).length;
        this.recipe.instructions.push({
            instructionId: length + 1,
            instructionNumber: length + 1,
            instructionName: instruction.name
        });
        this.addInstructionEvent.notify();
    },

    getInstructions: function () {
        return this.recipe.instructions;
    }
};