import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../+state/model';
import { UsersFacadeService } from '../../services/users-facade.service';
import { signOutRequested } from '../../+state/actions';

@Component({
  selector: 'app-account',
  templateUrl: './account.page.html',
  styleUrls: ['./account.page.scss'],
})
export class AccountPage implements OnInit {
  constructor(private usersFacade: UsersFacadeService) {}

  public user$: Observable<User> = this.usersFacade.getCurrentUser$();

  onSignOut() {
    this.usersFacade.dispatch(signOutRequested());
  }

  ngOnInit() {}
}
