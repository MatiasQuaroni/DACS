import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, Router } from '@angular/router';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticatedGuard implements CanActivate {
  constructor(private router: Router, private usersService: UsersService) {}

  canActivate() {
    if (this.usersService.isAuthenticated()) return true;
    this.router.navigate(['/login']);
    return false;
  }
}
