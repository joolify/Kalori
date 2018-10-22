var RecipeController = function (model, view) {
    this.model = model;
    this.view = view;

    this.init();
};

RecipeController.prototype = {
    init: function() {
        this.createChildren()
            .setupHandlers()
            .enable();
    },

    createChildren: function() {
        return this;
    },

    setupHandlers: function() {

        /*---------------------------------------------------
        ------- recipe
        ----------------------------------------------------*/
        this.recipeNameHandler = this.addName.bind(this);
        this.recipeCookingtimeHHandler = this.addCookingtimeH.bind(this);
        this.recipeCookingtimeMHandler = this.addCookingtimeM.bind(this);
        this.recipePortionsHandler = this.addPortions.bind(this);

        /*---------------------------------------------------
        ------- products
        ----------------------------------------------------*/
        this.addProductHandler = this.addProduct.bind(this);
        this.selectProductHandler = this.selectProduct.bind(this);
        this.unselectProductHandler = this.unselectProduct.bind(this);
        this.completeProductHandler = this.completeProduct.bind(this);
        this.deleteProductHandler = this.deleteProduct.bind(this);
        this.saveProductHandler = this.saveProduct.bind(this);

        /*---------------------------------------------------
        ------- instructions
        ----------------------------------------------------*/
        this.addInstructionHandler = this.addInstruction.bind(this);
        this.deleteInstructionHandler = this.deleteInstruction.bind(this);
        this.editInstructionHandler = this.editInstruction.bind(this);
        this.saveInstructionHandler = this.saveInstruction.bind(this);
        return this;
    },

    enable: function() {

        /*---------------------------------------------------
        ------- recipe
        ----------------------------------------------------*/
        this.view.recipeNameEvent.attach(this.recipeNameHandler);
        this.view.recipeCookingtimeHEvent.attach(this.recipeCookingtimeHHandler);
        this.view.recipeCookingtimeMEvent.attach(this.recipeCookingtimeMHandler);
        this.view.recipePortionsEvent.attach(this.recipePortionsHandler);

        /*---------------------------------------------------
        ------- products
        ----------------------------------------------------*/
        this.view.addProductEvent.attach(this.addProductHandler);
        this.view.completeProductEvent.attach(this.completeProductHandler);
        this.view.deleteProductEvent.attach(this.deleteProductHandler);
        this.view.selectProductEvent.attach(this.selectProductHandler);
        this.view.unselectProductEvent.attach(this.unselectProductHandler);
        this.view.saveProductEvent.attach(this.saveProductHandler);

        /*---------------------------------------------------
        ------- instructions
        ----------------------------------------------------*/
        this.view.addInstructionEvent.attach(this.addInstructionHandler);
        this.view.deleteInstructionEvent.attach(this.deleteInstructionHandler);
        this.view.editInstructionEvent.attach(this.editInstructionHandler);
        this.view.saveInstructionEvent.attach(this.saveInstructionHandler);
        return this;
    },

    /*---------------------------------------------------
    ------- recipe
    ----------------------------------------------------*/
    addName: function(sender, args) {
        console.log("controller.addName() " + args.name);
        this.model.addName(args);
    },

    addCookingtimeH: function(sender, args) {
        console.log("controller.addCookingtimeH()");
        this.model.addCookingtimeH(args);
    },

    addCookingtimeM: function(sender, args) {
        console.log("controller.addCookingtimeM()");
        this.model.addCookingtimeM(args);
    },

    addPortions: function(sender, args) {
        console.log("controller.addPortions()");
        this.model.addPortions(args);
    },

    /*---------------------------------------------------
    ------- products
    ----------------------------------------------------*/
    addProduct: function(sender, args) {
            console.log("controller.addProduct()" + args.name + ", " + args.mass + ", " + args.pricePerKg);
        this.model.addProduct(args);
    },

    selectProduct: function(sender, args) {
        console.log("controller.selectProduct()");
        this.model.setSelectedProduct(args.productIndex);
    },

    unselectProduct: function(sender, args) {
        console.log("controller.unselectProduct()");
        this.model.unselectProduct(args.productIndex);
    },

    completeProduct: function() {
        console.log("controller.completeProduct()");
        this.model.setProductsAsCompleted();
    },

    deleteProduct: function(sender, args) {
        console.log("controller.deleteProduct() " + args.index);
        this.model.deleteProduct(args);
    },

    saveProduct: function(sender, args) {
        console.log("controller.saveProduct() " + args.index + ", " + args.name);
        this.model.saveProduct(args);
    },

    /*---------------------------------------------------
    ------- instructions
    ----------------------------------------------------*/
    addInstruction: function(sender, args) {
        console.log("controller.addInstruction()" + args.name);
        this.model.addInstruction(args);
    },

    deleteInstruction: function(sender, args) {
        console.log("controller.deleteInstruction() " + args.index);
        this.model.deleteInstruction(args);
    },

    editInstruction: function(sender, args) {
        console.log("controller.editInstruction() " + args.index);
        this.model.editInstruction(args);
    },
    saveInstruction: function(sender, args) {
        console.log("controller.saveInstruction() " + args.index + ", " + args.name);
        this.model.saveInstruction(args);
    }
};