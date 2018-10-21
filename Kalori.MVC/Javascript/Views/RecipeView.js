var RecipeView = function (model) {
    this.model = model;

    // recipe
    this.recipeNameEvent = new Event(this);
    this.recipeCookingtimeHEvent = new Event(this);

    // products
    this.addProductEvent = new Event(this);
    this.selectProductEvent = new Event(this);
    this.unselectProductEvent = new Event(this);
    this.completeProductEvent = new Event(this);
    this.deleteProductEvent = new Event(this);

    // instructions
    this.addInstructionEvent = new Event(this);

    this.init();
};


RecipeView.prototype = {

    init: function () {
        this.createChildren()
            .setupHandlers()
            .setStoredData()
            .enable();
    },

    createChildren: function () {
        // cache the document object

        this.$container = $('.js-container');

        //recipe
        this.$recipeNameTextBox = this.$container.find('.js-name-recipe-textbox');
        this.$recipeCookingtimeHTextBox = this.$container.find('.js-cookingtimeH-recipe-textbox');

        // products
        this.$addProductButton = this.$container.find('.js-add-product-button');
        this.$productNameTextBox = this.$container.find('.js-name-product-textbox');
        this.$productMassTextBox = this.$container.find('.js-mass-product-textbox');
        this.$productPricePerKgTextBox = this.$container.find('.js-pricePerKg-product-textbox');
        this.$productsContainer = this.$container.find('.js-products-container');
        this.$productsTable = this.$productsContainer.find('#ingredients tbody');

        // instructions
        this.$addInstructionButton = this.$container.find('.js-add-instruction-button');
        this.$instructionNameTextBox = this.$container.find('.js-name-instruction-textbox');
        this.$instructionsContainer = this.$container.find('.js-instructions-container');
        this.$instructionsTable = this.$instructionsContainer.find('#instructions tbody');

        return this;
    },

    setupHandlers: function () {

        // recipe
        this.recipeNameTextBoxHandler = this.recipeNameTextBox.bind(this);
        this.recipeCookingtimeHTextBoxHandler = this.recipeCookingtimeHTextBox.bind(this);

        // products
        this.addProductButtonHandler = this.addProductButton.bind(this);
        this.selectOrUnselectProductHandler = this.selectOrUnselectProduct.bind(this);
        this.completeProductButtonHandler = this.completeProductButton.bind(this);
        this.deleteProductButtonHandler = this.deleteProductButton.bind(this);

        // instructions
        this.addInstructionButtonHandler = this.addInstructionButton.bind(this);

        /**
        Handlers from Event Dispatcher
        */
        // recipe
        //this.recipeNameHandler = this.recipeName.bind(this);

        // products
        this.addProductHandler = this.addProduct.bind(this);
        this.clearProductTextBoxHandler = this.clearProductTextBox.bind(this);
        this.setProductsAsCompletedHandler = this.setProductsAsCompleted.bind(this);
        this.deleteProductsHandler = this.deleteProducts.bind(this);

        // instructions
        this.addInstructionHandler = this.addInstruction.bind(this);

        return this;
    },


    setStoredData: function() {
        this.showName();
        this.showCookingtimeH();
        return this;
    },

    enable: function () {

        //recipe
        this.$recipeNameTextBox.keyup(this.recipeNameTextBoxHandler);
        this.$recipeCookingtimeHTextBox.keyup(this.recipeCookingtimeHTextBoxHandler);

        // products
        this.$addProductButton.click(this.addProductButtonHandler);
        this.$container.on('click', '.js-product', this.selectOrUnselectProductHandler);
        this.$container.on('click', '.js-complete-product-button', this.completeProductButtonHandler);
        this.$container.on('click', '.js-delete-product-button', this.deleteProductButtonHandler);

        // instructions
        this.$addInstructionButton.click(this.addInstructionButtonHandler);

        /*****************************************************
         **** Event Dispatcher
         ****************************************************/
        // products
        this.model.addProductEvent.attach(this.addProductHandler);
        this.model.addProductEvent.attach(this.clearProductTextBoxHandler);
        this.model.setProductsAsCompletedEvent.attach(this.setProductsAsCompletedHandler);
        this.model.deleteProductsEvent.attach(this.deleteProductsHandler);

        // instructions
        this.model.addInstructionEvent.attach(this.addInstructionHandler);

        return this;
    },

    // recipes
    recipeNameTextBox: function () {
        console.log("view.recipeNameTextBox()");
        this.recipeNameEvent.notify({
            name: this.$recipeNameTextBox.val()
        });
    },

    recipeCookingtimeHTextBox: function () {
        console.log("view.recipeCookingtimeHTextBox()");
        this.recipeCookingtimeHEvent.notify({
            cookingtimeH: this.$recipeCookingtimeHTextBox.val()
        });
    },


    // products
    addProductButton: function () {
        this.addProductEvent.notify({
            name: this.$productNameTextBox.val(),
            mass: this.$productMassTextBox.val(),
            pricePerKg: this.$productPricePerKgTextBox.val()
        });
    },

    completeProductButton: function () {
        this.completeProductEvent.notify();
    },

    deleteProductButton: function () {
        this.deleteProductEvent.notify();
    },

    selectOrUnselectProduct: function () {

        var productIndex = $(event.target).attr("data-index");

        if ($(event.target).attr('data-product-selected') === 'false') {
            $(event.target).attr('data-product-selected', true);
            this.selectProductEvent.notify({
                productIndex: productIndex
            });
        } else {
            $(event.target).attr('data-product-selected', false);
            this.unselectProductEvent.notify({
                productIndex: productIndex
            });
        }

    },

    // recipe
    showName: function() {
        var name = this.model.getName();
        console.log("view.showName()" + name);
        var $recipeName = this.$recipeNameTextBox;
        $recipeName.val(name);
    },

    showCookingtimeH: function() {
        var cookingtimeH = this.model.getCookingtimeH();
        console.log("view.showCookingtimeH()" + cookingtimeH);
        var $recipeCookingtimeH = this.$recipeCookingtimeHTextBox;
        $recipeCookingtimeH.val(cookingtimeH);
    },
 

    // products
    showProducts: function () {
        this.buildProducts();
    },

    buildProducts: function () {
        var products = this.model.getProducts();
        var $productsTable = this.$productsTable;

        $productsTable.html('');

        var index = 0;
        for (var product in products) {
           $productsTable.append("<tr><td>" + products[product].productName + "</td>" +
                "<td>" + products[product].productMass + "</td>" +
                "<td>" + products[product].productPricePerKg + "</td>" +
                "<td>" + products[product].productPriceTotal + "</td>" +
                "<td>delete</td>" +
                "</tr>");

            index++;
        }

    },
    // instructions
    addInstructionButton: function () {
        console.log("view.addInstructionButton");
        this.addInstructionEvent.notify({
            name: this.$instructionNameTextBox.val()
        });
    },

    showInstructions: function () {
        this.buildInstructions();
    },

    buildInstructions: function () {
        var instructions = this.model.getInstructions();
        var html = "";
        var $instructionsContainer = this.$instructionsContainer;
        var $instructionsTable = this.$instructionsTable;

        $instructionsTable.html('');

        var index = 0;
        for (var instruction in instructions) {

            $instructionsTable.append("<tr><td>" + instructions[instruction].instructionNumber + "</td>" +
                "<td>" + instructions[instruction].instructionName + "</td>" +
                "<td>delete</td>" +
                "</tr>");

            index++;
        }

    },



    /* -------------------- Handlers From Event Dispatcher ----------------- */
    clearProductTextBox: function () {
        this.$productNameTextBox.val('');
        this.$productMassTextBox.val('');
        this.$productPricePerKgTextBox.val('');
    },

    addProduct: function () {
        this.showProducts();
    },

    setProductsAsCompleted: function () {
        this.showProducts();
    },

    deleteProducts: function () {
        this.showProducts();
    },

    addInstruction: function () {
        this.showInstructions();
    },

    /* -------------------- End Handlers From Event Dispatcher ----------------- */
};