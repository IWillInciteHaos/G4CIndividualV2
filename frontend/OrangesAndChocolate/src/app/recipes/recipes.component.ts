import { Component, Input } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../Models/Recipe';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent {
  @Input() name: string = '';
  @Input() creatorName: string = '';
  @Input() ingredients: string[] = []
  @Input() directions: string = '';
  
  
  constructor(private recipeService: RecipeService){}
  
  ngOnInit() {
    
    /*this.recipeService.createRecipe(recParam).subscribe({
      next: (data) =>{
        console.log(data);
        this.recipes.push(data);
      }
    })*/
  }

  showMe(){    
    //console.log(this.recipes);
  }
    
}
