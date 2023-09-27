import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  app_name: string =  "Oranges and Chocolate"

  constructor(private router: Router){}


  goToLogin(){
    this.router.navigate(['/login-register']);
  }

  goToHomepage(){
    this.router.navigate(['/homepage'])
  }
}
