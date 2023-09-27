import { Component } from '@angular/core';
import { Recipe } from '../Models/Recipe';
import { RecipeService } from '../recipe.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  recipes: Recipe[] = [];

  constructor(private recipeService: RecipeService, private router:Router)
    //this.recipes.push(new Recipe("recipe1", "user1", ["salt", "peper"], "make stuff"))
    //this.recipes.push(new Recipe("recipe2", "user1", ["salt", "peper"], "make stuff"))  
    //this.recipes = []  
  {}
  
  ngOnInit(){
    this.recipeService.fetchRecipes().subscribe((responseData : Recipe[]) =>{
      console.log(responseData);
      this.recipes = responseData;
    })
  }
  addRecipe(){
    this.router.navigate(['/new-recipe'])
  }
}
