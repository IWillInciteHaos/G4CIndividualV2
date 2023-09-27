import { Component } from '@angular/core';
import { Recipe } from '../Models/Recipe';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  recipes: Recipe[] = []

  constructor(){
    this.recipes.push(new Recipe("recipe1", "user1", ["salt", "peper"], "make stuff"))
    this.recipes.push(new Recipe("recipe2", "user1", ["salt", "peper"], "make stuff"))
  }
}
