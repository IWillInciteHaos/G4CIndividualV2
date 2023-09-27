import { Component } from '@angular/core';
import { Recipe } from '../Models/Recipe';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent {
  recipe?: Recipe;
  
}
