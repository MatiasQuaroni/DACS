import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root',
})
export class UsersFacadeService {
  public dispatch(action: Action) {
    this.store$.dispatch(action);
  }

  constructor(private store$: Store) {}
}
