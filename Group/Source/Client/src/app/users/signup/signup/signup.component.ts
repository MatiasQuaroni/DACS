import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from '../../login/models';
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

  onConfirm() {
    this.usersService.signUp(this.email, this.password).then((res) => {
      if (res.user.uid) {
        let data = {
          id: res.user.uid,
          email: this.email,
          password: this.password,
        };
        this.usersService.saveUser(data).then(
          () => {
            this.router.navigate(['login']);
          },
          (error) => {
            console.log(error);
          }
        );
      }
    });
  }

  ngOnInit() {}
}
