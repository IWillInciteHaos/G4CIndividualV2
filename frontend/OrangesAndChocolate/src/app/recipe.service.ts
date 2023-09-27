import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from './Models/Recipe';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  
  constructor(private http: HttpClient) { }

  fetchRecipes(): Observable<Recipe[]>{
    return this.http.get<Recipe[]>('https://localhost:7234/api/Recipe/get_recipes');
  }
  /*
  createRecipe(recipe: Recipe) : Observable<Recipe> {
    var url = 'https://localhost:7234/api/Recipe/create_recipe';
    var body = recipe;

    return this.http.post<Recipe>(url, body).pipe(
      map(response => {
        return new Recipe(response.Name, response.CreatorName, response.Ingredients, response.Directions);
      })
    )

  }*/
}
