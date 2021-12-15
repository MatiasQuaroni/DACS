import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { User } from '../../+state/model';

@Component({
  selector: 'account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent implements OnInit {
  constructor() {}

  @Input()
  public user: User;

  @Output()
  public signOutClicked = new EventEmitter();

  onSignOutClicked() {
    this.signOutClicked.emit();
  }

  ngOnInit() {}
}
