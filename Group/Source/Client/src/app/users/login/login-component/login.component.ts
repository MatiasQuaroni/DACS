import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from '../../+state/model';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private usersService: UsersService) {}
  public email: string;
  public password: string;

  @Output()
  public loginClicked = new EventEmitter<LoginModel>();

  @Output()
  public signUpClicked = new EventEmitter();

  onSignUpClicked() {
    this.signUpClicked.emit();
  }

  onLogin() {
    this.loginClicked.emit({ email: this.email, password: this.password });
  }

  ngOnInit() {}
}
