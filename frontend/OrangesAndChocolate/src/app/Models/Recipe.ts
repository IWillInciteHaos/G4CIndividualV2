export class Recipe{
    name: string;
    creatorUserame: string;
    ingredients: string[]
    directions: string;

    constructor(Name: string, CreatorName : string, Ingredients : string[], dir: string){
        this.name = Name;
        this.creatorUserame = CreatorName;
        this.ingredients = Ingredients;
        this.directions = dir;
    }
}