import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';
import { filter, switchMap } from 'rxjs/operators';
import * as usersSelectors from '../+state/selectors';

@Injectable({
  providedIn: 'root',
})
export class UsersFacadeService {
  public getUsersLoading$ = this.store$.select(
    usersSelectors.selectUsersLoading$
  );

  public getCurrentUser$ = () =>
    this.getUsersLoading$.pipe(
      filter((loading) => loading === false),
      switchMap(() => this.store$.select(usersSelectors.selectCurrentUser$))
    );

  public dispatch(action: Action) {
    this.store$.dispatch(action);
  }

  constructor(private store$: Store) {}
}
