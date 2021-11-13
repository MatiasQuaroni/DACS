import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FirebaseAuthService } from '../../services/firebase.auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, private auth: FirebaseAuthService) {}
  public email: string;
  public password: string;

  onSignUpClicked() {
    this.router.navigate(['/signup']);
  }

  onLogin() {
    this.auth.signIn({ email: this.email, password: this.password }).then(
      () => {
        this.router.navigate(['home']);
      },
      (err) => {
        console.log(err);
      }
    );
  }

  ngOnInit() {}
}
