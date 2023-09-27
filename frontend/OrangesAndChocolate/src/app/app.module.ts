import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { RouterModule, Routes } from '@angular/router';
import { RecipesComponent } from './recipes/recipes.component';
import { HomepageComponent } from './homepage/homepage.component';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'homepage', pathMatch: 'full'},
  { path: 'homepage', component: HomepageComponent, pathMatch: 'full' },
  { path: 'recipe', component: RecipesComponent, pathMatch: 'full'},
  { path: 'new-recipe', component: CreateRecipeComponent, pathMatch: 'full'},
  { path: 'login-register', component: LoginRegisterComponent, pathMatch: 'full'}
]

@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterComponent,
    RecipesComponent,
    HomepageComponent,
    HeaderComponent,
    CreateRecipeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
