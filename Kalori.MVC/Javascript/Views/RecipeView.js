// <var>The recipe view</var>
var RecipeView = function (model) {
    this.model = model;

    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
    this.recipeNameEvent = new Event(this);
    this.recipeCookingtimeHEvent = new Event(this);
    this.recipeCookingtimeMEvent = new Event(this);
    this.recipePortionsEvent = new Event(this);

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    this.addProductEvent = new Event(this);
    this.selectProductEvent = new Event(this);
    this.unselectProductEvent = new Event(this);
    this.completeProductEvent = new Event(this);
    this.deleteProductEvent = new Event(this);
    this.editProductEvent = new Event(this);
    this.saveProductEvent = new Event(this);

    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    this.addInstructionEvent = new Event(this);
    this.deleteInstructionEvent = new Event(this);
    this.editInstructionEvent = new Event(this);
    this.saveInstructionEvent = new Event(this);

    this.init();
};

RecipeView.prototype = {

    /// <summary>
    ///  Initialize
    /// </summary>
    init: function () {
        this.createChildren()
            .setupHandlers()
            .setStoredData()
            .enable();
    },

    /// <summary>
    /// Cache objects
    /// </summary>
    createChildren: function () {
        this.$container = $('.js-container');

        /*---------------------------------------------------
        ------- recipe
        ----------------------------------------------------*/
        this.$recipeNameTextBox = this.$container.find('.js-name-recipe-textbox');
        this.$recipeCookingtimeHTextBox = this.$container.find('.js-cookingtimeH-recipe-textbox');
        this.$recipeCookingtimeMTextBox = this.$container.find('.js-cookingtimeM-recipe-textbox');
        this.$recipePortionsTextBox = this.$container.find('.js-portions-recipe-textbox');

        /*---------------------------------------------------*
        ------- products
        *----------------------------------------------------*/
        this.$addProductButton = this.$container.find('.js-add-product-button');
        this.$productNameTextBox = this.$container.find('.js-name-product-textbox');
        this.$productMassTextBox = this.$container.find('.js-mass-product-textbox');
        this.$productPricePerKgTextBox = this.$container.find('.js-pricePerKg-product-textbox');
        this.$productsContainer = this.$container.find('.js-products-container');
        this.$productsTable = this.$productsContainer.find('#ingredients tbody');

        /*---------------------------------------------------*
        ------- instructions
        *----------------------------------------------------*/
        this.$addInstructionButton = this.$container.find('.js-add-instruction-button');
        this.$instructionNameTextBox = this.$container.find('.js-name-instruction-textbox');
        this.$instructionsContainer = this.$container.find('.js-instructions-container');
        this.$instructionsTable = this.$instructionsContainer.find('#instructions tbody');

        return this;
    },

    /// <summary>
    /// Sets up the handlers
    /// </summary>
    setupHandlers: function () {

        /*---------------------------------------------------*
        ------- recipe
        *----------------------------------------------------*/
        this.recipeNameTextBoxHandler = this.recipeNameTextBox.bind(this);
        this.recipeCookingtimeHTextBoxHandler = this.recipeCookingtimeHTextBox.bind(this);
        this.recipeCookingtimeMTextBoxHandler = this.recipeCookingtimeMTextBox.bind(this);
        this.recipePortionsTextBoxHandler = this.recipePortionsTextBox.bind(this);

        /*---------------------------------------------------*
        ------- products
        *----------------------------------------------------*/
        this.addProductButtonHandler = this.addProductButton.bind(this);
        this.deleteProductLinkHandler = this.deleteProductLink.bind(this);
        this.editProductLinkHandler = this.editProductLink.bind(this);
        this.saveProductLinkHandler = this.saveProductLink.bind(this);
        this.selectOrUnselectProductHandler = this.selectOrUnselectProduct.bind(this);
        this.completeProductButtonHandler = this.completeProductButton.bind(this);
        this.deleteProductButtonHandler = this.deleteProductButton.bind(this);

        /*---------------------------------------------------*
        ------- instructions
        *----------------------------------------------------*/
        this.addInstructionButtonHandler = this.addInstructionButton.bind(this);
        this.deleteInstructionLinkHandler = this.deleteInstructionLink.bind(this);
        this.editInstructionLinkHandler = this.editInstructionLink.bind(this);
        this.saveInstructionLinkHandler = this.saveInstructionLink.bind(this);


        /*****************************************************
        ******* Handlers from event dispatcher
        ******************************************************/

        /*---------------------------------------------------*
        ------- products
        *----------------------------------------------------*/
        this.addProductHandler = this.addProduct.bind(this);
        this.clearProductTextBoxHandler = this.clearProductTextBox.bind(this);
        this.setProductsAsCompletedHandler = this.setProductsAsCompleted.bind(this);
        this.deleteProductsHandler = this.deleteProducts.bind(this);
        this.deleteProductHandler = this.deleteProduct.bind(this);

        /*---------------------------------------------------*
        ------- instructions
        *----------------------------------------------------*/
        this.addInstructionHandler = this.addInstruction.bind(this);
        this.deleteInstructionHandler = this.deleteInstruction.bind(this);

        return this;
    },

    /// <summary>
    /// Sets stored data from localstorage
    /// </summary>
    setStoredData: function () {
        this.showName();
        this.showCookingtimeH();
        this.showCookingtimeM();
        this.showPortions();
        this.showProducts();
        this.showInstructions();
        return this;
    },

    /// <summary>
    /// Enables the handlers
    /// </summary>
    enable: function () {

        /*---------------------------------------------------
        ------- recipe
        ----------------------------------------------------*/
        this.$recipeNameTextBox.keyup(this.recipeNameTextBoxHandler);
        this.$recipeCookingtimeHTextBox.keyup(this.recipeCookingtimeHTextBoxHandler);
        this.$recipeCookingtimeMTextBox.keyup(this.recipeCookingtimeMTextBoxHandler);
        this.$recipePortionsTextBox.keyup(this.recipePortionsTextBoxHandler);

        /*---------------------------------------------------
        ------- products
        ----------------------------------------------------*/
        this.$addProductButton.click(this.addProductButtonHandler);
        //this.$container.on('click', '.js-product', this.selectOrUnselectProductHandler);
        this.$container.on('click', '.js-delete-product', this.deleteProductLinkHandler);
        this.$container.on('click', '.js-edit-product', this.editProductLinkHandler);
        this.$container.on('click', '.js-save-product', this.saveProductLinkHandler);
        this.$container.on('click', '.js-complete-product-button', this.completeProductButtonHandler);
        this.$container.on('click', '.js-delete-product-button', this.deleteProductButtonHandler);

        /*---------------------------------------------------
        ------- instructions
        ----------------------------------------------------*/
        this.$addInstructionButton.click(this.addInstructionButtonHandler);
        this.$container.on('click', '.js-delete-instruction', this.deleteInstructionLinkHandler);
        this.$container.on('click', '.js-edit-instruction', this.editInstructionLinkHandler);
        this.$container.on('click', '.js-save-instruction', this.saveInstructionLinkHandler);

        /*****************************************************
        ******* Event dispatcher
        ******************************************************/

        /*---------------------------------------------------
        ------- products
        ----------------------------------------------------*/
        this.model.addProductEvent.attach(this.addProductHandler);
        this.model.addProductEvent.attach(this.clearProductTextBoxHandler);
        this.model.setProductsAsCompletedEvent.attach(this.setProductsAsCompletedHandler);
        this.model.deleteProductsEvent.attach(this.deleteProductsHandler);
        this.model.deleteProductEvent.attach(this.deleteProductHandler);

        /*---------------------------------------------------
        ------- instructions
        ----------------------------------------------------*/
        this.model.addInstructionEvent.attach(this.addInstructionHandler);
        this.model.deleteInstructionEvent.attach(this.deleteInstructionHandler);

        return this;
    },

    /*****************************************************
    ******* Notify listeners
    ******************************************************/

    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
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

    recipeCookingtimeMTextBox: function () {
        console.log("view.recipeCookingtimeMTextBox()");
        this.recipeCookingtimeMEvent.notify({
            cookingtimeM: this.$recipeCookingtimeMTextBox.val()
        });
    },

    recipePortionsTextBox: function () {
        console.log("view.recipePortionsTextBox()");
        this.recipePortionsEvent.notify({
            portions: this.$recipePortionsTextBox.val()
        });
    },

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    addProductButton: function () {
        this.addProductEvent.notify({
            name: this.$productNameTextBox.val(),
            mass: this.$productMassTextBox.val(),
            pricePerKg: this.$productPricePerKgTextBox.val()
        });
    },

    deleteProductLink: function () {
        var index = $(event.target).attr("data-index");
        console.log("view.deleteProductLink() " + index);
        this.deleteProductEvent.notify({
            index: index
        });
    },

    editProductLink: function () {
        $(event.target).removeClass().addClass("js-save-product");
        $(event.target).text("save");
        var tdName = $(event.target).closest('tr').find('.js-name-product');
        var tdMass = $(event.target).closest('tr').find('.js-mass-product');
        var tdPricePerKg = $(event.target).closest('tr').find('.js-pricePerKg-product');
        var index = $(event.target).attr("data-index");
        var name = tdName.text();
        var mass = tdMass.text();
        var pricePerKg = tdPricePerKg.text();
        console.log("view.editProductLink() " + index + ", " + name + ", " + mass + ", " + pricePerKg);
        tdName.html("").append("<input type='text' value=\"" + name + "\">");
        tdMass.html("").append("<input type='text' value=\"" + mass + "\">");
        tdPricePerKg.html("").append("<input type='text' value=\"" + pricePerKg + "\">");
        this.editProductEvent.notify({
            name: name,
            mass: mass,
            pricePerKg: pricePerKg
        });
    },

    saveProductLink: function () {
        console.log("view.saveProductLink()");
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

    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    addInstructionButton: function () {
        console.log("view.addInstructionButton() " + this.$instructionNameTextBox.val());
        this.addInstructionEvent.notify({
            name: this.$instructionNameTextBox.val()
        });
        this.$instructionNameTextBox.val("");
    },

    deleteInstructionLink: function () {
        var index = $(event.target).attr("data-index");
        console.log("view.deleteInstructionLink() " + index);
        this.deleteInstructionEvent.notify({
            index: index
        });
    },

    editInstructionLink: function () {
        $(event.target).removeClass().addClass("js-save-instruction");
        $(event.target).text("save");
        var td = $(event.target).closest('tr').find('.js-name-instruction');
        var index = $(event.target).attr("data-index");
        var name = td.text();
        console.log("view.editInstructionLink() " + index + ", " + name);
        td.html("").append("<input type='text' value=\"" + name + "\">");
        this.editInstructionEvent.notify({
            index: index
        });
    },

    saveInstructionLink: function () {
        var td = $(event.target).closest('tr').find('.js-name-instruction');
        var index = $(event.target).attr("data-index");
        var name = td.find('input').val();
        obj.Id = $(this).find("input").val();
        $(event.target).removeClass().addClass("js-edit-instruction");
        $(event.target).text("edit");
        console.log("view.saveInstructionLink() " + index);
        console.log("view.saveInstructionLink() " + name);
        td.html(name);
        this.saveInstructionEvent.notify({
            index: index,
            name: name
        });
    },

    /*****************************************************
    ******* Get data from model and display it
    ******************************************************/
    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
    showName: function () {
        var name = this.model.getName();
        console.log("view.showName()" + name);
        var $recipeName = this.$recipeNameTextBox;
        $recipeName.val(name);
    },

    showCookingtimeH: function () {
        var cookingtimeH = this.model.getCookingtimeH();
        console.log("view.showCookingtimeH()" + cookingtimeH);
        var $recipeCookingtimeH = this.$recipeCookingtimeHTextBox;
        $recipeCookingtimeH.val(cookingtimeH);
    },

    showCookingtimeM: function () {
        var cookingtimeM = this.model.getCookingtimeM();
        console.log("view.showCookingtimeM()" + cookingtimeM);
        var $recipeCookingtimeM = this.$recipeCookingtimeMTextBox;
        $recipeCookingtimeM.val(cookingtimeM);
    },

    showPortions: function () {
        var portions = this.model.getPortions();
        console.log("view.showPortions()" + portions);
        var $recipePortions = this.$recipePortionsTextBox;
        $recipePortions.val(portions);
    },

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    showProducts: function () {
        this.buildProducts();
    },

    buildProducts: function () {
        var products = this.model.getProducts();
        var $productsTable = this.$productsTable;

        $productsTable.html('');

        var index = 0;
        for (var product in products) {
            $productsTable.append("<tr><td class='js-name-product'>" + products[product].name + "</td>" +
                "<td class='js-mass-product'>" + products[product].mass + "</td>" +
                "<td class='js-pricePerKg-product'>" + products[product].pricePerKg + "</td>" +
                "<td>" + products[product].priceTotal + "</td>" +
                "<td><a href='#!' class='js-delete-product' data-index='" + index + "'>delete</a> <a href='#!' class='js-edit-product' data-index='" + index + "'>edit</a></td>" +
                "</tr>");

            index++;
        }
    },
    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    showInstructions: function () {
        this.buildInstructions();
    },

    buildInstructions: function () {
        var instructions = this.model.getInstructions();
        var $instructionsTable = this.$instructionsTable;

        $instructionsTable.html('');

        var index = 0;
        for (var instruction in instructions) {

            $instructionsTable.append("<tr><td>" + instructions[instruction].number + "</td>" +
                "<td class='js-name-instruction'>" + instructions[instruction].name + "</td>" +
                "<td><a href='#!' class='js-delete-instruction' data-index='" + index + "'>delete</a> <a href='#!' class='js-edit-instruction' data-index='" + index + "'>edit</a></td>" +
                "</tr>");

            index++;
        }
    },

    /*****************************************************
    ******* Handlers from event dispatcher
    ******************************************************/
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

    deleteProduct: function () {
        console.log("view.deleteProduct()");
        this.showProducts();
    },

    deleteProducts: function () {
        this.showProducts();
    },

    addInstruction: function () {
        this.showInstructions();
    },

    deleteInstruction: function () {
        console.log("view.deleteInstruction()");
        this.showInstructions();
    }
};