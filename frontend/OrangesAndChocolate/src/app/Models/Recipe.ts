export class Recipe{
    Name: string;
    CreatorName: string;
    Ingredients: string[]
    Directions: string;

    constructor(name: string ="default r name", cn : string = "default c name", ingr : string[], dir: string = "some directions"){
        this.Name = name;
        this.CreatorName = cn;
        this.Ingredients = ingr;
        this.Directions = dir;
    }
}