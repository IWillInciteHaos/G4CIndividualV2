import { Component, Input } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../Models/Recipe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent {
  recipes: Recipe[] = []
  
  
  constructor(private recipeService: RecipeService){}
  
  ngOnInit() {
    this.recipeService.fetchRecipes().subscribe((responseData : Recipe[]) =>{
      console.log(responseData);
      this.recipes = responseData;
    })
  }

  takeMeToTheRecipe(index: number){   
    //router.Navigate("/recipe/:id")
    console.log(index);
  }
    
}
