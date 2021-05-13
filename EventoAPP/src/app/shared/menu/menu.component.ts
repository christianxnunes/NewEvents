import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  isCollapsed = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  showMenu(): boolean {
    return this.router.url !== '/user/login';
  }

}
