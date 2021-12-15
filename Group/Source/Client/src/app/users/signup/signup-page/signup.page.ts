import { Component, OnInit } from '@angular/core';
import { UsersFacadeService } from '../../services/users-facade.service';
import { signUpRequested } from '../../+state/actions';
import { LoginModel } from '../../+state/model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.page.html',
  styleUrls: ['./signup.page.scss'],
})
export class SignupPage implements OnInit {
  constructor(private usersFacade: UsersFacadeService) {}

  ngOnInit() {}

  onConfirm(model: LoginModel) {
    this.usersFacade.dispatch(
      signUpRequested({
        emailAddress: model.email,
        password: model.password,
      })
    );
  }
}
