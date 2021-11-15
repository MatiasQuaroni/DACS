import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../+state/model';
import { UsersFacadeService } from '../../services/users-facade.service';
import * as UserActions from '../../+state/actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  constructor(private usersFacade: UsersFacadeService) {}

  onLogin(loginCredentials: LoginModel) {
    this.usersFacade.dispatch(
      UserActions.signInRequested({ loginCredentials: loginCredentials })
    );
  }

  ngOnInit() {}
}
