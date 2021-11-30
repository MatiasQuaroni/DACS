import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel, User } from '../../+state/model';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  constructor(private usersService: UsersService, private router: Router) {}

  public email: string;
  public password: string;

  @Output()
  public confirmClicked = new EventEmitter<LoginModel>();

  onConfirm() {
    this.confirmClicked.emit({
      email: this.email,
      password: this.password,
    });
  }

  ngOnInit() {}
}
