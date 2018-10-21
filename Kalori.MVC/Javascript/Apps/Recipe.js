$(function () {
    var model = new RecipeModel(),
        view = new RecipeView(model),
        controller = new RecipeController(model, view);
});
